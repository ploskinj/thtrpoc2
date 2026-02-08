import { _input_manager } from './InputManager.js';
class SignalRManager {
    constructor(hub_url) {
        this._connection = null;
        this._hub_url = hub_url;
        this._is_connected = false;
        this._reconnect_delay = 5000;
        this._tick_callback = null;
        this._connected_callback = null;
        this._disconnected_callback = null;
    }
    async start() {
        this._connection = new signalR.HubConnectionBuilder()
            .withUrl(this._hub_url)
            .withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())
            .withAutomaticReconnect()
            .configureLogging(signalR.LogLevel.Information)
            .build();
        this._connection.on("receive_tick", (timestamp) => {
            if (this._tick_callback) {
                this._tick_callback(timestamp);
            }
        });
        this._connection.onclose(() => {
            this._is_connected = false;
            if (this._disconnected_callback) {
                this._disconnected_callback();
            }
            this._attempt_reconnect();
        });
        this._connection.onreconnected(() => {
            this._is_connected = true;
            if (this._connected_callback) {
                this._connected_callback();
            }
        });

        _input_manager._on_up_down = () => this.invoke_server_method("client_up_down");
        _input_manager._on_up_up = () => this.invoke_server_method("client_up_up");
        _input_manager._on_down_down = () => this.invoke_server_method("client_down_down");
        _input_manager._on_down_up = () => this.invoke_server_method("client_down_up");
        _input_manager._on_left_down = () => this.invoke_server_method("client_left_down");
        _input_manager._on_left_up = () => this.invoke_server_method("client_left_up");
        _input_manager._on_right_down = () => this.invoke_server_method("client_right_down");
        _input_manager._on_right_up = () => this.invoke_server_method("client_right_up");
        _input_manager._on_attack_down = () => this.invoke_server_method("client_attack_down");
        _input_manager._on_attack_up = () => this.invoke_server_method("client_attack_up");

        try {
            await this._connection.start();
            this._is_connected = true;
            console.log('Its connected!');
            if (this._connected_callback) {
                this._connected_callback();
            }
        } catch (error) {
            console.error("SignalR connection failed:", error);
            this._attempt_reconnect();
        }
    }
    async _attempt_reconnect() {
        if (!this._is_connected) {
            setTimeout(() => this.start(), this._reconnect_delay);
        }
    }
    async stop() {
        if (this._connection) {
            await this._connection.stop();
            this._is_connected = false;
        }
    }
    on_tick(callback) {
        this._tick_callback = callback;
    }
    on_connected(callback) {
        this._connected_callback = callback;
    }
    on_disconnected(callback) {
        this._disconnected_callback = callback;
    }
    get is_connected() {
        return this._is_connected;
    }

    async invoke_server_method(method_name, ...args) {
        if (this._is_connected) {
            try {
                return await this._connection.invoke(method_name, ...args);
            } catch (error) {
                console.error(`Failed to invoke ${method_name}:`, error);
                throw error;
            }
        }
    }

}
export const _signal_r_manager = new SignalRManager("/poctick");