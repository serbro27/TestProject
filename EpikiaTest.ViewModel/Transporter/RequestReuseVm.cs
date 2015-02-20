using System;
using System.ComponentModel.DataAnnotations;

namespace EpikiaTest.ViewModel.Transporter
{
    public class RequestReuseVm
    {
        [Required]
        public string TransportersName { get; set; }
        public Guid ContainerId { get; set; }
        public DateTime DateOfReuse { get; set; }
    }
}
