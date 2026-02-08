class StageManager {
    constructor() {        
        this._set_manager = new THTR.SetManager();
        this._set_avatar = new THTR.SetAvatar();
    }

    async initialize() {

        console.log('THTR:', THTR);
        console.log('SetManager:', THTR.SetManager);
        console.log('typeof SetManager:', typeof THTR.SetManager);

        
        this._set_manager.instantiate();
        THTR.input_manager.instantiate_input();

        // poc code, fix
        await this._set_avatar.instantiate(THTR.avatar_animation_data.animations.get("male").get(1).get("south"));
        this._set_manager.make_entrance(this._set_avatar.get_sprite());

        THTR.signal_r_manager.on_tick((timestamp) => {
            console.log("Received tick:", timestamp);
        });

        THTR.signal_r_manager.on_connected(() => {
            console.log("Connected to hub");
        });

        THTR.signal_r_manager.on_disconnected(() => {
            console.log("Disconnected from hub");
        });

        THTR.signal_r_manager.start();

    }
}