using DogTrainingPlanList.DataBaseLayer;
using DogTrainingPlanList.View;
using System.Windows;
using System.Windows.Navigation;

namespace DogTrainingPlanList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationWindow navigationWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DataBaseHelper.InitialCreate();

            navigationWindow = new NavigationWindow();
            navigationWindow.Title = "План треннировок";
            navigationWindow.Height = 650;
            navigationWindow.Width = 900;
            var page = new SkillPage();
            navigationWindow.Navigate(page);
            navigationWindow.Show();
        }
    }
}
