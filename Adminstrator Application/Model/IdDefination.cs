﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Model
{
    public class IdDefination
    {
        public int id { get; set; }
        public string prefix { get; set; }
        public string prefix_separator { get; set; }
        public int length { get; set; }
        public string suffix_separator { get; set; }
        public string suffix { get; set; }
        public int type { get; set; }
    }
}
