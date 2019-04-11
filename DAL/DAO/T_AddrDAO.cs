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

        public List<T_Addr> GetByUserId(int userId)
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T_Addr>().Where(e => e.userId == userId).OrderByDescending(e => e.userId).ToList();
        }

        public int SetDefaultAddrIsFalseByUserId(int userId)
        {
            StoreDbContext db = new StoreDbContext();
            List<T_Addr> list = db.Set<T_Addr>().Where(e => e.userId == userId).ToList();
            int c = 0;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].defaultAddr = 0;
                c++;
            }

            db.SaveChanges();
            return c;
        }

    }
}
