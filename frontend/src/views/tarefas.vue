<template>
  <v-container fluid>
    <h2 v-if="status==1">Lista de Tarefas</h2>
    <form-tarefas
      :tarefa="tarefa"
      @adicionarTarefa="adicionarTarefa($event)"
      @atualizarLista="listarTarefas"
      v-if="status==1"
    />
    <lista-tarefas
      :tarefas="tarefas"
      @alterar="alterarTarefa($event)"
      @atualizarLista="listarTarefas"
    />
  </v-container>
</template>
<script>
import formTarefas from "../components/formTarefas.vue";
import listaTarefas from "../components/listaTarefas.vue";
import servicoTarefas from "../services/servicoTarefas";
export default {
  props: {
    status: {
      type: Number,
      default: 1
    }
  },
  components: {
    formTarefas,
    listaTarefas
  },
  data() {
    return {
      tarefas: [],
      tarefa: {},
      servicoTarefas: new servicoTarefas()
    };
  },

  methods: {
    alterarTarefa(tarefa) {
      this.tarefa = tarefa;
    },
    async adicionarTarefa(tarefa) {
      this.tarefas.push(tarefa);
    },
    async listarTarefas() {
      this.tarefa = {};

      let response = await this.servicoTarefas.listar();
      if (response.ok) {
        let json = await response.json();
        let url = this.$route.name;
        this.tarefas = json.filter(item => item.status == this.status);
      } else {
        let json = await response.json();
        let vm = this;
        json.forEach(erro => {
          vm.showMessage(1, erro.Value);
        });
      }
    }
  },
  created() {
    this.listarTarefas();
  }
};
</script>
