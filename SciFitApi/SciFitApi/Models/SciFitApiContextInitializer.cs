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
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/Xyd_fa5zoEU"
                    },
                    new SportTemplateModel
                    {
                        Name = "Pritūpimai",
                        Reps = "2X12",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 1,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Prigulimai",
                        Reps = "2X15",
                        Image = "http://www.learningthealexandertechnique.com/wp-content/uploads/2012/09/drp_6072.jpg",
                        Instructions = "Atsigulkite ir gulėkite.",
                        Level = 1,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/uPwHCGInwn4"
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
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Medziokle",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 2,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "DeadLift",
                        Reps = "2X800",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių.",
                        Level = 3,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Flying Bus",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 3,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "DeadLift",
                        Reps = "2X800",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių.",
                        Level = 4,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Flying Bus",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 4,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Sokantis briedis",
                        Reps = "2X20",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite ant triju koju ir padainuokite daina.",
                        Level = 4,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "DeadLift",
                        Reps = "2X800",
                        Image = "https://www.bodybuilding.com/exercises/exerciseImages/sequences/2001/Male/m/2001_1.jpg",
                        Instructions = "Atsigulkite ant nugaros, sulenkite kelius, padėkite rankas už galvos ir prisitraukite prie sulenktų kelių.",
                        Level = 5,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Flying Bus",
                        Reps = "2X120",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Atsistokite tiesia nugara, ištieskite rankas ir pritūpkite.",
                        Level = 5,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    },
                    new SportTemplateModel
                    {
                        Name = "Krintantis erelis",
                        Reps = "2X16",
                        Image = "http://pasmama.tv3.lt/uploads/editor/image/1%281%29.jpg",
                        Instructions = "Kriskite!",
                        Level = 5,
                        Done = false,
                        StartDate = DateTime.Now,
                        Video = "www.youtube.com/embed/UXJrBgI2RxA"
                    }
            };
            sportPlan.ForEach(x => context.SportTemplate.Add(x));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}