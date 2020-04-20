using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace HREFProject
{
    public class HRDbContext: DbContext
    {
        public HRDbContext():base("name=sql")//读连接字符串
        {
            Database.SetInitializer<HRDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());//加载整个程序集的配置类
        }

        public DbSet<salary_standard_details> salary_standard_details { get; set; }
        public DbSet<salar_standard_item> salar_standard_item { get; set; }
        public DbSet<salary_grant> salary_grant { get; set; }
        public DbSet<salary_standard> salary_standard { get; set; }
        public DbSet<salary_grant_details> salary_grant_details { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<config_file_first_kind> config_file_first_kind { get; set; }
        public DbSet<config_file_second_kind> config_file_second_kind { get; set; }
        public DbSet<config_file_third_kind> config_file_third_kind { get; set; }
        public DbSet<config_major> config_major { get; set; }
        public DbSet<config_major_kind> config_major_kind { get; set; }
    }
}
