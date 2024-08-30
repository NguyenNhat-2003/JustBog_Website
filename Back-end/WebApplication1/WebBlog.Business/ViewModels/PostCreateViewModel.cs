﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBlog.Business.ViewModels
{
    public class PostCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string UrlSlug { get; set; }
        public Guid CategoryId { get; set; }
        public bool Published { get; set; }
    }
}
