using CustomerSupport.Application.DTOs.Auth;
using CustomerSupport.Domain.Entities;
using CustomerSupport.Domain.Enums;

namespace CustomerSupport.Application.Mappings
{
    public static class UserMappingExtensions
    {
        public static User ToEntity(this RegisterRequestDTO request)
        {
            return new User
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim(),
                PhoneNumber = request.PhoneNumber?.Trim(),

                // Public self-registration always creates a Customer.
                // The client must never be allowed to register itself
                // as a Support Executive or Administrator.
                RoleId = RoleType.Customer,

                // Newly registered users are active by default.
                IsActive = true
            };
        }

        public static UserResponseDTO ToResponseDTO(this User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}".Trim(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.RoleId.ToString(),
                IsActive = user.IsActive
            };
        }
    }
}
