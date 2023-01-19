namespace dotNETCoreAPIRevamp.Contracts.V1.Requests
{
    public class UpdatePostRequest
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}
