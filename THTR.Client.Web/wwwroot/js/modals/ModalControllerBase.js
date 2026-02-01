class ModalControllerBase {    
    _is_open = false;
    _callback = null;
    _current_key = null;

    constructor() {
        // Check if this is being instantiated directly (not allowed for abstract class)
        if (new.target === ModalControllerBase) {
            throw new Error('ModalBase is an abstract class and cannot be instantiated directly');
        }
    }


    open(callback) {
        throw new Error('open() must be implemented by derived class');
    }

    close() {
        throw new Error('close() must be implemented by derived class');
    }
}



// Export for use in other modules
export { ModalControllerBase };
