﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDll
{
    public class Nguoi
    {
        public Nguoi(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
    }
}
