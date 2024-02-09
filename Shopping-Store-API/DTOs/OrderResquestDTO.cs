using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.DTOs
{
    public class OrderResquestDTO
    {
        public string? FullName { get; set; }
        public string? AddressName { get; set; }
        public string? City { get; set; }
        public bool? isDefault { get; set; } = false;
    }
}