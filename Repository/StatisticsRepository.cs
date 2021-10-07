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

        public FoodCollectionDate GetFoodCollectionByID(string CollectionId)
        {
            return _dbContext.FoodCollectionDates.Find(CollectionId);
        }

        public IEnumerable<FoodCollectionDate> GetFoodCollections()
        {
            return _dbContext.FoodCollectionDates.ToList();
        }

        public void InsertFoodCollection(FoodCollectionDate foodCollectionDate)
        {
            _dbContext.Add(foodCollectionDate);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateFoodCollection(FoodCollectionDate foodCollectionDate)
        {
            _dbContext.Entry(foodCollectionDate).State = EntityState.Modified;
            Save();
        }
    }
}
