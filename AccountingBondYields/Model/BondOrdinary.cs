using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBondYields.Model
{
    internal class BondOrdinary : Bond //Класс для обычной облигации, у которой нет ни амортизации ни переменного купона. Просто облигация
    {
        internal BondOrdinary(string companyName, string bondId, int bondRaiting, double bondNominalValue, int bondQuantity, double bondCurrentCost, double averageBondPourchasePrice, DateTime bondPayOffDate, DateTime? bondOfferDate, double couponValue, int numberOfCouponPerYear, double desiredPercentYieldPerYear) 
            : base (companyName, bondId, bondRaiting, bondNominalValue, bondQuantity, bondCurrentCost, averageBondPourchasePrice, bondPayOffDate, bondOfferDate, couponValue, numberOfCouponPerYear, desiredPercentYieldPerYear)
        { }
        internal BondOrdinary()
        {

        }
        internal void CreateInstance()
        {
            
        }
    }
}
