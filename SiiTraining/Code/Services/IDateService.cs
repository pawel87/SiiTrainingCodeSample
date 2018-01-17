using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Services
{
    public interface IDateService
    {
        DateTime GetCurrentTime();
    }

    public class DateService : IDateService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
