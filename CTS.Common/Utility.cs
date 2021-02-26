using CTS.Core.DataAccess;
using CTS.DataAccess.Core;
using CTS.Model;
using CTS.Model.Branches;
using CTS.Model.Exams;
using CTS.Model.Teachers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;



namespace CTS.Common
{
    public class Utility : CTSRepositoryBase
    {
        //public Utility(CTSContext db)
        //{
        //    this._db = db;
        //}

        

       

        public  string GetSubdomain()
        {
            //var data = GetSubDomain();
            //var data = _config.HttpContext.Request.Path;


            return "private";
        }       

        public string GetDatabasename(string subdomain)
        {
            try
            {
                DataSet ds = new DataSet();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@subDomain",subdomain }
                };
                CTSContext invokeContextObject = new CTSContext("");
                _db = invokeContextObject;
                ds = _db.Execute("GetDatabasename", CommandType.StoredProcedure, parameters);
                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //todo: Common code sorting and filtering and paging code implemented here for all grid control

        public static DataTable ServersidePaging(DataTable dt,int pagesize,int pageno,string sort,string filter,ref int icount, string paginationName)
        {
            DataColumn column = new DataColumn("RecordIndex");
            column.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(column);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "";

            //sorting code done here
            if (!string.IsNullOrEmpty(sort))
            {
                dv.Sort = sort;
            }

            //filteration code done here
            if (!string.IsNullOrEmpty(filter))
            {
                dv.RowFilter += filter;
            }

            DataTable tableToBeConstructed = dv.ToTable();
            DataTable finalDT = new DataTable();

            if (paginationName == "GetTeachers")
            {
                List<Teachers> constructedList = CostructTeachersGridLevelData(tableToBeConstructed);

                ListtoDataTableConverter converter = new ListtoDataTableConverter();

                finalDT = converter.ToDataTable(constructedList);

                if (finalDT != null && finalDT.Rows.Count > 0)
                {
                    finalDT = finalDT.AsEnumerable().GroupBy(r => new { id = r["id"] }).Select(g => g.OrderBy(r => r["id"]).First()).CopyToDataTable();
                }

                dv = finalDT.DefaultView;
            }

            else if (paginationName == "GetExams")
            {
                List<Exams> constructedList = CostructExamsGridLevelData(tableToBeConstructed);

                ListtoDataTableConverter converter = new ListtoDataTableConverter();

                finalDT = converter.ToDataTable(constructedList);

                if (finalDT != null && finalDT.Rows.Count > 0)
                {
                    finalDT = finalDT.AsEnumerable().GroupBy(r => new { id = r["id"] }).Select(g => g.OrderBy(r => r["id"]).First()).CopyToDataTable();
                }

                dv = finalDT.DefaultView;
            }

            DataColumn finalDTColumn = new DataColumn("RecordIndex");
            finalDTColumn.DataType = System.Type.GetType("System.Int32");
            finalDT.Columns.Add(finalDTColumn);
            

            //pagination code done here
            int lowbound = pagesize * (pageno - 1);
            int highbound = pagesize * pageno;

            icount = dv.Count;

            for(int i = 0; i <dv.Count; i++)
            {
                dv[i]["recordindex"] = i + 1;
            }
            if (paginationName != "")
            {
                dv.RowFilter += string.Format("{0}recordindex > {1} and {2} >= recordindex", (!string.IsNullOrEmpty(filter) ? " " : ""), lowbound, highbound);
            }
            else
            {
                dv.RowFilter += string.Format("{0}recordindex > {1} and {2} >= recordindex", (!string.IsNullOrEmpty(filter) ? " and " : ""), lowbound, highbound);
            }
            return dv.ToTable();
        }

        //Constructing Grid Level Teachers Data
        public static List<Teachers> CostructTeachersGridLevelData(DataTable dataTable)
        {
            return (from rw in dataTable.AsEnumerable()
                    select new Teachers()
                    {
                        id = Convert.ToString(rw["id"]),
                        teachername = Convert.ToString(rw["teachername"]),
                        mobilenumber = Convert.ToString(rw["mobilenumber"]),
                        dob = Convert.ToDateTime(rw["dob"]),
                        experience = Convert.ToString(rw["experience"]),
                        email = Convert.ToString(rw["email"]),
                        branch = Convert.ToString(rw["branch"]),
                        gender = Convert.ToString(rw["gender"]),
                        branchtitle = Convert.ToString(rw["branchtitle"]),
                        createddate = Convert.ToString(rw["createddate"]),
                        createdby = Convert.ToString(rw["createdby"]),
                        classes = Grouping(dataTable.Select("id=" + rw["id"] + "")
                        .AsEnumerable()
                        .Select(cl => new ListInfo
                        {
                            label = cl["class_name"].ToString(),
                            value = cl["class_id"].ToString()
                        }).ToList()),

                        sections = Grouping(dataTable.Select("id=" + rw["id"] + "")
                        .AsEnumerable().Select(se => new ListInfo
                        {
                            label = se["section_name"].ToString(),
                            value = se["section_id"].ToString()
                        }).ToList()),

                      

                        subjects = Grouping(dataTable.Select("id=" + rw["id"] + "")
                        .AsEnumerable().Select(su => new ListInfo
                        {
                            label = su["subject_name"].ToString(),
                            value = su["subject_id"].ToString()
                        }).ToList()),

                        qualifications = Grouping(dataTable.Select("id=" + rw["id"] + "")
                        .AsEnumerable().Select(su => new ListInfo
                        {
                            label = su["qualification_name"].ToString(),
                            value = su["qualification_id"].ToString()
                        }).ToList())

                    }).ToList();
        }

        //Constructiong Exams Grid Level Data
        public static List<Exams> CostructExamsGridLevelData(DataTable dataTable)
        {
            return (from rw in dataTable.AsEnumerable()
                    select new Exams()
                    {
                        id = Convert.ToString(rw["id"]),
                        year = Convert.ToString(rw["year"]),
                        title = Convert.ToString(rw["title"]),
                        createddate = Convert.ToDateTime(rw["createddate"]),
                        status = Convert.ToString(rw["status"]),
                        createdby = Convert.ToString(rw["createdby"]),
                        classes = Grouping(dataTable.Select("id=" + rw["id"] + "")
                        .AsEnumerable()
                        .Select(cl => new ListInfo
                        {
                            label = cl["classname"].ToString(),
                            value = cl["classid"].ToString()
                        }).ToList()),
                        subjects = SubjectsGrouping(dataTable.Select("id=" + rw["id"] + "")
                        .AsEnumerable()
                        .Select(cl => new ExamWiseSubjectsList
                        {
                            subjectid = cl["subjectid"].ToString(),
                            subject = cl["subjectname"].ToString(),
                            cutoff = cl["cutoff"].ToString(),
                            total = cl["total"].ToString(),
                        }).ToList())
                    }).ToList();
        }

        //Constructing Reports Data
        public  List<ExamReportsData> CostructReportsData(DataTable dataTable)
        {
            return (from rw in dataTable.AsEnumerable()
                    select new ExamReportsData()
                    {
                        id = Convert.ToString(rw["id"]),
                        studentname = Convert.ToString(rw["studentname"]),
                        dob = Convert.ToString(rw["dob"]),
                        classname = Convert.ToString(rw["class"]),
                        email = Convert.ToString(rw["email"]),
                        mobile = Convert.ToString(rw["mobile"]),
                        address = Convert.ToString(rw["address"]),
                        subjects = dataTable
                        .AsEnumerable()
                        .Select(cl => new ExamWiseSubjectsList
                        {
                            subject = cl["subject"].ToString(),
                            cutoff = cl["cutoffmarks"].ToString(),
                            total = cl["totalmarks"].ToString(),
                            obtained = cl["obtainedmarks"].ToString(),
                            status = cl["status"].ToString(),
                        }).ToList()

                    }).ToList();
        }


        private static List<ListInfo> Grouping(List<ListInfo> items)
        {
            List<ListInfo> groupedData = new List<ListInfo>();
            return groupedData = items.GroupBy(p => p.value)
                           .Select(grp => grp.First())
                           .ToList(); 
        }

        private static List<ExamWiseSubjectsList> SubjectsGrouping(List<ExamWiseSubjectsList> items)
        {
            List<ExamWiseSubjectsList> groupedData = new List<ExamWiseSubjectsList>();
            return groupedData = items.GroupBy(p => p.subjectid)
                           .Select(grp => grp.First())
                           .ToList();
        }

     

        public class ListtoDataTableConverter
        {           
            public DataTable ToDataTable<T>(IList<T> data)
            {
                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;

            }
        }


        public Dictionary<string, dynamic> ApplyPaging(DataSet gridDataSet, GridParameters pagingParameters,string paginationName = "")
        {
            DataTable filter = null;
            //List<Brnaches> BranchesList = new List<Brnaches>();
            int icount = 0;

            if (gridDataSet.Tables[0] != null && gridDataSet.Tables[0].Rows.Count > 0)
            {
                DataView dv = gridDataSet.Tables[0].DefaultView;

                //dv.Sort = "StagePriority asc, InitialTimeStamp desc";
                dv.Sort = pagingParameters.sorts;

                DataTable sortedDT = dv.ToTable();

                if (pagingParameters == null || (pagingParameters != null && pagingParameters.PageSize == 0))
                {
                    pagingParameters = new GridParameters() { PageNo = 1, PageSize = sortedDT.Rows.Count };

                }

                //sorting the datatieme with the initialTimeStamp field in the table
                if (pagingParameters.Sort != null && pagingParameters.Sort.ToString().ToUpper().Contains("WEBENABLEDDATE"))
                {
                    string sort = pagingParameters.Sort;
                    pagingParameters.Sort = sort.Replace("WEBENABLEDDATE", "InitailTimeStamp");
                }

                 filter = Utility.ServersidePaging(sortedDT, pagingParameters.PageSize, pagingParameters.PageNo, pagingParameters.Sort, pagingParameters.Filter, ref icount, paginationName);


                //filter.AsEnumerable().ToList().ForEach(eachRow =>
                //{
                //    Branches branch = new Branches();

                //    branch.Id = eachRow["id"].ToString();
                //    branch.Code = eachRow["code"].ToString();
                //    branch.Title = eachRow["title"].ToString();
                //    branch.CreateDate = Convert.ToDateTime(eachRow["createddate"]);
                //    branch.CreatedBy = eachRow["createdby"].ToString();

                //    BranchesList.Add(branch);
                //});
            }
            else
            {
                icount = 0;
            }

            Dictionary<string, dynamic> returnObject = new Dictionary<string, dynamic>();

            returnObject.Add("data", filter);
            returnObject.Add("count", icount);

            return returnObject;
        }
    }
}
