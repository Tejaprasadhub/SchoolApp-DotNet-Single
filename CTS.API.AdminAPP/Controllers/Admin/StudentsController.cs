using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.Model;
using CTS.Model.Exams;
using CTS.Model.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : ApiController
    {

        private readonly IConfiguration _config;
        private readonly IStudentsManager _studentssManager;
        public StudentsController(IConfiguration config, IStudentsManager studentsManager)
        {
            _config = config;
            _studentssManager = studentsManager;
        }

        [HttpPost("GetStudents")]
        public async Task<ActionResult> GetStudents([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _studentssManager.GetStudents(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDStudents")]
        public async Task<ActionResult> AEDStudents([FromBody]Students dataObj)
        {
            var userProfile = GetUserProfile();
            
            try
            {
                bool status = _studentssManager.AEDStudents(dataObj, userProfile.UserId);


                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("GetStudentProfile")]
        public async Task<ActionResult> GetStudentProfile([FromBody] StudentProfileModel reqObj)
        {

            DataTable dt = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();

            try
            {
                foreach (string spName in reqObj.data)
                {
                    dt = _studentssManager.GetStudentProfile(spName,reqObj.stduentid);

                    returnObj.Add(spName, dt);
                }

                return Ok(new { success = true, data = returnObj });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("GetExamWiseSubjectMarks")]
        public async Task<ActionResult> GetExamWiseSubjectMarks([FromBody] ExamWiseSubjects data)
        {

            DataTable dt = null;

            try
            {
               
               dt = _studentssManager.GetExamWiseSubjectMarks(data);            

                return Ok(new { success = true, data = dt });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("GetStudentClassWiseExamMarks")]
        public async Task<ActionResult> GetStudentClassWiseExamMarks([FromBody]ExamWiseSubjects data)
        {

            DataTable dt = null;

            try
            {

                dt = _studentssManager.GetStudentClassWiseExamMarks(data);

                return Ok(new { success = true, data = dt });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("GetStudentClassWiseExamReports")]
        public async Task<ActionResult> GetStudentClassWiseExamReports([FromBody] ExamWiseSubjects data)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                dt = _studentssManager.GetExamWiseSubjectMarks(data);

                Utility utility = new Utility();

                List<ExamReportsData> dataList = utility.CostructReportsData(dt);

                return Ok(new { success = true, data = dataList });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("GetExamWiseClassesDropdowns")]
        public async Task<ActionResult> GetExamWiseClassesDropdowns([FromBody] ExamWiseSubjects data)
        {
            DataTable dt = null;

            Dictionary<string, dynamic> returnObj = new Dictionary<string, dynamic>();

            try
            {               
                    dt = _studentssManager.GetExamWiseClassesDropdowns(data);

                    returnObj.Add(data.dropdownfor, dt);
             

                return Ok(new { success = true, data = returnObj });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost("SubmitStudentClassWiseExamMarks")]
        public async Task<ActionResult> SubmitStudentClassWiseExamMarks([FromBody] List<StudentClassWiseExamMarks> data)
        {
            bool status = false;
            var userProfile = GetUserProfile();
            try
            {
                foreach (var objectData in data)
                {
                     status = _studentssManager.SubmitStudentClassWiseExamMarks(objectData,userProfile.UserId);
                }                  

                return Ok(new { success = true, data = status });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
