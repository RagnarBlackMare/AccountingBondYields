using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingBondYields
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        //TDO: Загонять спосок облигаций в файл и счивать надо в отдельных потоках!!!
        //TODO: Сделать класс под аналитику. Там надо считать 1) Купонный доход в рублях за (год, месяц) 2) Купонный доход в % за (год, месяц)
        //TODO: На поле с датой оферты повесить 1) ОБязательный ввод поля 2) Проверку на дату НЕ меньше текущей
        //TODO: в качестве оллекции использовать НЕ лист, а ObservableCollection https://metanit.com/sharp/wpf/14.2.php
        //TODO:  сделать MessageBox. Show(не заполнена дата)
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddBondOrdinary addBondOrdinary = new AddBondOrdinary();
            addBondOrdinary.Show();
        }

        private void ButtonShowBondList_Click(object sender, RoutedEventArgs e)
        {
            BondListView bondListView = new BondListView();
            bondListView.Show();           
        }
    }
}