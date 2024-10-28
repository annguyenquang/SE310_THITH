using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Entities;
using WebApplication1.Model;

namespace WebApplication1.Persistent
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedAccounts = new List<Account>
            {
                new Account {  Id = Guid.NewGuid(), Username = "admin", Password = "admin", Role = AccountRole.Admin },
                new Account {  Id = Guid.NewGuid(), Username = "user", Password = "user", Role = AccountRole.User }
            };
            var seedShoes = new List<Shoe>
            {
                new () {  Id = Guid.NewGuid(), Name = "Nike Air Max 90", Brand = "Nike", Price = 100, Stock = 10, PictureUrl = "https://static.nike.com/a/images/t_PDP_936_v1/f_auto,q_auto:eco/m55is6buar3k4isirw0k/AIR+MAX+90.png" },
                new () {  Id = Guid.NewGuid(), Name = "Adidas Superstar", Brand = "Adidas", Price = 80, Stock = 5, PictureUrl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQ5aPLZv9-TuQejBdX7xycecTrxMRl4azdF_u2ts1GQmbtale2hQxq9xmp8cqZ6p5ZzOmtsCuDOodQZjHud5ZufOJIbocinSSA6Ygt7GPjCTb3OFPvvOcdMpg&usqp=CAc" },
                new () {  Id = Guid.NewGuid(), Name = "Converse Chuck Taylor", Brand = "Converse", Price = 60, Stock = 3, PictureUrl = "https://product.hstatic.net/1000382698/product/162050standard_0f83705012cb41c9930c876853344a92_master.jpg" },
                new ()  {  Id = Guid.NewGuid(), Name = "Nike Air Max 50", Brand = "Nike", Price = 100, Stock = 10, PictureUrl = "https://kicksmaniac.com/zdjecia/2018/04/17/404/56/6867AA3824_001_4.png" },
                new () {  Id = Guid.NewGuid(), Name = "Adidas Superstar 2", Brand = "Adidas", Price = 80, Stock = 5, PictureUrl = "https://assets.adidas.com/images/w_600,f_auto,q_auto/e4a1154466e347f7a00856f0c7327afc_9366/SUPERSTAR_DJen_IH3121_01_standard.jpg" },
                new () {  Id = Guid.NewGuid(), Name = "Converse Chuck TaylorSwitf", Brand = "Converse", Price = 60, Stock = 3, PictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTDoUFSk5h4bCAyn-e_Pwe7C2wkBzfljFPW2g&s" },

            };
            modelBuilder.Entity<Account>().HasData(seedAccounts);
            modelBuilder.Entity<Shoe>().HasData(seedShoes);
        }
    }
}
