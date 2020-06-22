using MongoDB.Bson;

namespace Ishooper.Dal
{
    public class DBUtils
    {
        public static ObjectId StringToObjectId (string str)
        {
            return new ObjectId(str);
        }

        public static string ObjectIdToString(ObjectId obj)
        {
            return obj.ToString();
        }
    }
}
