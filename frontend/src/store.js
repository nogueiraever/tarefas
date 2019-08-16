import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    notifications: []
  },
  mutations: {
    SHOW_MESSAGE_MUTATION(state, message) {
      state = state || {
        alerts
      };
      message.visible = true;
      state.notifications.push(message);
      if (message.type != 1) {
        setTimeout(function () {
          message.visible = false;
        }, message.timer || 3000);
      }
    },
    CLEAR_ALL_MESSAGES_MUTATION(state) {
      let size = state.notifications.length;
      for (let index = 0; index < size; index++) {
        state.notifications.splice(0, 1);
      }
    }
  },
  actions: {
    SHOW_MESSAGE({
      commit
    }, message) {
      commit("SHOW_MESSAGE_MUTATION", message);
    },
    CLEAR_ALL_MESSAGES({
      commit
    }) {
      commit("CLEAR_ALL_MESSAGES_MUTATION");
    }
  }
})