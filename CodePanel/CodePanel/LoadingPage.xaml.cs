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

	    private async Task EnableNavigation()
	    {
	        _canNavigateBack = true;
	        BackButton.IsEnabled = true;
	        BackButton.BackgroundColor = Color.Green;
	    }

	    private async Task ShowResult()
	    {
	        StatusLabel.Text = string.Empty;
	        if (AppData.Hints.ContainsKey(_password))
	        {
	            ResultLabel.Text = "Успех";
	            HintLabel.Text = AppData.Hints[_password];
                ResultGrid.BackgroundColor = Color.DeepSkyBlue;
	        }
	        else
	        {
	            ResultLabel.Text = "Пароль неверный";
	            HintLabel.IsVisible = false;
	            ResultGrid.BackgroundColor = Color.IndianRed;
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

	        await ShowResult();
	        await EnableNavigation();
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