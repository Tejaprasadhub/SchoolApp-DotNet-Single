using CTS.Business.AdminAPP.Interface;
using CTS.Business.Security;
using CTS.Business.Security.Interface;
using CTS.DataAccess.AdminAPP;
using CTS.DataAccess.AdminAPP.Interface;
using CTS.DataAccess.Security;
using CTS.DataAccess.Security.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.Business.AdminAPP
{
    public static class DependencyResolver
    {
        public static void ConfigureAdminAPPServices(this IServiceCollection services)
        {
            services.AddScoped<IAccessTokenManager, AccessTokenManager>();
            services.AddScoped<IAccessTokenRepository, AccessTokenRepository>(); 

            services.AddScoped<IBrnachesManager,BranchesManager>();
            services.AddScoped<IBranchesRepository,BranchesRepository>();

            services.AddScoped<IStudentsManager, StudentsManager>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();

            services.AddScoped<ITeachersManager, TeachersManager>();
            services.AddScoped<ITeachersRepository, TeachersRepository>();

            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddScoped<IExamsManager, ExamsManager>();
            services.AddScoped<IExamsRepository, ExamsRepository>();

            services.AddScoped<IClassesManager, ClassesManager>();
            services.AddScoped<IClassesRepository, ClassesRepository>();

            services.AddScoped<ITimeTableManager, TimeTableManager>();
            services.AddScoped<ITimetableRepository, TimeTableRepository>();

            services.AddScoped<IDropdownManager, DropdownManager>();
            services.AddScoped<IDropdownRepository, DropdownRepository>();

            services.AddScoped<ISubjectsManager, SubjectsManager>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();

            services.AddScoped<IAchievementManager, AchievementsManager>();
            services.AddScoped<IAchievementsRepository, AchievementsRepository>();

            services.AddScoped<IAuditLogsManager, AuditLogsManager>();
            services.AddScoped<IAuditLogsRepository, AuditLogsRepository>();

            services.AddScoped<INewsManager, NewsManager>();
            services.AddScoped<INewsRepository, NewsRepository>();

            services.AddScoped<IParentsManager, ParentsManager>();
            services.AddScoped<IParentsRepository, ParentsRepository>();


            services.AddScoped<IQualificationsManager, QualificationsManager>();
            services.AddScoped<IQualificationsRepository, QualificationsRepository>();

            services.AddScoped<IAccessTokenManager, AccessTokenManager>();
            services.AddScoped<IAccessTokenRepository, AccessTokenRepository>();

            services.AddScoped<IRoleAccessManager, RoleAccessManager>();
            services.AddScoped<IRoleAccessRepository, RoleAccessRepository>();
        }
    }
}
