using CTS.Model.Teachers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model.Exams
{
   public class Exams
    {
        public string id { get; set; }
        public string year { get; set; }
        public string title { get; set; }
        public DateTime createddate { get; set; }
        public string createdby { get; set; }
        public string status { get; set; }
        public string querytype { get; set; }
        public List<ListInfo> classes { get; set; }

        public List<ExamWiseSubjectsList> subjects { get; set; }

    }

    public class ExamWiseSubjectsList
    {
        public string subjectid { get; set; }
        public string classid { get; set; }
        public string subject { get; set; }
        public string cutoff { get; set; }
        public string total { get; set; }
        public string obtained { get; set; }
        public string status { get; set; }
    }

    public class ExamReportsData
    {
        public string id { get; set; }
        public string studentname { get; set; }
        public string dob { get; set; }
        public string classname { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public List<ExamWiseSubjectsList> subjects { get; set; }

    }


}
