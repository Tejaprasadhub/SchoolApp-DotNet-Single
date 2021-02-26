using CTS.Common;
using CTS.Core.DataAccess;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Core;
using CTS.Model;
using CTS.Model.Students;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP
{
   public class StudentsRepository : CTSRepositoryBase, IStudentsRepository
    {

        private readonly ILogger<StudentsRepository> _logger;
        public StudentsRepository(CTSContext db, ILogger<StudentsRepository> logger)
        {
            this._db = db;
            this._logger = logger;
        }

        public DataSet GetStudents(GridParameters pagingParameters)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();
                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@queryType",pagingParameters.queryType },
                    {"@idValue",pagingParameters.idValue }
                };

                ds = _db.Execute("GetStudents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AEDStudents(Students dataObj, string userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    {"@id",dataObj.id },
                    {"@firstName",dataObj.firstName },
                    {"@middleName",dataObj.middleName },
                    {"@lastName",dataObj.lastName },
                    {"@branch",dataObj.branch },
                    {"@dateofbirth",dataObj.dateofbirth },
                    {"@gender",dataObj.gender },
                    {"@joineddate",dataObj.joineddate },
                    {"@email",dataObj.email },
                    {"@class",dataObj.classs },
                    {"@section",dataObj.section },
                    {"@d_noc",dataObj.d_noc },
                    {"@streetc",dataObj.streetc },
                    {"@villagec",dataObj.villagec },
                    {"@countryc",dataObj.countryc },
                    {"@statec",dataObj.statec },
                    {"@cityc",dataObj.cityc },
                    {"@pincodec",dataObj.pincodec },
                    {"@homephn",dataObj.homephn },
                    {"@mblno",dataObj.mblno },
                    {"@parent",dataObj.parent },
                    {"@d_nop",dataObj.d_nop },
                    {"@streetp",dataObj.streetp },
                    {"@villagep",dataObj.villagep },
                    {"@countryp",dataObj.countryp },
                    {"@statep",dataObj.statep },
                    {"@cityp",dataObj.cityp },
                    {"@pincodep",dataObj.pincodep },
                    {"@e1fname",dataObj.e1fname },
                    {"@e1lname",dataObj.e1lname },
                    {"@e1mobile",dataObj.e1mobile },
                    {"@e1email",dataObj.e1email },
                    {"@e2fname",dataObj.e2fname },
                    {"@e2lname",dataObj.e2lname },
                    {"@e2mobile",dataObj.e2mobile },
                    {"@e2email",dataObj.e2email },
                    {"@userid",userid },
                    {"@querytype",dataObj.querytype },
                     {"@status",dataObj.status }
                };

                _db.Execute("AEDStudents", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetStudentProfile(string spName, string studentid)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@datafor",spName },
                    {"@id",studentid }
                };

                ds = _db.Execute("GetStudentProfile", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExamWiseSubjectMarks(ExamWiseSubjects dataObj)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@id",dataObj.id },
                    {"@classid",dataObj.classid },
                    {"@examid",dataObj.examid },
                    {"@type",dataObj.type }

                };

                ds = _db.Execute("GetExamWiseSubjectMarks", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetStudentClassWiseExamMarks(ExamWiseSubjects dataObj)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@id",dataObj.id },
                    {"@classid",dataObj.classid },
                    {"@examid",dataObj.examid },
                    {"@type",dataObj.type }
                };

                ds = _db.Execute("GetStudentClassWiseExamMarks", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExamWiseClassesDropdowns(ExamWiseSubjects dataObj)
        {
            try
            {
                DataSet ds = new DataSet();

                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    {"@dropDownFor",dataObj.dropdownfor },
                    {"@studentID",dataObj.id },
                    {"@classid",dataObj.classid },
                };

                ds = _db.Execute("GetExamWiseClassesDropdowns", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SubmitStudentClassWiseExamMarks(StudentClassWiseExamMarks dataObj, string userid)
        {
            try
            {
                Utility utility = new Utility();

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>()
                {
                    { "@studentId",dataObj.studentId },
                    { "@classId",dataObj.classId },
                    { "@examId",dataObj.examId },
                    { "@subjectId",dataObj.subjectId },
                    { "@marks",dataObj.marks },
                    {"@userid",userid }
                };

                _db.Execute("SubmitStudentClassWiseExamMarks", CommandType.StoredProcedure, parameters, utility.GetDatabasename(utility.GetSubdomain()));

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
