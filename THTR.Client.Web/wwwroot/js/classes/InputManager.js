class InputManager {
    constructor() {
        // Boolean states
        this._up = false;
        this._down = false;
        this._left = false;
        this._right = false;
        this._attack = false;
        // Integer enums for high-performance switching
        this._input = { UP: 0, DOWN: 1, LEFT: 2, RIGHT: 3, ATTACK: 4 };
        // Static lookup table (string -> integer)
        this._code_map = {
            'KeyW': this._input.UP, 'ArrowUp': this._input.UP,
            'KeyS': this._input.DOWN, 'ArrowDown': this._input.DOWN,
            'KeyA': this._input.LEFT, 'ArrowLeft': this._input.LEFT,
            'KeyD': this._input.RIGHT, 'ArrowRight': this._input.RIGHT,
            'KeyJ': this._input.ATTACK, 'KeyK': this._input.ATTACK
        };
        // Event handlers
        this._on_up_down = null;
        this._on_up_up = null;
        this._on_down_down = null;
        this._on_down_up = null;
        this._on_left_down = null;
        this._on_left_up = null;
        this._on_right_down = null;
        this._on_right_up = null;
        this._on_attack_down = null;
        this._on_attack_up = null;
    }
    instantiate_input() {
        $(document).on('keydown keyup', (e) => {
            const action = this._code_map[e.code];
            if (action === undefined) return;
            const is_pressed = e.type === 'keydown';
            switch (action) {
                case this._input.UP:
                    if (this._up !== is_pressed) {
                        this._up = is_pressed;
                        if (is_pressed && this._on_up_down) this._on_up_down();
                        if (!is_pressed && this._on_up_up) this._on_up_up();
                    }
                    break;
                case this._input.DOWN:
                    if (this._down !== is_pressed) {
                        this._down = is_pressed;
                        if (is_pressed && this._on_down_down) this._on_down_down();
                        if (!is_pressed && this._on_down_up) this._on_down_up();
                    }
                    break;
                case this._input.LEFT:
                    if (this._left !== is_pressed) {
                        this._left = is_pressed;
                        if (is_pressed && this._on_left_down) this._on_left_down();
                        if (!is_pressed && this._on_left_up) this._on_left_up();
                    }
                    break;
                case this._input.RIGHT:
                    if (this._right !== is_pressed) {
                        this._right = is_pressed;
                        if (is_pressed && this._on_right_down) this._on_right_down();
                        if (!is_pressed && this._on_right_up) this._on_right_up();
                    }
                    break;
                case this._input.ATTACK:
                    if (this._attack !== is_pressed) {
                        this._attack = is_pressed;
                        if (is_pressed && this._on_attack_down) this._on_attack_down();
                        if (!is_pressed && this._on_attack_up) this._on_attack_up();
                    }
            }
            e.preventDefault();
        });
    }
    get_up() { return this._up; }
    get_down() { return this._down; }
    get_left() { return this._left; }
    get_right() { return this._right; }
    get_attack() { return this._attack; }
    get_state() {
        return {
            up: this._up,
            down: this._down,
            left: this._left,
            right: this._right,
            attack: this._attack
        };
    }
}
export const _input_manager = new InputManager();