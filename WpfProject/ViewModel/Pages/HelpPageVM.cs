using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfProject.ViewModel.Pages
{
    public class HelpPageVM : ViewModelBase
    {
        public ICommand ClickSave
        {
            get
            {
                return new DelegateCommand((obj) => { CustomerMethods.Save(CustomerList, SaveText); });
            }
        }
        public ICommand ClickLoad
        {
            get
            {
                return new DelegateCommand((obj) => { CustomerList = CustomerMethods.Load(CustomerList); });
            }
        }
        public HelpPageVM()
        {

        }
    }
}
