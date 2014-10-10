using System;
using System.ComponentModel.DataAnnotations;
using DurandalDemo.Models;

namespace DurandalDemo.ViewModels
{
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
}