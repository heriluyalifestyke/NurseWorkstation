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
    public class PatientManager
    {
        //setting a patient object to operate all information of one 
    //public static Patient patient=new Patient();
        //read
        public static DataTable GetPatientInfoExistRoom(){
            string sql=@"SELECT AGE,In_HospitalNum,In_Date FROM PATIENT WHERE PatientName in (SELECT 
PATIENTNAME FROM ROOM)";
DataTable table=DBOper.GetDataTable(sql);
return table;
        }
        public static DataTable GetPatientInfo_FromPatientName(Patient p){
            string sql=@"SELECT PatientName as 姓名,age as 年龄,sex as 性别,
            idcard_num as 身份证号,
            In_HospitalNum as 住院号,
        Major_Doctor as 主管医师,
        Main_Symptom as 主要症状,
        Phone_Num as 电话号码,
        In_Date as 入院日期 from Patient where patientName=@patientName";
            MySqlParameter parameter=new MySqlParameter("@patientName",p.PatientName);
            DataTable dataTable=DBOper.GetDataTable(sql,parameter);
            return dataTable;
        }
        public static DataTable GetPatientInfo_FromInHospitalNum(Patient p){
            string sql=@"SELECT PatientName as 姓名,age as 年龄,sex as 性别,
            idcard_num as 身份证号,
            In_HospitalNum as 住院号,
        Major_Doctor as 主管医师,
        Main_Symptom as 主要症状,
        Phone_Num as 电话号码,
        In_Date as 入院日期 from Patient where in_HospitalNum=@in_HospitalNum";
            MySqlParameter parameter=new MySqlParameter("@in_HospitalNum",p.In_HospitalNum);
            DataTable dataTable=DBOper.GetDataTable(sql,parameter);
            return dataTable;
        }
        //insert
        public static bool InsertIntoPatient(Patient p){
            string sqlInsert=@"insert into patient values(
                @patientName,@age,@sex,@idCard_Num,@in_HospitalNum,@major_Doctor,
                @main_Symptom,@phone_Num,@in_Date
            )";
            MySqlParameter[] paramArray=new MySqlParameter[]{
                new MySqlParameter("@patientname",p.PatientName),
                new MySqlParameter("@age",p.Age),
                new MySqlParameter("@sex",p.Sex),
                new MySqlParameter("@idCard_Num",p.IdCard_Num),
                new MySqlParameter("@in_HospitalNum",p.In_HospitalNum),
                new MySqlParameter("@major_Doctor",p.Major_Doctor),
                new MySqlParameter("@main_Symptom",p.Main_Symptom),
                new MySqlParameter("@phone_Num",p.Phone_Num),
                new MySqlParameter("@in_Date",p.In_Date)
            }; 
            if(DBOper.ExecuteCommand(sqlInsert,paramArray)==1){
            return true;
            }
            else{
                return false;}
        }
        public static bool UpdatePatient(Patient p){
            string sqlUpdate=@"Update Patient set age=@age, 
            sex=@sex,idcard_num=@idCard_Num,in_hospitalnum=@in_HospitalNum,
            major_doctor=@major_Doctor,
            main_symptom=@main_Symptom,
            phone_num=@phone_Num,
            in_date=@in_Date
            where PatientName=@patientName
            ";
            MySqlParameter[] param=new MySqlParameter[]{
                new MySqlParameter("@age",p.Age),
                new MySqlParameter("@sex",p.Sex),
                new MySqlParameter("@idCard_Num",p.IdCard_Num),
                new MySqlParameter("@in_HospitalNum",p.In_HospitalNum),
                new MySqlParameter("@major_Doctor",p.Major_Doctor),
                new MySqlParameter("@main_Symptom",p.Main_Symptom),
                new MySqlParameter("@phone_Num",p.Phone_Num),
                new MySqlParameter("@in_Date",p.In_Date)
            };
            MySqlParameter pIn=new MySqlParameter("@patientName",p.PatientName);
            if(DBOper.ExecuteCommand(sqlUpdate,pIn,param)==1){
            
            return true;
            }else{
                return false;
                }
        }
        public static bool DeletePatient(Patient p){
            string sqlDelete=@"Delete from Patient where patientname=@patientName";
            MySqlParameter parameter=new MySqlParameter("@patientName",p.PatientName);
            if(DBOper.ExecuteCommand(sqlDelete,parameter)==1){
                return true;
                }else{
                    return false;
            }
        }
    }
}