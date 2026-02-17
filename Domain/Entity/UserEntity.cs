namespace Domain.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public int CompanyId { get; set; }
    }
}
