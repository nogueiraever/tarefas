namespace Tarefas.Dominio.Repositorios
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}