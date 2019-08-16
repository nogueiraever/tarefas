import store from "../store"
const plugins = {
    install(Vue) {
        Vue.prototype.showMessage = function (type, value) {
            store.dispatch("SHOW_MESSAGE", {
                value,
                type
            });
            window.scrollTo(0, 0);
        };

        Vue.prototype.clearAllMessages = function () {
            store.dispatch("CLEAR_ALL_MESSAGES");
        };
    }
}
export default plugins;