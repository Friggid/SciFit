using System.Collections.Generic;
using SciFit.Models;

namespace SciFit.Logic
{
    public class GeneratePlan
    {
        private int? adaptPlan(UserModel user)
        {
            var age =
                user.Age.Contains("18")
                    ? 18
                    : user.Age.Contains("19")
                        ? 19
                        : user.Age.Contains("25")
                            ? 25
                            : (int?) null;

            var weight =
                user.Weight.Contains("60")
                    ? "skinny"
                    : user.Weight.Contains("60 - 80")
                        ? "normal"
                        : user.Weight.Contains("80 - 100")
                            ? "fat"
                            : user.Weight.Contains("100")
                                ? "overweight"
                                : null;

            var difficulty =
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

            return null;
        }

        public List<SportPlanModel> GenerateSportPlan(UserModel user)
        {
            var adaptedPlan = adaptPlan(user);
            List<SportPlanModel> program = null;

            if (adaptedPlan == 1)
            {
                program = new List<SportPlanModel>
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
                    },
                    new SportPlanModel
                    {
                        Name = "Pritūpimai",
                        Reps = "2X12",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                    }
                };
            }
            else if (adaptedPlan == 2)
            {
                program = new List<SportPlanModel>
                {
                    new SportPlanModel
                    {
                        Name = "Mirties kilpa",
                        Reps = "4X18",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions =
                            "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių."
                    },
                    new SportPlanModel
                    {
                        Name = "Medziokle",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                    }
                };
            }
            else
            {
                program = new List<SportPlanModel>
                {
                    new SportPlanModel
                    {
                        Name = "DeadLift",
                        Reps = "2X800",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių."
                    },
                    new SportPlanModel
                    {
                        Name = "Flying Bus",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite."
                    }
                };
            }

            return program;
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