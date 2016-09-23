using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace StatsReaderFromTxt
{
    public class TxtReader
    {
        public void LoadStats(string path)
        {
            //string text = File.ReadAllText(path);

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                var elements = line.Split(',');
                Debug.WriteLine(elements.Length);
            }
        }

        private Stats ParseStats(string[] elements)
        {
            string sName = elements[0];
            int sPeriod = int.Parse(elements[1]);
            DateTime sDateNTime = DateTime.Now; //elements[2]
            float sOpen = float.Parse(elements[4]);
            float sHigh = float.Parse(elements[5]); 
            float sLow = float.Parse(elements[6]);
            float sClose = float.Parse(elements[7]);
            int sVolume = int.Parse(elements[8]);

            return new Stats() {Name = sName, Period = sPeriod, DateNTime = sDateNTime, Open = sOpen, High = sHigh, Low = sLow, Close = sClose, Volume = sVolume};
        }

        private DateTime ParseDatetime(string strDate, string strTime)
        {


        }
    }
}
