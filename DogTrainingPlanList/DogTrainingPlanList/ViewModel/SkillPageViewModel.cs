using DogTrainingPlanList.Model;
using Prism.Commands;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DogTrainingPlanList.ViewModel
{
    public class SkillPageViewModel : Page
    {
        #region Свойства зависимости
        
        public List<Skill> Skills
        {
            get { return (List<Skill>)GetValue(SkillsProperty); }
            set { SetValue(SkillsProperty, value); }
        }
        
        public static readonly DependencyProperty SkillsProperty =
            DependencyProperty.Register("Skills", typeof(List<Skill>), typeof(SkillPageViewModel), new PropertyMetadata(null));




        public DelegateCommand EditSkillsCommand
        {
            get { return (DelegateCommand)GetValue(EditSkillsCommandProperty); }
            set { SetValue(EditSkillsCommandProperty, value); }
        }
       
        public static readonly DependencyProperty EditSkillsCommandProperty =
            DependencyProperty.Register("EditSkillsCommand", typeof(DelegateCommand), typeof(SkillPageViewModel), new PropertyMetadata(null));


        public DelegateCommand CreatePlanCommand
        {
            get { return (DelegateCommand)GetValue(CreatePlanCommandProperty); }
            set { SetValue(CreatePlanCommandProperty, value); }
        }

        public static readonly DependencyProperty CreatePlanCommandProperty =
            DependencyProperty.Register("CreatePlanCommand", typeof(DelegateCommand), typeof(SkillPageViewModel), new PropertyMetadata(null));

        #endregion

        #region Конструкторы

        public SkillPageViewModel()
        {
            Skills = new List<Skill>
            {
                new Skill
                {
                    Id = 0,
                    Effort = 0,
                    Name = "Наведение",
                    PercentOfCompletion = 40,
                    IsHide = false
                },
                new Skill
                {
                    Id = 0,
                    Effort = 1,
                    Name = "Змейка",
                    PercentOfCompletion = 20,
                    IsHide = false
                },
                new Skill
                {
                    Id = 0,
                    Effort = 1,
                    Name = "Назад",
                    PercentOfCompletion = 10,
                    IsHide = false
                }
            };
            EditSkillsCommand = new DelegateCommand(EditSkills);
            CreatePlanCommand = new DelegateCommand(CreatePlan);
        }

        #endregion


        #region Методы

        private void EditSkills()
        {

        }

        private void CreatePlan()
        {

        }

        #endregion
    }
}
