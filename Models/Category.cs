﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Models
{
    public class Category
    {
        public string Name { get; set; }

        public string MaterialIcon { get; set; }

        public Category(string name, string icon)
        {
            Name = name;
            MaterialIcon = icon;
        }
    }
}
