
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bl_Services
{
    public static class BLCommon
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IBL.IUserBL), typeof(Bl_Services.UserBL));
            collection.AddScoped(typeof(IBL.ICategoryBL), typeof(Bl_Services.CategoryBL));
            collection.AddScoped(typeof(IBL.ILearningModeBl), typeof(Bl_Services.LearningModeBL));
            collection.AddScoped(typeof(IBL.ILecturerBL), typeof(Bl_Services.LecturerBL));
            collection.AddScoped(typeof(IBL.ICourseBL), typeof(Bl_Services.CourseBL));
            return collection;
        }
    }
}
