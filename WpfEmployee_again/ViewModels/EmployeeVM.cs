using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfApplication1.ViewModels;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM : INotifyPropertyChanged
    {
      //  private List<EmployeeModel> _EmployeesList;
        private NorthwindContext dc = new NorthwindContext();
        private List<string> _listTitle;
        public event PropertyChangedEventHandler PropertyChanged;
        private EmployeeModel _selectedEmployee;
        private ObservableCollection<EmployeeModel> _EmployeesList;
        private ObservableCollection<OrderModel> _OrdersList;
        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;
        public ObservableCollection<EmployeeModel> EmployeesList
        {
            get { return _EmployeesList = _EmployeesList ?? LoadEmployees(); }
        }

        private ObservableCollection<EmployeeModel> LoadEmployees()
        {
            ObservableCollection<EmployeeModel> localCollection = new ObservableCollection<EmployeeModel>();
            foreach (var employee in dc.Employees)
            {
                localCollection.Add(new EmployeeModel(employee));
            }
            return localCollection;
        }

        public ObservableCollection<OrderModel> OrdersList
        {
            get
            {
                if (SelectedEmployee != null)
                {
                    _OrdersList = loadOrders();
                }

                return _OrdersList;

            }

        }

        private ObservableCollection<OrderModel> loadOrders()
        {
            ObservableCollection<OrderModel> localCollection = new ObservableCollection<OrderModel>();
            var query = from Order o in dc.Orders
                        where (o.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId)
                        orderby o.OrderDate descending
                        select o;

            int i = 0;
            foreach (var item in query)
            {
                decimal total = dc.OrderDetails.Where(od => od.OrderId == item.OrderId).Sum(od => od.UnitPrice);
                localCollection.Add(new OrderModel(item, total));
                i++;
                if (i == 3) break;
            }

            return localCollection;

        }
        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("OrdersList"); }

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveEmployee); }
        }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand(AddEmployee);
            }

        }

        private void AddEmployee()
        {
            Employee EGlobal = new Employee();
            EmployeeModel EModel = new EmployeeModel(EGlobal);
            EmployeesList.Add(EModel);
            SelectedEmployee = EModel;
        }

        private void SaveEmployee()
        {
            Employee verif = dc.Employees.Where(e => e.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId).SingleOrDefault();
            if (verif == null)
            {
                dc.Employees.Add(SelectedEmployee.MonEmployee);
            }

            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }

        public List<string> ListTitle
        {
            get { return _listTitle = _listTitle ?? LoadTitle(); }
        }

        public List<string> LoadTitle()
        {
            return dc.Employees.Select(o => o.TitleOfCourtesy).Distinct().ToList();
        }
    }
}
