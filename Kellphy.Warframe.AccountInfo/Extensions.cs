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

		public static string FirstCharToUpper(this string input)
		{
			switch (input)
			{
				case null:
					throw new ArgumentNullException(nameof(input));
				case "":
					throw new ArgumentException("input cannot be empty", nameof(input));
				default:
					return input[0].ToString().ToUpper() + input.Substring(1);
			}
		}
	}
}
