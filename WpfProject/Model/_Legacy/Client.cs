using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Console_prototype.Utils;

namespace Console_prototype
{
    [Serializable]
    public class Client
    {
        public string name { get; set; }
        public int id { get; set; }
        public DateTime start_time { get; set; }
        
        [NonSerialized]
        public TimeSpan elapsed_time;

        public Client(string name, int id, DateTime start_time)
        {
            this.name = name;
            this.id = id;
            this.start_time = start_time;
        }
        public async Task Update()
        {
            await Task.Run(() =>
            {
                elapsed_time = DateTime.Now - start_time;
            });
        }
        public string InfoLine()
        {
            return "" + Convert.ToString(id) + " " + name + " - " + elapsed_time; 
        }
        public string getLine()
        {
            return name + " " + Convert.ToString(id) + " " + start_time;
        }
    }

}
