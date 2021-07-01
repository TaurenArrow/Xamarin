using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidX.AppCompat.App;
using static Android.Resource;

namespace MorePages
{
    [Activity(Label = "Second Page", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SecondActivity : AppCompatActivity
    {
        Button btnSecond;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            // Create your application here
            SetContentView(Resource.Layout.second_page);

            btnSecond = FindViewById<Button>(Resource.Id.btnSecondPage);

            btnSecond.Click += delegate { StartActivity(typeof(MainActivity)); };
        }
    }
}