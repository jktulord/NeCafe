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


        // Скидки
        private bool _if_discount_is_complementary;
        public bool if_discount_is_complementary
        {
            get { return _if_discount_is_complementary; }
            set { _if_discount_is_complementary = value; RaisePropertyChanged(() => if_discount_is_complementary); }
        }

        private bool _if_first_discount_applied;
        public bool if_first_discount_applied
        {
            get { return _if_first_discount_applied; }
            set { _if_first_discount_applied = value; RaisePropertyChanged(() => if_first_discount_applied); }
        }

        private bool _if_second_discount_applied;
        public bool if_second_discount_applied
        {
            get { return _if_second_discount_applied; }
            set { _if_second_discount_applied = value; RaisePropertyChanged(() => if_second_discount_applied); }
        }

        private bool _if_third_discount_applied;
        public bool if_third_discount_applied
        {
            get { return _if_third_discount_applied; }
            set { _if_third_discount_applied = value; RaisePropertyChanged(() => if_third_discount_applied); }
        }

        private double _discount_value;
        public double discount_value
        {
            get { return _discount_value; }
            set { _discount_value = value; RaisePropertyChanged(() => discount_value); }
        }

        private double _discount_benefit_value;
        public double discount_benefit_value
        {
            get { return _discount_benefit_value; }
            set { _discount_benefit_value = value; RaisePropertyChanged(() => discount_benefit_value); }
        }


        private double _sum_value_without_discount;
        public double sum_value_without_discount
        {
            get { return _sum_value_without_discount; }
            set { _sum_value_without_discount = value; RaisePropertyChanged(() => sum_value_without_discount); }
        }

        private double _sum_value;
        public double sum_value
        {
            get { return _sum_value; }
            set { _sum_value = value; RaisePropertyChanged(() => sum_value); }
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
                    first_cost_value = first_time_value * customer.tariff.default_calculation_value;
                }
                else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    first_time_value = condition_value;
                    first_cost_value = Math.Ceiling(first_time_value) * customer.tariff.default_calculation_value;
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
                    second_cost_value = second_time_value * customer.tariff.conditional_calculation_value;
                }
                else
                {
                    second_time_value = totalMinutes - first_time_value;
                    second_cost_value = customer.tariff.conditional_calculation_value;
                }
            }
            first_cost_value = Math.Round(first_cost_value, 2);
            first_time_value = Math.Round(first_time_value, 2);
            second_cost_value = Math.Round(second_cost_value, 2);
            second_time_value = Math.Round(second_time_value, 2);
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
                    first_cost_value = first_time_value * customer.tariff.default_calculation_value;
                }
                else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    first_time_value = totalMinutes / 60;
                    first_cost_value = Math.Ceiling(first_time_value) * customer.tariff.default_calculation_value;
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
                    second_cost_value = second_time_value * customer.tariff.conditional_calculation_value;
                }
                else if (customer.tariff.conditional_calculation_type == ConstLib.Calculation_Hour) // часовое
                {
                    second_time_value = totalMinutes / 60;
                    second_cost_value = Math.Ceiling(second_time_value) * customer.tariff.conditional_calculation_value;
                }
                else // стоп-чек
                {
                    second_time_value = totalMinutes;
                    second_cost_value = customer.tariff.conditional_calculation_value;
                }
            }
            first_cost_value = Math.Round(first_cost_value, 2);
            first_time_value = Math.Round(first_time_value, 2);
            second_cost_value = Math.Round(second_cost_value, 2);
            second_time_value = Math.Round(second_time_value, 2);
            RaisePropertyChanged(() => first_time_value);
            RaisePropertyChanged(() => first_cost_value);
            RaisePropertyChanged(() => second_time_value);
            RaisePropertyChanged(() => second_cost_value);
        }
        public void calculate_values_without_condition(double totalMinutes)
        {
            double condition_value;
            first_cost_value = 0;
            first_time_value = 0;
            second_cost_value = 0;
            second_time_value = 0;

            if (customer.tariff.default_calculation_type == ConstLib.Calculation_Minute) // минутное вычисление
            {
                first_time_value = totalMinutes;
                first_cost_value = first_time_value * customer.tariff.default_calculation_value;
            }
            else if (customer.tariff.default_calculation_type == ConstLib.Calculation_Hour) // часовое
            {
                first_time_value = totalMinutes / 60;
                first_cost_value = Math.Ceiling(first_time_value) * customer.tariff.default_calculation_value;
            }
            else // стоп-чек
            {
                first_time_value = totalMinutes;
                first_cost_value = customer.tariff.default_calculation_value;
            }
            first_cost_value = Math.Round(first_cost_value, 2);
            first_time_value = Math.Round(first_time_value, 2);
            second_cost_value = Math.Round(second_cost_value, 2);
            second_time_value = Math.Round(second_time_value, 2);
            RaisePropertyChanged(() => first_time_value);
            RaisePropertyChanged(() => first_cost_value);
            RaisePropertyChanged(() => second_time_value);
            RaisePropertyChanged(() => second_cost_value);
        }
        public void calculate_disconts_and_sum(double totalMinutes)
        {
            discount_value = 0;

            if (if_discount_is_complementary)
            {
                if (if_first_discount_applied) { discount_value += 10; }
                if (if_second_discount_applied) { discount_value += 5; }
                if (if_third_discount_applied) { discount_value += 5; }
            }
            else
            {
                if (if_first_discount_applied) { discount_value = 10; }
                else if (if_second_discount_applied) { discount_value = 5; }
                else if (if_third_discount_applied) { discount_value = 5; }
                else { discount_value = 0; };
            }

            sum_value_without_discount = first_cost_value + second_cost_value;
            discount_benefit_value = sum_value_without_discount * (discount_value / 100);
            sum_value = sum_value_without_discount - discount_benefit_value;

            sum_value_without_discount = Math.Round(sum_value_without_discount, 2);
            discount_benefit_value = Math.Round(discount_benefit_value, 2);
            sum_value = Math.Round(sum_value, 2);

            RaisePropertyChanged(() => discount_value);
            RaisePropertyChanged(() => sum_value_without_discount);
            RaisePropertyChanged(() => discount_benefit_value);
            RaisePropertyChanged(() => sum_value);

        }
        public void execute()
        {
            double totalMinutes = Math.Round(customer.elapsed_time.TotalMinutes, 2);
            double return_value = totalMinutes;

            if (customer.tariff.is_there_condition) // если есть условие
            {
                if (customer.tariff.condition_result_type == ConstLib.Condition_Result_Separate) // если условие сепарирование
                {
                    calculate_separate_values(totalMinutes);
                }
                else // если условие заменяющее
                {
                    calculate_overall_values(totalMinutes);
                }
            }
            else // если условия нет
            {
                calculate_values_without_condition(totalMinutes);
            }

            calculate_disconts_and_sum(totalMinutes);
        }

    }
}
