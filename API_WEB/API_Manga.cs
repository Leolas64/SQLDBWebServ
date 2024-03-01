using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB
{

    [Table("Manga")]

    public class Manga
    {
        [Column("ID_Manga")]
        public int Id { get; set; }
        [Column("Nom")]
        public string nom {  get; set; }
        [Column("N_Tomes")]
        public int nbTomes { get; set; }
        [Column("Etat_Avancement")]
        public string etatAvancement { get; set; }
        [Column("Date_Sortie_Prochain_Tome")]
        public DateTime? dateSortieProchainTome { get; set; }

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

