using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityInfo
{
    [Serializable]
    public class EntityClassPropertyInfo
    {
        public EntityClassPropertyInfo(DataRow drColumn)
        {
            this.PropertyName = drColumn["Name"].ToString();
            this.PropertyType = drColumn["DataType"].ToString();
            this.MaxLength = Convert.ToInt16(drColumn["MaxLength"].ToString());
            this.CanNull = drColumn["CanNull"].ToString();
            this.DefaultValue = drColumn["DefaultValue"].ToString();
            this.ColumnLabel = drColumn["Label"].ToString();
        }

        //列名
        public string PropertyName
        {
            get;
            private set;
        }
        //列的数据类型
        public string PropertyType
        {
            get;
            private set;
        }

        //列的长度
        public int MaxLength
        {
            get;
            private set;
        }
        //是否可为空
        public string CanNull
        {
            get;
            private set;
        }
        //是否有缺省值
        public string DefaultValue
        {
            get;
            private set;
        }
        //列的说明
        public string ColumnLabel
        {
            get;
            private set;
        }

        //public override bool Equals(object obj)
        //{
        //    EntityClassPropertyInfo temp = obj as EntityClassPropertyInfo;
        //    if (this.PropertyName == temp.PropertyName && this.PropertyType == temp.PropertyType)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        
    }
}
