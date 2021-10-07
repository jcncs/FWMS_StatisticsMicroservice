using StatisticsMicroservice.Models;
using StatisticsMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StatisticsMicroservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var foodCollection = _statisticsRepository.GetFoodCollections();
            return new OkObjectResult(foodCollection);
        }

        [HttpGet("{collectionId}", Name = "Get")]
        public IActionResult Get(string collectionId)
        {
            var foodCollection = _statisticsRepository.GetFoodCollectionByID(collectionId);
            return new OkObjectResult(foodCollection);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FoodCollectionDate foodCollection)
        {
            using (var scope = new TransactionScope())
            {
                _statisticsRepository.InsertFoodCollection(foodCollection);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = foodCollection.CollectionId }, foodCollection);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] FoodCollectionDate foodCollection)
        {
            if (foodCollection != null)
            {
                using (var scope = new TransactionScope())
                {
                    _statisticsRepository.UpdateFoodCollection(foodCollection);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

    }
}
