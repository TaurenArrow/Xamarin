using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using ListViewTutorial.Resources.layout;
using System.Collections.Generic;

namespace ListViewTutorial
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public string idItem;
        private List<string> items;
        private ListView listView1;
        private TextView log;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            listView1 = FindViewById<ListView>(Resource.Id.lv);
            log = FindViewById<TextView>(Resource.Id.log);

            items = new List<string>();
            items.Add("Ciao_1");
            items.Add("Ciao_2");
            items.Add("Ciao_3");

            ArrayAdapter<string> a = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);

            listView1.Adapter = a;

            listView1.ItemClick += ListView1_ItemClick;
        }

        private void ListView1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = items[e.Position];


            var MyIntent = new Intent(this, typeof(Activity1));
            MyIntent.PutExtra("IdItem", item);

            StartActivity(MyIntent);
        }

        public string getIdItem()
        {
            return idItem;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}