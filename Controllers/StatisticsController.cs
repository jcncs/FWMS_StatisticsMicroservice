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

        [HttpGet("GetDonorLeaderboard")]
        public IActionResult GetDonorLeaderboard()
        {
            var donors = _statisticsRepository.GetDonorLeaderboard();
            return new OkObjectResult(donors);
        }

        [HttpGet("GetCollectorLeaderboard")]
        public IActionResult GetCollectorLeaderboard()
        {
            var collectors = _statisticsRepository.GetCollectorLeaderboard();
            return new OkObjectResult(collectors);
        }

        [HttpGet("GetLocationLeaderboard")]
        public IActionResult GetLocationLeaderboard()
        {
            var locations = _statisticsRepository.GetLocationLeaderboard();
            return new OkObjectResult(locations);
        }

    }
}
