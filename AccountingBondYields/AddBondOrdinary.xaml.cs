using AccountingBondYields.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountingBondYields
{
    
    /// <summary>
    /// Логика взаимодействия для AddBondOrdinary.xaml
    /// </summary>
    public partial class AddBondOrdinary : Window
    {  //TODO: ПОискать нормальный фреймворк, в котором не надо извращаться с ручным писанирем методов для ограничения на прием в текстбокс только чисел
        internal string companyName;
        internal string bondId;
        internal int bondRaiting;
        internal double bondNominalValue;
        internal int bondQuantity;
        internal double bondCurrentCost;
        internal double averageBondPourchasePrice;
        internal DateTime bondPayOffDate;
        internal DateTime bondOfferDate; 
        internal double couponValue;
        internal int numberOfCouponPerYear;
        internal int desiredPercentYieldPerYear;
        public AddBondOrdinary()
        {            
            InitializeComponent();
            new Presenter(this);
        }
        internal event EventHandler EventSaveBond = null;
        private void CompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyName = CompanyName.Text.ToString();
        }

        private void BondId_TextChanged(object sender, TextChangedEventArgs e)
        {
            bondId = BondId.Text.ToString();
        }

        private void BondRaiting_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = int.TryParse(BondRaiting.Text, out bondRaiting);
        }

        private void BondNominalValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = double.TryParse(BondNominalValue.Text, out bondNominalValue);
        }

        private void BondQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = int.TryParse(BondQuantity.Text, out bondQuantity);
        }

        private void BondCurrentCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = double.TryParse(BondCurrentCost.Text, out bondCurrentCost);
        }

        private void AverageBondPourchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = double.TryParse(AverageBondPourchasePrice.Text, out averageBondPourchasePrice);
        }
        private void BondPayOffDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            bool t = DateTime.TryParse(BondPayOffDate.Text, out bondPayOffDate);
        }
        private void BondOfferDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            bool t = DateTime.TryParse(BondOfferDate.Text, out bondOfferDate);
        }
        private void CouponValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = double.TryParse(CouponValue.Text, out couponValue);
        }
        private void NumberOfCouponPerYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = int.TryParse(NumberOfCouponPerYear.Text, out numberOfCouponPerYear);
        }

        private void DesiredPercentYieldPerYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool t = int.TryParse(DesiredPercentYieldPerYear.Text, out desiredPercentYieldPerYear);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            EventSaveBond(sender, e);
            this.Close();
        }
    }
}
