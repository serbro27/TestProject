using System;
using System.ComponentModel.DataAnnotations;

namespace EpikiaTest.ViewModel.Carrier
{
    public class AddContainerVm
    {
        [Required]
        public string CarrierName { get; set; }
        [Range(0, Int32.MaxValue)]
        public int Size { get; set; }
        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}
