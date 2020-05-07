using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Helper
{
    public interface IDashboardService
    {
        Task<bool> EnrollForCourse(string Email, int CourseID);
    }
}
