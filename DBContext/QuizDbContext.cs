using System;
using COMP1551.QuestionContext;
using Microsoft.EntityFrameworkCore;

namespace COMP1551.DBContext
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string server = "HYUNITRO5\\SA";
            string database = "QuizGameDB";
            string userId = "sa";
            string password = "123456";
            bool trustedConnection = true;
            bool trustServerCertificate = true;

            // Xây dựng connection string trong phương thức OnConfiguring
            string connectionString = $"Server={server};Database={database};" +
                                      $"User Id={userId};Password={password};" +
                                      $"Trusted_Connection={trustedConnection};TrustServerCertificate={trustServerCertificate};";

            // Cấu hình DbContext để sử dụng connection string
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
