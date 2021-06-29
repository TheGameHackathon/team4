using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/levels")]
    public class LevelsController : Controller
    {
        [HttpGet]
        public IActionResult Levels()
        {
            
            return Ok(TestData.levels.Keys);
        }
    }

    
    [Route("api/levels/{level}")]
    public class SelectLevelController : Controller
    {
        [HttpPost]
        public IActionResult SelectLevel(string level)
        {
            var selectedLevel = level.Split(' ').LastOrDefault();
            if (selectedLevel is null)
            {
                TestData.selectedLevel = 0;
            }
            else
            {
                TestData.selectedLevel = int.Parse(selectedLevel);
            }
            return Ok();
        }
    }
}
