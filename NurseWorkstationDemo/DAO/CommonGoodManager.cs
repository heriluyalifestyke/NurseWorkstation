using System;
using System.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NurseWorkstationDemo.PO;
using NurseWorkstationDemo.Common;
namespace NurseWorkstationDemo.DAO
{
    public class CommonGoodManager
    {
        public static DataTable GetDataTableInfo_CommonGood(CommonGood cw){
            string sql=@"
            SELECT goodname as 公共物品名,
            status_g as 物品状态,
            good_num as 物品编号,
            user_name as 使用者,
            cost as 价格 from CommonGood where user_name=@user_Name
            ";
            MySqlParameter parameter=new MySqlParameter("@user_Name",cw.User_Name);
            DataTable table=DBOper.GetDataTable(sql,parameter);
            return table;
        }
        public static bool InsertInfo_CommonGood(CommonGood cg){
            string sqlInsert=@"
            INSERT INTO COMMONGOOD VALUES(@goodName,@status_G,@good_Num,@user_Name,@cost)
            ";
            MySqlParameter[] pArray=new MySqlParameter[]{
                new MySqlParameter("@goodName",cg.GoodName),
                new MySqlParameter("@status_G",cg.Status_G),
                new MySqlParameter("@good_Num",cg.GoodName),
                new MySqlParameter("@user_Name",cg.User_Name),
                new MySqlParameter("@cost",cg.Cost)
            };
            if(DBOper.ExecuteCommand(sqlInsert,pArray)==1){return true;}else{
                return false;
            }
        }
        public static bool UpdateInfo_CommonGood(CommonGood cg){
            string sqlUpdate=@"
            Update CommonGood set user_name=@user_Name,
            status_G=@status_G,
            where good_Num=@good_Num 
            ";
            MySqlParameter p=new MySqlParameter("@good_Num",cg.Good_Num);
            if(DBOper.ExecuteCommand(sqlUpdate,p)==1){return true;}else{
                return false;
            }
        }
        public static bool DeleteInfo_CommonGood(CommonGood cg){
            string sqlDelete=@"
            Delete from CommonGood where good_Num=@good_Num
            ";
            MySqlParameter parameter=new MySqlParameter("@good_Num",cg.Good_Num);
            if(DBOper.ExecuteCommand(sqlDelete,parameter)==1){
                return true;
            }else{
                return false;
            }
        }
    }
}