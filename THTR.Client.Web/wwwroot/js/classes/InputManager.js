class InputManager {
    constructor() {
        // Boolean states
        this._up = false;
        this._down = false;
        this._left = false;
        this._right = false;

        // Integer enums for high-performance switching
        this._input = { UP: 0, DOWN: 1, LEFT: 2, RIGHT: 3 };

        // Static lookup table (string -> integer)
        this._code_map = {
            'KeyW': this._input.UP, 'ArrowUp': this._input.UP,
            'KeyS': this._input.DOWN, 'ArrowDown': this._input.DOWN,
            'KeyA': this._input.LEFT, 'ArrowLeft': this._input.LEFT,
            'KeyD': this._input.RIGHT, 'ArrowRight': this._input.RIGHT
        };
    }

    instantiate_input() {
        $(document).on('keydown keyup', (e) => {
            const action = this._code_map[e.code];

            if (action === undefined) return;

            const is_pressed = e.type === 'keydown';

            switch (action) {
                case this._input.UP:
                    this._up = is_pressed;
                    break;
                case this._input.DOWN:
                    this._down = is_pressed;
                    break;
                case this._input.LEFT:
                    this._left = is_pressed;
                    break;
                case this._input.RIGHT:
                    this._right = is_pressed;
                    break;
            }

            e.preventDefault();
        });
    }

    get_up() { return this._up; }
    get_down() { return this._down; }
    get_left() { return this._left; }
    get_right() { return this._right; }

    get_state() {
        return {
            up: this._up,
            down: this._down,
            left: this._left,
            right: this._right
        };
    }
}



export const _input_manager = new InputManager();