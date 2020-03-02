namespace NurseWorkstationDemo.PO
{
    public class CommonGood
    {
        private string goodName;
        private string  status_G;
        private string   good_Num;
        private string user_Name;
        private int cost;
        public  string GoodName{
            set{this.goodName=value;}
            get{return goodName;}
        }
        public string Status_G{
            set{this.status_G=value;}
            get{return status_G;}
        }
        public string Good_Num{
            set{this.good_Num=value;}
            get{return good_Num;}
        }
        public string User_Name{
            set{this.user_Name=value;}
            get{return user_Name;}
        }
        public int Cost{
            set{this.cost=value;}
            get{return cost;}
        }
    }
}