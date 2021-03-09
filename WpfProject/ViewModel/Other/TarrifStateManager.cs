using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using WpfProject.Model;

namespace WpfProject.ViewModel.Other
{
    public class TarrifStateManager : ViewModelBase
    {
        private string _ListBoxVisibility;
        public string ListBoxVisibility
        {
            get { return _ListBoxVisibility; }
            set
            {
                _ListBoxVisibility = value;
                RaisePropertyChanged(() => ListBoxVisibility);
            }
        }
        private string _AddMenuVisibility;
        public string AddMenuVisibility
        {
            get { return _AddMenuVisibility; }
            set
            {
                _AddMenuVisibility = value;
                RaisePropertyChanged(() => AddMenuVisibility);
            }
        }
        private string _FinaliseMenuVisibility;
        public string FinaliseMenuVisibility
        {
            get { return _FinaliseMenuVisibility; }
            set
            {
                _FinaliseMenuVisibility = value;
                RaisePropertyChanged(() => FinaliseMenuVisibility);
            }
        }

        public TarrifStateManager()
        {
            ListBoxVisibility = ConstLib.Visible;
            FinaliseMenuVisibility = ConstLib.Hidden;
            AddMenuVisibility = ConstLib.Hidden;
        }
        public void SwitchToListBox()
        {
            ListBoxVisibility = ConstLib.Visible;
            FinaliseMenuVisibility = ConstLib.Hidden;
            AddMenuVisibility = ConstLib.Hidden;
        }
        public void SwitchToAddMenu()
        {
            ListBoxVisibility = ConstLib.Hidden;
            FinaliseMenuVisibility = ConstLib.Hidden;
            AddMenuVisibility = ConstLib.Visible;
        }
        public void SwitchToFinalise()
        {
            ListBoxVisibility = ConstLib.Hidden;
            FinaliseMenuVisibility = ConstLib.Visible;
            AddMenuVisibility = ConstLib.Hidden;
        }
    }
    


}
