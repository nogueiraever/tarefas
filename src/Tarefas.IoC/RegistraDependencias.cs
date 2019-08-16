using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tarefas.Aplicacao;
using Tarefas.Aplicacao.Controladores;
using Tarefas.Dados;
using Tarefas.Dominio;
using Tarefas.Dominio.Repositorios;

namespace Tarefas.IoC
{
    public static class RegistraDependencias
    {
        public static void Registrar(IServiceCollection servicos)
        {
            RegistraRepositorios(servicos);
            RegistraControladores(servicos);
        }

        private static void RegistraControladores(IServiceCollection servicos)
        {
            servicos.AddScoped<IManterTarefas, ManterTarefas>();
        }

        private static void RegistraRepositorios(IServiceCollection servicos)
        {
            servicos.TryAddScoped<IUnitOfWork, UnitOfWork>();
            servicos.TryAddScoped<IRepositorioTarefa, RepositorioTarefa>();
        }
    }
}