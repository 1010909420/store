using EF;
using Microsoft.EntityFrameworkCore;
using Model.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Public
{
    public class BaseDAO<T> where T : BaseEntity<T>
    {
        //StoreDbContext db = new StoreDbContext();

        public IQueryable<T> GetAll()
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T>();
        }

        /// <summary>
        /// 根据id获取，返回对象无外键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            StoreDbContext db = new StoreDbContext();
            return db.Set<T>().Find(id);
        }

        public int Add(T entity)
        {
            StoreDbContext db = new StoreDbContext();
            db.Set<T>().Add(entity);
            return db.SaveChanges();
        }

        public int Update(T entity)
        {
            StoreDbContext db = new StoreDbContext();
            db.Entry(entity).State = EntityState.Modified;
            //db.SaveChanges();
            return db.SaveChanges();
        }

        public int DelById(int id)
        {
            StoreDbContext db = new StoreDbContext();
            T entity = GetById(id);
            db.Set<T>().Remove(entity);
            return db.SaveChanges();
        }




        /// <summary>
        /// 根据条件查询，返回IQueryable，需要引入外键对象须手动Include，最后记得ToList
        /// </summary>
        /// <param name="total">符号条件的总记录数</param>
        /// <param name="strWhere">文本查询条件</param>
        /// <param name="where">查询条件lambda表达式</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页记录数，-1表示不分页全部取出</param>
        /// <param name="orderBy">排序条件lambda表达式</param>
        /// <param name="isDescending">是否降序</param>
        /// <returns></returns>
        public IQueryable<T> Search(
            ref int total,
            String strWhere = "",
            Expression<Func<T, bool>> where = null,
            Expression<Func<T, dynamic>> orderBy = null,
            bool isDescending = true,
            int page = 1,
            int size = 10
           )
        {

            StoreDbContext db = new StoreDbContext();

            IQueryable<T> result; //最终查询结果
            IQueryable<T> query; //初次查询

            if (where == null) //如果不设条件，则取出所有
            {
                if (!String.IsNullOrWhiteSpace(strWhere))
                {
                    //如果有文本查询条件
                    where = JoinStrWhere(strWhere);
                    query = db.Set<T>().Where(where);
                }
                else
                {
                    query = db.Set<T>();
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(strWhere))
                {
                    //如果有文本查询条件，则讲两个条件 and 连接起来
                    where = where.And(JoinStrWhere(strWhere));
                    query = db.Set<T>().Where(where);
                }
                else
                {
                    query = db.Set<T>().Where(where);
                }
            }

            total = query.Count();//查出总记录数

            //然后再执行排序和分页
            if (orderBy == null)
            {
                //如果没有排序条件，直接按默认排序进行分页
                if (size > 0)
                    result = query.Skip((page - 1) * size).Take(size);
                else
                    result = query;//如果size < 0，则不需要二次处理IQueryable                
            }
            else
            { //如果有排序条件
                if (size <= 0) //如果size < 0，则不需要进行分页
                {
                    if (isDescending) //逆序（降序）
                        result = query.OrderByDescending(orderBy);
                    else //正序
                        result = query.OrderBy(orderBy);
                }
                else
                { //size > 0，进行分页处理
                    if (isDescending) //逆序（降序）
                        result = query.OrderByDescending(orderBy).Skip((page - 1) * size).Take(size);
                    else //正序
                        result = query.OrderBy(orderBy).Skip((page - 1) * size).Take(size);
                }
            }

            return result;
        }

        public String test(
            String strWhere
           )
        {
            StoreDbContext db = new StoreDbContext();
            Expression<Func<T, bool>> where = null;

            IQueryable<T> query; //初次查询

            if (where == null) //如果不设条件，则取出所有
            {
                if (!String.IsNullOrWhiteSpace(strWhere))
                {
                    //如果有文本查询条件
                    where = JoinStrWhere(strWhere);
                    query = db.Set<T>().Where(where);
                }
                else
                {
                    query = db.Set<T>();
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(strWhere))
                {
                    //如果有文本查询条件，则讲两个条件 and 连接起来
                    where = where.And(JoinStrWhere(strWhere));
                    query = db.Set<T>().Where(where);
                }
                else
                {
                    query = db.Set<T>().Where(where);
                }
            }

            return where.ToString();
        }


        /// <summary>
        /// 更新多条记录（尚未测试）
        /// </summary>
        /// <param name="entities">待更新的对象的集合</param>
        /// <returns>影响行数</returns>
        public int BatchUpdate(List<T> entities)
        {

            StoreDbContext db = new StoreDbContext();

            //这里应当加上事务，其中一条出现错误应该回滚

            entities.ForEach(m =>
            {
                db.Entry<T>(m).State = EntityState.Modified;
            });
            return db.SaveChanges();
        }

        private static Dictionary<String, DBColumn> ColumnTypes = null;

        /// <summary>
        /// 通过反射获取某个类对应的所有列名，原则上应该只允许内部调用，之所以公开是方便调试
        /// </summary>
        public static Dictionary<String, DBColumn> GetColumnTypes()
        {
            if (ColumnTypes == null) //如果没有则构造数据
            {
                ColumnTypes = new Dictionary<String, DBColumn>();

                foreach (System.Reflection.PropertyInfo p in typeof(T).GetProperties())
                {
                    //没有自定义attribute的则是常规数据列                    
                    String type = p.PropertyType.ToString();
                    if (type.Contains("System.Int") || type.Contains("System.Double") || type.Contains("System.float"))
                    {
                        ColumnTypes[p.Name] = new DBColumn(DBColumnType.Numeric);
                    }
                    else if (type.Contains("System.DateTime"))
                    {
                        ColumnTypes[p.Name] = new DBColumn(DBColumnType.DateTime);
                    }
                    else if (type.Contains("System.Boolean"))
                    {
                        ColumnTypes[p.Name] = new DBColumn(DBColumnType.Bool);
                    }
                    else if (type.Contains("System.String"))
                    {
                        ColumnTypes[p.Name] = new DBColumn(DBColumnType.String);
                    }

                    try
                    {
                        //判断是否有自定义Attribute，如果有，取出第一条（因为我只会写入一条，不存在多条）
                        if (p.GetCustomAttributes(false).Length > 0)
                        {
                            //读取出的自定义attribute是Object[]，需要强制转换，理论上是有可能出现转换错误异常的
                            DBColumn column = (DBColumn)p.GetCustomAttributes(false)[0];

                            ColumnTypes[p.Name] = column;//对于外键列来说，主要是获取表名和需要查询文本的列名而已（一般是那些“name”列）
                        }
                    }
                    catch (Exception ex)
                    {
                        //尝试读取自定义Annotation，出错不处理直接跳过
                    }
                }
            }

            return ColumnTypes;
        }

        /// <summary>
        /// 简单来说，是要生成类似这样的lambda表达式，做全字段查询
        /// IQueryable.Where(p => (p.name + p.createTime.Value.ToString("yyyy-MM-dd")).Contains("瓜"));
        /// 注意这个方法会同时搜索一级外键里面的字符串，当然如果要关闭的话只关闭 switch case DBColumnType.ForeignKey:这部分即可
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        private Expression<Func<T, bool>> JoinStrWhere(String strWhere)
        {
            Expression<Func<T, bool>> where = PredicateBuilder.True<T>();

            String[] list = strWhere.Trim().Split(" "); //将所有关键字以空格切割

            foreach (String subStrWhere in list)
            {
                if (String.IsNullOrWhiteSpace(subStrWhere.Trim()))
                {
                    continue; //空关键字直接跳过
                }

                Dictionary<String, DBColumn> cols = GetColumnTypes(); //调用静态方法 

                ////构建Lambda表达式
                var parameter = Expression.Parameter(typeof(T), "p");

                Expression constant;
                ////临时的表达式左侧 like: p.Name
                Expression left;
                Expression text = Expression.Constant(""); //常量表达式，空字符串，拼接用

                ////不直接反射，只在第一次执行反射
                foreach (String columnName in cols.Keys)
                {
                    
                    //这里可能会出现读取属性值为空的情况，空值理应不处理，直接跳过该字段
                    try
                    {
                        DBColumn column = cols[columnName];
                        if (column.dbColumnType == DBColumnType.Bool)
                            continue; //布尔值类型不作查询处理，直接跳过

                        left = Expression.PropertyOrField(parameter, columnName); //先读取对象属性值，如果是字符串则不需要二次处理

                        switch (column.dbColumnType)
                        {
                            case DBColumnType.Numeric:
                                //注意空值
                                left = Expression.Call(left,
                                    "ToString", null
                                    ); //数字型字段的处理方式，构建表达式树来调用ToString方法
                                text = Expression.Add(text, left, typeof(String).GetMethod("Concat", new[] { typeof(string), typeof(string) }));
                                break;

                            case DBColumnType.DateTime:
                                //注意空值调用Value会报错
                                left = Expression.PropertyOrField(left, "Value");
                                left = Expression.Call(left,
                                    "ToString", null,
                                    Expression.Constant("yyyy-MM-dd")); //时间字段的处理方式，构建表达式树来调用方法
                                break;
                            case DBColumnType.ForeignKey:
                                //如果是外键
                                String FkText = cols[columnName].FKText; //获得外键列
                                left = Expression.PropertyOrField(left, FkText);//原则上外键列应该都是字符串类型，就不ToString了，有异常直接跳过
                                break;
                        }

                        //最终都要拼接
                        text = Expression.Add(text, left, typeof(String).GetMethod("Concat", new[] { typeof(string), typeof(string) }));

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                        continue; //这里可能会出现读取属性值为空的情况，空值理应不处理，直接跳过该字段
                    }
                    ////表达式右侧，比较值， like '张三'
                    //var right = Expression.Constant(strWhere);
                }

                constant = Expression.Call(text,
                        "Contains", null,
                        Expression.Constant(subStrWhere));

                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, Boolean>>(constant, parameter);
                where = where.And(lambda);
            }

            return where;
        }

        /// <summary>
        /// 根据类的列名返回想要的orderBy表达式，
        /// 如果害怕反射会影响性能，可以考虑将结果存到静态成员
        /// （由于order by子句不出现在底层sql里，故猜测EF会将sql返回的结果二次处理，可能这个才是性能瓶颈）
        /// </summary>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        public Expression<Func<T, dynamic>> GetOrderByFromColName(String colName)
        {
            var param = colName;
            var propertyInfo = typeof(T).GetProperty(param);
            Expression<Func<T, dynamic>> orderByAddress = (x => propertyInfo.GetValue(x, null));
            return orderByAddress;
        }

    }
}
