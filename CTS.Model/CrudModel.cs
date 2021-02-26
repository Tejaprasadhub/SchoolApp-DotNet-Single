using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Model
{
    public class CrudModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string noofsections { get; set; }
        public string year { get; set; }
        public int branchid { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string disname { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public int classid { get; set; }
        public int subjectid { get; set; }
        public int teacherid { get; set; }
        public DateTime periodfrom { get; set; }
        public DateTime periodto { get; set; }
        public string image { get; set; }
        public string category { get; set; }
        public string accept_registrations { get; set; }
        public int querytype { get; set; }


        //users
        public string dispName { get; set; }
        public string parent { get; set; }
        public string teacher { get; set; }
        public string userName { get; set; }
        public string userstatus { get; set; }
        public string usertype { get; set; }


        //parents
        public string fname { get; set; }
        public string lname { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public string email { get; set; }

    }

    public class RoleAccessDataObject
    {
        public string id { get; set; }
        public List<RoleAccessData> listData { get; set; }
    }

    public class RoleAccessData
    {
        public string featureId { get; set; }
        public string featureIndex { get; set; }
        public string featureOption { get; set; }
        public string featureTitle { get; set; }
        public string status { get; set; }
    }
}
