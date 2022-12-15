namespace RealEstateAd_Minimalist
{
    using Microsoft.EntityFrameworkCore;

    public class RealEstateAdDb : DbContext
    {
        public RealEstateAdDb(DbContextOptions<RealEstateAdDb> options)
            : base(options) { }

        public DbSet<RealEstateAd> Ads => Set<RealEstateAd>();
    }
}
