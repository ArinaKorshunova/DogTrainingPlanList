namespace DogTrainingPlanList
{
    public static class Constatns
    {
        #region База данных

        public const string DataBaseName = "DogTraining.sqlite";
        public const string SkillTableName = "Skills";
        public const string TrainingTableName = "Trainings";
        public const string TrainingSkillsTableName = "TrainingSkills";

        #endregion

        public const string SkillTypeCommand = "Команда";
        public const string SkillTypeTrick = "Трюк";
        public const string SkillTypeSkill = "Навык";
        public const string SkillTypePastime = "Времяпровождение";
        public const string SkillTypeComplex = "Комплекс";

        public const string EffortLow = "Легкий";
        public const string EffortMedium = "Средний";
        public const string EffortHard = "Сложный";

    }
}
