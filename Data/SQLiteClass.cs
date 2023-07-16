using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNovelist_Windows.Data
{
    class SQLiteClass
    {
        /// <summary>
        /// 创建数据库
        /// </summary>
        public static void CreateDB()
        {
            var path = @"./123.db";
            SQLiteConnection.CreateFile(path);
            //SQLiteConnection cn = new SQLiteConnection("data source=" + path);
            //cn.Open();
            //cn.Close();
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        static void DeleteDB()
        {
            string path = @"d:\test\123.sqlite";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        /// <summary>
        /// 添加表
        /// </summary>
        public static void CreateTable()
        {
            string path = @"./123.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = cn;
                //cmd.CommandText = "CREATE TABLE t1(id varchar(4),score int)";
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS t1(id varchar(4),score int)";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }

        /// <summary>
        /// 删除表
        /// </summary>
        public static void DeleteTable()
        {
            string path = @"./123.db";
            SQLiteConnection cn = new SQLiteConnection("data source=" + path);
            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DROP TABLE IF EXISTS t1";
                cmd.ExecuteNonQuery();
            }
            cn.Close();
        }
    }
}
