namespace SQLite
{
    internal class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string numTelefono { get; set; }

        public override string ToString()
        {
            return "Contact " + Id + ": " + Nome + " " + Cognome + " - " + numTelefono;
        }
    }
}