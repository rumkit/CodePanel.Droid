﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodePanel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskPage : ContentPage
	{
		public TaskPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        var currentQuest = AppData.CurrentQuest;
	        this.Title = currentQuest.QuestName;
	        QuestContent.Text = currentQuest.TaskText;
	        base.OnAppearing();
	    }

        private async void NextButton_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new PasswordPage());
        }
	}
}