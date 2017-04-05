using System.Collections.Generic;
using SciFit.Models;

namespace SciFit.Logic
{
    public class GeneratePlan
    {
        private int adaptPlan(UserModel user)
        {
            var age =
                user.Age.Contains("18")
                    ? 18
                    : user.Age.Contains("19")
                        ? 19
                        : user.Age.Contains("25")
                            ? 25
                            : (int?) null;

            string weight =
                user.Weight.Contains("60")
                    ? "skinny"
                    : user.Weight.Contains("60 - 80")
                        ? "normal"
                        : user.Weight.Contains("80 - 100")
                            ? "fat"
                            : user.Weight.Contains("100")
                                ? "overweight"
                                : null;

            string difficulty =
                user.Difficulty.Contains("did not train")
                    ? "low"
                    : user.Difficulty.Contains("trained a little")
                        ? "medium"
                        : user.Difficulty.Contains("trained few times")
                            ? "hard"
                            : user.Difficulty.Contains("trained a lot")
                                ? "insane"
                                : null;

            if ((age == 18 || age == 19) &&
                (weight == "skinny" || weight == "normal") &&
                (difficulty == "low" || difficulty == "medium"))
            {
                return 1;
            }

            if (age == 25 && weight == "overweight" && difficulty == "low")
            {
                return 2;
            }

            if (age == 19 && weight == "normal" && difficulty == "insane")
            {
                return 3;
            }     

            return -1;
        }

        public List<SportModel> GenerateSportPlan(UserModel user)
        {
            var sportPlan = new SportPlan();

            var adaptedPlan = adaptPlan(user);
            var program = sportPlan.GetSportPlanById(user.Id);

            if (program == null)
            {
                program = sportPlan.PostSportPlan(user.Id, adaptedPlan);
            }

            return program.Sport;
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