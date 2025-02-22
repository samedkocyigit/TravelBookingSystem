using UserService.Domain.Models;

namespace UserService.Domain.Dtos.UserDtos
{
    public class UpdateUserAfterPaymentsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
