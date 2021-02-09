using System;
using System.Collections.Generic;
using System.Text;

namespace WpfProject.Model
{
    public static class ConstLib
    {
        // Visibility
        public const string Visible = "Visible";
        public const string Hidden = "Hidden";

        // Tariff Type
        enum Tariff_Type
        {
            Minute,
            Hour,
            Stop_Check
        }

        public const string Tariff_Minute = "Минуту";
        public const string Tariff_Hour = "Час";
        public const string Tariff_Stop_Check = "Стоп-Чек";

        // Tariff Condition 
        public enum Tariff_Condition
        {
            Minute,
            Hour
        }

        public const string Condition_Minute = "Минут";
        public const string Condition_Hour = "Часов";

        // Condition result type
        public enum Condition_Result
        {
            Overall,
            Separate
        }
        public const string Condition_Result_Overall = "Общее время вычисляется по";
        public const string Condition_Result_Separate = "Следующее время считается по";

    }
}
