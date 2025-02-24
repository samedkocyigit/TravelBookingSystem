using UserService.Domain.Models;

namespace UserService.Domain.Dtos.UserDtos
{
    public class UserDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public int age { get; set; }
        public string nationality { get; set; }
        public DateTime birthday { get; set; }
        public List<Payment> payments { get; set; }
        public List<Guid> flightBookingIds { get; set; }
        public List<Guid> hotelBookingIds { get; set; }

    }
}
