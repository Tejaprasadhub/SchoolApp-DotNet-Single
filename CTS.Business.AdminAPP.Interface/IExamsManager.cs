using CTS.Model;
using CTS.Model.Exams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IExamsManager
    {
        Task<Dictionary<string, dynamic>> GetExams(GridParameters pagingParameters);
        bool AEDExams(ExamWiseSubjectsList input, string userid,string title,string year,string status,string id, string querytype);
        bool CheckExistsOrNot(Exams input,string type);

        bool DeleteExamwiseSubjects(string examid);


    }
}
