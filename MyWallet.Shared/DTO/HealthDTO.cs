namespace MyWallet.Shared.DTO
{
    public class HealthDTO
    {
        public Guid? Id { get; set; }
        public decimal Systolic { get; set; }
        public decimal Diastolic { get; set; }
        public decimal Weight { get; set; }
        public int SleepQuality { get; set; }
        public bool IsTired { get; set; }
        public decimal StomachSize { get; set; }
        public DateTime HealthDate { get; set; }
    }
}
