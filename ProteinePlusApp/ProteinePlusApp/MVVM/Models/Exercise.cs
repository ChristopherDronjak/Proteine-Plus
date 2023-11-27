using SQLite;
using ProteinePlusApp.MVVM.Views;

namespace ProteinePlusApp.MVVM.Models
{
    [Table("exercise")]
    public class Exercise
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("exercise_name")]
        public string ExerciseName { get; set; }

        [Column("reps")]
        public string Reps { get; set; }

        [Column("sets")]
        public string Sets { get; set; }

        [Column("excdate")]
        public DateTime ExcDate { get; set; }
    }
}