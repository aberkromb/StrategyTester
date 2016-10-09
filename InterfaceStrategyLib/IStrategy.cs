using System;
using System.Collections.Generic;
using Models;

namespace IInterfaces
{
    public interface IStrategy
    {
        string Name { get; }
        Guid UniqId { get; }
        string TypeOfLib { get; }
        string TypeOfPosition { get; }
        string Discription { get; }
        List<Stats> Logic(List<Stats> stats);
    }
}