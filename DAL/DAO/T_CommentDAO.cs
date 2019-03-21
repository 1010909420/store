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
    public class T_CommentDAO : BaseDAO<T_Comment>
    {
        StoreDbContext db = new StoreDbContext();

        public IQueryable<T_Comment> getByGoodsId(int goodsId)
        {
            return db.Set<T_Comment>().Where(e => e.goodsId == goodsId).Include(e => e.userEntity).Include(e => e.goodsEntity);
        }

        public static implicit operator T_CommentDAO(T_GoodsDAO v)
        {
            throw new NotImplementedException();
        }
    }
}
