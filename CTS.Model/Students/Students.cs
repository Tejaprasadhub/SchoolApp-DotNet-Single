using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model.Students
{
    public class Students
    {
      public string id { get; set; }
      public string firstName { get; set; }
      public string middleName { get; set; }
      public string lastName { get; set; }
      public int branch { get; set; }
      public string dateofbirth { get; set; }
      public string gender { get; set; }
      public string joineddate { get; set; }
      public string email { get; set; }
      public int classs { get; set; }
      public int section { get; set; }
      public string d_noc { get; set; }
      public string streetc { get; set; }
      public string villagec { get; set; }
      public string countryc { get; set; }
      public string statec { get; set; }
      public string cityc { get; set; }
      public string pincodec { get; set; }
      public string homephn { get; set; }
      public string mblno { get; set; }
      public string d_nop { get; set; }
      public string streetp { get; set; }
      public string villagep { get; set; }
      public string countryp { get; set; }
      public string statep { get; set; }
      public string cityp { get; set; }
      public string pincodep { get; set; }
      public int parent { get; set; }
      public string e1fname { get; set; }
      public string e1lname { get; set; }
      public string e1mobile { get; set; }
      public string e1email { get; set; }
      public string e2fname { get; set; }
      public string e2lname { get; set; }
      public string e2mobile { get; set; }
      public string e2email { get; set; }
      public int indexId { get; set; }
      public int querytype { get; set; }
        public string status { get; set; }

    }

    public class ExamWiseSubjects
    {
        public string id { get; set; }
        public int classid { get; set; }
        public int examid { get; set; }
        public string dropdownfor { get; set; }
        public string type { get; set; }
    }

    public class StudentClassWiseExamMarks
    {
        public string studentId { get; set; }
        public int classId { get; set; }
        public int examId { get; set; }
        public int subjectId { get; set; }
        public string marks { get; set; }
    }

    public class StudentProfileModel
    {
        public string stduentid { get; set; }
        public List<string> data { get; set; }
    }
}
