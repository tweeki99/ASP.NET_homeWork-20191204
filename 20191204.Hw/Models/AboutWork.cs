using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20191204.Hw.Models
{
    public class AboutWork
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Year { get; set; }
        public string Text { get; set; }
    }
}
