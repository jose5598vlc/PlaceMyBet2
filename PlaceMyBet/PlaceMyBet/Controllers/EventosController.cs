using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventoDTO> Get()
        {
            
            var repo = new EventoRepository();
            /*
            List<Evento> evento = repo.Retrieve();
            */
            List<EventoDTO> eventos = repo.RetrieveDTO();
            return eventos;
        }

        //Ejercicio 1
        // GET: api/Eventos/5
        public IEnumerable<EventoExamen> GetEventoExamen(int idEvento)
        {
            
            var repo = new EventoRepository();
            List<EventoExamen> eventos = repo.RetrieveEventoExamen(idEvento);
            return eventos;
            
        }

        // GET: api/Eventos/idEvento=idEvento
        /*
        public IEnumerable<EventoExamen> GetEventoExamen(int idEvento)
        {
            var repo = new EventoRepository();
            List<EventoExamen> eventos = repo.RetrieveEventoExamen(idEvento);
            return eventos;
        }
        */

        // POST: api/Eventos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
