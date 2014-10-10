using DurandalDemo.Command;

namespace DurandalDemo.Services
{
    public interface IDeleteHandler<TKey, in TCommand> : IHandler where TCommand : IDeleteCommand<TKey>
    {
        int Execute(TCommand cmd); //rows affected;
    }
}