using System;

namespace welcome_api;

public class UserRepo : IUserRepo
{
    public string GetUserById(int id)
    {
        return "Aman";
    }

    public int GetCurrentUserid()
    {
        throw new NotImplementedException();
    }
}
