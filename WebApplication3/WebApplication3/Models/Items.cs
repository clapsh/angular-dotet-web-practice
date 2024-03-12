using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models{
    public class Items
    {
        static int newId = 1;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; } = newId++;
        public int userId { get; set; }
        public string userName { get; set;}

        public Items(){
            newId = newId++;
        }
    }
}
