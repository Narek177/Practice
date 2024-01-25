using Newtonsoft.Json;

namespace Practice.ModelExtensions
{
    public static class FormCollectionExtensions
    {
        /// <summary>
        /// converts a form collection to a list of key value pairs. <strong>Only the first item in the value collection for a key is taken.</strong>
        /// </summary>
        /// <typeparam name="T">the type you want to deserialise into</typeparam>
        /// <param name="pairs">the form collection</param>
        /// <returns></returns>
        public static T AsObject<T>(this IFormCollection pairs) where T : class, new()
        {
            string jsonString = $"{{{string.Join(",", pairs.Select(x => $"\"{x.Key}\" : \"{x.Value}\""))}}}";

            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
