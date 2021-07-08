using OnlineShop.Data;

namespace OnlineShop.Services
{
    public class DbRepository
    {
        public ApplicationDbContext Context { get; set; }

        public DbRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }

    //public class DbRepository
    //{
    //    private static ApplicationDbContext _context;

    //    private DbRepository()
    //    {
    //        _context = new ApplicationDbContext();
    //    }

    //    public static ApplicationDbContext GetDb()
    //    {
    //        if(_context == null)
    //        {
    //            _context = new DbRepository();
    //        }
    //        return _context;
    //    }
    //}
}
