using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Public
{
    /// <summary>
    /// 用于描述属性 对应数据列 元信息的结构，
    /// 用于DAO里面查询外键文本使用
    /// </summary>
    [Serializable]
    public class DBColumn : System.Attribute
    {
        /// <summary>
        /// 注意，使用了反射以后，name和type理应不需要从attribute传进来才对，
        /// 构造函数里面只需要传进“额外”的信息，比如主键、外键这些。
        /// 后面FKClass这些信息用
        /// [FKColumn("deptId", DBType.String, false, true, FKClass = "com.SLS_Survey.Model.T_Dept", FKTable = "T_Dept", FKColumn = "id", FKText = "name")]	
        /// 这种方式写入
        /// </summary>
        public DBColumn(DBColumnType dbColumnType, String FKTable = null, String FKText = null)
        {
            this.dbColumnType = dbColumnType;
            this.FKTable = FKTable;
            this.FKText = FKText;
        }

        public String FKTable { get; set; }
        public String FKText { get; set; }

        public DBColumnType dbColumnType { get; set; }
    }
}
