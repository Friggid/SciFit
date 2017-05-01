using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFit.Models
{
    public class StatisticsModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public int DoneCount { get; set; }

        public int CurrentLvl { get; set; }
    }
}