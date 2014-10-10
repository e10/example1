using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurandalDemo.Models
{
    public enum ProspectType 
    {
        ProspectType1 = 1,
        ProspectType2 = 2,
        ProspectType3 = 3
    }

    public class Prospect
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public ProspectType ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }
}