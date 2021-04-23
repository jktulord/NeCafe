using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfProject.Model;
using WpfProject.Model.User_Model;
using static WpfProject.Model.ConstLib;

namespace WpfProject.ViewModel.Pages
{
    class ProfilePageVM : ViewModelBase
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
        private User _CurrentUser;
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                _CurrentUser = value;
                RaisePropertyChanged(() => CurrentUser);
            }
        }

        private UserTypes _userTypes;
        public UserTypes userTypes
        {
            get { return _userTypes; }
            set
            {
                _userTypes = value;
                RaisePropertyChanged(() => userTypes);
            }
        }

        private String _typeString;
        public String typeString
        {
            get { return _typeString; }
            set
            {
                _typeString = value;
                RaisePropertyChanged(() => typeString);
            }
        }

        private String _ListVisibility;
        public String ListVisibility
        {
            get { return _ListVisibility; }
            set
            {
                _ListVisibility = value;
                RaisePropertyChanged(() => ListVisibility);
            }
        }
        private String _AddVisibility;
        public String AddVisibility
        {
            get { return _AddVisibility; }
            set
            {
                _AddVisibility = value;
                RaisePropertyChanged(() => AddVisibility);
            }
        }
        private String _TypesVisibility;
        public String TypesVisibility
        {
            get { return _TypesVisibility; }
            set
            {
                _TypesVisibility = value;
                RaisePropertyChanged(() => TypesVisibility);
            }
        }

        public ICommand Add_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    CurrentUser = new User() { type = ConstLib.Kassier, firstname = "", surname = "", password = "" };
                    SwitchToAdd();
                });
            }
        }
        public ICommand Edit_command
        {
            get
            {
                return new DelegateCommand((obj) => { });
            }
        }
        public ICommand Save_command
        {
            get
            {
                return new DelegateCommand((obj) => { });
            }
        }
        public ICommand Delete_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    if (SelectedUser != null)
                    {
                        UserList.Remove(UserList.Where(i => i.firstname + " " + i.surname == SelectedUser.firstname + " " + SelectedUser.surname).Single());
                    }
                });
            }
        }

        public ICommand Add_Finish_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    CurrentUser.type = typeString;
                    UserList.Add(CurrentUser);
                    SwitchToList();
                });
            }
        }
        public ICommand Add_Cancel_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    SwitchToList();
                });
            }
        }
        
        public void SwitchToList()
        {
            ListVisibility = ConstLib.Visible;
            AddVisibility = ConstLib.Hidden;
            TypesVisibility = ConstLib.Hidden;
        }
        public void SwitchToAdd()
        {
            ListVisibility = ConstLib.Hidden;
            AddVisibility = ConstLib.Visible;
            TypesVisibility = ConstLib.Hidden;
        }
        public void SwitchToTypes()
        {
            ListVisibility = ConstLib.Hidden;
            AddVisibility = ConstLib.Hidden;
            TypesVisibility = ConstLib.Visible;
        }

        public ProfilePageVM()
        {
            ListVisibility = ConstLib.Visible;
            AddVisibility = ConstLib.Hidden;
            TypesVisibility = ConstLib.Hidden;
            userTypes = new UserTypes();
            UserList = new ObservableCollection<User>();
            UserList.Add(new User() { type = ConstLib.Admin, firstname = "admin", surname = "adminovich", password = "admin" }) ;
            UserList.Add(new User() { type = ConstLib.Manager, firstname = "Salamander", surname = "13", password = "13" });
            UserList.Add(new User() { type = ConstLib.Kassier, firstname = "qwerty", password = "1" });
        
        
        }
    }
}
