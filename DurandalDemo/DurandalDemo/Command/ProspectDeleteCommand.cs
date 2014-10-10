using System;

namespace DurandalDemo.Command
{
    public class ProspectDeleteCommand : IDeleteCommand<Guid>
    {
        public Guid ID { get; set; }
    }
}