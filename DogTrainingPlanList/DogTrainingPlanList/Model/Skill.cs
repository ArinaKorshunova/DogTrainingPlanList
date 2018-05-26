using System.Windows;
using System.Windows.Media;

namespace DogTrainingPlanList.Model
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Effort { get; set; }
        public int PercentOfCompletion { get; set; }
        public bool IsHide { get; set; }
        public string Type { get; set; }

        public Brush Color {
            get {
                if(PercentOfCompletion <= 20)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if(PercentOfCompletion <= 50)
                {

                    return new SolidColorBrush(Colors.Orange);
                }
                else if (PercentOfCompletion <= 80)
                {

                    return new SolidColorBrush(Colors.Gold);
                }
                else
                {
                    return new SolidColorBrush(Colors.YellowGreen);
                }
            }
        }
        public string EffortString
        {
            get
            {
                if (Effort == 0)
                {
                    return "Легкий";
                }
                else if (Effort == 1)
                {
                    return "Средний";
                }
                else if (Effort == 2)
                {
                    return "Сложный";
                }

                return "Не определен";
            }
        }

        public Visibility HideButtonVisibility
        {
            get
            {
                if (IsHide)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
    }
}
