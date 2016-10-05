using System;
using System.Collections.Generic;

namespace MunzeeInMap
{
    public static class CitesLogic
    {
        static List<string> cites = new List<string>()
        {
            "To nevymyslíš.",
            "To musí bavit.",
            "Baf. Lek.",
            "Pozól, jdou k vám kužátkáa.",
            "Vy tu sedíte jako kuřátka.",
            "Neuč orla lítat.",
            "Neviděl bych to tak černě.",
            "Jedna, dvě, tři, osm, devatená.",
            "Asi taťka.",
            "Zas až zítra.",
            "Já slyším, ale nevím.",
            "Co už. Sa neokotím.",
            "Hůůůstý.",
            "Dobrýy, no.",
            "Ty nikam něuběgaj.",
            "Ja guljaju v parke.",
            "A hrome.",
            "Ja ja, srandu si robtě ze starého člověka.",
            "Až vy budětě v mojich rokach.",
            "To, co jste dnes vy, byli jsme i my, ale to co jsme my, budete i vy.",
            "Dva krumíci.",
            "Zprava dobré, zleva tanky."
        };
        private static int count = cites.Count;
        private static DateTime builded = new DateTime(2015, 4, 29);

        public static string GetRandomCite()
        {
            Random rand= new Random();
            int index = rand.Next(0, count);
            return cites[index];
        }

        public static string GetCiteOfToday()
        {
            long ms = DateTime.Now.Ticks - builded.Ticks;
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - builded.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            int NumberOfDaysInOffset = elapsedSpan.Days;
            Random rand = new Random(NumberOfDaysInOffset);
            int index = rand.Next(0, count);
            return cites[index];
        }
    }
}