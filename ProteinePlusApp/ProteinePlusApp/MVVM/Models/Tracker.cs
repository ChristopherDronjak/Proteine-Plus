using SQLite;
using ProteinePlusApp.MVVM.Views;

namespace ProteinePlusApp.MVVM.Models
{
    [Table("tracker")]
    //Used to gather the users input in the Food Intake page, this table collects the Meal name, protein, calorie and fat intake along with the date the users selects.
    // assigns the meal an ID
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
