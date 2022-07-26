using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//DTL and press return now a day a transfer object is a container, basically for moving data between layers
//Data transfer object
namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl {get; set;}

        public string ProductType { get; set; }
        
        public string ProductBrand { get; set; }
    }
}