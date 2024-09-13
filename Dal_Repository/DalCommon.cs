using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public static class DalCommon
    {
        public static IServiceCollection AddDalDependencies(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IDAL.IUserDal),typeof(Dal_Repository.UserDal));
            collection.AddScoped(typeof(IDAL.ICategoryDal), typeof(Dal_Repository.CategoryDal));
            collection.AddScoped(typeof(IDAL.ILearningModeDal), typeof(Dal_Repository.LearningModeDal));
            collection.AddScoped(typeof(IDAL.ILecturerDal), typeof(Dal_Repository.LecturerDal));
            collection.AddScoped(typeof(IDAL.ICourseDal), typeof(Dal_Repository.CourseDal));
            return collection;
        }
        
    }
}
