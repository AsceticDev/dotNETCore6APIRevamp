namespace dotNETCoreAPIRevamp.Contracts.V1.Responses
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public IEnumerable<TagResponse> Tags { get; set; }
    }
}
