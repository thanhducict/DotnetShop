using Microsoft.Data.SqlClient;

namespace DotnetShop.Catalog.API
{
    public static class Helpers
    {
        public static T GetFieldValue<T>(this SqlDataReader dr, string name)
        {
            T ret = default;

            if (!dr[name].Equals(DBNull.Value))
            {
                ret = (T)dr[name];
            }

            return ret;
        }
    }
}
