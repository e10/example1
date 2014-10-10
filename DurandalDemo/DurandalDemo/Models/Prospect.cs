﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurandalDemo.Models
{
    public class Prospect
    {
        public Guid ProspectID { get; set; }
        public string ProspectName { get; set; }
        public ProspectType ProspectType { get; set; }
        public bool Closed { get; set; }
        public string AdditionalInfo { get; set; }
    }
}