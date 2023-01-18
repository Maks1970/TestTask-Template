using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime sumarryday= new DateTime(1,1,1)  ;
            int weekendsCount;

            if (weekEnds != null)
            {


                if (weekEnds.Length > 1)
                {
                    // weekends in work day
                    for (int i = 0; i < weekEnds.Length; i++)
                    {
                        if (weekEnds[i].StartDate < startDate.AddDays(dayCount))
                        {
                            weekendsCount = weekEnds[0].EndDate.Day - weekEnds[0].StartDate.Day;
                            if (weekendsCount == 0) { weekendsCount = 1; }
                            dayCount += weekendsCount;

                        }
                    }
                    sumarryday = startDate.AddDays(dayCount);
                }
                if (weekEnds.Length == 1)
                {

                    // weekends in work day
                    if (weekEnds[0].StartDate < startDate.AddDays(dayCount))
                    {
                        weekendsCount = weekEnds[0].EndDate.Day - weekEnds[0].StartDate.Day;
                        if (weekendsCount == 0) { weekendsCount = 1; }
                        dayCount += weekendsCount;

                    }
                    sumarryday = startDate.AddDays(dayCount);
                }
            } else { sumarryday = startDate.AddDays(dayCount-1); }

           // throw new NotImplementedException();
           return sumarryday;
        }
    }
}
