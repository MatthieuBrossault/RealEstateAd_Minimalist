namespace RealEstateAd_Minimalist
{
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

    public class RealEstateAd
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Localisation { get; set; } = string.Empty;
        public PropertyType PropertyType { get; set; }
        public PublishStatus PublishStatus { get; set; }
    }
}
