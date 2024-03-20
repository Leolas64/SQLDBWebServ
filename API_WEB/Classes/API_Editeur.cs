using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{
    [Table("Editeur")]

    public class Editeur
    {
        [Column("ID_Editeur")]
        public int Id { get; set; }
        [Column("Nom_Editeur")]
        public string nom { get; set; }


        public Editeur(int id, string nom)
        {
            Id = id;
            this.nom = nom;
        }

    }
}
