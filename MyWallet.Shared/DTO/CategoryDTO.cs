namespace MyWallet.Shared.DTO
{
    public record CategoryEntryDTO(Guid UserId, string Name);

    public class CategoryDTO
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}