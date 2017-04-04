using System.Collections.Generic;

namespace SciFitApi.Models
{
    public class SportPlanModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<SportModel> Sport { get; set; }
    }
}