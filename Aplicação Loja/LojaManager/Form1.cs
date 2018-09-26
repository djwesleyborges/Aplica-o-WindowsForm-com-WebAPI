using Loja.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaManager
{
    public partial class Form1 : Form
    {
        BindingSource dados = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dados.DataSource = new BindingList<Cliente>(Cliente.Todos());
            dataGridView1.DataSource = dados;

            // dados.DataSource = Cliente.Todos(); // Pegando os dados do cliente
            // dataGridView1.DataSource = dados; // Colocando os dados na tela

            // Caixa de texto vai exibir o dados do obj"dados" 
            txtCodigo.DataBindings.Add("Text", dados, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", dados, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTipo.DataBindings.Add("Text", dados, "Tipo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataCadastro.DataBindings.Add("Text", dados, "DataCadastro", true, DataSourceUpdateMode.OnPropertyChanged);

            txtCodigoContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged); // Editando as Propriedades na tela
            txtDadosContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "DadosContato", true, DataSourceUpdateMode.OnPropertyChanged); // Editando as Propriedades na tela
            txtTipoContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Tipo", true, DataSourceUpdateMode.OnPropertyChanged); // Editando as Propriedades na tela
            //txtClienteContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Cliente", true, DataSourceUpdateMode.OnPropertyChanged); // Editando as Propriedades na tela


            dados.CurrentChanged += dados_CurrentChanged;
            dgvContatos.DataSource = ((Cliente)dados.Current).Contatos;
        }

        private void dados_CurrentChanged(object sender, EventArgs e)
        {
            dgvContatos.DataSource = ((Cliente)dados.Current).Contatos;
        }

        // Evento do botão Gravar
        private void button1_Click(object sender, EventArgs e)
        {
            // A linha que estiver, grave.
            if (MessageBox.Show("Deseja salvar alterações ?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ((Cliente)dados.Current).Gravar();

                ((Cliente)dados.Current).Contatos.ForEach(x=> x.Gravar() );
            }
            
        }

        // Evento do botão Novo
        private void button2_Click(object sender, EventArgs e)
        {
            // Adicionando novo cliente
            dados.Add(new Cliente());
            dados.MoveLast(); // Adiciona o cliente e mova para a ultima linha
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente apagar este cliente ?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ((Cliente)dados.Current).Apagar(); // Apagando do banco de dados
                dados.RemoveCurrent(); // Apagando da fonte de dados do objeto
            }
            
        }
        
    }
}
