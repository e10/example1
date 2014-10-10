using DurandalDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DurandalDemo.ViewModels
{
    public class ProspectViewModel
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public string ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }
    public class ProspectGridViewModel
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public string ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }

    public class ProspectCreateViewModel
    {

        public Guid ProspectID { get; set; }
        [Required]
        [StringLength(100)]
        public string ProspectName { get; set; }

        public bool Closed { get; set; }

        [Required]
        public ProspectType ProspectType { get; set; }

        [StringLength(200)]
        public string AdditionalInfo { get; set; }

    }

    public class ProspectEditViewModel
    {
        public Guid ProspectID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProspectName { get; set; }

        public bool Closed { get; set; }

        [Required]
        public ProspectType ProspectType { get; set; }

        [StringLength(200)]
        public string AdditionalInfo { get; set; }
    }

    public class ProspectDeleteViewModel
    {
        public long ProspectID { get; set; }
    }
}