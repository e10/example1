using DurandalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurandalDemo.Command
{
    
    public interface ICommand { }

    public interface IDeleteCommand<T> : ICommand
    {
        T ID { get; set; }
    }
    public interface ICreateCommand : ICommand { }
    public interface IUpdateCommand<T> : ICommand
    {
        T ID { get; set; }
    }

    public class ProspectCreateCommand : ICreateCommand
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public ProspectType ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class ProspectUpdateCommand : IUpdateCommand<Guid>
    {
        public Guid ID { get; set; }
        public string ProspectName { get; set; }
        public ProspectType ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class ProspectDeleteCommand : IDeleteCommand<Guid>
    {
        public Guid ID { get; set; }
    }
}