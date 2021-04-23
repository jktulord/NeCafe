using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfProject.Model
{
    public static class ConstLib
    {
        // Visibility 
        public const string Visible = "Visible";
        public const string Hidden = "Hidden";

        // Condition result type
        public const string Black = "Black";
        public const string White = "White";

        // Tariff States


        // Tariff Type
        public const string Calculation_Minute = "Минуту";
        public const string Calculation_Hour = "Час";
        public const string Calculation_Stop_Check = "Стоп-Чек";

        // Tariff Condition 
        public const string Condition_Minute = "Минут";
        public const string Condition_Hour = "Часов";

        // Condition result type


        // Condition result type
        public const string Manager = "Управляющий";
        public const string Admin = "Админ";
        public const string Kassier = "Кассир";


        public const string Condition_Result_Overall = "Общее время вычисляется по";
        public const string Condition_Result_Separate = "Следующее время считается по";

        public const string Show_Type_Simple = "Упрощенный";
        public const string Show_Type_Full = "Полный";

        public class CalculationTypes : ObservableCollection<string>
        {
            public CalculationTypes()
            {
                Add(Calculation_Minute);
                Add(Calculation_Hour);
                Add(Calculation_Stop_Check);
            }
        }
        public class ConditionTypes : ObservableCollection<string>
        {
            public ConditionTypes()
            {
                Add(Condition_Minute);
                Add(Condition_Hour);
            }
        }
        public class ConditionResultTypes : ObservableCollection<string>
        {
            public ConditionResultTypes()
            {
                Add(Condition_Result_Overall);
                Add(Condition_Result_Separate);
            }
        }
        public class ShowTypes : ObservableCollection<string>
        {
            public ShowTypes()  
            {
                Add(Show_Type_Simple);
                Add(Show_Type_Full);
            }
        }
        public class UserTypes : ObservableCollection<string>
        {
            public UserTypes()
            {
                Add(Manager);
                Add(Admin);
                Add(Kassier);
            }
        }

    }
}
