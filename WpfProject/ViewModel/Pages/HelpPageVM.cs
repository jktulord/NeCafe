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
                return new DelegateCommand((obj) => { });
            }
        }
        public ICommand ClickLoad
        {
            get
            {
                return new DelegateCommand((obj) => { });
            }
        }
        public HelpPageVM()
        {

        }
    }
}
