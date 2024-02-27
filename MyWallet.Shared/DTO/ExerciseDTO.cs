using MyWallet.Domain.Enums;
using MyWallet.Domain.Models;

namespace MyWallet.Shared.DTO
{
    public class ExerciseDTO
    {
        public Guid? Id { get; set; }
        public DateTime ExerciseDate { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public double? Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public EIntensity Intensity { get; set; }
        public EExerciseType ExerciseType { get; set; }
        public int? Repetitions { get; set; }
        public string? Tags { get; set; }
    }
}
