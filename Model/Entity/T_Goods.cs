using Model.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class T_Goods : BaseEntity<T_Goods>
    {
        public int id { get; set; }
        public String name { get; set; }
        public decimal? price { get; set; }
        public String presentation { get; set; }
        public int? inventory { get; set; }
        public String pictureUrl1 { get; set; }
        public String pictureUrl2 { get; set; }
        public String pictureUrl3 { get; set; }
        public String pictureUrl4 { get; set; }
        public String pictureUrl5 { get; set; }
    }
}
