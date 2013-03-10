using System.Collections.Generic;
using System.Web.Http;
using Longsor.Data;
using Longsor.Data.Contracts;
using Longsor.Model;

namespace Longsor.Api.Controllers
{
    public class AvalancheController : ApiControllerBase
    {
        protected IAvalanchesRepository Repo;

        public AvalancheController()
        {
            Repo = new AvalanchesRepository();
        }

        public AvalancheController(ILongsorUow uow)
        {
            Uow = uow;
        }

        // GET api/avalanche
        public IEnumerable<Avalanche> Get()
        {
            return Repo.GetAll();
            //return Uow.Avalanches.GetAll().OrderBy(a => a.Id);
        }

        // GET api/avalanche/5
        public Avalanche Get(int id)
        {
            return Repo.GetById(id);
        }

        // POST api/avalanche
        public void Post([FromBody]Avalanche value)
        {
            Repo.Add(value);
        }

        // PUT api/avalanche/5
        public void Put(int id, [FromBody]Avalanche value)
        {
            Repo.Update(value);
        }

        // DELETE api/avalanche/5
        public void Delete(int id)
        {
            Repo.Delete(id);
        }
    }
}
