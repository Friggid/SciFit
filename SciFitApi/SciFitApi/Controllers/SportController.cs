using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using SciFitApi.Models;

namespace SciFitApi.Controllers
{
    public class SportController : ApiController
    {
        private readonly SciFitApiContext _db = new SciFitApiContext();

        //GET api/SportCollection
        public IQueryable<SportPlanModel> GetSport()
        {
            return _db.SportCollection;
        }

        //GET api/SportCollection/5
        [ResponseType(typeof(SportPlanModel))]
        public IHttpActionResult GetSport(int id)
        {
            var sportPlan = (from x in _db.SportCollection
                             where x.UserId == id
                             select x).SingleOrDefault();

            if (sportPlan == null)
            {
                return NotFound();
            }
            var allSports = (from x in _db.Sport
                             where x.SportPlanId == sportPlan.Id && x.Done == 0
                             select x).ToList();

            sportPlan.Sport = allSports;
            return Ok(sportPlan);
        }

        //PUT api/SportCollection/5
        public IHttpActionResult PutSport(int id, int sportId)
        {
            var sportPlan = (from x in _db.SportCollection
                            where x.UserId == id
                            select x).SingleOrDefault();
            //_db.SportCollection.Find(id);
            if (sportPlan == null)
            {
                return BadRequest();
            }

            var sport = _db.Sport.Find(sportId);

            if (sport == null)
            {
                return BadRequest();
            }

            sport.Done = 1;

            _db.Entry(sport).State = EntityState.Modified;
            _db.SaveChanges();

            var allSports = (from x in _db.Sport
                            where x.SportPlanId == sportPlan.Id && x.Done == 0
                            select x).ToList();

            sportPlan.Sport = allSports;

            return Ok(sportPlan);
        }

        //POST api/SportCollection
        [ResponseType(typeof(SportPlanModel))]
        public IHttpActionResult PostSport(int id, int? level)
        {
            if (level == null)
            {
                return BadRequest(ModelState);
            }
            var sportPlan = (from x in _db.SportTemplate
                             where x.Level == level
                             select x).ToList();

            var sportMapped = Mapper.Map<List<SportModel>>(sportPlan);

            var sportCollection = new SportPlanModel
            {
                UserId = id,
                Sport = sportMapped
            };

            _db.Entry(sportCollection).State = EntityState.Added;

            _db.SaveChanges();

            return Ok(sportCollection);
        }
    }
}