namespace APhoto.Api.Requests
{
    public record AcceptOrderRequestV1
    {
        public required uint OrderId { get; set; }
    }
}
