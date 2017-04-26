using System.Collections.Generic;

namespace WebAppDri.Models
{
    public class Kind
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}