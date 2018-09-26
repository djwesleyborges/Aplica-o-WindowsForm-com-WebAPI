using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Classes
{
    public partial class Cliente
    {
        
        private bool _isNew;
        [Browsable(false)] // Ocultando o Widget _isNew

        public bool IsNew
        {
            get { return _isNew; }
        }

        private bool _isModified;
        [Browsable(false)] // Ocultando o Widget _isModified
        public bool IsModified
        {
            get { return _isModified; }
        }
        
        
        //public int Codigo { get; set; }
        private int _codigo;
        [DisplayName("Código")]
        public int Codigo
        {
            get 
            { 
                return _codigo; 
            }
            set 
            {
                if (value < 0)
                {
                    throw new Loja.Execoes.ExecaoCliente.ValidacaoException("O código do cliente não pode ser negativo");
                    _codigo = 0;
                }
                _codigo = value;
                this._isModified = true;
            }
        }

        //public string Nome { get; set; }
        private string _nome;
        [DisplayName("Nome do Cliente")]
        public string Nome
        {
            get { return _nome; }
            set {
                if (value.Length >= 3)
                {
                    // throw new Loja.Execoes.ExecaoCliente.ValidacaoException("O nome do cliente presica ter no minimo 4 caracteres.");
                    //}
                    _nome = value;
                    this._isModified = true;
                }
                }
        }

        //public int? Tipo { get; set; }
        private int? _tipo;
        public int? Tipo 
        {
            get { return _tipo; }
            set { _tipo = value; this._isModified = true; }
        }

        //public DateTime? DataCadastro { get; set; }
        private DateTime? _dataCadastro;
        [DisplayName("Data do Cadastro")]
        public DateTime? DataCadastro 
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; this._isModified = true; }
        }
        public List<Contato> Contatos { get; set; } // Colocando a Classe Contato como propriedade da Classe Cliente
    }
}