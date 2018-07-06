using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodePanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        InfoMessage[] _messages;
        private bool _quitOnMessageEnd;
        public InfoPage(InfoMessage[] messages, bool quitOnMessageEnd = false)
        {
            InitializeComponent();
            _quitOnMessageEnd = quitOnMessageEnd;
            _messages = messages;
            var message = GetInfoMessage();
            UpdateUI(message);
        }

        private void UpdateUI(InfoMessage message)
        {
            NextButton.Text = message.ButtonText;
            InfoContent.Text = message.Text;
        }

        private int currentInfoMessage = 0;

        private InfoMessage GetInfoMessage()
        {
            if (currentInfoMessage >= _messages.Length)
                return null;
            return _messages[currentInfoMessage++];
        }

        private async void NextButton_OnClicked(object sender, EventArgs e)
        {
            var message = GetInfoMessage();
            if (message == null)
            {
                if(_quitOnMessageEnd)
                    Application.Current.Quit();
                var nextQuestAvailable = AppData.NextQuest();
                await Application.Current.SavePropertiesAsync();
                if (nextQuestAvailable)
                    Application.Current.MainPage = new NavigationPage(new QuestPage());
            }
            else UpdateUI(message);
        }
    }
}