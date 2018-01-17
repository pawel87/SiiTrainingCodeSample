using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Models.Binding
{
    public class SampleViewModel
    {
        public List<string> Elements { get; set; }

        public List<ArtistViewModel> Artists { get; set; }
    }

    public class ArtistViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
