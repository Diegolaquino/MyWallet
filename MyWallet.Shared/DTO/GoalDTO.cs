namespace MyWallet.Shared.DTO
{
    public class GoalDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Limit { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
