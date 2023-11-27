using SQLite;
using ProteinePlusApp.MVVM.Views;

namespace ProteinePlusApp.MVVM.Models
{
    [Table("tracker")]
    public class Tracker
    {
        [PrimaryKey]
        [AutoIncrement]
       [Column("trackid")]
        public int TrackId { get; set; }

        [Column("mealname")]
        public string MealName { get; set; }

        [Column("protein")]
        public string Protein { get; set; }

        [Column("calories")]
        public string Calories { get; set; }

        [Column("fat")]
        public string Fat { get; set; }

        [Column("tradate")]
        public DateTime TraDate { get; set; }
    }
}
