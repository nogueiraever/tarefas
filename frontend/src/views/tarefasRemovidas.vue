<template>
  <v-container fluid>
    <h2>Lista de Tarefas Removidas</h2>
    <tarefas :status="3" />
  </v-container>
</template>
<script>
import tarefas from "./tarefas.vue";
export default {
  components: {
    tarefas
  }
};
</script>
