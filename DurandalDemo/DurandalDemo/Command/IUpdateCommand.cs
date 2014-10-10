namespace DurandalDemo.Command
{
    public interface IUpdateCommand<T> : ICommand
    {
        T ID { get; set; }
    }
}