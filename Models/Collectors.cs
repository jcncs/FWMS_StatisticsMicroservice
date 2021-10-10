using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsMicroservice.Models
{
    public class CollectorsDto
    {
        public string CollectorName { get; set; }
        public int TotalCollectionCount { get; set; }

    }
}
