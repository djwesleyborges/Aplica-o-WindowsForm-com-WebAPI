using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Classes
{
    public partial class Contato
    {
        private bool _isNew;  // Propriedade Interna da Classe
        [Browsable(false)] // Ocultando o Widget _isNew

        public bool IsNew
        {
            get { return _isNew; }
        }

        private bool _isModified; // Propriedade Interna da Classe
        [Browsable(false)] // Ocultando o Widget _isModified
        public bool IsModified
        {
            get { return _isModified; }
        }

        private int _codigo; // Propriedade Interna da Classe
        [DisplayName("Código")] // Nome que vai aparecer no widget
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
        private string _dadosContato;
        
        public string DadosContato
        {
            get { return _dadosContato; }
            set { _dadosContato = value; this._isModified = true; }
        }
        
        //public int? Tipo { get; set; }
        private int? _tipo; // Propriedade Interna da Classe
        public int? Tipo
        {
            get { return _tipo; }
            set { _tipo = value; this._isModified = true; }
        }

        private int _cliente;


        [Browsable(false)] // Ocultando o Widget
        public int Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
    }
}
