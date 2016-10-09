using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IInterfaces;
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
        public List<Stats> Logic(List<Stats> stats)
        {
            throw new NotImplementedException();
        }
    }
}
