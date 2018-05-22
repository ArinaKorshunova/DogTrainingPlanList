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
            navigationWindow = new NavigationWindow();
            navigationWindow.Height = 850;
            navigationWindow.Width = 1200;
            var page = new SkillPage();
            navigationWindow.Navigate(page);
            navigationWindow.Show();
        }
    }
}
