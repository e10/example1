using System;

namespace DurandalDemo.ViewModels
{
    public class ProspectGridViewModel
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public string ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }
}