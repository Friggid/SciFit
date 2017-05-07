using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace SciFitApi.Models
{
    public class SportModel
    {
        public int Id { get; set; }

        public int SportPlanId { get; set; }

        public string Name { get; set; }

        public string Reps { get; set; }

        public string Image { get; set; }

        public string Instructions { get; set; }

        public int? Level { get; set; }

        public int Done { get; set; }

        public byte[] ImgContent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual SportPlanModel SportPlan { get; set; }
    }
}