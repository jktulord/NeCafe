using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfProject.Model;
using WpfProject.Model.User_Model;

namespace WpfProject.ViewModel.Pages
{
    class ProfileAutificationPageVM : ViewModelBase
    {

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
                    }
                    else
                    {
                        AwarenessLine = "Не верный пароль";
                    }

                });
            }
        }

        public ProfileAutificationPageVM()
        {
            PasswordColor = ConstLib.Black;
            AwarenessLine = "";
            UserList = new ObservableCollection<User>();
            UserList.Add(new User() { firstname = "admin", password = "admin" }) ;
            UserList.Add(new User() { firstname = "Salamander", password = "13" });
            UserList.Add(new User() { firstname = "qwerty", password = "qwerty" });
        }
    }
}
