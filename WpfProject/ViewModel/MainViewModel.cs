using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Model;
using WpfProject.Model.User_Model;

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

        private ObservableCollection<User> _UserList;
        public ObservableCollection<User> UserList
        {
            get { return _UserList; }
            set
            {
                _UserList = value;
                RaisePropertyChanged(() => UserList);
            }
        }

        private User _SelectedUser;
        public User SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
                RaisePropertyChanged(() => SelectedUser);
            }
        }

        private User _AutherisedUser;

        public User AutherisedUser
        {
            get { return _AutherisedUser; }
            set
            {
                _AutherisedUser = value;
                RaisePropertyChanged(() => AutherisedUser);
            }
        }

        private String _MenuVisability;
        public String MenuVisability
        {
            get { return _MenuVisability; }
            set
            {
                _MenuVisability = value;
                RaisePropertyChanged(() => MenuVisability);
            }
        }

        private String _AutenticationVisability;
        public String AutenticationVisability
        {
            get { return _AutenticationVisability; }
            set
            {
                _AutenticationVisability = value;
                RaisePropertyChanged(() => AutenticationVisability);
            }
        }

        private String _CurPassword;
        public String CurPassword
        {
            get { return _CurPassword; }
            set
            {
                _CurPassword = value;
                RaisePropertyChanged(() => CurPassword);
            }
        }

        private String _PasswordColor;
        public String PasswordColor
        {
            get { return _PasswordColor; }
            set
            {
                _PasswordColor = value;
                RaisePropertyChanged(() => PasswordColor);
            }
        }

        private String _AwarenessLine;
        public String AwarenessLine
        {
            get { return _AwarenessLine; }
            set
            {
                _AwarenessLine = value;
                RaisePropertyChanged(() => AwarenessLine);
            }
        }

        private int _MenuWidth;
        public int MenuWidth
        {
            get { return _MenuWidth; }
            set
            {
                _MenuWidth = value;
                RaisePropertyChanged(() => MenuWidth);
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
        public ICommand ClickShowPassword
        {
            get
            {
                return new DelegateCommand((obj) => {
                    if (PasswordColor == ConstLib.White)
                    {
                        PasswordColor = ConstLib.Black;
                    }
                    else
                    {
                        PasswordColor = ConstLib.White;
                    }

                });
            }
        }
        public ICommand ClickSignIn
        {
            get
            {
                return new DelegateCommand((obj) => {
                    if (CurPassword == SelectedUser.password)
                    {
                        AwarenessLine = "Авторизировано";
                        AutherisedUser = SelectedUser;
                        MenuVisability = ConstLib.Visible;
                        AutenticationVisability = ConstLib.Hidden;
                    }
                    else
                    {
                        AwarenessLine = "Не верный пароль";
                    }

                });
            }
        }
        public ICommand ClickSignOut
        {
            get
            {
                return new DelegateCommand((obj) => {
                    
                    AwarenessLine = "";
                    MenuVisability = ConstLib.Hidden;
                    AutenticationVisability = ConstLib.Visible;
                    
                });
            }
        }
        public MainViewModel()
        {
            PasswordColor = ConstLib.Black;
            AwarenessLine = "";
            UserList = new ObservableCollection<User>();
            UserList.Add(new User() { firstname = "admin", password = "admin" });
            UserList.Add(new User() { firstname = "Salamander", password = "13" });
            UserList.Add(new User() { firstname = "qwerty", password = "qwerty" });
            AutenticationVisability = ConstLib.Visible;
            MenuVisability = ConstLib.Hidden;
            CurrentPage = MainPage;
        }
        
    }
}
