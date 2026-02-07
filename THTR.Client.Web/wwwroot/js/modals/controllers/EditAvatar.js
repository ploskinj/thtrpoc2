import { ModalControllerBase } from '../ModalControllerBase.js'
import { _avatar_animation_data } from '../../classes/AvatarAnimationData.js'
import { Avatar } from '../../classes/Avatar.js';


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