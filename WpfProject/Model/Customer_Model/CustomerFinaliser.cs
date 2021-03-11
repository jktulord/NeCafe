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
            set { _customer = value; }
        }

        private double _first_time_value;
        public double first_time_value
        {
            get { return _first_time_value;  }
            set { _first_time_value = value; }
        }
        private double _second_time_value;
        public double second_time_value
        {
            get { return _second_time_value; }
            set { _second_time_value = value; }
        }

        private double _first_cost_value;
        public double first_cost_value
        {
            get { return _first_cost_value; }
            set { _first_cost_value = value; }
        }
        private double _second_cost_value;
        public double second_cost_value
        {
            get { return _second_cost_value; }
            set { _second_cost_value = value; }
        }

        private double _sum_value;
        public double sum_value
        {
            get { return _sum_value; }
            set { _sum_value = value; }
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
            first_time_value = 0;
            first_cost_value = 0;
            second_time_value = 0;
            second_cost_value = 0;
            if (tariff.is_there_condition)
            {
                if (tariff.condition_type == ConstLib.Condition_Minute)
                {
                    if (totalMinutes <= tariff.condition_value)
                    {
                        first_time_value = totalMinutes;
                        first_cost_value = Math.Round(totalMinutes * tariff.default_calculation_value, 2);
                    }
                    else
                    {
                        first_time_value = tariff.condition_value;
                        first_cost_value = Math.Round(tariff.condition_value * tariff.default_calculation_value, 2);
                        second_time_value = totalMinutes - tariff.condition_value;
                        second_cost_value = Math.Round((totalMinutes - tariff.condition_value) * tariff.default_calculation_value, 2);
                    }
                }
                
            }
            else
            {
                first_time_value = totalMinutes;
                first_cost_value = Math.Round(totalMinutes * tariff.default_calculation_value, 2);
            }
            sum_value = first_cost_value + second_cost_value;
        }
    }
}
