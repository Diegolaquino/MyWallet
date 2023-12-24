using MyWallet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Models
{
    public class Exercise : BaseEntity
    {
        public double Distance { get; set; }   
        public TimeSpan Duration { get; set; } 
        public string Intensity { get; set; }  
        public EExerciseType ExerciseType { get; set; }
        public int Repetitions { get; set; }  
        public string Tags { get; set; }
        public Exercise(double distance, TimeSpan duration, string intensity, EExerciseType exerciseType, int repetitions, string tags)
        {
            Distance = distance;
            Duration = duration;
            Intensity = intensity;
            ExerciseType = exerciseType;
            Repetitions = repetitions;
            Tags = tags;
        }
    }
}
