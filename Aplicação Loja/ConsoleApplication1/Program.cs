using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Loja.Classes.Cliente cli2 = new Classes.Cliente(2))
            {
                cli2.Nome = "Wesley";
            }

            //using (Classes.Cliente cli = new Classes.Cliente())
            //{
            //    cli.Codigo = 2;
            //    cli.Nome = "Pedrinho";
            //    cli.Tipo = 2;

            //    cli.DataCadastro = new DateTime(2018, 12, 10);
            //}
            //try
            //{
            //    cli.Codigo = 1;
            //    int metadeCLiente = cli.Codigo.Metade();
            //    cli.Nome = "João".PrimeiraMaiuscula(true);
            //    cli.Tipo = 1;
            //    cli.DataCadastro = new DateTime(2018, 09, 10);
            //    cli.Dispose();
            //}
            //catch (ConsoleApplication1.Execoes.ExecaoCliente.ValidacaoException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

            //using (Classes.Cliente cli2 = new Classes.Cliente(5))
            //{
            //    cli2.Nome = "xyz";
            //}
            //Classes.Cliente cli2 = new Classes.Cliente(5);
            
            //Classes.Contato contato1 = new Classes.Contato();
            //contato1.Codigo = 1;
            //contato1.DadosContato = "555-555";
            //contato1.Tipo = "Telefone";

            //Classes.Contato contato2 = new Classes.Contato();
            //contato2.Codigo = 2;
            //contato2.DadosContato = "wesley@gmail.com";
            //contato2.Tipo = "E-mail";

            //cli.Contatos = new List<Classes.Contato>();
            //cli.Contatos.Add(contato1);
            //cli.Contatos.Add(contato2);
            
            ////cli.Gravar();

            //foreach (Classes.Contato count in cli.Contatos)
            //{
            //    Console.WriteLine(count.DadosContato);
            //}

            //cli.Contatos.ForEach(cont => cont.Gravar());

            //Classes.Contato contatoBuscado = cli.Contatos.FirstOrDefault(x => x.Tipo == "Telefone");
            ////Console.WriteLine(contatoBuscado.DadosContato);

            //Console.ReadLine();

        }
    }
}