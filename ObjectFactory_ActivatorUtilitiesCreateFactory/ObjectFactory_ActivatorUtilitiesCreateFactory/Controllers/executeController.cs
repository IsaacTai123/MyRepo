using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectFactory_ActivatorUtilitiesCreateFactory
{
    [Route("[controller]/[action]")]
    public class executeController : Controller
    {
        //private IServiceProvider _provider;

        private readonly IServiceProvider _provider;

        public executeController(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void CreateAnInstanceOfEmployee()
        {
            var factory = ActivatorUtilities.CreateFactory(typeof(Employee), new Type[] { typeof(string) });
            var employee = factory(_provider, new object[] { "johnDu" }) as Employee;
            employee.Say();
        }
    }
}
