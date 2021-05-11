using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // To call this method, use "https://localhost:44392/home"

        [HttpPost("{model}")]
        public IActionResult Index([FromBody]user model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }
            if (model.Id < 1)
            {
                ModelState.AddModelError("Id", "Id not exist");
            }
            if (ModelState.IsValid)
            {
                return Ok(model);
            }
            return BadRequest(ModelState);
        }
    }
}
