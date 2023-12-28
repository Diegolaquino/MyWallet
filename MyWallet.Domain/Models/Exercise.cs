using MyWallet.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Exercises")]
    public class Exercise : BaseEntity
    {
        public DateTime ExerciseDate { get; set; }
        public double? Distance { get; set; }   
        public TimeSpan Duration { get; set; } 
        public EIntensity Intensity { get; set; }  
        public EExerciseType ExerciseType { get; set; }
        public int? Repetitions { get; set; }  
        public string Tags { get; set; }
        
        public Exercise(Guid id): base(id) { }

        public Exercise()
        {
                
        }
    }

    public enum EIntensity
    {
        High = 1, Low = 2, Medium = 3
    }
}
