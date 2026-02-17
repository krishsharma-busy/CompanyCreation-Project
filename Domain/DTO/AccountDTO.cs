namespace Domain.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Group { get; set; } = "";
        public decimal Balance { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public int CompanyId { get; set; }
    }
}
