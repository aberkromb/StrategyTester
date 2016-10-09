using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IInterfaces
{
    public interface IPattern
    {
        string Name { get; }
        Guid UniqId { get; }
        byte TypeOfLib { get; }
        byte TypeOfPosition { get; }
        string Discription { get; }
        List<Stats> Logic(List<Stats> stats);
    }
}
