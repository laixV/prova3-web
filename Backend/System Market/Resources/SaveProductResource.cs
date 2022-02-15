using Super_Market.Domain.Helpers;
using Super_Market.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Super_Market.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnityOfMeasurement UnityOfMeasurement { get; set; }
        [Required]
        public int CategoryId { get; set; }
     
    }
}
