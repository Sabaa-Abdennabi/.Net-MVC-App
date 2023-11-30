namespace Movie.Models
{
    public class memebrshiptypes
    {
        public int id { get; set; }
        public float SignUpFee { get; set; }
        public int DurationMonth { get; set; }
        public float DiscountRate { get; set; }
        public ICollection<Customers>? Customers { get; set; }
    }
}
