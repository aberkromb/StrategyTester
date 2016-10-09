using System;
using System.Collections.Generic;
using Models;

namespace IInterfaces
{
    public interface IStrategy
    {
        string Name { get; }
        Guid UniqId { get; }
        byte TypeOfLib { get; }
        byte TypeOfPosition { get; }
        string Discription { get; }
        List<Stats> Logic(List<Stats> stats);
    }
}