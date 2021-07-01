using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.IO;

namespace SQLite
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Create components variables
        TextView txtNome, txtCog, log;
        EditText etNome, etCog;
        Button btnInsert, btnSelectAll;
        private string completePath;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            #region Set Up Components
            txtNome = FindViewById<TextView>(Resource.Id.txtNome);
            txtCog = FindViewById<TextView>(Resource.Id.txtCog);
            log = FindViewById<TextView>(Resource.Id.txtLog);

            etNome = FindViewById<EditText>(Resource.Id.etNome);
            etCog = FindViewById<EditText>(Resource.Id.etCog);

            btnInsert = FindViewById<Button>(Resource.Id.btnInsert);
            btnSelectAll = FindViewById<Button>(Resource.Id.btnSelectAll);

            btnInsert.Click += BtnInsert_Click;
            btnSelectAll.Click += BtnSelectAll_Click;
            #endregion

            #region crete path db
            string fileName = "contacts_db.db3";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            completePath = Path.Combine(folderPath, fileName);
            #endregion
        }

        //BTN INSERT
        private void BtnInsert_Click(object sender, System.EventArgs e)
        {
            //create obj
            Contact contact = new Contact()
            {
                Nome = etNome.Text,
                Cognome = etCog.Text
            };

            //create connection and insert
            using (SQLiteConnection con = new SQLiteConnection(completePath))
            {
                con.CreateTable<Contact>();
                int rowsAdded = con.Insert(contact);
                updateLog(etNome.Text + " " + etCog.Text + " è stato inserito (" + rowsAdded + ")");
            }
        }

        //BTN SELECT
        private void BtnSelectAll_Click(object sender, System.EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(completePath))
            {
                con.CreateTable<Contact>();
                var contacts = con.Table<Contact>().ToList();
                foreach (var item in contacts) Console.WriteLine(item);

                //contacts.ForEach(Console.WriteLine);  
            }
        }

        //UPDATE LOG
        private void updateLog(string s)
        {
            string logString = log.Text + " \n " + s;
            log.Text = logString;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}