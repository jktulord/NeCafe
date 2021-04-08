using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfProject.Model.User_Model
{
    public class User : ViewModelBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(() => id); }
        }
        private string _firstname;
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; RaisePropertyChanged(() => firstname); }
        }
        private string _surname;
        public string surname
        {
            get { return _surname; }
            set { _surname = value; RaisePropertyChanged(() => surname); }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => password); }
        }
        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged(() => type); }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; RaisePropertyChanged(() => Active); }
        }
        
        public ConvertedUser converted
        {
            get { return new ConvertedUser(this); }
        }
        public User(ConvertedUser user)
        {

            this.firstname = user.firstname;
            this.surname = user.surname;
            this.id = user.id;
            this.password = user.password;
            this.type = user.type;
            this.Active = user.Active;
        }
        public User()
        {
            this.firstname = "";
            this.surname = "";
            this.id = id;
            this.password = "";
            this.type = "";
            this.Active = true;
        }
        
    }
    [Serializable]
    public class ConvertedUser
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value;}
        }
        private string _firstname;
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        private string _surname;
        public string surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }


        public ConvertedUser(User user)
        {
            this.firstname = user.firstname;
            this.surname = user.surname;
            this.id = user.id;
            this.password = user.password;
            this.type = user.type;
            this.Active = user.Active;
        }
    }
}
