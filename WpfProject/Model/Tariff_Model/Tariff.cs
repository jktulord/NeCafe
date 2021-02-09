using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfProject.Model.Tariff_Model
{
    class Tariff : ViewModelBase
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
            set { _default_calculation_value = value; RaisePropertyChanged(() => _default_calculation_value); }
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
            set { _conditional_calculation_value = value; RaisePropertyChanged(() => _conditional_calculation_value); }
        }
    }
}
