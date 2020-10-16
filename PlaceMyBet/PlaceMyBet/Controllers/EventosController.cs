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
            List<EventoDTO> evento = repo.RetrieveDTO();
            return evento;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            /*
            var repo = new EventoRepository();
            Evento e = repo.Retrieve();
            return e;
            */
            return null;
        }

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
