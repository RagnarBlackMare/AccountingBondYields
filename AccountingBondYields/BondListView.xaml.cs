using AccountingBondYields.Data;
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
    /// Логика взаимодействия для BondListView.xaml
    /// </summary>
    delegate void DelegaToShowBonds();
    public partial class BondListView : Window
    {
        internal List<Bond> BondOrdinaryList { get; set; }
        internal event DelegaToShowBonds EventShowBonds = null;
        public BondListView()
        {
            InitializeComponent();            
            new Presenter(this);
            EventShowBonds();
            this.DataContext = BondOrdinaryList;
        }
        
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
