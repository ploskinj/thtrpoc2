class SetAvatar {
    constructor() {
        this._body_animation_textures = new Map();
        this._sprite = null;
    }

    async instantiate(body_animation_data, sprite_sheet_dir) {
        // Use Promise.all to load all animations in parallel efficiently
        const animation_promises = Array.from(body_animation_data.entries()).map(async ([animation_name, animation_data]) => {
            const textures = await this._create_textures_from_spritesheet(animation_data, sprite_sheet_dir);
            this._body_animation_textures.set(animation_name, textures);
        });

        await Promise.all(animation_promises);

        const idle_textures = this._body_animation_textures.get("idle_normal_loop1");

        if (idle_textures && idle_textures.length > 0) {
            this._sprite = new PIXI.Sprite(idle_textures[0]);
        }
    }

    get_sprite() {
        return this._sprite;
    }

    async _create_textures_from_spritesheet(animation_data, sprite_sheet_dir) {
        const textures = [];
        const frame_width = animation_data.frame_width;
        const num_frames = animation_data.num_frames;
        const sprite_path = '/images/avatars/male_color1/' + animation_data.sprite_sheet_file_name;

        // Load the asset and wait for it to be ready
        const source_texture = await PIXI.Assets.load(sprite_path);

        // In v8, baseTexture is now source
        source_texture.source.scaleMode = 'nearest';

        for (let i = 0; i < num_frames; i++) {
            const frame_x = i * frame_width;
            const frame_y = 0;

            const frame_rect = new PIXI.Rectangle(frame_x, frame_y, frame_width, frame_width);

            // Create a new texture specifically bound to the frame rectangle
            const frame_texture = new PIXI.Texture({
                source: source_texture.source,
                frame: frame_rect
            });

            textures.push(frame_texture);
        }

        return textures;
    }
}

export { SetAvatar };