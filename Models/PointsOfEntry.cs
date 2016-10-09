using System;

namespace Models
{
    public struct PointsOfEntry
    {
        public PointsOfEntry(string name, int period, DateTime dateNTime, byte position, float entryPrice)
        {
            Name = name;
            Period = period;
            DateNTime = dateNTime;
            Position = position;
            EntryPrice = entryPrice;
        }

        public string Name { get; set; }
        public int Period { get; set; }
        public DateTime DateNTime { get; set; }
        public byte Position { get; set; }
        public float EntryPrice { get; set; }

        public override string ToString()
        {
            //return string.Concat(Name + " " + Period + " " + DateNTime.ToString("yyyyMMdd HHmmss") + " " + Open + " " + High + " " + Low + " " + Close + " " + Volume);
            return string.Concat($"{Name} {Period} {DateNTime} {Position} {EntryPrice}");
        }
    }
}