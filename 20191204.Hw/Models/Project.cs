using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20191204.Hw.Models
{
    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImagePath { get; set; }
        public string Text { get; set; }
    }
}
