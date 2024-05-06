namespace APhoto.Api.Requests
{
    public record AddOrderRequestV1
    {
        public required string OrderType { get; set; }
        public required string ClientName { get; set; }
        public required string ContactInformation { get; set; }
        public required string FbUrl { get; set; }
        public required string Message { get; set; }
    }
}
