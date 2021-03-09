using Console_prototype;
using Console_prototype.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Media.TextFormatting;

namespace WpfProject.Model.Tariff_Model
{
    static class TariffMethods
    {
        static public Tariff get_def_tariff()
        {
            Tariff cur = new Tariff();
            cur.name = "Тариф";
            cur.id = 1;
            cur.is_it_available_today = true;
            cur.default_calculation_type = ConstLib.Calculation_Minute;
            cur.default_calculation_value = 10;
            cur.is_there_condition = true;
            cur.condition_type = ConstLib.Condition_Minute;
            cur.condition_value = 120;
            cur.condition_result_type = ConstLib.Condition_Result_Overall;
            cur.conditional_calculation_type = ConstLib.Calculation_Stop_Check;
            cur.conditional_calculation_value = 100;

            return cur;
        }
        public static void Update(ObservableCollection<Tariff> list)
        {
            foreach (Tariff cur in list)
            {
                cur.id = cur.id + 1;
            }
        }

        public static void Save(ObservableCollection<Tariff> list)
        {
            ObservableCollection<ConvertedTariff> converted_list = new ObservableCollection<ConvertedTariff>();
            foreach (Tariff cur in list)
            {
                converted_list.Add(cur.Converted);
            }
            BinarySerialization.WriteToBinaryFile<ObservableCollection<ConvertedTariff>>("C:/Users/user/source/repos/WpfProject/WpfProject/Savefiles/TariffData.bin", converted_list);
            
        }
        public static ObservableCollection<Tariff> Load()
        {
            ObservableCollection<Tariff> list = new ObservableCollection<Tariff>();
            ObservableCollection<ConvertedTariff> converted_list = BinarySerialization.ReadFromBinaryFile<ObservableCollection<ConvertedTariff>>("C:/Users/user/source/repos/WpfProject/WpfProject/Savefiles/TariffData.bin");
            
            int i = 0;
            foreach (ConvertedTariff cur in converted_list)
            {
                i++;

                list.Add(new Tariff(cur));
            }
            Console.WriteLine("Loaded");
            return list;
        }

        public static ObservableCollection<Tariff> LoadAvailable()
        {
            ObservableCollection<Tariff> list = Load();
            ObservableCollection<Tariff> new_list = new ObservableCollection<Tariff>();
            foreach (Tariff cur in list)
            {
                if (cur.is_it_available_today is true)
                {
                    new_list.Add(cur);
                }
            }
            
            return new_list;
        }
    }
}
