using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zmart.EventApp.Handlers
{
    public class SchemaHandler
    {
        public Color CalendarColorManager(int count)
        {
            if (count % 2 == 0)
            {
                return Color.Blue;
            }
            return Color.Green;
        }

        public Color CalendarColorManager2(int count)
        {
            if (count % 2 == 0)
            {
                return Color.Yellow;
            }
            return Color.Red;
        }

        public string TruncateTitle(string title)
        {
            var charArr = title.ToCharArray();
            var res = title;
            if (charArr.Length >= 16)
            {
                var truncated = title.Insert(13, "...");
                res = truncated.Remove(16);
            }
            return res;
        }

        public int ConvertStopTimeToRows(string timeStop, string timeStart)
        {
            var stopSplitted = timeStop.Split(':');
            var startSplitted = timeStart.Split(':');

            var stopHour = Int32.Parse(stopSplitted[0]);
            var startHour = Int32.Parse(startSplitted[0]);

            var stopMin = Int32.Parse(stopSplitted[1]);
            var startMin = Int32.Parse(startSplitted[1]);

            double finalStop = 0;
            double finalStart = 0;

            if (stopMin == 30)
            {
                finalStop = stopHour + 0.5;
            }
            else
            {
                finalStop = stopHour;
            }

            if (startMin == 30)
            {
                finalStart = startHour + 0.5;
            }
            else
            {
                finalStart = startHour;
            }

            var res = ((finalStop - finalStart) * 2);

            return (int)res;
        }

        public int ConvertStartTimeToRows(string timeStart)
        {
            string[] timeSplitted = timeStart.Split(':');

            var hour = Int32.Parse(timeSplitted[0]);

            if (!timeSplitted[1].Equals("30"))
            {
                return (int)((hour + 0.5) * 2);
            }
            else
            {
                return (int)((hour + 0.5) * 2) + 1;
            }
        }

    }
}
