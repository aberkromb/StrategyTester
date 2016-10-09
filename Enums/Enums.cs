namespace Enums
{
    public enum TypeOfPosition
    {
        Bull = 1,
        Bear = 2,
        //Для стратегий где может быть несколько направлений, просто для указания направления используются первые 2
        Multi = 3
    }

    public enum TypeOfLib
    {
        Pattern = 1,
        Strategy = 2,
        Indicator = 3
    }
}