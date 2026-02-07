// Import your classes and singletons
import { Avatar } from '/js/classes/Avatar.js';
import { _avatar_animation_data } from '/js/classes/AvatarAnimationData.js';
import { _input_manager } from  '/js/classes/InputManager.js';
import { SetAvatar } from  '/js/classes/SetAvatar.js';
import { SetManager } from  '/js/classes/SetManager.js';
import { _signal_r_manager } from  '/js/classes/SignalRManager.js';
import { _modal_manager } from '/js/modals/ModalManager.js'

const THTR = {
    // --- The Blueprints (Classes) ---
    // You can name the key whatever you want to use in your HTML
    Avatar: Avatar, 
    SetAvatar: SetAvatar,
    SetManager: SetManager,

    // --- The Instances (Singletons) ---
    avatar_animation_data: _avatar_animation_data,
    input_manager: _input_manager,
    signal_r_manager: _signal_r_manager,
    modal_manager: _modal_manager,

    Init: () => {
        console.log("Theater App initialized");
    }
};

export { THTR };