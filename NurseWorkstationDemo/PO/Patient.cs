using System;
namespace NurseWorkstationDemo.PO
{
    public class Patient
    {
        private string patientName;
        private int age;
        private string sex;
        private string in_HospitalNum;
        private string major_Doctor;
        private string main_Symptom;
        private string idCard_Num;
        private string phone_Num;
        private DateTime in_Date;
        public Patient(){}
        public string PatientName{
            set{this.patientName=value;}
            get{return patientName;}
        }
        public int Age{
            set{this.age=value;}
            get{return age;}
        }
        public string Sex{
            set{this.sex=value;}
            get{return sex;}
        }
        public string In_HospitalNum{
        set{this.in_HospitalNum=value;}
        get{return in_HospitalNum;}
        }
        public string Main_Symptom{
            set{this.main_Symptom=value;}
            get{return main_Symptom;}}
        public string Major_Doctor{
            set{this.major_Doctor=value;}
        get{return major_Doctor;}}
        public string IdCard_Num{
            set{this.idCard_Num=value;}
            get{return idCard_Num;}
        }
        public string Phone_Num{
            set{this.phone_Num=value;}
            get{return phone_Num;}
        }
        public DateTime In_Date{
            set{this.in_Date=value;}
            get{return in_Date;}
        }
    }
}