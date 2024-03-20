using System.ComponentModel.DataAnnotations.Schema;

namespace API_WEB
{
    [Table("Concours")]
    public class Concours
    {
        [Column("ID_Concours")]
        public int Id { get; set; }
        [Column("Nom")]
        public string NomConcours { get; set; }
        [Column("Date_Concours")]
        public DateTime? Date_Concours { get; set; }
        [Column("Type_Concours")]
        public string Type_Concours { get; set; }



        public Concours(int id, string nom, string typeConcours)
        {
            Id = id;
            this.NomConcours = nom;
            this.Type_Concours = typeConcours;
        }
    }
}
