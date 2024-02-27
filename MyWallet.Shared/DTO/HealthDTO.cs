namespace MyWallet.Shared.DTO
{
    public class HealthDTO
    {
        public Guid? Id { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public decimal Weight { get; set; }
        public int SleepQuality { get; set; }
        public bool IsTired { get; set; }
        public int StomachSize { get; set; }
        public DateTime HealthDate { get; set; }
    }
}
