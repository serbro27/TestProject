using System;
using System.ComponentModel.DataAnnotations;

namespace EpikiaTest.ViewModel.Transporter
{
    public class AddCreditsVm
    {
        [Required]
        public string Name { get; set; }
        [Range(0, Double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
