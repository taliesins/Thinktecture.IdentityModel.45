﻿namespace Thinktecture.Samples.Security
{
    public static class UserCredentials
    {
        public static bool Validate(string username, string password)
        {
            return (username == password);
        }
    }
}
