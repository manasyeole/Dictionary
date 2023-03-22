using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary_Test.Models
{
    public class Translation
    {
        public Guid  Id { get; set; }

        public string English { get; set; }

        public string Hungarian { get; set; }
    }
}
