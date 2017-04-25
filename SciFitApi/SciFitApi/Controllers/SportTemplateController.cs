using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.Description;
using SciFitApi.Models;

namespace SciFitApi.Controllers
{
    public class SportTemplateController : ApiController
    {
        private readonly SciFitApiContext _db = new SciFitApiContext();

        //GET api/SportTemplate
        public IQueryable<SportTemplateModel> GetSport()
        {
            return _db.SportTemplate;
        }

        //GET api/SportTemplate/5
        [ResponseType(typeof(SportTemplateModel))]
        public IHttpActionResult GetSportTemplate(int id)
        {
            var sportTemplate = (from x in _db.SportTemplate
                             where x.Id == id
                             select x).SingleOrDefault();

            if (sportTemplate == null)
            {
                return NotFound();
            }
            return Ok(sportTemplate);
        }

        //PUT api/SportTemplate/5
        public IHttpActionResult PutSportTemplate(SportTemplateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(model);
        }

        //POST api/SportTemplate
        [ResponseType(typeof(SportTemplateModel))]
        public IHttpActionResult PostSportTemplate(SportTemplateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            _db.Entry(model).State = EntityState.Added;

            _db.SaveChanges();

            return Ok(model);
        }

        public IHttpActionResult DeleteSport(int id)
        {
            var sportTemplate = (from x in _db.SportTemplate
                             where x.Id == id
                             select x).SingleOrDefault();

            if (sportTemplate == null)
            {
                return NotFound();
            }

            _db.Entry(sportTemplate).State = EntityState.Deleted;

            _db.SaveChanges();
            return Ok();
        }
    }
}