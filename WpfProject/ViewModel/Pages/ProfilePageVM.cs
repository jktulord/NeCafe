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
                return new DelegateCommand((obj) => { });
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

        public ProfilePageVM()
        {
            ListVisibility = ConstLib.Visible;
            AddVisibility = ConstLib.Hidden;
            TypesVisibility = ConstLib.Hidden;
            UserList = new ObservableCollection<User>();
            UserList.Add(new User() { type = ConstLib.Admin, firstname = "admin", password = "admin" }) ;
            UserList.Add(new User() { type = ConstLib.Manager, firstname = "Salamander", password = "13" });
            UserList.Add(new User() { type = ConstLib.Kassier, firstname = "qwerty", password = "1" });
        
        
        }
    }
}
