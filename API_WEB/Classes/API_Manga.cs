using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{

    [Table("Manga")]

    public class Manga
    {
        [Column("ID_Manga")]
        public int Id { get; set; }
        [Column("Nom")]
        public string nom { get; set; }
        [Column("N_Tomes")]
        public int nbTomes { get; set; }
        [Column("Etat_Avancement")]
        public string etatAvancement { get; set; }
        [Column("Date_Sortie_Prochain_Tome")]
        public DateTime? dateSortieProchainTome { get; set; }
        [Column("ID_Genre")]
        public int idG { get; set; }
        [Column("ID_Categorie")]
        public int idC { get; set; }
        [Column("ID_Auteur")]
        public int idA { get; set; }

        public Manga(int id, string nom, int nbTomes, string etatAvancement, int idG, int idC, int idA)
        {
            Id = id;
            this.nom = nom;
            this.nbTomes = nbTomes;
            this.etatAvancement = etatAvancement;
            this.idG = idG;
            this.idC = idC;
            this.idA = idA;
        }
    }
}

