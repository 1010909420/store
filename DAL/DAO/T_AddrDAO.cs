using DAL.Public;
using EF;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.DAO
{
    public class T_AddrDAO : BaseDAO<T_Addr>
    {
        public List<T_Addr> test()
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T_Addr>().ToList();
        }

    }
}
