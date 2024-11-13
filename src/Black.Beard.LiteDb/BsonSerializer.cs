using Bb.JsonParser;
using LiteDB;
using Bb.Json.Linq;

namespace Bb.LiteDb
{

    /// <summary>
    /// Extension
    /// </summary>
    public static class BsonSerializer
    {

        /// <summary>
        /// Convert to bson
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static BsonValue ConvertToBson(this IStore store)
        {

            switch (store.Type)
            {
                case StoreType.Object:
                    return ConvertToBson((StoreObject)store);
                case StoreType.Array:
                    return ConvertToBson((StoreArray)store);
                case StoreType.Property:
                    return ConvertToBson((StoreProperty)store);
                case StoreType.Value:
                    return ConvertToBson((StoreValue)store);
            }

            return null;

        }

        internal static BsonValue ConvertToBson(this StoreObject store)
        {
            var result = new BsonDocument();
            foreach (var item in store.GetChilds)
                result.Add(item.Name, item.ConvertToBson());
            return result;
        }

        internal static BsonValue ConvertToBson(this StoreArray store)
        {
            var result = new BsonArray();
            foreach (var item in store.GetChilds)
                result.Add(item.ConvertToBson());
            return result;
        }

        internal static BsonValue ConvertToBson(this StoreProperty store)
        {
            return store.Value.ConvertToBson();
        }

        internal static BsonValue ConvertToBson(this StoreValue store)
        {

            var f = store.JsonModel as JValue;
            var value = f.Value;

            switch (f.Type)
            {

                case JTokenType.Null:
                    return BsonValue.Null;

                case JTokenType.Integer:
                    return new BsonValue(value as long? ?? 0L);
                    
                case JTokenType.Float:
                    return new BsonValue(value as double? ?? 0.0);

                case JTokenType.String:
                    return new BsonValue(value as string ?? string.Empty);

                case JTokenType.Uri:
                    return new BsonValue((value as Uri).ToString());

                case JTokenType.Boolean:
                    return new BsonValue(value as bool? ?? false);

                case JTokenType.Bytes:
                    return new BsonValue(value as byte[]);

                case JTokenType.Guid:
                    return new BsonValue((Guid)value);

                case JTokenType.Raw:
                case JTokenType.Date:
                case JTokenType.TimeSpan:
                    return new BsonValue(value);

                case JTokenType.Undefined:
                case JTokenType.Object:
                case JTokenType.Array:
                case JTokenType.Constructor:
                case JTokenType.Property:
                case JTokenType.Comment:
                case JTokenType.None:
            default:
                    break;
            }
            
            throw new System.NotImplementedException();

        }
    
    }


}
