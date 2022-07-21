using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public string GetCategories()
        {
            return "categories plural";
        }

        [HttpGet("{id}")]
        public string GetCategory(int id)
        {
            return "single category";
        }
    }
}