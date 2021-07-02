using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace ListViewTutorial.Resources.layout
{
    [Activity(Label = "Second page", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Activity1 : AppCompatActivity
    {
        TextView txtId;
        Button btnBack;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            SetContentView(Resource.Layout.activity_second);
            base.OnCreate(savedInstanceState);


            txtId = FindViewById<TextView>(Resource.Id.txtId);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);

            btnBack.Click += delegate { StartActivity(typeof(MainActivity)); };

            var gettedIntent = Intent.GetStringExtra("IdItem");
            var c = gettedIntent;
            txtId.Text = "";
            txtId.Text = gettedIntent;
            btnBack.Click += delegate { StartActivity(typeof(MainActivity)); };

        }
    }
}