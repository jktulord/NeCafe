using Console_prototype.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace WpfProject.Model.User_Model
{
    class UserMethods
    {
        public static void Save(ObservableCollection<User> list)
        {
            ObservableCollection<ConvertedUser> converted_list = new ObservableCollection<ConvertedUser>();
            foreach (User cur in list)
            {
                converted_list.Add(cur.converted);
            }
            String path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.IndexOf("bin\\Debug")) + "/Savefiles/TariffData.bin";
            BinarySerialization.WriteToBinaryFile<ObservableCollection<ConvertedUser>>(path, converted_list);

        }
        public static ObservableCollection<User> Load()
        {
            ObservableCollection<User> list = new ObservableCollection<User>();
            String path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.IndexOf("bin\\Debug")) + "/Savefiles/TariffData.bin";
            ObservableCollection<ConvertedUser> converted_list = BinarySerialization.ReadFromBinaryFile<ObservableCollection<ConvertedUser>>(path);

            int i = 0;
            foreach (ConvertedUser cur in converted_list)
            {
                i++;

                list.Add(new User(cur));
            }
            Console.WriteLine("Loaded");
            return list;
        }
    }
}
