using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            /*
            return new string[] { "value1", "value2" };
            */
            var repo = new ApuestaRepository();
            /*
            List<Apuesta> apuesta = repo.Retrieve();
            */
            List<ApuestaDTO> apuesta = repo.RetrieveDTO();
            return apuesta;
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            /*
            var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve();
            return a;
            */
            return null;
        }

        // GET: api/Apuestas?idUsuario=Email

        public IEnumerable<ApuestaUsuario> GetApuestaUsuarios(string Email)
        {
            var repo = new ApuestaRepository();
            List<ApuestaUsuario> apuesta = repo.RetrieveEmail(Email);
            return apuesta;
        }

        // GET: api/Apuestas?tipoMercado=Mercado

        public IEnumerable<ApuestaMercado> GetApuestaMercado(double tipoMercado)
        {
            var repo = new ApuestaRepository();
            List<ApuestaMercado> apuesta = repo.RetrieveApuestaMercado(tipoMercado);
            return apuesta;
        }

        // POST: api/Apuestas
        public void Post([FromBody] Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
