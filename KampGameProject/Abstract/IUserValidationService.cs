using KampGameProject.Entities;

namespace KampGameProject.Abstract
{
    public interface IUserValidationService
    {
        bool Validate(User user);
    }
}
