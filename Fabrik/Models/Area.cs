﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrik.Models
{
    public class Area
    {   [Key]
        public int Id { get; set; }
        public Workshop Workshop { get; set; }
        public string Name { get; set; }
    }
}
