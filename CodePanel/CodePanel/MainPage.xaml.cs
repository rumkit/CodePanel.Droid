using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodePanel
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    foreach (var child in PanelGrid.Children)
		    {
		        if (child is Button button)
		            button.Clicked += CodePanelButton_Clicked;
		    }
		}

	    private void CodePanelButton_Clicked(object sender, EventArgs e)
	    {
	        var button = sender as Button;
            if(button == null)
                return;
            if(PasswordEntry.Text?.Length < PasswordLength)
                PasswordEntry.Text += button.Text;
	    }

	    private void EraseButton_Clicked(object sender, EventArgs e)
	    {
	        PasswordEntry.Text = string.Empty;
	    }

        private const int PasswordLength = 5;

	    private void PasswordEntry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        EraseButton.IsEnabled = e.NewTextValue.Length > 0;
	        if (e.NewTextValue.Length == PasswordLength)
	        {
	            ConfirmButton.IsEnabled = true;
                ConfirmButton.BackgroundColor = Color.Green;
	        }
	        else
	        {
	            ConfirmButton.IsEnabled = false;
                ConfirmButton.BackgroundColor = Color.Gray;
	        }
	    }

	    async private void ConfirmButton_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new LoadingPage(PasswordEntry.Text));
	        PasswordEntry.Text = string.Empty;
	    }
	}
}
