using Console_prototype.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_prototype.classes
{
    public class Commands
    {

        public List<Client> clients = new List<Client>();


        public async void Task_Update_Init() /* Метод инициализации обновления времени */
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Thread.Sleep(900);
                    foreach (Client cur in clients)
                    {
                        await cur.Update();
                    }
                }
            });
        }

        public async void Add_Client(string name) /* Метод добавления клиента */
        {
            await Task.Run(() =>
            {
                Client new_client = new Client(name, 1, DateTime.Now);
                clients.Add(new_client);
                Console.WriteLine("Клиент создан");
            });
        }

        public async void SaveToJson()
        {
            await Task.Run(() =>
            {
                BinarySerialization.WriteToBinaryFile<List<Client>>("C:/Users/user/source/repos/Console_prototype/Console_prototype/Data.bin", clients);
                Console.WriteLine("Saved");
            });
        }
        public async void LoadFromJson()
        {
            await Task.Run(() =>
            {
                clients = BinarySerialization.ReadFromBinaryFile<List<Client>>("C:/Users/user/source/repos/Console_prototype/Console_prototype/Data.bin");
                Console.WriteLine("Loaded");
            });
        }


        /*
        public async void SaveToJson()
        {
            await Task.Run(() =>
            {
                string data = "";
                foreach (Client cur in list)
                {
                    data += cur.getLine()+";";
                }
                System.IO.File.WriteAllText(@"C:\Users\user\source\repos\Console_prototype\Console_prototype\Data.txt", data);
                Console.WriteLine(data);
            });
        }

        public async void LoadFromJson()
        {
            await Task.Run(() =>
            {
                string text = System.IO.File.ReadAllText(@"C:\Users\user\source\repos\Console_prototype\Console_prototype\Data.txt");
                
                string[] words = text.Split(new char[] { ';' });
                List<Client> temp_list = new List<Client>();
                
                foreach (string cur in words)
                {
                    Console.WriteLine(cur);     
                    string[] s_cur = cur.Split(new char[] { ' ' });
                    temp_list.Add(new Client(s_cur[0], Convert.ToInt32(s_cur[1]), Convert.ToDateTime(s_cur[2])));
                }
                list = temp_list;
            });
        }
        */
        public async void PrintList()
        {
            await Task.Run(() =>
            {
                foreach (Client cur in clients)
                {
                    Console.WriteLine("№" + cur.InfoLine());
                }

            });
        }
    }
}
