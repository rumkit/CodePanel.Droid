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
	        string header = string.Empty;
	        string message = string.Empty;
	        StatusLabel.Text = string.Empty;
	        if (AppData.Hints.ContainsKey(_password))
	        {
	            header = "Успех";
	            message = AppData.Hints[_password];
	        }
	        else
	        {
	            header = "Провал";
	            message = "Пароль неверный";
	        }

	        await DisplayAlert(header, message, "Закрыть");
	    }

	    private async void ProgressTask()
	    {
            for (int i = 0; i < 1000; i++)
	        {
	            await Task.Delay(10);
	            if (i % 201 == 0)
	                StatusLabel.Text = AppData.LoadingStrings.GetRandomElement();
	            LoadingBar.Progress = 0.001 * i;
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