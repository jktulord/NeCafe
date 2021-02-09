using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using WpfProject.Model;
using WpfProject.Model.Tariff_Model;

namespace WpfProject.ViewModel.Pages
{
    class TariffPageVM : ViewModelBase
    {
        private Tariff _Cur_Tariff;
        public Tariff Cur_Tariff
        {
            get { return _Cur_Tariff; }
            set
            {
                _Cur_Tariff = value;
                RaisePropertyChanged(() => Cur_Tariff);
            }
        }

        public Tariff get_def_tariff()
        {
            Tariff cur = new Tariff();
            cur.name = "Тариф";
            cur.id = 1;
            cur.default_calculation_type = ConstLib.Tariff_Minute;
            cur.default_calculation_value = 10;
            cur.is_there_condition = true;
            cur.condition_type = ConstLib.Condition_Minute;
            cur.condition_value = 120;
            cur.condition_result_type = ConstLib.Condition_Result_Overall;
            cur.conditional_calculation_type = ConstLib.Tariff_Stop_Check;
            cur.conditional_calculation_value = 100;
           
            return cur;
        }

        public TariffPageVM()
        {
            Cur_Tariff = get_def_tariff();
           
        }
    }
}
