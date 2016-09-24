using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace StatsReaderFromTxt
{
    public class TxtReader
    {
        public List<Stats> LoadStats(string path)
        {
            List<Stats> result = new List<Stats>();

            string[] lines = File.ReadAllLines(path);
            string[] elements;

            foreach (string line in lines)
            {
                elements = line.Split(',');
                result.Add(ParseStats(elements));
            }

            return result;
        }

        private Stats ParseStats(string[] elements)
        {
            string sName = elements[0];
            int sPeriod = int.Parse(elements[1]);
            DateTime sDateNTime = ParseDatetime(elements[2],elements[3]); //elements[2]
            float sOpen = float.Parse(elements[4], CultureInfo.InvariantCulture);
            float sHigh = float.Parse(elements[5], CultureInfo.InvariantCulture); 
            float sLow = float.Parse(elements[6], CultureInfo.InvariantCulture);
            float sClose = float.Parse(elements[7], CultureInfo.InvariantCulture);
            int sVolume = int.Parse(elements[8]);

            return new Stats() {Name = sName, Period = sPeriod, DateNTime = sDateNTime, Open = sOpen, High = sHigh, Low = sLow, Close = sClose, Volume = sVolume};
        }

        private DateTime ParseDatetime(string strDate, string strTime)
        {
            string datetime = strDate + strTime;
            DateTime dt = DateTime.ParseExact(datetime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            //Debug.WriteLine(dt);
            return dt;
        }
    }
}
