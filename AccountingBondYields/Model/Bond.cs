using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBondYields.Model
{
    internal abstract class Bond
    {
        protected string CompanyName { get; set; }
        protected string BondId { get; set; }
        protected int BondRaiting { get; set; }
        protected double BondNominalValue { get; set; }
        protected int BondQuantity { get; set; }
        protected double BondCurrentCost { get; set; }
        protected double AverageBondPourchasePrice { get; set; }// средняя цена по которой я купил облигации
        protected DateTime BondPayOffDate { get; set; } //Дата погашения
        protected DateTime? BondOfferDate { get; set; } //Дата оферты
        private int numberMothsToPayOff;
        protected int NumberMothsToPayOff { get { return numberMothsToPayOff; } set { GetNumberMothsToPayOff(); } }//количество месцев до погашения, округление в бошьшуюю сторону
        private int numberMonthsToOffer;
        protected int NumberMonthsToOffer { get { return numberMonthsToOffer; } set { GetNumberMothsToOffer(); } }//Количество месяцев до оферты
        protected double CouponValue { get; set; }
        protected int NumberOfCouponPerYear { get; set; } //кол-во кпонов в год
        private double bondIncomeForCouponPeriodPercent;
        protected double BondIncomeForCouponPeriodPercent { get { return bondIncomeForCouponPeriodPercent; } set { GetBondIncomeForCouponPriodPercent(); } }// Годовая доходность КУПОНА в процентах
        private double bondIncomePerYearPercent;
        protected double BondIncomePerYearPercent { get { return bondIncomePerYearPercent; } set { GetBondIncomePerYearPercent(); } }//доходность облигации в год в процентах
        private double incomeBondMaturityPercent;
        protected double IncomeBondMaturityPercent { get { return incomeBondMaturityPercent; } set { GetIncomeBondMaturityPercent(); } }//доходность к погашению в процентах
        private double couponsPaidToMe;
        protected double CouponsPaidToMe { get { return couponsPaidToMe; } set { GetCouponsPaidToMe(); } } //Сумма выплаченных МНЕ купонов
        protected double DesiredPercentYieldPerYear { get; set; }//желаемый процент доходности в год. Нужно для расчета поля BondCostToDesiredPercentYieldPerYear
        private double bondCostToDesiredPercentYieldPerYear;
        protected double BondCostToDesiredPercentYieldPerYear { get { return bondCostToDesiredPercentYieldPerYear; } set { GetBondCostToDesiredPercentYieldPerYear(); } }//Стоимость облигации при которой будет желаемый процент доходности, то есть на какую стоимость выставлять заявку
        private double incomeFromDifferenceNominalAndAveragePourchaseCost;
        protected double IncomeFromDifferenceNominalAndAveragePourchaseCost { get { return incomeFromDifferenceNominalAndAveragePourchaseCost; } set { GetIncomeFromDifferenceNominalAndAveragePourchaseCost(); } }//Доход от разницы в номинала и средней цены покупки
       
        protected Bond(string companyName, string bondId, int bondRaiting, double bondNominalValue, int bondQuantity, double bondCurrentCost, double averageBondPourchasePrice, DateTime bondPayOffDate, DateTime? bondOfferDate, double couponValue, int numberOfCouponPerYear, 
          double desiredPercentYieldPerYear)
        {
            CompanyName = companyName;
            BondId = bondId;
            BondRaiting = bondRaiting;
            BondNominalValue = bondNominalValue;
            BondQuantity = bondQuantity;
            BondCurrentCost = bondCurrentCost;
            AverageBondPourchasePrice = averageBondPourchasePrice;
            BondPayOffDate = bondPayOffDate;
            BondOfferDate = bondOfferDate;            
            CouponValue = couponValue;
            NumberOfCouponPerYear = numberOfCouponPerYear;            
            DesiredPercentYieldPerYear = desiredPercentYieldPerYear;            
        }
        protected Bond() { }

        protected int GetNumberMothsToPayOff()
        {
            DateTime currentDate = DateTime.Now;
            int numreOfMonths = (BondPayOffDate.Month - currentDate.Month) + (12 * (BondPayOffDate.Year - currentDate.Year));
            return numreOfMonths;
        }
        protected int GetNumberMothsToOffer()
        {
            if (BondOfferDate is not null)
            {
                DateTime currentDate = DateTime.Now;
                DateTime bondOfferDate = (DateTime)BondOfferDate;
                int numreOfMonths = (bondOfferDate.Month - currentDate.Month) + (12 * (BondPayOffDate.Year - currentDate.Year));
                return numreOfMonths;
            }
            else { return 0; }
        }
        protected double GetCouponsPaidToMe()
        {
            double couponsPaidToMe = CouponValue * BondQuantity;
            return couponsPaidToMe;
        }
        protected double GetBondCostToDesiredPercentYieldPerYear()
        {
            double couponSumPerYear = CouponValue * NumberOfCouponPerYear;
            double bondCostToDesiredPercentYieldPerYear = (100 * couponSumPerYear) / DesiredPercentYieldPerYear;
            return bondCostToDesiredPercentYieldPerYear;
        }
       protected double GetIncomeFromDifferenceNominalAndAveragePourchaseCost()
        {
            double incomeFromDifferenceNominalAndAveragePourchaseCost = (BondNominalValue - AverageBondPourchasePrice) * BondQuantity;
            return incomeFromDifferenceNominalAndAveragePourchaseCost;
        }
        protected double GetBondIncomeForCouponPriodPercent()
        {
            double bondIncomeForCouponPriodPercent = (100 * CouponValue) / AverageBondPourchasePrice;
            return bondIncomeForCouponPriodPercent;
        }
        protected double GetBondIncomePerYearPercent()
        {
            double bondIncomePerYearPercent = BondIncomeForCouponPeriodPercent * NumberOfCouponPerYear;
            return bondIncomePerYearPercent;
        }
        protected double GetIncomeBondMaturityPercent()
        {
            DateTime currentDate = DateTime.Now;
            int numberOfYesrBeforeMaturity = BondPayOffDate.Year - currentDate.Year;
            double incomeBondMaturity = BondIncomePerYearPercent * numberOfYesrBeforeMaturity;
            return incomeBondMaturity;
        }
        protected void SetNewAverageBondPourchasePrice(double newAveragePourchasePrice) //метод для изменения средней цены покупки акций
        {
            AverageBondPourchasePrice = newAveragePourchasePrice;
        }
    }
}
