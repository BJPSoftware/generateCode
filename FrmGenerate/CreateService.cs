using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BJP.Framework.Repository;
using BJP.Framework.Utility;
using BJP.Framework.Code;

namespace GenerateCode
{
    public class CreateService
    {
        private string excludes = "CREATE_TIME,CREATE_USER,UPDATE_TIME,UPDATE_USER,VERSION,ISDELETE,ORDER_INDEX,EXT_FIELD01,EXT_FIELD02,EXT_FIELD03,EXT_FIELD04,EXT_FIELD05,NODE_LAYER,NODE_INFO,NODE_TYPE,NODE_INFOTYPE";
        public string connectionString { get; set; }
        public DataTable getTableNameList() {
            try
            {
                string sql = "SELECT a.*,";
                sql += "  label = b.value,";
                sql += " PrimaryKey = KCU.COLUMN_NAME";
                sql += " FROM sys.TABLES a";
                sql += " LEFT JOIN  sys.extended_properties b on a.object_id = b.major_id and b.minor_id = 0";
                sql += " LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU ON KCU.TABLE_NAME = a.name";
                sql += " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ON tc.TABLE_NAME = a.name AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'";
                sql += "     AND KCU.CONSTRAINT_NAME = tc.CONSTRAINT_NAME";
                sql += " WHERE a.type = 'U' order by a.name";

                DbHelper dbHelper = new DbHelper(connectionString);
                DataTable dtTableName = dbHelper.Fill(sql);

                return dtTableName;
            }
            catch (Exception ex){
                return null;
            }
        }

        public DataTable getTabbleColumnList(string tableName) {
            try
            {
                DataTable dtColumns = null;
                string sql = string.Format("select * from SYS_T_MENUTABLECOLUMN where table_name='{0}'", tableName);
                DbHelper dbHelper = new DbHelper(connectionString);
                DataTable dtTableName = dbHelper.Fill(sql);
                if (dtTableName.Rows.Count < 1) {
                    string colSql = @"INSERT INTO dbo.SYS_T_MENUTABLECOLUMN
                                        ( COL_D ,
                                          COL_CODE ,
                                          COL_NAME ,
                                          COL_TYPE ,
                                          COL_LENGTH ,
                                          PRIMARY_KEY ,
                                          COL_PRECISION ,
                                          CAN_EDIT ,
                                          CAN_NULL ,
                                          ORDER_INDEX,
                                          DIC_CODE,
                                          COL_DESC,
                                          INPUT_TYPE,
                                          TABLE_NAME
                                        )
                                SELECT   NEWID(),
                                                CONVERT(VARCHAR(16),a.name),
                                                CONVERT(VARCHAR(64),isnull(g.[value],'')),
                                                CONVERT(VARCHAR(16),b.name),
                                                BitLenght=a.length,
                                                IsPK=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype='PK'   and   name   in   (
                                                SELECT   name   FROM   sysindexes   WHERE   indid   in(
                                                SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid
                                                )))   then   '1'   else   '0'   end,
                                                Digits=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                                                1,
                                                CanNull=case   when   a.isnullable=1   then   '1'else   '0'   end,
                                                1,
                                                '',
                                                 CONVERT(VARCHAR(64),isnull(g.[value],'')),
                                                '手工输入',
                                                '{0}'
                                                FROM   syscolumns   a
                                                left   join   systypes   b   on   a.xusertype=b.xusertype
                                                inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'
                                                left   join   syscomments   e   on   a.cdefault=e.id
                                                left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id
                                                left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0
                                                where   d.name='{1}' 
                                                order   by   a.id,a.colorder";
                    dbHelper.Add(string.Format(colSql, tableName,tableName));
                    sql = @"delete from SYS_T_MENUTABLECOLUMN where table_name='{0}' and COL_CODE in ('{1}')";
                    sql = string.Format(sql, tableName, excludes.Replace(",", "','"));
                    dbHelper.Add(sql);

                }
                sql = @"SELECT COL_D , COL_CODE , COL_NAME , COL_TYPE , COL_LENGTH ,ORDER_INDEX,COL_PRECISION,INPUT_TYPE,DIC_CODE,PRIMARY_KEY  ,LIST_DISPLAY , QUICK_QUERY , EXPERT_QUERY ,
                CAN_EDIT ,CAN_NULL , COL_DESC,TABLE_NAME  FROM SYS_T_MENUTABLECOLUMN WHERE TABLE_NAME='{0}' ORDER BY ORDER_INDEX ASC ";

                dtColumns = dbHelper.Fill(string.Format(sql, tableName));

                return dtColumns;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public DataTable resetColumn(string sql,string tableName) {
            try
            {
                DbHelper dbHelper = new DbHelper(connectionString);
                dbHelper.Add(sql);

                return getTabbleColumnList(tableName);
            }
            catch (Exception ex) {
                return null;
            }

        }

        public string PackageNameToDirName(string packageName)
        {
            //将项目的包名转换成目录
            string[] listDir = packageName.Split('.');
            StringBuilder sb = new StringBuilder();
            foreach (string s in listDir)
            {
                sb.Append(s);
                sb.Append("\\");
            }

            return sb.ToString();
        }
    }
}
