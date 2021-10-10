using StatisticsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsMicroservice.Repository
{
    public interface IStatisticsRepository
    {
        IEnumerable<FoodCollectionDate> GetFoodCollections();

        IEnumerable<DonorsDto> GetDonorLeaderboard();

        IEnumerable<CollectorsDto> GetCollectorLeaderboard();

        IEnumerable<LocationsDto> GetLocationLeaderboard();
    }
}
