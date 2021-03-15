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

        // Значения
        private double _first_time_value;
        public double first_time_value
        {
            get { return _first_time_value; }
            set { _first_time_value = value; RaisePropertyChanged(() => first_time_value); }
        }

        private double _first_cost_value;
        public double first_cost_value
        {
            get { return _first_cost_value; }
            set { _first_cost_value = value; RaisePropertyChanged(() => first_cost_value); }
        }

        private double _second_time_value;
        public double second_time_value
        {
            get { return _second_time_value; }
            set { _second_time_value = value; RaisePropertyChanged(() => second_time_value); }
        }

        private double _second_cost_value;
        public double second_cost_value
        {
            get { return _second_cost_value; }
            set { _second_cost_value = value; RaisePropertyChanged(() => second_cost_value); }
        }
        public double sum_value
        {
            get { return first_cost_value + second_cost_value; }
        }

        // Стринги значений
        public string first_type_string
        {
            get
            {
                string return_value = "";
                if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute)
                {
                    return_value = "руб/мин";
                }
                else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour)
                {
                    return_value = "руб/час";
                }
                else
                {
                    return_value = "руб/стоп-чек";
                }

                return return_value;
            }
        }
        public string second_type_string
        {
            get
            {
                string return_value = "";
                if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Minute)
                {
                    return_value = "руб/мин";
                }
                else if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Hour)
                {
                    return_value = "руб/час";
                }
                else
                {
                    return_value = "руб/стоп-чек";
                }

                return return_value;
            }
        }
        public CustomerFinaliserManager(Customer customer)
        {
            this.customer = customer;
            execute();
        }

        public void calculate_separate_values(double totalMinutes)
        {
            
            double condition_value;
            first_cost_value = 0;
            first_time_value = 0;
            second_cost_value = 0;
            second_time_value = 0;
            if (customer.tariff.condition_type == ConstLib.Condition_Minute) // условие минутное
            {
                condition_value = customer.tariff.condition_value;
            }
            else
            {
                condition_value = customer.tariff.condition_value * 60;
            }
            if (totalMinutes <= condition_value) // Если время больше чем по условию
            {
                if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute) // минутное вычисление
                {
                    first_time_value = totalMinutes;
                    first_cost_value = Math.Round(first_time_value * customer.tariff.default_calculation_value, 2);
                }
                else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    first_time_value = totalMinutes / 60;
                    first_cost_value = Math.Round(Math.Ceiling(first_time_value) * customer.tariff.default_calculation_value, 2);
                }
                else // стоп-чек
                {
                    first_time_value = totalMinutes;
                    first_cost_value = customer.tariff.default_calculation_value;
                }

            }
            else // време выходит за рамки стандартного
            {
                if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute) // минутное вычисление
                {
                    first_time_value = condition_value;
                    first_cost_value = Math.Round(first_time_value * customer.tariff.default_calculation_value, 2);
                }
                else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    first_time_value = condition_value;
                    first_cost_value = Math.Round(Math.Ceiling(first_time_value) * customer.tariff.default_calculation_value, 2);
                }
                else // стоп-чек
                {
                    first_time_value = condition_value;
                    first_cost_value = customer.tariff.default_calculation_value;
                }

                if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Minute)
                {
                    second_time_value = totalMinutes - first_time_value;
                    second_cost_value = second_time_value * customer.tariff.conditional_calculation_value;
                }
                else if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Hour)
                {
                    second_time_value = totalMinutes - first_time_value;
                    second_cost_value = Math.Round(second_time_value * customer.tariff.conditional_calculation_value, 2);
                }
                else
                {
                    second_time_value = totalMinutes - first_time_value;
                    second_cost_value = customer.tariff.conditional_calculation_value;
                }
            }            
            RaisePropertyChanged(() => first_time_value);
            RaisePropertyChanged(() => first_cost_value);
            RaisePropertyChanged(() => second_time_value);
            RaisePropertyChanged(() => second_cost_value);
        }
        public void calculate_overall_values(double totalMinutes)
        {

            double condition_value;
            first_cost_value = 0;
            first_time_value = 0;
            second_cost_value = 0;
            second_time_value = 0;
            if (customer.tariff.condition_type == ConstLib.Condition_Minute) // условие минутное
            {
                condition_value = customer.tariff.condition_value;
            }
            else
            {
                condition_value = customer.tariff.condition_value * 60;
            }
            if (totalMinutes <= condition_value) // Если время больше чем по условию
            {
                if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute) // минутное вычисление
                {
                    first_time_value = totalMinutes;
                    first_cost_value = Math.Round(first_time_value * customer.tariff.default_calculation_value, 2);
                }
                else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    first_time_value = totalMinutes / 60;
                    first_cost_value = Math.Round(Math.Ceiling(first_time_value) * customer.tariff.default_calculation_value, 2);
                }
                else // стоп-чек
                {
                    first_time_value = totalMinutes;
                    first_cost_value = customer.tariff.default_calculation_value;
                }

            }
            else // време выходит за рамки стандартного
            {
                if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Minute) // минутное вычисление
                {
                    second_time_value = totalMinutes;
                    second_cost_value = Math.Round(second_time_value * customer.tariff.conditional_calculation_value, 2);
                }
                else if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    second_time_value = totalMinutes / 60;
                    second_cost_value = Math.Round(Math.Ceiling(second_time_value) * customer.tariff.conditional_calculation_value, 2);
                }
                else // стоп-чек
                {
                    second_time_value = totalMinutes;
                    second_cost_value = customer.tariff.conditional_calculation_value;
                }
            }
            RaisePropertyChanged(() => first_time_value);
            RaisePropertyChanged(() => first_cost_value);
            RaisePropertyChanged(() => second_time_value);
            RaisePropertyChanged(() => second_cost_value);
        }

        public void execute()
        {
            double totalMinutes = Math.Round(customer.elapsed_time.TotalMinutes, 2);
            double return_value = totalMinutes;

            if (customer.tariff.is_there_condition) // если есть условие
            {
                if (customer.tariff.condition_result_type == ConstLib.Condition_Result_Separate) // если вычисление сепарирование
                {
                    calculate_separate_values(totalMinutes);
                }
                else
                {
                    calculate_overall_values(totalMinutes);
                }
            }
            else
            {
                
            }

            /*
            if (customer.tariff.condition_type == ConstLib.Condition_Minute)
            {
                if ((totalMinutes <= customer.tariff.condition_value) || (customer.tariff.is_there_condition == false)) // Если время больше чем по условию
                {
                    if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute)
                    {
                        return_value = totalMinutes;
                    }
                    else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour)
                    {
                        return_value = totalMinutes / 60;
                    }
                    else
                    {
                        return_value = totalMinutes;
                    }

                }
                else
                {
                    if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute)
                    {
                        return_value = customer.tariff.default_calculation_value;
                    }
                    else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour)
                    {
                        return_value = customer.tariff.default_calculation_value / 60;
                    }
                    else
                    {
                        return_value = customer.tariff.default_calculation_value;
                    }
                }

            }
            else // условие часовое
            {
                if (customer.tariff.condition_result_type == ConstLib.Condition_Result_Separate)
                {

                    if ((totalMinutes <= customer.tariff.condition_value) || (customer.tariff.is_there_condition == false)) // Если время больше чем по условию
                    {
                        if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute) // если тип вычисления минутный
                        {
                            return_value = totalMinutes;
                        }
                        else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // если тип вычисления часовой
                        {
                            return_value = totalMinutes / 60;
                        }
                        else // стоп-чек
                        {
                            return_value = totalMinutes;
                        }

                    }
                    else
                    {
                        if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute) // если тип вычисления минутный
                        {
                            return_value = customer.tariff.default_calculation_value;
                        }
                        else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // если тип вычисления часовой
                        {
                            return_value = customer.tariff.default_calculation_value / 60;
                        }
                        else // стоп-чек
                        {
                            return_value = customer.tariff.default_calculation_value;
                        }
                    }
                }

            }
            first_time_value = return_value;
            RaisePropertyChanged(() => first_time_value);
            */
        }


    }
}
