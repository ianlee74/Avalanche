using System.Configuration;

namespace Longsor.Data
{
    public static class LongsorDb
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Longsor"].ConnectionString; }
        }
    }
}
