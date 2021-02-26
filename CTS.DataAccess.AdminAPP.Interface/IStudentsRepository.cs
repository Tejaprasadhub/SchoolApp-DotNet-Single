using CTS.Model;
using CTS.Model.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTS.DataAccess.AdminAPP.Interface
{
    public interface IStudentsRepository
    {
        DataSet GetStudents(GridParameters pagingParameters);
        bool AEDStudents(Students input, string userid);

        DataSet GetStudentProfile(string spName, string studentid);
        DataSet GetExamWiseSubjectMarks(ExamWiseSubjects dataObj);
        DataSet GetStudentClassWiseExamMarks(ExamWiseSubjects dataObj);

        DataSet GetExamWiseClassesDropdowns(ExamWiseSubjects dataObj);

        bool SubmitStudentClassWiseExamMarks(StudentClassWiseExamMarks input, string userid);
    }
}
