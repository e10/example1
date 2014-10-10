using System;
using DurandalDemo.Models;

namespace DurandalDemo.Command
{
    public class ProspectCreateCommand : ICreateCommand
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public ProspectType ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }
}