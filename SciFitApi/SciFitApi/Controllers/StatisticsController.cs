using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;
using SciFitApi.Models;

namespace SciFitApi.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly SciFitApiContext _db = new SciFitApiContext();

        //GET api/Statistics
        public IQueryable<StatisticsModel> GetStatistics()
        {
            return _db.Statistics;
        }

        //GET api/Statistics/5
        [ResponseType(typeof(StatisticsModel))]
        public IHttpActionResult GetStatistics(int id)
        {
            var statistics = (from x in _db.Statistics
                                 where x.Id == id
                                 select x).SingleOrDefault();

            if (statistics == null)
            {
                return NotFound();
            }
            return Ok(statistics);
        }

        //PUT api/Statistics
        public IHttpActionResult PutStatistics(StatisticsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(model);
        }

        //POST api/Statistics
        [ResponseType(typeof(StatisticsModel))]
        public IHttpActionResult PostStatistics(StatisticsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Added;

            _db.SaveChanges();

            return Ok(model);
        }

        //DELETE api/Statistics/1
        public IHttpActionResult DeleteStatistics(int id)
        {
            var statistics = (from x in _db.Statistics
                                 where x.Id == id
                                 select x).SingleOrDefault();

            if (statistics == null)
            {
                return NotFound();
            }

            _db.Entry(statistics).State = EntityState.Deleted;

            _db.SaveChanges();
            return Ok();
        }
    }
}