using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CTS.Business.AdminAPP.Interface;
using CTS.Common;
using CTS.Model;
using CTS.Model.Exams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CTS.API.AdminAPP.Controllers
{
    [Route("api/[controller]")]
    public class ExamsController : ApiController
    {

        private readonly IConfiguration _config;
        private readonly IExamsManager _examsManager;
        public ExamsController(IConfiguration config, IExamsManager examsManager)
        {
            _config = config;
            _examsManager = examsManager;
        }

        [HttpPost("GetExams")]
        public async Task<ActionResult> GetExams([FromBody] GridParameters pagingParameters)
        {

            DataSet ds = new DataSet();

            DataTable dt = null;
            try
            {
                var count = 0;

                Dictionary<string, dynamic> apiResult = await _examsManager.GetExams(pagingParameters);

                dt = apiResult["data"];

                count = Convert.ToInt32(apiResult["count"]);


                return Ok(new { success = true, data = dt, Total = count });

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("AEDExams")]
        public async Task<ActionResult> AEDExams([FromBody] Exams dataObj)
        {
            var userProfile = GetUserProfile();

            ExamWiseSubjectsList examWiseSubjects = new ExamWiseSubjectsList();
            bool status = false;
            try
            {
                 status = _examsManager.CheckExistsOrNot(dataObj,"Exam");

                if (status && dataObj.querytype == "1")
                {
                    foreach (var objectData in dataObj.subjects)
                    {
                        status = _examsManager.AEDExams(objectData, userProfile.UserId,dataObj.title,dataObj.year,dataObj.status,dataObj.id,dataObj.querytype);
                    }
                }
                else if (dataObj.querytype == "2")
                {
                   bool isDeleted = _examsManager.DeleteExamwiseSubjects(dataObj.id);
                    if (isDeleted)
                    {
                        foreach (var objectData in dataObj.subjects)
                        {
                            status = _examsManager.AEDExams(objectData, userProfile.UserId, dataObj.title, dataObj.year, dataObj.status, dataObj.id, dataObj.querytype);
                        }
                    }
                    status = true;
                }
                else if (dataObj.querytype == "3")
                {                   
                    status = _examsManager.AEDExams(examWiseSubjects, userProfile.UserId, dataObj.title, dataObj.year, dataObj.status, dataObj.id, dataObj.querytype);
                 
                    status = true;
                }
                else
                {
                    return Ok(new { success = status });
                }

                return Ok(new { success = status });

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
