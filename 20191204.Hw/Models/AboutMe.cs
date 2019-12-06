using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20191204.Hw.Models
{
    public class AboutMe
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Paragraph { get; set; }
    }
}
