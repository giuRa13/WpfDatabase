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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDatabase
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

        private void main_window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfDatabase.MainDs.EmployeesDs employeesDs = ((WpfDatabase.MainDs.EmployeesDs)(this.FindResource("employeesDs")));
            // Load data into the table Employee_Info. You can modify this code as needed.
            WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter employeesDsEmployee_InfoTableAdapter = new WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter();
            employeesDsEmployee_InfoTableAdapter.Fill(employeesDs.Employee_Info);
            System.Windows.Data.CollectionViewSource employee_InfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employee_InfoViewSource")));
            employee_InfoViewSource.View.MoveCurrentToFirst();

            
        }
    }
}
