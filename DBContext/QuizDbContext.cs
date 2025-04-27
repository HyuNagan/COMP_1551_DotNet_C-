using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP1551.QuestionContext;
using Microsoft.EntityFrameworkCore;

namespace COMP1551.DBContext
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        string connectionString = "Server = HYUNITRO5\\SA;Database = QuizGameDB;" +
            "User Id=sa;Password = 123456;" +
            "Trusted_Connection = True;" +
            "TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
