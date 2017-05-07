using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SciFitApi.Models
{
    public class SciFitApiContextInitializer : DropCreateDatabaseAlways<SciFitApiContext>
    {
        protected override void Seed(SciFitApiContext context)
        {
            var roles = new List<RolesModel>
            {
                new RolesModel
                {
                    Title = "User"
                },
                new RolesModel
                {
                    Title = "Admin"
                }
            };
            roles.ForEach(x => context.Roles.Add(x));
            context.SaveChanges();

            //var users = new List<UsersModel>
            //{
            //    new UsersModel
            //    {
            //        RoleId = 1,
            //        Name = "Lukas",
            //        Surname = "Ignatavicius",
            //        Address = "Virsuliskes",
            //        Email = "lukas@gmail.com",
            //        UserName = "Lukas",
            //        Password = "admin",
            //        Age = "10",
            //        Weight = "10",
            //        Height = "10",
            //        Difficulty = "0"
            //    }
            //};
            //users.ForEach(x => context.Users.Add(x));
            //context.SaveChanges();

            //var plan = new List<PlanModel>
            //{
            //    new PlanModel
            //    {
            //        UserId = 0,
            //        Title = "My first plan",
            //        Author = "A name of author",
            //        StartDate = "2016"
            //    }
            //};
            //plan.ForEach(x => context.Plan.Add(x));
            //context.SaveChanges();

            var sportPlan = new List<SportTemplateModel>
            {
                new SportTemplateModel
                    {
                        Name = "Atsilenkimai",
                        Reps = "2X8",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių.",
                        Level = 1,
                        Done = false,
                        StartDate = DateTime.Now
                    },
                    new SportTemplateModel
                    {
                        Name = "Pritūpimai",
                        Reps = "2X12",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 1,
                        Done = false,
                        StartDate = DateTime.Now
                    },
                    new SportTemplateModel
                    {
                        Name = "Mirties kilpa",
                        Reps = "4X18",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions =
                            "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių.",
                        Level = 2,
                        Done = false,
                        StartDate = DateTime.Now
                    },
                    new SportTemplateModel
                    {
                        Name = "Medziokle",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 2,
                        Done = false,
                        StartDate = DateTime.Now
                    },
                    new SportTemplateModel
                    {
                        Name = "DeadLift",
                        Reps = "2X800",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių.",
                        Level = 3,
                        Done = false,
                        StartDate = DateTime.Now
                    },
                    new SportTemplateModel
                    {
                        Name = "Flying Bus",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 3,
                        Done = false,
                        StartDate = DateTime.Now
                    }
            };
            sportPlan.ForEach(x => context.SportTemplate.Add(x));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}