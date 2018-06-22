using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CodePanel
{
    class PasswordEntry : Entry
    {
        public PasswordEntry()
        {
            this.IsPassword = true;
        }
    }
}
