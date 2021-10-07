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
        FoodCollectionDate GetFoodCollectionByID(string CollectionId);
        void InsertFoodCollection(FoodCollectionDate foodCollectionDate);
        void UpdateFoodCollection(FoodCollectionDate foodCollectionDate);
        void Save();
    }
}
