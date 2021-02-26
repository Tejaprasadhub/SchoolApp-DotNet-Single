using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model.Teachers
{
   public class Teachers
    {
        public string id { get; set; }
        public string teachername { get; set; }
        public string mobilenumber { get; set; }
        public DateTime dob { get; set; }
        public string experience { get; set; }
        public string email { get; set; }
        public List<ListInfo> qualifications { get; set; }
        public string branchtitle { get; set; }
        public string branch { get; set; }

        public string gender { get; set; }
        public string createddate { get; set; }
        public string createdby { get; set; }
        public List<ListInfo> classes { get; set; }
        public List<ListInfo> sections { get; set; }
        public List<ListInfo> subjects { get; set; }

    }

    public class ListInfo
    {
        public string label { get; set; }
        public string value { get; set; }
    }


    public class createTeacher
    {
     public int id { get; set; }
     public string teacherName { get; set; }
     public string dateofbirth { get; set; }
     public string qualifications { get; set; }
     public string email { get; set; }
     public string mobile { get; set; }
     public string experience { get; set; }
     public string subjects { get; set; }
     public string classes { get; set; }
     public string sections { get; set; }
     public int branch { get; set; }
     public string gender { get; set; }
     public int indexId { get; set; }
     public string status { get; set; }
     public int querytype { get; set; }

    }

  
}
