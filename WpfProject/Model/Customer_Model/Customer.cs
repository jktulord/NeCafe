using DevExpress.Mvvm;
using System;
using System.Threading.Tasks;
using WpfProject.Model.Tariff_Model;
using WpfProject.ViewModel.Pages;

namespace Model.Customer_Model
{
    [Serializable]
    public class Customer : ViewModelBase
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

        private DateTime _start_time;
        public DateTime start_time
        {
            get { return _start_time; }
            set { _start_time = value; RaisePropertyChanged(() => start_time); }
        }

        private TimeSpan _elapsed_time;
        public TimeSpan elapsed_time
        {
            get { return _elapsed_time; }
            set { _elapsed_time = value; RaisePropertyChanged(() => elapsed_time); }
        }

        private Tariff _tariff;
        public Tariff tariff
        {
            get { return _tariff; }
            set { _tariff = value; RaisePropertyChanged(() => tariff); }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; RaisePropertyChanged(() => Active); }
        }
        public String StartTimeString
        {
            get
            {
                return start_time.ToShortTimeString();
            }
        }
        public String ElapsedTimeString
        {
            get
            {
                return Convert.ToString(Math.Round(elapsed_time.TotalMinutes, 2)) + " мин.";
            }
        }
        public ConvertedCustomer convertedCustomer
        {
            get { return new ConvertedCustomer(this); }
        } 
        public Customer(string firstname, string surname, int id, DateTime start_time, Tariff tariff)
        {
            this.firstname = firstname;
            this.surname = surname;
            this.id = id;
            this.start_time = start_time;
            this.Active = false;
            this.tariff = tariff;
        }
        public Customer(ConvertedCustomer customer)
        {
            this.firstname = customer.firstname;
            this.surname = customer.surname;
            this.id = customer.id;   
            this.start_time = customer.start_time;
            this.elapsed_time = customer.elapsed_time;
            this.Active = customer.Active;
            this.tariff = new Tariff(customer.tariff);
        }
        public Customer()
        {
            this.firstname = "";
            this.surname = "";
            this.id = id;
            this.start_time = DateTime.Now;
            this.Active = true;
        }
        public void Update()
        {
            if (Active)
            {
                elapsed_time = DateTime.Now - start_time;
                RaisePropertyChanged(() => StartTimeString);
                RaisePropertyChanged(() => ElapsedTimeString);
            }
        }
    }
    [Serializable]
    public class ConvertedCustomer
    {
        private string _firstname;
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value;}
        }
        private string _surname;
        public string surname
        {
            get { return _surname; }
            set { _surname = value; }
        }


        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value;}
        }

        private DateTime _start_time;
        public DateTime start_time
        {
            get { return _start_time; }
            set { _start_time = value; }
        }

        private TimeSpan _elapsed_time;
        public TimeSpan elapsed_time
        {
            get { return _elapsed_time; }
            set { _elapsed_time = value; }
        }

        private ConvertedTariff _tariff;
        public ConvertedTariff tariff
        {
            get { return _tariff; }
            set { _tariff = value; }
        }

        private bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public ConvertedCustomer(Customer customer)
        {
            this.firstname = customer.firstname;
            this.surname = customer.surname;
            this.id = customer.id;
            this.start_time = customer.start_time;
            this.elapsed_time = customer.elapsed_time;
            this.Active = customer.Active;
            this.tariff = customer.tariff.Converted;
        }
    }


}
