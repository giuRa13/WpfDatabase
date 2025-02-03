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
            WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter employeesDsEmployee_InfoTableAdapter = new WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter();
            employeesDsEmployee_InfoTableAdapter.Fill(employeesDs.Employee_Info);
            
            System.Windows.Data.CollectionViewSource employee_InfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employee_InfoViewSource")));
            employee_InfoViewSource.View.MoveCurrentToFirst();
            this.employee_InfoDataGrid.ScrollIntoView(employee_InfoViewSource.View.CurrentItem);

            this.save_btn.IsEnabled = false;
            this.save_btn.Opacity = 0.5;
            this.return_btn.IsEnabled = false;
            this.return_btn.Opacity = 0.5;

            this.group_box_left.IsEnabled = false;
            this.group_box_left.Opacity = 0.5;
            this.employee_InfoDataGrid.IsEnabled = true;
            
        }

        void new_edit_del_btns()
        {
            this.new_btn.IsEnabled = false;
            this.new_btn.Opacity = 0.5;
            this.edit_btn.IsEnabled = false;
            this.edit_btn.Opacity = 0.5;

            this.save_btn.IsEnabled = true;
            this.save_btn.Opacity = 1.0;
            this.return_btn.IsEnabled = true;
            this.return_btn.Opacity = 1.0;

            this.group_box_left.IsEnabled = true;
            this.group_box_left.Opacity = 1.0;
            this.employee_InfoDataGrid.IsEnabled = false;
        }

        void save_return_btns()
        {
            this.new_btn.IsEnabled = true;
            this.new_btn.Opacity = 1.0;
            this.edit_btn.IsEnabled = true;
            this.edit_btn.Opacity = 1.0;
            this.delete_btn.IsEnabled = true;
            this.delete_btn.Opacity = 1.0;

            this.save_btn.IsEnabled = false;
            this.save_btn.Opacity = 0.5;
            this.return_btn.IsEnabled = false;
            this.return_btn.Opacity = 0.5;

            this.group_box_left.IsEnabled = false;
            this.group_box_left.Opacity = 0.5;
            this.employee_InfoDataGrid.IsEnabled = true;
        }

        private void new_btn_Click(object sender, RoutedEventArgs e)
        {
            new_edit_del_btns();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            new_edit_del_btns();
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            new_edit_del_btns();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            save_return_btns();
        }

        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            save_return_btns();
        }
    }
}
