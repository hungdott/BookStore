using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
