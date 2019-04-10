using DAL.Public;
using EF;
using Microsoft.EntityFrameworkCore;
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

        public List<T_Addr> GetByUserId(String userId)
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T_Addr>().Where(e => e.userId == int.Parse(userId)).OrderByDescending(e => e.userId).ToList();
        }

    }
}
