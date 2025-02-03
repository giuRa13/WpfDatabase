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
using WpfDatabase.MainDs;

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

        WpfDatabase.MainDs.EmployeesDs employeesDs;
        WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter employeesDsEmployee_InfoTableAdapter;
        System.Windows.Data.CollectionViewSource employee_InfoViewSource;
        Boolean is_delete_btn_clicked = false;

        private void main_window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                employeesDs = ((WpfDatabase.MainDs.EmployeesDs)(this.FindResource("employeesDs")));
                employeesDsEmployee_InfoTableAdapter = new WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter();
                employeesDsEmployee_InfoTableAdapter.Fill(employeesDs.Employee_Info);

                employee_InfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employee_InfoViewSource")));
                employee_InfoViewSource.View.MoveCurrentToFirst();
                this.employee_InfoDataGrid.ScrollIntoView(employee_InfoViewSource.View.CurrentItem);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

            if(is_delete_btn_clicked == true)
            {
                this.group_box_left.IsEnabled = false;
                this.group_box_left.Opacity = 0.5;
                is_delete_btn_clicked = false ;
            }         
            else
            {
                this.group_box_left.IsEnabled = true;
                this.group_box_left.Opacity = 1.0;
            }

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
            try
            {
                new_edit_del_btns();

                //employeesDs = ((WpfDatabase.MainDs.EmployeesDs)(this.FindResource("employeesDs")));

                System.Data.DataRow dr;
                dr = employeesDs.Employee_Info.NewEmployee_InfoRow();
                employeesDs.Employee_Info.Rows.Add(dr);

                //employee_InfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employee_InfoViewSource")));
                employee_InfoViewSource.View.MoveCurrentToLast();
                this.employee_InfoDataGrid.ScrollIntoView(employee_InfoViewSource.View.CurrentItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //employeesDs = ((WpfDatabase.MainDs.EmployeesDs)(this.FindResource("employeesDs")));
                Int32 rc;
                rc = employeesDs.Employee_Info.Rows.Count;
                if(rc == 0)
                {
                    MessageBox.Show("Nothing to Edit", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                new_edit_del_btns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }


        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //employeesDs = ((WpfDatabase.MainDs.EmployeesDs)(this.FindResource("employeesDs")));
                Int32 rc;
                rc = employeesDs.Employee_Info.Rows.Count;
                if (rc == 0)
                {
                    MessageBox.Show("Nothing To Delete", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                is_delete_btn_clicked = true;
                new_edit_del_btns();

                //employee_InfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employee_InfoViewSource")));
                System.Data.DataRowView drv;
                drv = (System.Data.DataRowView)employee_InfoViewSource.View.CurrentItem;

                drv.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                save_return_btns();

                //employeesDsEmployee_InfoTableAdapter = new WpfDatabase.MainDs.EmployeesDsTableAdapters.Employee_InfoTableAdapter();
                //employeesDs = ((WpfDatabase.MainDs.EmployeesDs)(this.FindResource("employeesDs")));
                
                Int32 rv;
                rv = employeesDsEmployee_InfoTableAdapter.Update(employeesDs.Employee_Info); //(INSERT)
                if (rv > 0)
                    MessageBox.Show("Changed Saved to Database", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Error Saving Data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                save_return_btns();
                employeesDs.RejectChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

}
