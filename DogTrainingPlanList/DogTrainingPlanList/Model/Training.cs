using System;
using System.Collections.Generic;

namespace DogTrainingPlanList.Model
{
    public class Training
    {
        public int Id { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Duration { get; set; }
        public int Order { get; set; }
        public List<TrainingSkills> PlanSkills { get; set; }
    }
}
