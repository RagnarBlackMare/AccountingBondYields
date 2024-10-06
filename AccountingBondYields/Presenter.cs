using AccountingBondYields.Data;
using AccountingBondYields.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AccountingBondYields
{
    class Presenter
    {
        BondOrdinary bondOrdinary;
        AddBondOrdinary addBondOrdinary;
        BondListView bondListView;
        //DataStorage dataStorage;

        internal Presenter(AddBondOrdinary addBondOrdinary)
        {
            this.addBondOrdinary = addBondOrdinary;
            bondOrdinary = new BondOrdinary();            
            addBondOrdinary.EventSaveBond += AddBondOrdinary_EventSaveBond1;            
        }
        internal Presenter (BondListView bondListView)
        {            
            this.bondListView = bondListView;
            bondListView.EventShowBonds += BondListView_EventShowBonds1;
        }

        private void BondListView_EventShowBonds1()
        {
            List<Bond> bondOrdinaryList = DataStorage.GetAllData();            
            bondListView.BondListGrid.ItemsSource = bondOrdinaryList; //Источник данных для грида
            bondListView.BondListGrid.DataContext = bondOrdinaryList;
            bondListView.BondListGrid.SetBinding(DataGrid.ItemsSourceProperty, new Binding() { Path = new PropertyPath(".") });
            bondListView.BondOrdinaryList = bondOrdinaryList;
        }        

        //01.01.0001 0:00:00
        private void AddBondOrdinary_EventSaveBond1(object? sender, EventArgs e)
        {
            DateTime defaulDate = new DateTime(01, 01, 0001, 0, 00, 00); // дата по дефалту, которая будет, если не выбрать дату оферты, а ее может и не быть, значит ставим null
            if (addBondOrdinary.bondOfferDate == defaulDate)
            {
                DateTime? bondOfferDate = null;
                BondOrdinary bond = new BondOrdinary(addBondOrdinary.companyName, addBondOrdinary.bondId, addBondOrdinary.bondRaiting, addBondOrdinary.bondNominalValue, addBondOrdinary.bondQuantity, addBondOrdinary.bondCurrentCost, addBondOrdinary.averageBondPourchasePrice, addBondOrdinary.bondOfferDate, bondOfferDate, addBondOrdinary.couponValue,
                addBondOrdinary.numberOfCouponPerYear, addBondOrdinary.desiredPercentYieldPerYear);
                DataStorage.AddBondOrdinary(bond);
            }
            else
            {
                BondOrdinary bond = new BondOrdinary(addBondOrdinary.companyName, addBondOrdinary.bondId, addBondOrdinary.bondRaiting, addBondOrdinary.bondNominalValue, addBondOrdinary.bondQuantity, addBondOrdinary.bondCurrentCost, addBondOrdinary.averageBondPourchasePrice, addBondOrdinary.bondOfferDate, addBondOrdinary.bondOfferDate, addBondOrdinary.couponValue,
                    addBondOrdinary.numberOfCouponPerYear, addBondOrdinary.desiredPercentYieldPerYear);
                DataStorage.AddBondOrdinary(bond);
            }

        }
        

    }
}
