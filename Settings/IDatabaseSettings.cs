namespace AkademiQMongoDb.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string TeamCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string BannerCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string MessageCollectionName { get; set; }
        public string GalleryCollectionName { get; set; }
        public string WhyUsCollectionName { get; set; }
        public string TeamsSocialLinkCollectionName { get; set; }
        public string AdminCollectionName { get; set; }
        public string BasketCollectionName { get; set; }
        public string SubscriberCollectionName { get; set; }
    }
}
