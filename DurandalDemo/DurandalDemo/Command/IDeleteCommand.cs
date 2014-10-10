namespace DurandalDemo.Command
{
    public interface IDeleteCommand<T> : ICommand
    {
        T ID { get; set; }
    }
}