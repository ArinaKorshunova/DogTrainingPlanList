using DogTrainingPlanList.DataBaseLayer;
using DogTrainingPlanList.Model;
using DogTrainingPlanList.NavigationHelper;
using DogTrainingPlanList.View;
using Prism.Commands;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DogTrainingPlanList.ViewModel
{
    public class EditSkillViewModel : Page
    {
        #region Свойства зависимости

        public Skill Skill
        {
            get { return (Skill)GetValue(SkillProperty); }
            set { SetValue(SkillProperty, value); }
        }

        public static readonly DependencyProperty SkillProperty =
            DependencyProperty.Register("Skill", typeof(Skill), typeof(EditSkillViewModel), new PropertyMetadata(null));


        public DelegateCommand SaveSkillsCommand
        {
            get { return (DelegateCommand)GetValue(SaveSkillsCommandProperty); }
            set { SetValue(SaveSkillsCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveSkillsCommandProperty =
            DependencyProperty.Register("SaveSkillsCommand", typeof(DelegateCommand), typeof(EditSkillViewModel), new PropertyMetadata(null));



        public List<string> Efforts
        {
            get { return (List<string>)GetValue(EffortsProperty); }
            set { SetValue(EffortsProperty, value); }
        }
        public static readonly DependencyProperty EffortsProperty =
            DependencyProperty.Register("Efforts", typeof(List<string>), typeof(EditSkillViewModel), new PropertyMetadata(null));


        public List<string> Types
        {
            get { return (List<string>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(List<string>), typeof(EditSkillViewModel), new PropertyMetadata(null));


        public string SelectedEffort
        {
            get { return (string)GetValue(SelectedEffortProperty); }
            set { SetValue(SelectedEffortProperty, value); }
        }
        public static readonly DependencyProperty SelectedEffortProperty =
            DependencyProperty.Register("SelectedEffort", typeof(string), typeof(EditSkillViewModel), new PropertyMetadata(null));



        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(EditSkillViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public EditSkillViewModel()
        { }

        public EditSkillViewModel(int? id)
        {
            if (id != null)
            {
                Skill = DataBaseHelper.GetSkillById((int)id);
                SelectedEffort = Skill.EffortString;
            }
            else
            {
                Skill = new Skill();
            }

            Efforts = new List<string> { Constatns.EffortLow, Constatns.EffortMedium, Constatns.EffortHard };
            Types = new List<string> { Constatns.SkillTypeTrick, Constatns.SkillTypeSkill, Constatns.SkillTypePastime, Constatns.SkillTypeComplex, Constatns.SkillTypeCommand };

            SaveSkillsCommand = new DelegateCommand(SaveSkills);
        }

        #endregion


        #region Методы
        
        public void SaveSkills()
        {
            Skill.Effort = GetEffortByString(SelectedEffort);

            if (Skill.Id != 0)
            {
                DataBaseHelper.EditSkill(Skill);
            }
            else
            {
                DataBaseHelper.AddSkill(Skill);
            }

            Navigation.NavigateTo(new SkillPage());
        }


        private int GetEffortByString(string selectedEffort)
        {
            if(selectedEffort == Constatns.EffortHard)
            {
                return 2;
            }
            else if(selectedEffort == Constatns.EffortMedium)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        #endregion
    }
}
