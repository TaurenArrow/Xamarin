using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;

namespace SQLite
{
    [Activity(Label = "Select all", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SelectActivity : AppCompatActivity
    {
        Button btnBack;
        ListView lstContact;

        private List<string> mItems;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_select);
            base.OnCreate(savedInstanceState);

            //BTN BACK
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            lstContact = FindViewById<ListView>(Resource.Id.lstContacts);

            btnBack.Click += delegate { StartActivity(typeof(MainActivity)); };
            
            //List and ListView
            mItems = new List<string>();

            //DATABASE
            DbManagment db = new DbManagment();
            db.createPath();

            using (SQLiteConnection con = new SQLiteConnection(db.completePath))
            {
                con.CreateTable<Contact>();
                var contacts = con.Table<Contact>().ToList();

                foreach (var item in contacts)
                {
                    var stringItem = item.ToString();
                    Console.WriteLine(stringItem);
                    mItems.Add(stringItem);
                }
                con.Close();
            }

            ArrayAdapter listAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            lstContact.Adapter = listAdapter;
        }
    }
}