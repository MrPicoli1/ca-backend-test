﻿namespace BackendTest.API.Models
{
    public class UserModel
    {
        public string? Name { get;  set; }
        public string? Email { get;  set; }
        public string? Address { get;  set; }

        public bool IsNull() { return  Name == null || Email == null || Address == null; }
    }
}
