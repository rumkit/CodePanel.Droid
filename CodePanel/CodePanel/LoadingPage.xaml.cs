using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodePanel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingPage : ContentPage
	{
	    private readonly string _password;
	    private bool _canNavigateBack;
		public LoadingPage (string password)
		{
			InitializeComponent ();
		    _password = password;
		}

	    public LoadingPage()
	    {
	        
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        NavigationPage.SetHasBackButton(this, false);
	        var task = new Task(ProgressTask);
            task.RunSynchronously();
	    }

        private void EnableNavigation()
        {
            _canNavigateBack = true;
            BackButton.IsEnabled = true;
            BackButton.IsVisible = true;
            BackButton.BackgroundColor = Color.Green;
        }

        private void ShowResult()
        {
            StatusLabel.Text = string.Empty;
            if (_password == AppData.CurrentQuest.QuestAnswer)
            {
                Application.Current.Properties["CurrentQuestId"] = (int)Application.Current.Properties["CurrentQuestId"] + 1;
                Application.Current.MainPage = new NavigationPage(new QuestPage());
            }
            else
            {
                ResultLabel.Text = "Пароль неверный";
                ResultLabel.BackgroundColor = Color.OrangeRed;
                ResultLabel.TextColor = Color.White;
                HintLabel.IsVisible = false;
                EnableNavigation();
            }

            ResultGrid.IsVisible = true;
            LoadingGrid.IsVisible = false;
        }

        private async void ProgressTask()
	    {
	        const int max = 800;
	        const int statusUpdateRate = 5;
            for (int i = 0; i < max; i++)
	        {
	            await Task.Delay(10);
	            if (i % (max / statusUpdateRate + 1) == 0)
	                StatusLabel.Text = AppData.LoadingStrings.GetRandomElement();
	            LoadingBar.Progress = 0.00125 * i;
            }

	        ShowResult();
	    }

	    protected override bool OnBackButtonPressed()
	    {
	        if (_canNavigateBack)
	            return base.OnBackButtonPressed();
	        return true;
	    }

	    private async void BackButton_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PopModalAsync();
	    }
	}
}