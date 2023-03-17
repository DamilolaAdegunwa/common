//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;
//using System.Linq;

//namespace EFGetStarted
//{
//    //page 1
//    /// <summary>
//    /// Here is the Blogging context for the blogging app
//    /// </summary>
//    public class BloggingContext : DbContext
//    {
//        /// <summary>
//        /// Class mirroring the Blogs table
//        /// </summary>
//        public DbSet<Blog> Blogs { get; set; }
//        /// <summary>
//        /// Class mirroring the Posts table
//        /// </summary>
//        public DbSet<Post> Posts { get; set; }
//        /// <summary>
//        /// string representing the connection string
//        /// </summary>
//        public string DbPath { get; private set; }

//        /// <summary>
//        /// ctor for the blogging context
//        /// </summary>
//        public BloggingContext()
//        {
//            var folder = Environment.SpecialFolder.LocalApplicationData;
//            var path = Environment.GetFolderPath(folder);
//            //DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
//            DbPath = $"Data Source=.;Initial Catalog=blogging.db;Trusted_Connection=true";
//        }

//        // The following configures EF to create a Sqlite database file in the
//        // special "local" folder for your platform.
//        protected override void OnConfiguring(DbContextOptionsBuilder options)
//           // => options.UseSqlite($"Data Source={DbPath}");
//            => options.UseSqlServer($"{DbPath}");
//    }

//    public class Blog
//    {
//        public int BlogId { get; set; }
//        public string Url { get; set; }

//        public List<Post> Posts { get; } = new List<Post>();
//    }

//    /// <summary>
//    /// Post attached to blog
//    /// </summary>
//    public class Post
//    {
//        public int PostId { get; set; }
//        public string Title { get; set; }
//        public string Content { get; set; }

//        public int BlogId { get; set; }
//        public Blog Blog { get; set; }
//    }

//    //page 2

//    internal class Program
//    {
//        private static void Main()
//        {
//            using (var db = new BloggingContext())
//            {
//                // Note: This sample requires the database to be created before running.
//                //Console.WriteLine($"Database connection string: {db.DbPath}.");

//                // Create
//                //Console.WriteLine("Inserting a new blog");
//                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
//                db.SaveChanges();

//                // Read
//                Console.WriteLine("Querying for a blog");
//                var blog = db.Blogs.ToList()
//                    .OrderBy(b => b.BlogId)
//                    .First();

//                // Update
//                Console.WriteLine("Updating the blog and adding a post");
//                blog.Url = "https://devblogs.microsoft.com/dotnet";
//                blog.Posts.Add(
//                    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
//                db.SaveChanges();

//                // Delete
//                Console.WriteLine("Delete the blog");
//                db.Remove(blog);
//                db.SaveChanges();
//            }
//        }
//    }
//}