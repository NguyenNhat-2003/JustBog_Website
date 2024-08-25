using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebBlog.Data.Models;

namespace WebBlog.Business.Mapper
{
	public static class PostMapper
	{
		public static PostViewModel FromPostToViewModel(this Post post)
		{
			return new PostViewModel
			{
				Id = post.Id,
				Title = post.Title,
				Content = post.Content,
			};
		}
	}
}
