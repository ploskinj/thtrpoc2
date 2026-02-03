class AvatarAnimationData {
    constructor() {
        this.animations = null;
        this.loaded = false;
        await this.load();
    }

    async load() {
        if (!this.loaded) {
            await this.load_avatar_json();
            await this.load_avatar_images();
            this.loaded = true;
        }
    }

    async load_avatar_images() {
        const load_promises = [];

        this.animations.forEach((skin_map, sex) => {
            skin_map.forEach((direction_map, skin) => {
                direction_map.forEach((anim_map, direction) => {
                    anim_map.forEach((anim_data, anim_key) => {
                        const img = new Image();
                        const img_path = anim_data.sprite_sheet_dir + anim_data.sprite_sheet_file_name;

                        const load_promise = new Promise((resolve, reject) => {
                            img.onload = () => resolve();
                            img.onerror = () => reject(new Error(`Failed to load: ${img_path}`));
                            img.src = img_path;
                        });

                        anim_data.img = img;
                        load_promises.push(load_promise);
                    });
                });
            });
        });

        await Promise.all(load_promises);
    }

    async load_avatar_json() {
        const response = await fetch('/avatars/avatar.json');
        const avatar_meta_data = await response.json();

        this.animations = new Map();

        const sexes = ['male', 'female'];
        const skins = [1, 2, 3, 4];
        const directions = ['north', 'south', 'east', 'west'];
        const direction_prefixes = {
            'north': 'n',
            'south': 's',
            'east': 'e',
            'west': 'w'
        };

        sexes.forEach(sex => {
            this.animations.set(sex, new Map());

            skins.forEach(skin => {
                this.animations.get(sex).set(skin, new Map());

                directions.forEach(direction => {
                    this.animations.get(sex).get(skin).set(direction, new Map());

                    avatar_meta_data.animations.forEach(anim_obj => {
                        const anim_key = Object.keys(anim_obj)[0];
                        const anim_data = { ...anim_obj[anim_key] };

                        anim_data.sprite_sheet_file_name = anim_data.sprite_sheet_file_name.replace('{dir}', direction_prefixes[direction]);
                        anim_data.sprite_sheet_dir = avatar_meta_data.sprite_sheet_dir.replace('{sex}', sex).replace('{skin}', skin);

                        this.animations.get(sex).get(skin).get(direction).set(anim_key, anim_data);
                    });
                });
            });
        });
    }
}

const _avatarAnimationData = new AvatarAnimationData();

// Execution pauses here until load() finishes
await _avatarAnimationData.load();

export { _avatarAnimationData };
