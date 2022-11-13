using System.ComponentModel.DataAnnotations.Schema;


namespace PruebaTenica.Shared
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Title { get; set; }
        public String ReleaseDate {get; set; }
        public double Lenght {get; set; }
        public String Director { get; set; }
        

    }
}
