using System;
using System.ComponentModel;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private readonly Employee _monEmployee;

        public Employee MonEmployee
        {
            get { return _monEmployee; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EmployeeModel(Employee monEmployee)
        {
            _monEmployee = monEmployee;
        }

        public String DisplayBirthDate
        {
            get
            {
                if (_monEmployee.BirthDate.HasValue)
                {
                    return _monEmployee.BirthDate.Value.ToShortDateString();
                }
                return "";
            }
        }

        public String FullName
        {
            get
            {
                return _monEmployee.FirstName + " " + _monEmployee.LastName;
            }
        }

        public string TitleOfCourtesy
        {
            get { return _monEmployee.TitleOfCourtesy; }
            set
            {
                _monEmployee.TitleOfCourtesy = value;

            }
        }

        public string LastName
        {
            get
            {
                return _monEmployee.LastName;
            }
            set
            {
                _monEmployee.LastName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string FirstName
        {
            get
            {
                return _monEmployee.FirstName;
            }
            set
            {
                _monEmployee.FirstName = value;
                OnPropertyChanged("FullName");

            }
        }

        public DateTime? BirthDate
        {
            get
            {
                return _monEmployee.BirthDate;
            }
            set
            {
                _monEmployee.BirthDate = value;
                OnPropertyChanged("DisplayBirthDate");
            }
        }

        public DateTime? HireDate
        {
            get { return _monEmployee.HireDate; }
            set { _monEmployee.HireDate = value; }

        }
    }
}
