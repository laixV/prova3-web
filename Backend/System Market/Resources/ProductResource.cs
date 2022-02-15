using System;
using Super_Market.Domain.Helpers;
using Super_Market.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Super_Market.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnityOfMeasurement UnityOfMeasurement { get; set; }
        public DateTime CreatedAt { get; set; }
       
        
    }
}