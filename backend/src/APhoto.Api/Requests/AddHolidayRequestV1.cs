namespace APhoto.Api.Requests
{
    public class AddHolidayRequestV1
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Comment { get; set; }

        public bool AllowOrders { get; set; } = false;
    }
}
