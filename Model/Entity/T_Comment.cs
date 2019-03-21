using Model.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    [Serializable]
    public class T_Comment : BaseEntity<T_Comment>
    {
        public int id { get; set; }
        public int? userId { get; set; }

        [DBColumn(DBColumnType.ForeignKey, "t_comment", "name")]
        [ForeignKey("userId")]
        public T_User userEntity { get; set; }

        public int? goodsId { get; set; }

        [DBColumn(DBColumnType.ForeignKey, "t_comment", "name")]
        [ForeignKey("goodsId")]
        public T_Goods goodsEntity { get; set; }

        public String content { get; set; }
        public String picture { get; set; }
        public int? grade { get; set; }
    }
}
