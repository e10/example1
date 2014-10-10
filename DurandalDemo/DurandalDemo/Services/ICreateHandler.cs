using DurandalDemo.Command;

namespace DurandalDemo.Services
{
    public interface ICreateHandler<in TCommand> : IHandler where TCommand : ICreateCommand
    {
        int Execute(TCommand cmd); //rows affected
    }

    public interface ICreateHandler<TEntity, in TCommand> : IHandler where TCommand : ICreateCommand
    {
        DataExecutionResult<TEntity> Execute(TCommand cmd);
        TEntity CommandToEntity(TCommand cmd);
    }
}