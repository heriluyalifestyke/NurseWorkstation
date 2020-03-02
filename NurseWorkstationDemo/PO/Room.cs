namespace NurseWorkstationDemo.PO
{
    public class Room
    {
        private string room_Num;
        private string bed_Num;
        private string patientName;
        private string sex;
        private string status_R;
        private string administratorOffice;

        public string Room_Num{
            set{this.room_Num=value;}
            get{return room_Num;}
        }
        public string Bed_Num{
            set{this.bed_Num=value;}
            get{return bed_Num;}
        }
        public string PatientName{
            set{this.patientName=value;}
            get{return patientName;}
        }
        public string Sex{
            set{this.sex=value;}
            get{return sex;}
        }
        public string Status_R{
            set{this.status_R=value;}
            get{return status_R;}
        }
        public string AdministratorOffice{
            set{this.administratorOffice=value;}
            get{return administratorOffice;}
        }
    }
}