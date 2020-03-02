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
    public class RoomManager
    {
        public static DataTable GetDataTableInfoOfNullBednum(){
            string sql=@"SELECT Room_Num as 房间号,Bed_Num as 床位号,
            Status_R as 床位状态,
            AdministratorOffice as 主管科室 FROM ROOM WHERE PATIENTNAME IS NULL";
            DataTable dataTable=DBOper.GetDataTable(sql);
            return dataTable;
        }

        public static DataTable GetNullBedNum(){
            string sql=@"SELECT COUNT(*) FROM ROOM WHERE PATIENTNAME IS NULL";
            DataTable dataTable=DBOper.GetDataTable(sql);
            return dataTable;
        }//得到空置的床位数量
        public static DataTable GetAllBedNum(){
            string sql=@"SELECT COUNT(*) FROM ROOM";
            DataTable dataTable=DBOper.GetDataTable(sql);
            return dataTable;
        }
        public static DataTable GetDataTableInfo_RoomNumAndBedNum(Room room){
            string sql=@"SELECT Room_Num as 房间号,Bed_Num as 床位号,PatientName as 姓名,
            Sex as 性别,Status_R as 床位状态,AdministratorOffice as 主管科室 from Room
            where Room_Num=@room_Num and Bed_Num=@bed_Num";
            MySqlParameter[] paramArray=new MySqlParameter[]{
                new MySqlParameter("@room_Num",room.Room_Num),
                new MySqlParameter("@bed_Num",room.Bed_Num)
            };
            DataTable dataTable=DBOper.GetDataTable(sql,paramArray);
            return dataTable;
        }

        public static DataTable GetDataTableInfo_PatientName(Room room){
            string sql=@"SELECT Room_Num as 房间号,Bed_Num as 床位号,PatientName as 姓名,
            Sex as 性别,Status_R as 床位状态,AdministratorOffice as 主管科室 from Room
            where PatientName=@patientName";
            MySqlParameter p=new MySqlParameter("@patientName",room.PatientName);
            DataTable dataTable=DBOper.GetDataTable(sql,p);
            return dataTable;
        }
        
        public static DataTable GetDataTableInfo(){
            string sql=@"SELECT Room_Num as 房间号,Bed_Num as 床位号,PatientName as 姓名,
            Sex as 性别,Status_R as 床位状态,AdministratorOffice as 主管科室 from Room";
            DataTable dataTable=DBOper.GetDataTable(sql);
            return dataTable;
        }
        public static bool InsertRoom(Room r){
            string sqlInsert=@"INSERT INTO ROOM VALUES(@room_Num,@bed_Num,@patientRoom,
            @sex,@status_R,@administratorOffice";
            MySqlParameter[] paramArray=new MySqlParameter[]{
                new MySqlParameter("@room_Num",r.Room_Num),
                new MySqlParameter("@bed_Num",r.Bed_Num),
                new MySqlParameter("@patientRoom",r.PatientName),
                new MySqlParameter("@sex",r.Sex),
                new MySqlParameter("@status_R",r.Status_R),
                new MySqlParameter("@administratorOffice",r.AdministratorOffice)
            };
            if(DBOper.ExecuteCommand(sqlInsert,paramArray)==1){
                return true;
            }else{return false;}
        }
        public static bool UpdateRoom(Room room){
            string sqlUpdate=@"Update Room set PatientName=@patientName,
            Sex=@sex,
            Status_R=@status_R
            WHERE Room_Num=@room_Num and
            Bed_Num=@bed_Num";
            MySqlParameter[] parameters=new MySqlParameter[]{
            new MySqlParameter("@patientName",room.PatientName),
                new MySqlParameter("@sex",room.Sex),
                new MySqlParameter("@status_R",room.Status_R),
                new MySqlParameter("@room_Num",room.Room_Num),
                new MySqlParameter("@bed_Num",room.Bed_Num)
            };
            if(DBOper.ExecuteCommand(sqlUpdate,parameters)==1){
                return true;
            }else{
                return false;
            }
        }
        public static bool DeleteTableInfo(Room room){
            string sqlDelete=@"Delete from Room WHERE patientName=@patientName";
            MySqlParameter parameter=new MySqlParameter("@patientName",room.PatientName);
            if(DBOper.ExecuteCommand(sqlDelete,parameter)==1){return true;}
            else{return false;}
        }
        public enum ObejctStatus{
            INSERT,
            UPDATE,
            DELETE,
            SELECT
        }
        public ObejctStatus ObejctOperation{
            get;set;
        }
    }
}