using Loja.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        // GET api/clientes
        public IHttpActionResult Get()
        //public IEnumerable<Cliente> Get()
        {
            try
            {
                return Ok(Cliente.Todos());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/clientes/5
        public IHttpActionResult Get(int id)
        {
            Cliente _return = new Cliente(id);
            if(_return.Codigo == 0)
            {
                _return = null;
                return NotFound();
            }
            else
                return Ok (_return); // Retorna null quando um cliente não existe
        }

        // POST api/clientes
        [HttpPost]
        [HttpPut]
        public IHttpActionResult Post([FromBody]Cliente value) // Recebe um Objeto do tipo Cliente como parametro
        {
            try
            {
                value.Insert();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Ocorreu erro"));
            }

            return Ok();
        }

        // PUT api/clientes/5
        public IHttpActionResult Put(int id, [FromBody]Cliente value) // Recebe um Objeto do tipo Cliente como parametro
        {
            Cliente cli = new Cliente(id); // Instancia o Objeto passado pelo parametro
            cli.Codigo = value.Codigo;     // Atualiza os valores
            cli.Nome = value.Nome;
            cli.DataCadastro = value.DataCadastro;
            cli.Tipo = value.Tipo;

            try
            {
                cli.Update(); // Tenta fazer a inserção.
            }
            catch (Exception)
            {
                return InternalServerError(new Exception ("Ororreu erro"));
            }

            return Ok();
        }

        // DELETE api/clientes/5
        public IHttpActionResult Delete(int id) // Recebe um Objeto do tipo Cliente como parametro
        {
            Cliente cli = new Cliente(id);
            try
            {
                cli.Apagar();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
    }
}
