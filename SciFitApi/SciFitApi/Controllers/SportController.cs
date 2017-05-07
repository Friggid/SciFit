using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using SciFitApi.Models;
using System;

namespace SciFitApi.Controllers
{
    public class SportController : ApiController
    {
        private readonly SciFitApiContext _db = new SciFitApiContext();

        //GET api/SportCollection
        [ResponseType(typeof(SportPlanModel))]
        public IHttpActionResult GetSport(int id, int? var)
        {

            var sportPlan = (from x in _db.SportCollection
                             where x.UserId == id
                             select x).SingleOrDefault();

            if (sportPlan == null)
            {
                return NotFound();
            }
            var allSports = (from x in _db.Sport
                             where x.SportPlanId == sportPlan.Id
                             select x).ToList();

            sportPlan.Sport = allSports;
            return Ok(sportPlan);
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
                             where x.SportPlanId == sportPlan.Id && x.Done == 0 && x.StartDate <= DateTime.Now && x.EndDate > DateTime.Now
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
                             where x.SportPlanId == sportPlan.Id && x.Done == 0 && x.StartDate <= DateTime.Now && x.EndDate > DateTime.Now
                             select x).ToList();

            sportPlan.Sport = allSports;

            return Ok(sportPlan);
        }

        //first create
        //POST api/SportCollection
        [ResponseType(typeof(SportPlanModel))]
        public IHttpActionResult PostSport(int id, int? level)
        {
            if (level == null)
            {
                return BadRequest(ModelState);
            }
            var highestLvl = (from x in _db.SportTemplate
                             select x).Max(x => x.Level);

            List<SportTemplateModel> sportPlan;
            List<SportModel> sportMapped;
            List<SportModel> fullList = new List<SportModel>();
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            if (highestLvl != null)
            {
                for(int i = 1; i < highestLvl+1; i++)
                {
                    sportPlan = (from x in _db.SportTemplate
                                 where x.Level == i
                                 select x).ToList();
                    sportMapped = Mapper.Map<List<SportModel>>(sportPlan);
                    foreach (var item in sportMapped)
                    {
                        item.StartDate = start;
                        item.EndDate = start.AddDays(1);
                        fullList.Add(item);
                    }
                    start = start.AddDays(1);
                }
            }
            
            var sportCollection = new SportPlanModel
            {
                UserId = id,
                Sport = fullList
            };

            _db.Entry(sportCollection).State = EntityState.Added;

            _db.SaveChanges();

            var list = (from x in fullList
                        where x.StartDate <= DateTime.Now && x.EndDate > DateTime.Now
                        select x).ToList();

            sportCollection.Sport = list;
            return Ok(sportCollection);
        }

        public IHttpActionResult DeleteSport(int id)
        {
            var sportPlan = (from x in _db.SportCollection
                             where x.UserId == id
                             select x).SingleOrDefault();

            if (sportPlan == null)
            {
                return NotFound();
            }
           
            _db.Entry(sportPlan).State = EntityState.Deleted;

            _db.SaveChanges();
            return Ok();
        }
    }
}