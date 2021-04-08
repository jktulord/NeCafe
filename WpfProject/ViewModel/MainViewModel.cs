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
        private Uri HistoryPage = new Uri("Pages/HistoryPage.xaml", UriKind.Relative);
        private Uri ProfilePage = new Uri("Pages/ProfilePage.xaml", UriKind.Relative);
        private Uri TariffPage = new Uri("Pages/TariffPage.xaml", UriKind.Relative);
        private Uri HelpPage = new Uri("Pages/HelpPage.xaml", UriKind.Relative);
        private Uri DBPage = new Uri("Pages/DBPage.xaml", UriKind.Relative);

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
        public ICommand ClickProfilePage
        {
            get
            {
                return new DelegateCommand((obj) => { CurrentPage = ProfilePage; });
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
        public ICommand ClickHistoryPage
        {
            get
            {
                return new DelegateCommand((obj) => { CurrentPage = HistoryPage; });
            }
        }
        
        public ICommand ClickHelpPage
        {
            get
            {
                return new DelegateCommand((obj) => { CurrentPage = HelpPage; });
            }
        }
        public ICommand ClickDBPage
        {
            get
            {
                return new DelegateCommand((obj) => { CurrentPage = DBPage; });
            }
        }
        public MainViewModel()
        {
            CurrentPage = MainPage;
        }
        
    }
}
