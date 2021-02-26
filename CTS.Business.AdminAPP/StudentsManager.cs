
using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.Model;
using CTS.Model.Students;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace CTS.Business.AdminAPP
{
   public class StudentsManager : IStudentsManager
    {

        private readonly IConfiguration _config;
        private readonly IStudentsRepository _studentsRepository;
        public StudentsManager(IConfiguration config, IStudentsRepository studentsRepository)
        {
            _config = config;
            _studentsRepository = studentsRepository;
        }

        public async Task<Dictionary<string, dynamic>> GetStudents(GridParameters pagingParameters)
        {

            DataSet gridDataSet = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();
            try
            {

                gridDataSet = _studentsRepository.GetStudents(pagingParameters);

                Utility utility = new Utility();

                returnObj = utility.ApplyPaging(gridDataSet, pagingParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnObj;
        }

        public bool AEDStudents(Students dataObj, string userid)
        {
            bool status = false;
            try
            {
                status = _studentsRepository.AEDStudents(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }

        public DataTable GetStudentProfile(string spName, string studentid)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _studentsRepository.GetStudentProfile(spName,studentid);

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable GetExamWiseSubjectMarks(ExamWiseSubjects dataObj)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _studentsRepository.GetExamWiseSubjectMarks(dataObj);

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable GetStudentClassWiseExamMarks(ExamWiseSubjects dataObj)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _studentsRepository.GetStudentClassWiseExamMarks(dataObj);

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable GetExamWiseClassesDropdowns(ExamWiseSubjects dataObj)
        {

            DataSet gridDataSet = null;

            DataTable dt = null;
            try
            {

                gridDataSet = _studentsRepository.GetExamWiseClassesDropdowns(dataObj);

                dt = gridDataSet.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }


        public bool SubmitStudentClassWiseExamMarks(StudentClassWiseExamMarks dataObj, string userid)
        {
            bool status = false;
            try
            {
                status = _studentsRepository.SubmitStudentClassWiseExamMarks(dataObj, userid);

            }
            catch (Exception ex)
            {
                throw;
            }
            return status;
        }
    }
}
