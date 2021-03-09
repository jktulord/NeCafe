using Console_prototype;
using Console_prototype.Utils;
using Model.Customer_Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

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
            customers.Add(new Customer("Иван"+Convert.ToString(rnd.Next(1, 99)), 1+customers.Count, DateTime.Now, new Tariff_Model.Tariff()));
            return customers;
        }
        public static ObservableCollection<Customer> Add_Custom_Customer(ObservableCollection<Customer> customers, Customer customer, bool MinuteTariff, bool HourTarriff)
        {
            Random rnd = new Random();
            string tariff;
            if (MinuteTariff)
            {
                tariff = ConstLib.Calculation_Minute;
            }
            else
            {
                tariff = ConstLib.Calculation_Hour;
            }
            customers.Add(new Customer(customer.name, 1 + customers.Count, DateTime.Now, new Tariff_Model.Tariff()));
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
            String path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.IndexOf("bin\\Debug")) + "/Savefiles/CustomerData.bin";
            BinarySerialization.WriteToBinaryFile<ObservableCollection<ConvertedCustomer>>(path, converted_customers);
            SaveText.Value = "Saved";
        }
        public static ObservableCollection<Customer> Load(ObservableCollection<Customer> customers)
        {
            customers = Init_Customer();

            String path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.IndexOf("bin\\Debug")) + "/Savefiles/CustomerData.bin";
            ObservableCollection<ConvertedCustomer> converted_customers = BinarySerialization.ReadFromBinaryFile<ObservableCollection<ConvertedCustomer>>(path);
            int i = 0;
            foreach (ConvertedCustomer cur in converted_customers)
            {
                customers.Add(new Customer(cur));
            }
            Console.WriteLine("Loaded");
            return customers;
        }

    }
}
