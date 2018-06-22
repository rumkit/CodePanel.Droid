using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CodePanel;
using CodePanel.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PasswordEntry), typeof(PasswordEntryRenderer))]
namespace CodePanel.Droid.CustomRenderer
{
    class PasswordEntryRenderer : EntryRenderer
    {
        public PasswordEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;
            var ctrl = (Entry)Element;
            ctrl.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center;
        }

        //public override void ChildDrawableStateChanged(Android.Views.View child)
        //{
        //    base.ChildDrawableStateChanged(child);
        //    Control.Text = Control.Text;
        //}
    }
}