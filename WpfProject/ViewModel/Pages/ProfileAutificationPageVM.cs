using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
        public ProfileAutificationPageVM()
        {
            UserList = new ObservableCollection<User>();
            UserList.Add(new User() { firstname = "123", password = "123" }) ;
            UserList.Add(new User() { firstname = "Salamander", password = "13" });
            UserList.Add(new User() { firstname = "qwerty", password = "qwerty" });
        }
    }
}
