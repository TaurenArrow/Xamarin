using System.IO;

namespace SQLite
{
    class DbManagment
    {
        public string completePath { get; set; }

        public void createPath()
        {
            string fileName = "contacts_db2.db3";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            this.completePath = Path.Combine(folderPath, fileName);
        }

        public override string ToString()
        {
            return "DB in: " + completePath;
        }

    }
}