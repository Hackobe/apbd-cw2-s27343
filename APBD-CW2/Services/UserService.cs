using APBD_CW2.Models;

namespace APBD_CW2.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}