using DurandalDemo.Command;

namespace DurandalDemo.Services
{
    public interface IUpdateHandler<TEntity, TKey, in TCommand> : IHandler where TCommand : IUpdateCommand<TKey>
    {
        DataExecutionResult<TEntity> Execute(TCommand cmd);
        TEntity CommandToEntity(TCommand cmd, TEntity entity);
    }
}