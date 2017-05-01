using System.Collections.Generic;

namespace SciFit.Models
{
    public class AdministrationModel
    {
        public List<UserModel> Users { get; set; }

        public List<PlanTemplateModel> Plans { get; set; }
    }
}