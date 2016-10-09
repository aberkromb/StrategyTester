using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IInterfaces;
using Models;

namespace HammerAndHangingMan
{
    public class Hammer : IPattern
    {
        public string Name { get; } = "Молот (Hammer)";
        public Guid UniqId { get; } = new Guid("C42CDE37-5B6A-4963-9BDB-0FF78BEA16EB");
        public string TypeOfLib { get; } = "Pattern";
        public string TypeOfPosition { get; } = "Bull";
        public string Discription { get; } = @"Бычий паттерн разворота. Находится в нижней части (ценового диапазона). Тень в 2 раза > тела. Верхняя тень либо отсутствует, либо мала. Цвет тела значения не имеет.";

        public List<Stats> Logic(List<Stats> stats)
        {
            List<Stats> result = new List<Stats>();

            // RawBody добавлены чтобы знать направление свечи, просто Body это длина тела без знака
            //c - candle - целевая свеча
            float cRawBody, cBody, cUpShadow, cBottShadow;
            //p - previous - предыдущая свеча
            float pRawBody, pBody, pUpShadow, pBottShadow;
            //s - successive - последующая свеча
            float sRawBody, sBody, sUpShadow, sBottShadow;

            for (int i = 1; i <= stats.Count - 2; i++)
            {
                cRawBody = stats[i].Open - stats[i].Close;
                cBody = cRawBody > 0 ? cRawBody : cRawBody*(-1);
                cUpShadow = stats[i].Open > stats[i].Close
                    ? stats[i].High - stats[i].Open
                    : stats[i].High - stats[i].Close;
                cBottShadow = stats[i].Open > stats[i].Close
                    ? stats[i].Close - stats[i].Low
                    : stats[i].Open - stats[i].Low;

                pRawBody = stats[i - 1].Open - stats[i - 1].Close;
                pBody = pRawBody > 0 ? pRawBody : pRawBody*(-1);
                pUpShadow = stats[i - 1].Open > stats[i - 1].Close
                    ? stats[i - 1].High - stats[i - 1].Open
                    : stats[i - 1].High - stats[i - 1].Close;
                pBottShadow = stats[i - 1].Open > stats[i - 1].Close
                    ? stats[i - 1].Close - stats[i - 1].Low
                    : stats[i - 1].Open - stats[i - 1].Low;

                sRawBody = stats[i + 1].Open - stats[i + 1].Close;
                sBody = sRawBody > 0 ? sRawBody : sRawBody*(-1);
                sUpShadow = stats[i + 1].Open > stats[i + 1].Close
                    ? stats[i + 1].High - stats[i + 1].Open
                    : stats[i + 1].High - stats[i + 1].Close;
                sBottShadow = stats[i + 1].Open > stats[i + 1].Close
                    ? stats[i + 1].Close - stats[i + 1].Low
                    : stats[i + 1].Open - stats[i + 1].Low;

                //1 Тень больше в 2 раза чем тело
                //2 Верхняя тень маленькая (здесь - меньше тела)
                //3 Предыдущая свеча - Тело больше теней (условие не обязательное, сделал чтобы иметь полноценную свечу)
                //4 Пред свеча больще целевой свечи
                //5 Пред св. медвежья 
                //6 Cлед св. Бычья
                //7 Тело больше теней
                //8 Тело больше целевой св 
                if ((cBottShadow > cBody*2) && (cBody > cUpShadow)
                    && (pBody > pUpShadow + pBottShadow)
                    && (pBody > cBody) && (pRawBody > 0) && (sBody > cBody)
                    && (sBody > sBottShadow + sUpShadow) && (sRawBody < 0))
                {
                    result.Add(stats[i]);
                }
            }

            return result;
        }
    }
}
