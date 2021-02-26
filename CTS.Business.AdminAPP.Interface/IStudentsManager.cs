using CTS.Model;
using CTS.Model.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Business.AdminAPP.Interface
{
    public interface IStudentsManager
    {
        Task<Dictionary<string, dynamic>> GetStudents(GridParameters pagingParameters);

        bool AEDStudents(Students input, string userid);

        DataTable GetStudentProfile(string spName, string studentid);
        DataTable GetExamWiseSubjectMarks(ExamWiseSubjects spName);
        DataTable GetStudentClassWiseExamMarks(ExamWiseSubjects spName);
        DataTable GetExamWiseClassesDropdowns(ExamWiseSubjects dataObj);

        bool SubmitStudentClassWiseExamMarks(StudentClassWiseExamMarks dataObj, string userid);
    }
}
