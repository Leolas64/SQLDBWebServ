namespace API_WEB
{
    public class Manga
    {
        public int Id { get; set; }
        public string nom {  get; set; }
        public int nbTomes { get; set; }
        public string etatAvancement { get; set; }
        public DateTime dateSortieProchainTome { get; set; }

        public Manga(int id, string nom, int nbTomes, string etatAvancement)
        {
            Id = id;
            this.nom = nom;
            this.nbTomes = nbTomes;
            this.etatAvancement = etatAvancement;
        }

        //public void WriteId(int id)
        //{
        //    _Id = id;
        //}
    }
}

