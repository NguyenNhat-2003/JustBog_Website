﻿namespace WebBlog.Business
{
    public class RegisterViewModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
