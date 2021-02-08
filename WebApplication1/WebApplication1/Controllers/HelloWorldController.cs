using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-5.0&tabs=visual-studio

// https://www.youtube.com/watch?v=prNptonJAiY Attribute Routing in ASP Net core MVC
namespace AttributeRouting.Controllers
{
    //[Route("Home")]
    [Route("[controller]/[action]")] // replace with token
    public class HelloWorldController : Controller
    {

        [Route("~/HelloWorld")] //execute when we nevigate the root url
        //[Route("Home")]
        //[Route("Home/Index")]
        //[Route("Index")]
        //[Route("~/")] // if the Route begin with / or ~/ the controller route template is not combined with the individual action method route
        //[Route("[action]")]
        [Route("")] // if we want the action method to be executed when we navigate to the root URL use this (when we use this with the constructor token replace it means we use the constructor set up
        // we call this controller's View method
        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult Welcome2(string name, int numTimes = 1)
        //{
        //    ViewData["Message"] = "Hello" + name;
        //    ViewData["NumTimes"] = numTimes;

        //    return View(); // The ViewData dictionary object contains data that will be passed to the view.
        //}

        // Get /HelloWorld/
        public string Hello() // Controller methods (also known as action methods)
        {
            return "this is my default action";  // ctrl + shift + Enter to add a line below, ctrl + Enter will add a line above
        }

        //[Route("Welcome/{name}/{ID?}")] // the ? mark is mean "optional"
        [Route("{name}/{ID?}")] // using replace token
        // Get /HelloWorld/Welcome/
        public string Welcome(string name, int? ID)
        {
            //return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID??1}, test:"); // if the ID is null the default value will be 1
            return $"Hello {name}, ID: {ID??1}"; // if the ID is null the default value will be 1
        }

        [Route("{data}")]
        public string testing(string data, [FromQuery]string param)
        {
            return $"this is data : {data}, and this is the param : {param}";
        }
    }
}
