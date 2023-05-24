using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace CalculationsLib
{
    public class Calculations
    {
        static public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            checkErrors(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            List<string> resultList = new List<string>();

            TimeSpan currentTime = beginWorkingTime;
            int startTimeIndex = 0;
            while (currentTime < endWorkingTime)
            {
                currentTime += TimeSpan.FromMinutes(consultationTime);

                if (startTimeIndex < startTimes.Length && currentTime > startTimes[startTimeIndex])
                {
                    currentTime = startTimes[startTimeIndex] + TimeSpan.FromMinutes(durations[startTimeIndex]);
                    ++startTimeIndex;
                    continue;
                }

                TimeSpan startPeriod = currentTime - TimeSpan.FromMinutes(consultationTime);
                TimeSpan endPeriod = currentTime;

                resultList.Add(startPeriod.ToString() + " - " + endPeriod.ToString());
            }

            print(resultList);
            return resultList.ToArray();
        }

        static private void print(List<string> periods)
        {
            foreach (var period in periods)
            {
                Console.WriteLine(period);
            }
        }

        static private void checkErrors(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime) 
        {
            if (consultationTime <= 0)
            {
                throw new Exception("Invalid consultationTime");
            }

            if (endWorkingTime <= beginWorkingTime)
            {
                throw new Exception("Invalid endWorkingTime");
            }

            if (startTimes.Length != durations.Length)
            {
                throw new Exception("Invalid startTimes and durations");
            }
        }
    }
}
