using System.ComponentModel.DataAnnotations;

namespace EpikiaTest.ViewModel.Actor
{
    public class CreateActorVm
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public ActorType Type { get; set; }
    }
}
