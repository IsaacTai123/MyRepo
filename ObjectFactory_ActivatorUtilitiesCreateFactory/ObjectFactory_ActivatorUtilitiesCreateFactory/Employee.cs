using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectFactory_ActivatorUtilitiesCreateFactory
{
    public class Employee
    {
        private readonly ILogger<Employee> _logger;
        private readonly string _name;

        public Employee(ILogger<Employee> logger, string name)
        {

            _logger = logger;
            _name = name;
        }

        public void Say()
        {
            _logger.LogInformation($"My name is {_name}");
        }
    }
}
