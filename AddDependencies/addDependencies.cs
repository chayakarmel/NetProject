using Microsoft.Extensions.DependencyInjection;

namespace AddDependencies
{
    public static class addDependencies
    {
        public static void AddDependencies(this IServiceCollection collection)
        {
            Bl_Services.BLCommon.AddBLDependencies(collection);
            Dal_Repository.DalCommon.AddDalDependencies(collection);

            //Bl_Services.AddScoped(typeof(IBL.Ibl), typeof(Bl_Services.UserBL));

        }

    }
}