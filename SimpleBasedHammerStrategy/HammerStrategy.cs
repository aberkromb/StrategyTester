using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IInterfaces;
using LibsLoader;
using Models;

namespace SimpleBasedHammerStrategy
{
    public class HammerStrategy : IStrategy
    {
        public string Name { get; } = "SimpleHammerStrategy";
        public Guid UniqId { get; } = new Guid("EF6A2D79-64AC-4945-8454-96D0D51DFD94");
        public byte TypeOfLib { get; } = (byte)Enums.TypeOfLib.Strategy;
        public byte TypeOfPosition { get; } = (byte)Enums.TypeOfPosition.Bull;

        public string Discription { get; } =
            "Простая стратегия со входом в длинные позиции основанная на паттерне Молот";

        //На вход принимаем сырые данные свечей
        public List<PointsOfEntry> Logic(List<Stats> stats)
        {
            List<PointsOfEntry> pointsOfEntry = new List<PointsOfEntry>();

            //Получаем паттерн
            var pattern = LoadStrategies.GetPatterns.First(atr => atr.UniqId == new Guid("C42CDE37-5B6A-4963-9BDB-0FF78BEA16EB"));
            //Получаем выполнения патерна
            List<Stats> patternPoints = pattern.Logic(stats);

            foreach (var pPoint in patternPoints)
            {
                foreach (var candle in stats)
                {
                    if (pPoint.DateNTime == candle.DateNTime)
                    {
                        pointsOfEntry.Add(new PointsOfEntry(candle.Name, candle.DateNTime, TypeOfPosition, candle.Close));
                    }
                }
            }

            return pointsOfEntry;
        }
    }
}
