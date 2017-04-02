using System.Collections.Generic;
using SciFit.Models;

namespace SciFit.Logic
{
    public class GeneratePlan
    {

        private int adaptPlan(UserModel user)
        {
            return 1;
        }

        public List<SportPlanModel> GenerateSportPlan(UserModel user)
        {
            var sportList = new List<SportPlanModel>
            {
                new SportPlanModel
                {
                    Name = "Atsilenkimai",
                    Reps = "2X8",
                    Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                    Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių."
                },
                new SportPlanModel
                {
                    Name = "Pritūpimai",
                    Reps = "2X12",
                    Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                    Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                }
            };

            var sportList2 = new List<SportPlanModel>
            {
                new SportPlanModel
                {
                    Name = "Atsilenkimai",
                    Reps = "2X8",
                    Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                    Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių."
                },
                new SportPlanModel
                {
                    Name = "Pritūpimai",
                    Reps = "2X12",
                    Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                    Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                }
            };

            var sportList3 = new List<SportPlanModel>
            {
                new SportPlanModel
                {
                    Name = "Atsilenkimai",
                    Reps = "2X8",
                    Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                    Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių."
                },
                new SportPlanModel
                {
                    Name = "Pritūpimai",
                    Reps = "2X12",
                    Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                    Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                }
            };

            var sportList4 = new List<SportPlanModel>
            {
                new SportPlanModel
                {
                    Name = "Atsilenkimai",
                    Reps = "2X8",
                    Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                    Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių."
                },
                new SportPlanModel
                {
                    Name = "Pritūpimai",
                    Reps = "2X12",
                    Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                    Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                }
            };

            return sportList;
        }

        public List<NutritionPlanModel> GenerateNutritionPlan(UserModel user)
        {
            var nutritionList = new List<NutritionPlanModel>
            {
                new NutritionPlanModel
                {
                    Name = "Bananas",
                    Image = "http://freenology.com/images/71442518538Banana.jpg",
                    Calories = "15",
                    Weight = "2kg",
                    Price = "10euru"
                },
                new NutritionPlanModel
                {
                    Name = "Obuolys",
                    Image = "http://www.asvyras.lt/turinys/galerija/obuolys.jpg",
                    Calories = "30",
                    Weight = "1kg",
                    Price = "5eurai"
                }
            };

            return nutritionList;
        }
    }
}