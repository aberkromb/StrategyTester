using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace InterfaceStrategyLib
{
    public interface IStrategy
    {
        string Name();
        string Type();
        string Discription();
        string Logic(List<Stats> stats);
    }
}
