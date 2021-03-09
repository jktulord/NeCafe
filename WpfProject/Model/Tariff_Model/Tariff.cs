using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfProject.Model.Tariff_Model
{
    public class Tariff : ViewModelBase
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

        private bool _is_it_available_today;
        public bool is_it_available_today
        {
            get { return _is_it_available_today; }
            set { _is_it_available_today = value; RaisePropertyChanged(() => is_it_available_today); }
        }

        // default calculation
        private string _default_calculation_type;
        public string default_calculation_type
        {
            get { return _default_calculation_type; }
            set { _default_calculation_type = value; RaisePropertyChanged(() => default_calculation_type); }
        }

        private double _default_calculation_value;
        public double default_calculation_value
        {
            get { return _default_calculation_value; }
            set { _default_calculation_value = value; RaisePropertyChanged(() => default_calculation_value); }
        }

        // condition 
        private bool _is_there_condition;
        public bool is_there_condition
        {
            get { return _is_there_condition; }
            set { _is_there_condition = value; RaisePropertyChanged(() => condition_type); }
        }

        private string _condition_type;
        public string condition_type
        {
            get { return _condition_type; }
            set { _condition_type = value; RaisePropertyChanged(() => condition_type); }
        }

        private double _condition_value;
        public double condition_value
        {
            get { return _condition_value; }
            set { _condition_value = value; RaisePropertyChanged(() => condition_value); }
        }
        
        private string _condition_result_type;
        public string condition_result_type
        {
            get { return _condition_result_type; }
            set { _condition_result_type = value; RaisePropertyChanged(() => condition_result_type); }
        }

        // conditional calculation
        private string _conditional_calculation_type;
        public string conditional_calculation_type
        {
            get { return _conditional_calculation_type; }
            set { _conditional_calculation_type = value; RaisePropertyChanged(() => conditional_calculation_type); }
        }

        private double _conditional_calculation_value;
        public double conditional_calculation_value
        {
            get { return _conditional_calculation_value; }
            set { _conditional_calculation_value = value; RaisePropertyChanged(() => conditional_calculation_value); }
        }

        public Tariff(ConvertedTariff Converted)
        {
            this.name = Converted.name;
            this.id = Converted.id;
            this.is_it_available_today = Converted.is_it_available_today;

            this.default_calculation_type = Converted.default_calculation_type;
            this.default_calculation_value = Converted.default_calculation_value;

            this.is_there_condition = Converted.is_there_condition;
            this.condition_type = Converted.condition_type;
            this.condition_value = Converted.condition_value;

            this.condition_result_type = Converted.condition_result_type;
            this.conditional_calculation_type = Converted.conditional_calculation_type;
            this.conditional_calculation_value = Converted.conditional_calculation_value;

        }

        public Tariff()
        {
        }

        public ConvertedTariff Converted
        {
            get {
                ConvertedTariff convertedTariff = new ConvertedTariff();
                convertedTariff.name = name;
                convertedTariff.id = id;
                convertedTariff.is_it_available_today = is_it_available_today;

                convertedTariff.default_calculation_type = default_calculation_type;
                convertedTariff.default_calculation_value = default_calculation_value;

                convertedTariff.is_there_condition = is_there_condition;
                convertedTariff.condition_type = condition_type;
                convertedTariff.condition_value = condition_value;

                convertedTariff.condition_result_type = condition_result_type;
                convertedTariff.conditional_calculation_type = conditional_calculation_type;
                convertedTariff.conditional_calculation_value = conditional_calculation_value;

                return convertedTariff;
                
            }
        }

    }
    [Serializable]
    public class ConvertedTariff
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

        private bool _is_it_available_today;
        public bool is_it_available_today
        {
            get { return _is_it_available_today; }
            set { _is_it_available_today = value;}
        }

        // default calculation
        private string _default_calculation_type;
        public string default_calculation_type
        {
            get { return _default_calculation_type; }
            set { _default_calculation_type = value;}
        }

        private double _default_calculation_value;
        public double default_calculation_value
        {
            get { return _default_calculation_value; }
            set { _default_calculation_value = value; }
        }

        // condition 
        private bool _is_there_condition;
        public bool is_there_condition
        {
            get { return _is_there_condition; }
            set { _is_there_condition = value;}
        }

        private string _condition_type;
        public string condition_type
        {
            get { return _condition_type; }
            set { _condition_type = value; }
        }

        private double _condition_value;
        public double condition_value
        {
            get { return _condition_value; }
            set { _condition_value = value;}
        }

        private string _condition_result_type;
        public string condition_result_type
        {
            get { return _condition_result_type; }
            set { _condition_result_type = value; }
        }

        // conditional calculation
        private string _conditional_calculation_type;
        public string conditional_calculation_type
        {
            get { return _conditional_calculation_type; }
            set { _conditional_calculation_type = value; }
        }

        private double _conditional_calculation_value;
        public double conditional_calculation_value
        {
            get { return _conditional_calculation_value; }
            set { _conditional_calculation_value = value; }
        }
    }
}
