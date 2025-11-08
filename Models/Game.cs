namespace Steam.Models
{

    
    public record class Game
    {
        public enum Recommend
        {
            YES, NO
        }

        // MÉTODO PARA ADICIONAR UMA ANÁLISE (REVIEW)
        public void AddReview(Recommend recommendation,
                              string? description = null)
        {
            this.Reviews.Add(new Review
            {
                Id = Guid.NewGuid(),
                Recommended = recommendation == Recommend.YES,
                Description = description
            });
        }


        // attribute
        // private string _title;
        // property
        public required string Title
        {
            get; set;
        }

        // UUID, GUID (Globally Unique Identifier)
        public required Guid Id
        {
            get; set;
        }

        public required Developer Developer
        {
            get; set;
        }
        // void, empty
        public List<Review> Reviews
        {
            get;
        } = [];
    }
}