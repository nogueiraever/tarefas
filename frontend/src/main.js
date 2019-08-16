import '@babel/polyfill'
import Vue from 'vue'
import './plugins/vuetify'
import plugins from './plugins/util.js'
import App from './App.vue'
import router from "./router"
Vue.config.productionTip = false
Vue.use(plugins);
new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
