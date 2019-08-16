<template>
  <v-form ref="form" v-model="formValid" lazy-validation>
    <v-layout row wrap>
      <v-flex xs12 sm12 lg6>
        <v-text-field
          v-model="tarefaEmEdicao.titulo"
          label="Digite o título da tarefa"
          hint="Pressione enter para salvar"
          :rules="tarefaEmEdicaoRules"
          counter="50"
          @keypress.enter="salvarTarefa"
          autofocus
          solo
          ref="tarefaEmEdicao"
          id="tarefaEmEdicao"
        ></v-text-field>
      </v-flex>
    </v-layout>
    <v-layout row wrap>
      <v-flex xs12 sm12 lg6>
        <v-text-field
          v-model="tarefaEmEdicao.descricao"
          label="Digite a descrição da tarefa"
          hint="Pressione enter para adicionar"
          :rules="descriptionRules"
          counter="50"
          @keypress.enter.native="salvarTarefa"
          solo
        ></v-text-field>
      </v-flex>
    </v-layout>
  </v-form>
</template>
<script>
import servicoTarefas from "../services/servicoTarefas";

export default {
  data() {
    return {
      tarefaEmEdicao: this.tarefa || {
        titulo: "",
        descricao: "",
        status: 0,
        inEdit: false
      },
      servicoTarefas: new servicoTarefas(),
      tarefaEmEdicaoRules: [
        value => !!value || "O título é obrigatório.",
        value =>
          (value ? value.length <= 50 : true) ||
          "O título deve ter no máximo 50 caracteres."
      ],
      descriptionRules: [
        value =>
          (value ? value.length <= 50 : true) ||
          "A descrição deve ter no máximo 50 caracteres."
      ],
      formValid: true
    };
  },

  methods: {
    salvarTarefa() {
      if (this.$refs.form.validate()) {
        let tarefaEmEdicao = {};
        Object.assign(tarefaEmEdicao, this.tarefaEmEdicao);
        if (tarefaEmEdicao.id) {
          this.alterarTarefa(tarefaEmEdicao);
        } else {
          this.criarTarefa(tarefaEmEdicao);
        }
        this.$refs.form.reset();
        document.querySelector("#tarefaEmEdicao").focus();
      }
    },
    criarTarefa(tarefa) {
      this.servicoTarefas.criar(tarefa).then(resposta => {
        if (resposta.ok) {
          resposta.json().then(tarefa => {
            this.$emit("adicionarTarefa", tarefa);
            this.showMessage("success", "Tarefa criada com sucesso.");
          });
        } else {
          response.json().then(json => {
            json.forEach(erro => {
              this.showMessage("error", erro.Value);
            });
          });
        }
      });
    },
    alterarTarefa(tarefa) {
      this.servicoTarefas.atualizar(tarefa).then(resposta => {
        if (resposta.ok) {
          this.$emit("atualizarLista");
          this.showMessage("success", "Tarefa alterada com sucesso.");
        } else {
          response.json().then(json => {
            json.forEach(erro => {
              this.showMessage("error", erro.Value);
            });
          });
        }
      });
    }
  },
  props: {
    tarefa: Object
  },
  watch: {
    tarefa(value) {
      this.tarefaEmEdicao = value;
    }
  }
};
</script>
