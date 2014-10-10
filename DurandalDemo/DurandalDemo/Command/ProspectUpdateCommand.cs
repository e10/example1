using System;
using DurandalDemo.Models;

namespace DurandalDemo.Command
{
    public class ProspectUpdateCommand : IUpdateCommand<Guid>
    {
        public Guid ID { get; set; }
        public string ProspectName { get; set; }
        public ProspectType ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }
}