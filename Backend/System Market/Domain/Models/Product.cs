using System;
using Super_Market.Domain.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Super_Market.Domain.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnityOfMeasurement UnityOfMeasurement { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public Category Category { get; set; }
    }
}