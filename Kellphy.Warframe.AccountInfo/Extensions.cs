using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kellphy.Warframe.AccountInfo
{
	public static class Extensions
	{
		public static List<T> Deserialize<T>(this JObject jsonData, string propertyName)
		{
			var data = jsonData[propertyName]?.ToString(Formatting.None);
			return JsonConvert.DeserializeObject<List<T>>(data ?? string.Empty) ?? new List<T>();
		}
	}
}
