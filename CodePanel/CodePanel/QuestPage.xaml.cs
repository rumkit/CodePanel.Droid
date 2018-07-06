using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodePanel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuestPage : ContentPage
	{
		public QuestPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
            var currentQuest = AppData.CurrentQuest;
	        this.Title = currentQuest.QuestName;
	        QuestContent.Text = currentQuest.QuestText;
            base.OnAppearing();
	    }


	    private async void NextButton_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new TaskPage());
        }
	}
}