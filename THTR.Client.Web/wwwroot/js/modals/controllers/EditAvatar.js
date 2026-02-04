import { ModalControllerBase } from '/js/modals/ModalControllerBase.js'
import { _avatar_animation_data } from '/js/classes/AvatarAnimationData.js'
import { Avatar } from '/js/classes/Avatar.js';


/// -----
///       Edit Avatar Controller
/// ----- 
class Controller extends ModalControllerBase  {
    constructor() {
        super();
    }

    open(callback) {
        _avatar_animation_data
    }

    close() {
        // Your close logic here
    }
}

export { Controller };