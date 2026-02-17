namespace Domain.DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Gstin { get; set; } = "";
        public string Country { get; set; } = "";
        public string State { get; set; } = "";
    }
}
