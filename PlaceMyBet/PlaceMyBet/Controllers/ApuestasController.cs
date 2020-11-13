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
            List<ApuestaUsuario> apuestas = repo.RetrieveEmail(Email);
            return apuestas;
        }

        // GET: api/Apuestas?tipoMercado=Mercado

        public IEnumerable<ApuestaMercado> GetApuestaMercado(double tipoMercado)
        {
            var repo = new ApuestaRepository();
            List<ApuestaMercado> apuestas = repo.RetrieveApuestaMercado(tipoMercado);
            return apuestas;
        }

        // Pregunta 2 
        // GET: api/Apuestas?val1=cuota&val2=cuota

            public IEnumerable<ApuestaExamen> GetApuestaExamen(double cuota)
        {
            var repo = new ApuestaRepository();
            List<ApuestaExamen> apuestas = repo.RetrieveApuestaExamen(cuota);
            return apuestas;
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
