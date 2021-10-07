using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsMicroservice.Models
{
    public class FoodCollectionDate
    {
        [Key]
        public string CollectionId { get; set; }
        public string CollectionName { get; set; }
        public DateTime CollectionDate { get; set; }
        public string DonationId { get; set; }
        public string LocationId { get; set; }
    }
}
