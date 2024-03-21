using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{
    [Table("Auteur")]

    public class Auteur
    {
        [Column("ID_Auteur")]
        public int Id { get; set; }
        [Column("Nom")]
        public string nom { get; set; }
        [Column("Prenom")]
        public string prenom { get; set; }


        public Auteur(int id, string nom, string prenom)
        {
            Id = id;
            this.nom = nom;
            this.prenom = prenom;
        }
    }
}
