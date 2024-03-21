using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{
    [Table("Tome")]

    public class Tome
    {
        [Column("ID_Tome")]
        public int Id { get; set; }
        [Column("Titre")]
        public string titre { get; set; }
        [Column("N_Pages")]
        public int nPages { get; set; }
        [Column("Num_Tome")]
        public int numTome { get; set; }
        [Column("Editeur")]
        public string editeur { get; set; }
        [Column("Dessinateur")]
        public string dessinateur { get; set; }
        [Column("Date_Sortie")]
        public DateTime dateSortie { get; set; }
        [Column("Readaptation")]
        public bool readaptation { get; set; }
        [Column("Prix")]
        public int prix { get; set; }
        [Column("Resume")]
        public string resume { get; set; }

        public Tome(int id, string titre, int nPages, int numTome, string dessinateur, string editeur, DateTime dateSortie, bool readaptation, int prix, string resume)
        {
            Id = id;
            this.titre = titre;
            this.nPages = nPages;
            this.numTome = numTome;
            this.dessinateur = dessinateur;
            this.editeur = editeur;
            this.dateSortie = dateSortie;
            this.readaptation = readaptation;
            this.prix = prix;
            this.resume = resume;
        }
    }
}
