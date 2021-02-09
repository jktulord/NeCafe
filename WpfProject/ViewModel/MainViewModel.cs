using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProject.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private Uri MainPage = new Uri("Pages/MainPage.xaml", UriKind.Relative);
        private Uri TariffPage = new Uri("Pages/TariffPage.xaml", UriKind.Relative);

        
        private Uri _CurrentPage;
        public Uri CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                RaisePropertyChanged(()=> CurrentPage);
            }
        }

        public ICommand ClickMainPage
        {
            get
            {
                return new DelegateCommand((obj) => { CurrentPage = MainPage; });
            }
        }
        public ICommand ClickTariffPage
        {
            get
            {
                return new DelegateCommand((obj) => { CurrentPage = TariffPage; });
            }
        }


        public MainViewModel()
        {
            CurrentPage = MainPage;
        }
        
    }
}
