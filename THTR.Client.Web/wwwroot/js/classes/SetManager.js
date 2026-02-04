class SetManager {
    constructor() {
        this._pixi_app = null;
    }

    async instantiate() {
        this._pixi_app = new PIXI.Application();

        const window_width = window.innerWidth * 0.9;
        const scale_factor = window_width / 320;

        await this._pixi_app.init({
            width: 320,
            height: 180,
            resolution: scale_factor,
            autoDensity: true,
            antialias: false,
            roundPixels: true
        });

        this._pixi_app.canvas.style.width = `${window_width}px`;
        this._pixi_app.canvas.style.height = `${180 * scale_factor}px`;
        this._pixi_app.canvas.style.imageRendering = 'pixelated';

        document.body.appendChild(this._pixi_app.canvas);
    }

    async make_entrance(child) {
        this._pixi_app.stage.addChild(child);
    }

    async make_exit(child) {
        this._pixi_app.stage.removeChild(child);
    }
}
export { SetManager }