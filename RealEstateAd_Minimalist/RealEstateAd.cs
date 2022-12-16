namespace RealEstateAd_Minimalist
{
    using Microsoft.EntityFrameworkCore;

    public enum PropertyType
    {
        House = 0,
        Apartment = 1,
        Parking = 2,
    }

    public enum PublishStatus
    {
        WaitingValidation = 0,
        Published = 1,
    }

    [Owned]
    public class Location
    {
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; } = 52.52;
        public double Longitude { get; set; } = 13.41;
    }

    public class RealEstateAd
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Location Location { get; set; } = new Location();
        public PropertyType PropertyType { get; set; }
        public PublishStatus PublishStatus { get; set; }
    }
}
