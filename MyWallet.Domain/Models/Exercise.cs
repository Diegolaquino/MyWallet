using MyWallet.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWallet.Domain.Models
{
    [Table("Exercises")]
    public class Exercise : BaseEntity
    {
        public double? Distance { get; set; }   
        public TimeSpan Duration { get; set; } 
        public EIntensity Intensity { get; set; }  
        public EExerciseType ExerciseType { get; set; }
        public int? Repetitions { get; set; }  
        public string Tags { get; set; }
        public Exercise(double distance, TimeSpan duration, EIntensity intensity, EExerciseType exerciseType, int repetitions, string tags)
        {
            Distance = distance;
            Duration = duration;
            Intensity = intensity;
            ExerciseType = exerciseType;
            Repetitions = repetitions;
            Tags = tags;
        }
    }

    public enum EIntensity
    {
        High = 1, Low = 2, Medium = 3
    }
}
