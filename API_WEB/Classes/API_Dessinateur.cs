using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{
    [Table("Dessinateur")]

    public class Dessinateur
    {
        [Column("ID_Dessinateur")]
        public int Id { get; set; }
        [Column("Nom")]
        public string nom { get; set; }
        [Column("Prenom")]
        public string prenom { get; set; }


        public Dessinateur(int id, string nom, string prenom)
        {
            Id = id;
            this.nom = nom;
            this.prenom = prenom;
        }
    }
}
