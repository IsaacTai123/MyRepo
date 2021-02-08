using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        ILogger _logger;
        IDataAccess _dataAccess;

        // the constructor passes in the two instances it will need for this ProcessData method, that will allow us pass up the chain the dependencies
        public BusinessLogic(ILogger logger, IDataAccess dataAccess) // Constructor injection
        {
            _logger = logger; //take our parameters and we put into our class level variables (private variable)
            _dataAccess = dataAccess;
        }
        public void ProcessData()
        {
            _logger.Log("Starting the processing of data.");
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.Log("Finished processing of the data.");
        }
    }
}
