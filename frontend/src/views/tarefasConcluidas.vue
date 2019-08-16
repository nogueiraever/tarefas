<template>
  <v-container fluid>
    <h2>Lista de Tarefas Concluídas</h2>
    <tarefas :status="2" />
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
