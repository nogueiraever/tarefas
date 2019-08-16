<template>
  <v-app>
    <v-navigation-drawer persistent v-model="drawer" enable-resize-watcher fixed app clipped>
      <v-list>
        <v-list-tile v-for="(item, i) in items" :key="i" @click :to="item.path">
          <v-list-tile-action>
            <v-icon v-html="item.icon"></v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar app :clipped-left="true" color="indigo" dark>
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title v-text="title"></v-toolbar-title>
    </v-toolbar>
    <v-content>
      <v-layout row wrap>
        <template v-for="notification in notificacoes">
          <v-flex lg12 :key="notification.Key">
            <v-alert
              v-model="notification.visible"
              :color="notification.type"
              dismissible
            >- {{notification.value}}</v-alert>
          </v-flex>
        </template>
      </v-layout>
      <router-view />
    </v-content>
  </v-app>
</template>

<script>
import store from "./store";
export default {
  name: "App",
  data() {
    return {
      drawer: true,
      items: [
        {
          icon: "bookmark",
          title: "Todas as Tarefas",
          path: "/"
        },
        {
          icon: "delete",
          title: "Tarefas Removidas",
          path: "deleted"
        },
        {
          icon: "thumb_up",
          title: "Tarefas Concluídas",
          path: "completed"
        }
      ],
      title: "Tarefas"
    };
  },
  computed: {
    notificacoes: function() {
      return store.state.notifications;
    }
  }
};
</script>