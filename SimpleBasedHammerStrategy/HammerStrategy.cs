using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IInterfaces;

namespace SimpleBasedHammerStrategy
{
    public class HammerStrategy : IStrategy
    {
        public string Name { get; } = "SimpleHammerStrategy";
        public Guid UniqId { get; } = new Guid("EF6A2D79-64AC-4945-8454-96D0D51DFD94");
        public string TypeOfLib { get; } = "Strategy";
        public string TypeOfPosition { get; } = Enums.TypeOfPosition.Multi.ToString();
        public string Discription { get; }
        public List Logic(List stats)
        {
            throw new NotImplementedException();
        }
    }
}
