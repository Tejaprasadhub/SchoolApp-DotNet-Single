using CTS.Model;
using CTS.Model.Exams;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IExamsRepository
    {
        DataSet GetExams(GridParameters pagingParameters);
        bool AEDExams(ExamWiseSubjectsList input, string userid,string title,string year,string status,string id,string querytype);
        bool CheckExistsOrNot(Exams input,string type);

        bool DeleteExamwiseSubjects(string examid);

    }
}
