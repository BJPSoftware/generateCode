using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EntityInfo
{
    [Serializable]
    public class EntityClassInfo
    {
        public string tableName { get; set; }    //指定的数据表名
        public string className { get; set; }   //要生成的类的名称
        public string packageName { get; set; }  //指定的包名
        public DataTable dataTable { get; set; }  //列信息指定的数据表
        
        //指定表的列属性
        public List<EntityClassPropertyInfo> RopertyList
        {
            get;
            private set;
        }
        public EntityClassInfo()
        {
            //this.ClassName = dt.TableName;

            //List<EntityClassPropertyInfo> ropertyListTemp = new List<EntityClassPropertyInfo>();
           
            //foreach (DataColumn dcol in dt.Columns)
            //{
            //    ropertyListTemp.Add(new EntityClassPropertyInfo(dcol));
            //}
            //this.RopertyList = ropertyListTemp;

            //List<EntityClassPropertyInfo> primaryKeyListTemp = new List<EntityClassPropertyInfo>();
            //List<EntityClassPropertyInfo> notPrimaryKeyListTemp = new List<EntityClassPropertyInfo>(ropertyListTemp);
            //foreach (DataColumn dcol in dt.PrimaryKey)
            //{
            //    primaryKeyListTemp.Add(new EntityClassPropertyInfo(dcol));
            //    notPrimaryKeyListTemp.Remove(new EntityClassPropertyInfo(dcol));
            //}
            //this.PrimaryKeyList = primaryKeyListTemp;
            //this.NotPrimaryKeyList = notPrimaryKeyListTemp;
        }

        public void createColumnInfo()
        {
            List<EntityClassPropertyInfo> ropertyListTemp = new List<EntityClassPropertyInfo>();
            foreach (DataRow dr in dataTable.Rows)
            {
                ropertyListTemp.Add(new EntityClassPropertyInfo(dr));
            }
            this.RopertyList = ropertyListTemp;
        }
    }
}