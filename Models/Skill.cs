using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Skill 1";
        public RpgClass Class { get; set; } = RpgClass.Knight;

    }
}