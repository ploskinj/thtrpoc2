import { Avatar } from './classes/Avatar.js';
import { _avatar_animation_data } from './classes/AvatarAnimationData.js';
import { _input_manager } from './classes/InputManager.js';
import { SetAvatar } from './classes/SetAvatar.js';
import { SetManager } from './classes/SetManager.js';
import { _signal_r_manager } from './classes/SignalRManager.js';
import { _modal_manager } from './modals/ModalManager.js'

const THTR = {
    Avatar: Avatar,
    SetAvatar: SetAvatar,
    SetManager: SetManager,
    avatar_animation_data: _avatar_animation_data,
    input_manager: _input_manager,
    signal_r_manager: _signal_r_manager,
    modal_manager: _modal_manager,
    Init: async () => {
        await _avatar_animation_data.load();
        console.log("Theater App initialized");
    }
};

window.THTR = THTR;  // Manual assignment
