using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ConsumindoWebAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40649/api/clientes");
                var resposta = await client.GetAsync("");
                string dados = await resposta.Content.ReadAsStringAsync();

                List<Cliente> clientes = new JavaScriptSerializer().Deserialize<List<Cliente>>(dados);
                dataGridView1.DataSource = clientes; // Jogando os dados na Grid

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40649/api/clientes");
                
                Cliente cli = new Cliente();
                cli.Codigo = Convert.ToInt32(textBox1.Text);
                cli.Nome = textBox2.Text;
                cli.DataCadastro = dateTimePicker1.Value;
                cli.Tipo = Convert.ToInt32(textBox3.Text);

                var resposta = await client.PostAsJsonAsync("", cli);
                string retorno = await resposta.Content.ReadAsStringAsync();
                if (resposta.IsSuccessStatusCode)
                    MessageBox.Show("Cliente Inserido");
                else
                    MessageBox.Show(retorno);
            }


        }
    }
}
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public DateTime DataCadastro { get; set; }
        public object Contatos { get; set; }
    }