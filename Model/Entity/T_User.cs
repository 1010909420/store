using Model.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    [Serializable]
    public class T_User : BaseEntity<T_User>
    {
        public int id { get; set; }
        public String account { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public int? age { get; set; }
        public int? sex { get; set; }
        public int? level { get; set; }
    }
}
