namespace Steam.Models
{
    // 1:1, 1:N, N:N
    // Unidirecional, Bidirecional
    public record class Developer
    {

        public Guid Id
        {
            get; set;
        }

        public required string Name
        {
            get; set;
        }
    }
}