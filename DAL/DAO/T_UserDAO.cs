using DAL.Public;
using EF;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.DAO
{
    public class T_UserDAO : BaseDAO<T_User>
    {
        public T_User getByAccount(String account)
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T_User>().Where(e => e.account == account).FirstOrDefault();
        }

        public T_User getByOpenid(String openid)
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T_User>().Where(e => e.openid == openid).FirstOrDefault();
        }
    }
}
