﻿using System;
using System.Collections.Generic;
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
}