using StatisticsMicroservice.DBContexts;
using StatisticsMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsMicroservice.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly StatisticsContext _dbContext;
        public StatisticsRepository(StatisticsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FoodCollectionDate> GetFoodCollections()
        {
            return _dbContext.FoodCollectionDates.ToList();
        }

        public IEnumerable<DonorsDto> GetDonorLeaderboard()
        {
            var foodDonationList = _dbContext.Donations.ToList();

            var donorsTotal = foodDonationList.GroupBy(n => n.CreatedBy)
                                               .Select(n => new DonorsDto
                                               {
                                                   DonorName = n.Key,
                                                   TotalDonationCount = n.Count()
                                               })
                                               .OrderByDescending(n => n.TotalDonationCount);

            return donorsTotal;
        }

        public IEnumerable<CollectorsDto> GetCollectorLeaderboard()
        {
            var foodCollectionList = _dbContext.FoodCollectionDates.ToList();

            var collectorsTotal = foodCollectionList.GroupBy(n => n.CollectionName)
                                                    .Select(n => new CollectorsDto
                                                    {
                                                        CollectorName = n.Key,
                                                        TotalCollectionCount = n.Count()
                                                    })
                                                    .OrderByDescending(n => n.TotalCollectionCount);
            return collectorsTotal;
        }

        public IEnumerable<LocationsDto> GetLocationLeaderboard()
        {
            var collectionList = (from fc in _dbContext.FoodCollectionDates
                                 join lc in _dbContext.Locations on fc.LocationId equals lc.LocationId
                                 into t
                                 from rt in t.DefaultIfEmpty()
                                 orderby fc.LocationId
                                 select new
                                 {
                                     fc.CollectionId,
                                     fc.LocationId,
                                     rt.LocationName,
                                 }).ToList();


            var locationTotal = collectionList.GroupBy(n => n.LocationName)
                                                    .Select(n => new LocationsDto
                                                    {
                                                        LocationName = n.Key,
                                                        TotalLocationCount = n.Count()
                                                    })
                                                    .OrderByDescending(n => n.TotalLocationCount);

            return locationTotal;
        }
    }
}
