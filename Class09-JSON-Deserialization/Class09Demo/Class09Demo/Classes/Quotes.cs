using Newtonsoft.Json;
using System.Collections.Generic;

namespace Class09Demo.Classes
{
	class Quotes
	{

		//[JsonProperty("Tags")]
		//public List<string> Tags { get; set; }

		[JsonProperty("Likes")]
		public string Likes { get; set; }

		[JsonProperty("Author")]
		public string Author { get; set; }

		[JsonProperty("Text")]
		public string Text { get; set; }
	}
}
