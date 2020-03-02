CREATE DATABASE NURSEWORKSTATIONDEMO;
CREATE TABLE Patient(
    PatientName CHAR(8) PRIMARY KEY,
    Age INT(4),
    Sex CHAR(2),
    IdCard_Num CHAR(24),
    In_HospitalNum CHAR(8),
    Major_Doctor CHAR(8),
    Main_Symptom VARCHAR(64),
    Phone_Num CHAR(16),
    In_Date DATE
);
CREATE TABLE ROOM(
    Room_Num CHAR(8),
    Bed_Num CHAR(8),
    PatientName CHAR(8),
    Sex CHAR(2),
    Status_R CHAR(6),
    AdministratorOffice CHAR(8),
    PRIMARY KEY(Room_Num,Bed_Num),
    CONSTRAINT FOR_pATIENTNAME
    FOREIGN KEY (PatientName) REFERENCES Patient(PatientName)
);
CREATE TABLE CommonGood(
    GoodName CHAR(8),
    Cost INT(4),
    STATUS_G CHAR(4),
    Good_Num VARCHAR(8) PRIMARY KEY,
    USER_NAME CHAR(8),
    CONSTRAINT FOR_username
    FOREIGN KEY (USER_NAME) REFERENCES Patient(PatientName)
);

INSERT INTO Patient VALUES("贾晓燕",21,"女","142202199812010045","C000001","吴海峰","咳嗽",
"18945696529",'2020-02-23');
INSERT INTO Patient VALUES("安志萍",21,"女","142202199812010089","C000002","吴海峰","咳嗽",
"18945691029",'2020-03-02');
INSERT INTO Patient VALUES("郭文静",21,"女","1422021998120100833","C000003","吴海峰","咳嗽",
"18945691256",'2020-03-02');
INSERT INTO ROOM VALUES("101","001","贾晓燕","女","占用","呼吸科");
insert INTO ROOM(Room_Num,Bed_Num,Status_R,AdministratorOffice) VALUES("101","002","未占用","妇科"); 
insert INTO ROOM(Room_Num,Bed_Num,Status_R,AdministratorOffice) VALUES("101","003","未占用","妇科"); 
insert INTO ROOM(Room_Num,Bed_Num,Status_R,AdministratorOffice) VALUES("101","004","未占用","妇科"); 
insert INTO ROOM(Room_Num,Bed_Num,Status_R,AdministratorOffice) VALUES("101","005","未占用","妇科"); 
insert INTO ROOM(Room_Num,Bed_Num,Status_R,AdministratorOffice) VALUES("101","001","未占用","外科"); 
UPDATE Patient SET PatientName="贾晓燕" WHERE Room_Num="101" AND Bed_Num="001";
Update Room set PatientName="郭文静",
            Sex="女",
            Status_R="占用"
            WHERE (Room_Num="101" AND
            Bed_Num="005");
SELECT PatientName as 姓名,age as 年龄,sex as 性别,
            idcard_num as 身份证号,
            In_HospitalNum as 住院号,
        Major_Doctor as 主管医师,
        Main_Symptom as 主要症状,
        Phone_Num as 电话号码,
        In_Date as 入院日期 from Patient where patientName="贾晓燕";
SELECT Room_Num as 房间号,Bed_Num as 床位号,PatientName as 姓名,
            Sex as 性别,Status_R as 床位状态,AdministratorOffice as 主管科室 from Room
            where Room_Num="101" and Bed_Num="001";
SELECT AGE,In_HospitalNum,In_Date FROM PATIENT WHERE PatientName in (SELECT 
PATIENTNAME FROM ROOM);
delete from room; 