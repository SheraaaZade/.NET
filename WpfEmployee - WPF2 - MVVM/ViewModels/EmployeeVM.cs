using System.Collections.Generic;
using System.Linq;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM
    {
        private List<EmployeeModel> _EmployeesList;
        private NorthwindContext NorthwindContext = new NorthwindContext();
        private List<string> _listTitle;


        public List<EmployeeModel> EmployeesList
        {
            get { return _EmployeesList = _EmployeesList ?? LoadEmployees(); }
        }

        private List<EmployeeModel> LoadEmployees()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var employee in NorthwindContext.Employees)
            {
                localCollection.Add(new EmployeeModel(employee));
            }
            return localCollection;
        }

        public List<string> ListTitle
        {
            get { return _listTitle = _listTitle ?? LoadTitleOfCourtesy(); }

        }

        private List<string> LoadTitleOfCourtesy()
        {
            return NorthwindContext.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }
    }
}
