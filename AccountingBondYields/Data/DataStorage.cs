using AccountingBondYields.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBondYields.Data
{
    internal static class DataStorage //Статика удобнее для доступа из разных окон, да и вообще у этого класса НЕ подразумевается наличие НЕСКОЛЬКИХ  инстансов
    {
        //Прошу сильно не ругать за использование листов, просто он удобнее в работе чем массив, а столько облигаций тут точно НЕ наберется, что бы была заметна разница в производительности
        internal static List<BondOrdinary> bondOrdinaryList = new List<BondOrdinary>();

        internal static void AddBondOrdinary(BondOrdinary bondOrdinaryArray)
        {
            bondOrdinaryList.Add(bondOrdinaryArray);            
        }
        internal static List<Bond> GetAllData()
        {
           List<Bond> bonds = new List<Bond>();
            bonds.AddRange(bondOrdinaryList);
            return bonds;
        }
    }
}
