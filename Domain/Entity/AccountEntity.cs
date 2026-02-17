namespace Domain.Entity
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Group { get; set; } = "";
        public decimal Balance { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public int CompanyId { get; set; }
    }
}
