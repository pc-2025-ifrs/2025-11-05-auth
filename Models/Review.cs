namespace Steam.Models
{
    public record class Review
    {

        public required Guid Id
        {
            get; set;
        }

        public required bool Recommended
        {
            get; set;
        }

        // ? = pode ser anulável (NULLABLE)
        // sem ? = NOT NULL
        public string? Description
        {
            get; set;
        }
    }
}