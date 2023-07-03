using System;
using System.IO;

namespace welcome_api;

public class UserFileRepo : IUserRepo
{
    public string GetUserById(int id)
    {
        using (StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\test.txt"))
        {
            // Read the first line of the file
            string line = sr.ReadLine();

            // Print the line to the console
            return line;
        }
        throw new NotImplementedException();
    }

    public int GetCurrentUserid()
    {
        throw new NotImplementedException();
    }
}
