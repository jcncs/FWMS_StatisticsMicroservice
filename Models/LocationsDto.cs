using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsMicroservice.Models
{
    public class LocationsDto
    {
        public string LocationName { get; set; }
        public int TotalLocationCount { get; set; }
    }
}
