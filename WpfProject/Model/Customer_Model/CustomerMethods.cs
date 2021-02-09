using Console_prototype;
using Console_prototype.Utils;
using Model.Customer_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfProject.ViewModel.Pages;

namespace WpfProject.Model
{
    public static class CustomerMethods
    {
        
        public static ObservableCollection<Customer> Init_Customer()
        {
            return new ObservableCollection<Customer> { };
        }
        public static void Id_Restruct(ObservableCollection<Customer> customers)
        {
            int i = 0;
            foreach (Customer cur in customers)
            {
                i++;
                cur.id = i;
            }
        }

        public static ObservableCollection<Customer> Add_Customer(ObservableCollection<Customer> customers)
        {
            Random rnd = new Random();
            customers.Add(new Customer("Иван"+Convert.ToString(rnd.Next(1, 99)), 1+customers.Count, DateTime.Now, ConstLib.Tariff_Minute));
            return customers;
        }
        public static ObservableCollection<Customer> Add_Custom_Customer(ObservableCollection<Customer> customers, Customer customer, bool MinuteTariff, bool HourTarriff)
        {
            Random rnd = new Random();
            string tariff;
            if (MinuteTariff)
            {
                tariff = ConstLib.Tariff_Minute;
            }
            else
            {
                tariff = ConstLib.Tariff_Hour;
            }
            customers.Add(new Customer(customer.name, 1 + customers.Count, DateTime.Now, tariff));
            return customers;
        }
        public static void Update(ObservableCollection<Customer> customers)
        {
            foreach (Customer i in customers)
            {
                if (i.Active)
                {
                    i.elapsed_time = DateTime.Now - i.start_time;
                }
            }
        }
        public static void Save(ObservableCollection<Customer> customers, TextLine SaveText)
        {
            ObservableCollection<ConvertedCustomer> converted_customers = new ObservableCollection<ConvertedCustomer>();
            foreach (Customer cur in customers)
            {
                converted_customers.Add(cur.convertedCustomer);
            }
            BinarySerialization.WriteToBinaryFile<ObservableCollection<ConvertedCustomer>>("C:/Users/user/source/repos/WpfProject/WpfProject/Model/Data.bin", converted_customers);
            SaveText.Value = "Saved";
        }
        public static ObservableCollection<Customer> Load(ObservableCollection<Customer> customers, TextLine SaveText)
        {
            customers = Init_Customer();
            ObservableCollection<ConvertedCustomer> converted_customers = BinarySerialization.ReadFromBinaryFile<ObservableCollection<ConvertedCustomer>>("C:/Users/user/source/repos/WpfProject/WpfProject/Model/Data.bin");
            SaveText.Value = "0";
            int i = 0;
            foreach (ConvertedCustomer cur in converted_customers)
            {
                i++;
                SaveText.Value = i+" Loaded";
                customers.Add(new Customer(cur));
            }
            Console.WriteLine("Loaded");
            return customers;
        }

    }
}
