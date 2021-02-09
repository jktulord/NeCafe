using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.ModuleInjection;
using System;
using System.Threading.Tasks;
using WpfProject.ViewModel.Pages;

namespace Console_prototype
{
    [Serializable]
    public class TextLine : ViewModelBase
    {
        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; RaisePropertyChanged(() => Value); }
        }
    }

}
