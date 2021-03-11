using DevExpress.Mvvm;
using Model.Customer_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfProject.Model.Customer_Model
{
    public class CustomerFinaliserManager : ViewModelBase
    {

        private Customer _customer;
        public Customer customer
        {
            get { return _customer; }
            set { _customer = value; RaisePropertyChanged(() => customer); }
        }

        public double first_time_value
        {
            get {
                double totalMinutes = Math.Round(customer.elapsed_time.TotalMinutes, 2);
                double return_value = totalMinutes;

                if (customer.tariff.condition_type == ConstLib.Condition_Minute)
                {
                    if (totalMinutes <= customer.tariff.condition_value)
                    {
                        return_value = totalMinutes;
                    }
                    else
                    {
                        return_value = customer.tariff.condition_value;
                    }
                    
                }
                return return_value;
            }
        }
    
        public double second_time_value
        {
            get
            {
                double totalMinutes = Math.Round(customer.elapsed_time.TotalMinutes, 2);
                double return_value;

                if (customer.tariff.condition_type == ConstLib.Condition_Minute)
                {
                    if (totalMinutes <= customer.tariff.condition_value)
                    {
                        return_value = 0;
                    }
                    else
                    {
                        return_value = totalMinutes - customer.tariff.condition_value; 
                    }

                }
                else
                {
                    return_value = 0;
                }
                return return_value;
            }
        }

       
        public double first_cost_value
        {
            get
            {
                double totalMinutes = Math.Round(customer.elapsed_time.TotalMinutes, 2);
                double return_value;

                if (customer.tariff.condition_type == ConstLib.Condition_Minute)
                {
                    if (totalMinutes <= customer.tariff.condition_value)
                    {
                        return_value = Math.Round(totalMinutes * customer.tariff.default_calculation_value, 2);
                    }
                    else
                    {
                        return_value = Math.Round(customer.tariff.condition_value * customer.tariff.default_calculation_value, 2); 
                    }

                }
                else
                {
                    return_value = Math.Round(totalMinutes * customer.tariff.default_calculation_value, 2);
                }
                return return_value;
            }
        }
        private double _second_cost_value;
        public double second_cost_value
        {
            get { return _second_cost_value; }
            set { _second_cost_value = value; RaisePropertyChanged(() => second_cost_value); }
        }

        private double _sum_value;
        public double sum_value
        {
            get { return _sum_value; }
            set { _sum_value = value; RaisePropertyChanged(() => sum_value); }
        }
        public CustomerFinaliserManager(Customer customer)
        {
            this.customer = customer;
            Calculate();
        }

        public void Calculate()
        {
            double totalMinutes = Math.Round(customer.elapsed_time.TotalMinutes);
            Tariff_Model.Tariff tariff = customer.tariff;
            
            second_cost_value = 0;
            if (tariff.is_there_condition)
            {
                if (tariff.condition_type == ConstLib.Condition_Minute)
                {
                    if (totalMinutes <= tariff.condition_value)
                    {
                       
                    }
                    else
                    {
                        
                        second_cost_value = Math.Round((totalMinutes - tariff.condition_value) * tariff.default_calculation_value, 2);
                    }
                }
            }
            else
            {
               
            }
            sum_value = first_cost_value + second_cost_value;
        }
    }
}
