using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace PRACTICA_API
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Form1 programa = new Form1();
            await GetTodoItems();
        }

        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(" https://jsonplaceholder.typicode.com/todos");
            Console.WriteLine(response);
            List<Todo> porhacer = JsonConvert.DeserializeObject<List<Todo>>(response);
            foreach (var item in porhacer)
            {
                string parseduserID = Convert.ToString(item.userID);
                string parsedid = Convert.ToString(item.id);
                string parsedtitle = item.title;
                string parsedcompleted = Convert.ToString(item.completed);
                string[] row = { parseduserID, parsedid, parsedtitle, parsedcompleted };
                var lisViewItems = new ListViewItem(row);
                listView1.Items.Add(lisViewItems);
            }
        }
    }

    class Todo
    {
        public int userID { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }
}
