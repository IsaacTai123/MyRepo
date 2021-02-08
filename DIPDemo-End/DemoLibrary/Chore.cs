using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Chore : IChore
    {
        ILogger _logger;
        IMessageSender _messageSender;
        
        
        public string ChoreName { get; set; }
        public IPerson Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; private set; }
        
        public Chore(ILogger logger, IMessageSender messageSender) // we passed in two interfaces into our chore class, we use those two interfaces to then make calls to both send a message and also to log a message 
        {
            _logger = logger;
            _messageSender = messageSender;
        }

        public void PerformedWork(double hours)
        {
            HoursWorked += hours;
            _logger.Log($"Performed work on { ChoreName }");
        }

        public void CompleteChore()
        {
            IsComplete = true;

            _logger.Log($"Completed { ChoreName }");

            _messageSender.SendMessage(Owner, $"The chore { ChoreName } is complete.");
        }
    }
}
