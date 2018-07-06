using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanel
{
    public class InfoMessage
    {
        public InfoMessage(string text, string buttonText)
        {
            Text = text;
            ButtonText = buttonText;
        }

        public readonly string Text;
        public readonly string ButtonText;
    }
}
