using System;

namespace welcome_api;

public interface IUserRepo
{
    int GetCurrentUserid();
    string GetUserById(int id);
}
