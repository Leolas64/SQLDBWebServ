using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB.Classes
{
    [Table("Genre")]

    public class Genre
    {
        [Column("ID_Genre")]
        public int Id { get; set; }
        [Column("Type")]
        public string nom { get; set; }


        public Genre(int id, string nom)
        {
            Id = id;
            this.nom = nom;
        }
    }
}
