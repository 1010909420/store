using Model.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    [Serializable]
    public class T_Addr : BaseEntity<T_Addr>
    {
        public int id { get; set; }

        public int? userId { get; set; }

        [DBColumn(DBColumnType.ForeignKey, "t_addr", "name")]
        [ForeignKey("userId")]
        public virtual T_User userEntity { get; set; }

        public String addr { get; set; }
        public String mobile { get; set; }
        public String name { get; set; }
        public int defaultAddr { get; set; }
    }
}
