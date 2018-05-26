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




        public DelegateCommand<int?> EditSkillsCommand
        {
            get { return (DelegateCommand<int?>)GetValue(EditSkillsCommandProperty); }
            set { SetValue(EditSkillsCommandProperty, value); }
        }
       
        public static readonly DependencyProperty EditSkillsCommandProperty =
            DependencyProperty.Register("EditSkillsCommand", typeof(DelegateCommand<int?>), typeof(SkillPageViewModel), new PropertyMetadata(null));

        public DelegateCommand<int?> HideSkillsCommand
        {
            get { return (DelegateCommand<int?>)GetValue(HideSkillsCommandProperty); }
            set { SetValue(HideSkillsCommandProperty, value); }
        }

        public static readonly DependencyProperty HideSkillsCommandProperty =
            DependencyProperty.Register("HideSkillsCommand", typeof(DelegateCommand<int?>), typeof(SkillPageViewModel), new PropertyMetadata(null));

        public DelegateCommand AddSkillCommand
        {
            get { return (DelegateCommand)GetValue(AddSkillCommandProperty); }
            set { SetValue(AddSkillCommandProperty, value); }
        }

        public static readonly DependencyProperty AddSkillCommandProperty =
            DependencyProperty.Register("AddSkillCommand", typeof(DelegateCommand), typeof(SkillPageViewModel), new PropertyMetadata(null));


        public DelegateCommand CreatePlanCommand
        {
            get { return (DelegateCommand)GetValue(CreatePlanCommandProperty); }
            set { SetValue(CreatePlanCommandProperty, value); }
        }

        public static readonly DependencyProperty CreatePlanCommandProperty =
            DependencyProperty.Register("CreatePlanCommand", typeof(DelegateCommand), typeof(SkillPageViewModel), new PropertyMetadata(null));

        
        public bool ShowHided
        {
            get { return (bool)GetValue(ShowHidedProperty); }
            set { SetValue(ShowHidedProperty, value); }
        }
        
        public static readonly DependencyProperty ShowHidedProperty =
            DependencyProperty.Register("ShowHided", typeof(bool), typeof(SkillPageViewModel), new PropertyMetadata(null));




        public DelegateCommand ChangeShowHidedCommand
        {
            get { return (DelegateCommand)GetValue(ChangeShowHidedCommandProperty); }
            set { SetValue(ChangeShowHidedCommandProperty, value); }
        }
        
        public static readonly DependencyProperty ChangeShowHidedCommandProperty =
            DependencyProperty.Register("ChangeShowHidedCommand", typeof(DelegateCommand), typeof(SkillPageViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public SkillPageViewModel()
        {
            Skills = DataBaseHelper.GetNotHighSkills();
            ShowHided = false;
            ChangeShowHidedCommand = new DelegateCommand(ChangeShowHided);
            EditSkillsCommand = new DelegateCommand<int?>(EditSkills);
            HideSkillsCommand = new DelegateCommand<int?>(HideSkills);
            AddSkillCommand = new DelegateCommand(AddSkill);
            CreatePlanCommand = new DelegateCommand(CreatePlan);
        }

        #endregion


        #region Методы

        private void ChangeShowHided()
        {
            if (ShowHided)
            {
                Skills = DataBaseHelper.GetAllSkills();
            }
            else
            {
                Skills = DataBaseHelper.GetNotHighSkills();
            }
        }

        private void EditSkills(int? id)
        {
            EditSkillPage child = new EditSkillPage();
            child.DataContext = new EditSkillViewModel(id);
            Navigation.NavigateTo(child);
        }
        private void HideSkills(int? id)
        {
            if (id != null)
            {
                DataBaseHelper.HideSkill((int)id);
                Skills = DataBaseHelper.GetNotHighSkills();
            }
        }

        private void CreatePlan()
        {

        }

        private void AddSkill()
        {

            EditSkillPage child = new EditSkillPage();
            child.DataContext = new EditSkillViewModel();
            Navigation.NavigateTo(child);
        }

        #endregion
    }
}
