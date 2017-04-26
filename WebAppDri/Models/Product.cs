namespace WebAppDri.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int KindId { get; set; }
        public Kind Kind { get; set; }
    }    
}