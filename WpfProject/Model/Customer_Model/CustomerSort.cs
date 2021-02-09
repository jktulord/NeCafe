using Model.Customer_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfProject.Model
{
    public static class CustomerSort
    {
        public static ObservableCollection<Customer> ById(ObservableCollection<Customer> customers, bool Progresive)
        {
            int cur = 0;
            Customer buffer; 
            for (int i = 0; i < customers.Count-1; i++)
            {
                for (int j = i; j < customers.Count-1; j++)
                {
                    if (Progresive)
                    {
                        if (customers[i].id > customers[j].id)
                        {
                            cur = j;
                        }
                    }
                    else
                    {
                        if (customers[i].id < customers[j].id)
                        {
                            cur = j;
                        }
                    }
                    
                }
                buffer = customers[i];
                customers[i] = customers[cur];
                customers[cur] = buffer;
            }
            return customers;
        }
    }
}
