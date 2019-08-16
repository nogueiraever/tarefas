<template>
  <v-layout row wrap mt-2>
    <v-flex xs12 sm12 lg6>
      <v-card v-if="tarefas.length">
        <v-list>
          <v-list-tile v-for="tarefa in tarefas" :key="tarefa.id" @click>
            <v-list-tile-action>
              <v-checkbox
                v-model="tarefa.status"
                :false-value="statusTarefa.Novo"
                :true-value="statusTarefa.Concluido"
                @click.native="alterarStatus(tarefa)"
                v-show="tarefa.status!=statusTarefa.Removido"
              ></v-checkbox>
            </v-list-tile-action>
            <v-list-tile-content @click="alterarTarefa(tarefa)" :title="tarefa.descricao">
              <v-list-tile-title>
                <span
                  :class="tarefa.status== statusTarefa.Concluido ? 'concluded body-1' : 'subheading'"
                >{{tarefa.titulo}}</span>
                <v-divider :key="tarefa.id"></v-divider>
              </v-list-tile-title>
            </v-list-tile-content>
            <v-list-tile-action v-if="tarefa.status!=statusTarefa.Removido">
              <v-btn icon title="Excluir tarefa">
                <v-icon color="error" @click="confirmDelete(tarefa)">delete</v-icon>
              </v-btn>
            </v-list-tile-action>
          </v-list-tile>
        </v-list>
      </v-card>
    </v-flex>
    <v-dialog v-model="removeTaskConfirmation" persistent max-width="450px">
      <v-card>
        <v-card-title>
          <h3 class="error--text">Remoção de tarefa</h3>
        </v-card-title>
        <v-card-text>Deseja realmente remover a tarefa "{{tarefaSelecionada.titulo}}"?</v-card-text>
        <v-card-actions style="justify-content: flex-end">
          <v-btn color="primary" flat @click="closeConfirmation(false)">Cancelar</v-btn>
          <v-btn color="primary" flat @click="closeConfirmation(true)">Confirmar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>
<script>
import servicoTarefas from "../services/servicoTarefas";
import statusTarefa from "../models/statusTarefaEnum";
export default {
  props: {
    tarefas: [Array]
  },
  data() {
    return {
      servicoTarefas: new servicoTarefas(),
      tarefaEmEdicao: null,
      removeTaskConfirmation: false,
      tarefaSelecionada: { titulo: "", descricao: "" },
      statusTarefa: statusTarefa
    };
  },
  methods: {
    alterarStatus(tarefa) {
      this.clearAllMessages();
      let vue = this;
      if (tarefa.status == vue.statusTarefa.Concluido) {
        this.concluirTarefa(tarefa);
      } else {
        this.reativarTarefa(tarefa);
      }
    },
    concluirTarefa(tarefa) {
      let vue = this;
      vue.servicoTarefas.concluir(tarefa.id).then(resposta => {
        if (resposta.ok) {
          vue.showMessage("success", "Tarefa concluída com sucesso.");
          vue.$emit("atualizarLista");
        } else {
          resposta.json().then(erros => {
            erros.mensagens.forEach(erro => vue.showMessage("error", erro));
          });
          tarefa.status = vue.statusTarefa.Concluido;
        }
      });
    },
    reativarTarefa(tarefa) {
      let vue = this;
      vue.servicoTarefas.reativar(tarefa.id).then(resposta => {
        if (resposta.ok) {
          vue.showMessage("success", "Tarefa reativada com sucesso.");
          vue.$emit("atualizarLista");
        } else {
          resposta.json().then(erros => {
            erros.mensagens.forEach(erro => vue.showMessage("error", erro));
          });
          tarefa.status = vue.statusTarefa.Novo;
        }
      });
    },
    alterarTarefa(tarefa) {
      if (tarefa.status != this.statusTarefa.Removido) {
        this.$emit("alterar", tarefa);
      }
    },

    closeConfirmation(confirm) {
      if (confirm) {
        this.remover(this.tarefaSelecionada);
      }
      this.removeTaskConfirmation = false;
    },

    confirmDelete(tarefa) {
      this.removeTaskConfirmation = true;
      this.tarefaSelecionada = tarefa;
    },

    async remover(tarefa) {
      let response = await this.servicoTarefas.remover(tarefa.id);
      if (response.ok) {
        let indice = this.tarefas.indexOf(tarefa);
        this.tarefas.splice(indice, 1);
        this.showMessage("success", "Tarefa removida com sucesso.");
      } else {
        let json = await response.json();
        let vm = this;
        json.mensagens.forEach(erro => {
          vm.showMessage("error", erro);
        });
      }
    }
  }
};
</script>
<style>
.concluded {
  color: lightgray;
  text-decoration: line-through;
}
</style>