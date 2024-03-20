using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{
    [Table("Categorie")]

    public class Categorie
    {
        [Column("ID_Categorie")]
        public int Id { get; set; }
        [Column("Type")]
        public string nom { get; set; }


        public Categorie(int id, string nom)
        {
            Id = id;
            this.nom = nom;
        }
    }
}
