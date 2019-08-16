import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'tarefas',
      component: () =>
        import(/* webpackChunkName: "about" */ './views/tarefas.vue')
    },
    {
      path: '/completed',
      name: 'completed',
      component: () =>
        import(/* webpackChunkName: "about" */ './views/tarefasConcluidas.vue')
    },
    ,
    {
      path: '/deleted',
      name: 'deleted',
      component: () =>
        import(/* webpackChunkName: "about" */ './views/tarefasRemovidas.vue')
    }
  ]
});
