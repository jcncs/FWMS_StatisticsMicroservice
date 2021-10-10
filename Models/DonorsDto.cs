using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsMicroservice.Models
{
    public class DonorsDto
    {
        public string DonorName { get; set; }
        public int TotalDonationCount { get; set; }

    }
}
