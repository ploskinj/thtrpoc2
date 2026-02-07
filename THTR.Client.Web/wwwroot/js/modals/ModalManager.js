
import { ModalControllerBase } from '/js/modals/ModalControllerBase.js'

class ModalManager {
    constructor() {
        this.active_controller = null;
        this.container = $("#modal_container");
        this.callback = null;
    }

    async open(key, callback) {
        var html_content = await (await fetch(`/Modal/Fetch/${key}`)).text();        

        const module = await import(`/js/modals/controllers/${key}.js`);
        // Assume each module exports a 'Controller' class
        this.show_content(html_content);
        this.activeController = new module.Controller();
        this.callback = callback;
    }

    show_content(html_content) {
        this.container.html(html_content);
        this.container.show();       
    }

    hide_content() {
        this.container.hide();
    }

    async close() {
        this.callback();
    }
    
}

export const _modal_manager = new ModalManager();
