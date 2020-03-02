using System;
using System.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace NurseWorkstationDemo.Common
{
    public class DBOper
    {
        private static MySqlConnection connection;
        public static MySqlConnection Connection{
            get{
                if(connection==null){
                    string connStr=ConfigurationManager.ConnectionStrings["NurseWorkstationDemo"]
                    .ConnectionString;
                    connection=new MySqlConnection(connStr);
                    connection.Open();
                }else if(connection.State==System.Data.ConnectionState.Closed){
                    connection.Open();
                }else if(connection.State==System.Data.ConnectionState.Broken){
                    connection.Ping();
                }
            return connection;
            }
        }
        public static int ExecuteCommand(string sql){
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            return cmd.ExecuteNonQuery();
        }
        public static int ExecuteCommand(string sql,params MySqlParameter[] v)
        {
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            cmd.Parameters.AddRange(v);
            return cmd.ExecuteNonQuery();
        }
        public static int ExecuteCommand(string sql,MySqlParameter p,params MySqlParameter[] v)
        {
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            cmd.Parameters.Add(p);
            cmd.Parameters.AddRange(v);
            return cmd.ExecuteNonQuery();
        }
        public static MySqlDataReader GetReader(string sql){
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            return cmd.ExecuteReader();
        }
        public static MySqlDataReader GetReader(string sql,params MySqlParameter[] v){
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            cmd.Parameters.AddRange(v);
            return cmd.ExecuteReader();
        }
        public static DataTable GetDataTable(string sql){
            MySqlDataAdapter dataAdapter=new MySqlDataAdapter(sql,Connection);
            DataSet ds=new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetDataTable(string sql,params MySqlParameter[] v){
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            cmd.Parameters.AddRange(v);
            MySqlDataAdapter dataAdapter=new MySqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetDataTable(string sql,MySqlParameter v){
            MySqlCommand cmd=new MySqlCommand(sql,Connection);
            cmd.Parameters.Add(v);
            MySqlDataAdapter dataAdapter=new MySqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}