namespace DogTrainingPlanList.Model
{
    public class TrainingSkills
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public Skill Skill { get; set; }
        public int SkillId { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }
        public bool IsComplete { get; set; }
        public int Value { get; set; }
    }
}
