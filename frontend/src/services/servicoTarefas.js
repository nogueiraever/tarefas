import apiUrl from '../utils/config';
export default class ServicoTarefas {
  listar() {
    return fetch(`${apiUrl}/tarefas`);
  }

  criar(tarefa) {
    return fetch(`${apiUrl}/tarefas`, {
      method: 'post',
      body: JSON.stringify(tarefa),
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }

  remover(id) {
    return fetch(`${apiUrl}/tarefas/${id}`, {
      method: 'delete'
    });
  }

  concluir(id) {
    return fetch(`${apiUrl}/tarefas/concluir/${id}`, {
      method: 'put'
    });
  }

  reativar(id) {
    return fetch(`${apiUrl}/tarefas/reativar/${id}`, {
      method: 'put'
    });
  }

  atualizar(tarefa) {
    return fetch(`${apiUrl}/tarefas/`, {
      method: 'put',
      body: JSON.stringify(tarefa),
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }
}
