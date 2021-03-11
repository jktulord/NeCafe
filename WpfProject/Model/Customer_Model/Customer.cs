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
        private string _name; 
        public string name 
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => name); }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(() => id); }
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
        public ConvertedCustomer convertedCustomer
        {
            get { return new ConvertedCustomer(this); }
        } 
        public Customer(string name, int id, DateTime start_time, Tariff tariff)
        {
            this.name = name;
            this.id = id;
            this.start_time = start_time;
            this.Active = false;
            this.tariff = tariff;
        }
        public Customer(ConvertedCustomer customer)
        {
            this.name = customer.name;
            this.id = customer.id;
            this.start_time = customer.start_time;
            this.elapsed_time = customer.elapsed_time;
            this.Active = customer.Active;
            this.tariff = new Tariff(customer.tariff);
        }
        public Customer()
        {
            this.name = "Имя";
            this.id = id;
            this.start_time = DateTime.Now;
            this.Active = true;
        }
    }
    [Serializable]
    public class ConvertedCustomer
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value;}
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
            this.name = customer.name;
            this.id = customer.id;
            this.start_time = customer.start_time;
            this.elapsed_time = customer.elapsed_time;
            this.Active = customer.Active;
            this.tariff = customer.tariff.Converted;
        }
    }


}
