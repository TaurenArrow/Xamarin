using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace SQLite
{
    [Activity(Label = "Add new contact", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        char[] test = new char[1];

        //Create components variables
        TextView log;
        EditText etNome, etCog, etTel;
        Button btnInsert, btnSelectAll;
        
        //DB obj
        DbManagment db;
        int rowsAdded;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            test[0] = default(char);

            #region Set Up Components
            log = FindViewById<TextView>(Resource.Id.txtLog);

            etNome = FindViewById<EditText>(Resource.Id.etNome);
            etCog = FindViewById<EditText>(Resource.Id.etCog);
            etTel = FindViewById<EditText>(Resource.Id.etTel);

            btnInsert = FindViewById<Button>(Resource.Id.btnInsert);
            btnSelectAll = FindViewById<Button>(Resource.Id.btnSelectAll);

            btnInsert.Click += BtnInsert_Click;
            btnSelectAll.Click += delegate { StartActivity(typeof(SelectActivity)); };
            #endregion

            #region Set Up DB
            db = new DbManagment();
            db.createPath();
            #endregion

            #region DROP TABLE
            /*
            using (SQLiteConnection con = new SQLiteConnection(db.completePath))
            {
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = " DROP Table 'contact'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            */
            #endregion
        }

        //BTN INSERT
        private void BtnInsert_Click(object sender, System.EventArgs e)
        {
            //create obj
            Contact contact = new Contact()
            {
                Nome = etNome.Text,
                Cognome = etCog.Text,
                numTelefono = etTel.Text
            };

            Console.WriteLine(db);
            Console.WriteLine(contact);


            //create connection and insert
            using (SQLiteConnection con = new SQLiteConnection(db.completePath))
            {
                con.CreateTable<Contact>();
                rowsAdded = con.Insert(contact);
                con.Close();
            }

            updateLog(etNome.Text + " " + etCog.Text + " è stato inserito nel db");

            etNome.SetText(test, 0, 1);
            etCog.SetText(test, 0, 1);
            etTel.SetText(test, 0, 1);
        }

        //UPDATE LOG
        private void updateLog(string s)
        {
            string logString = log.Text + " \n" + s;
            log.Text = logString;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}