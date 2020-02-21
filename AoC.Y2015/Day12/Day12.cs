using AoC.Helpers.Days;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day12 : BaseDay
    {
        public Day12() : base(2015, 12)
        {
        }

        public Day12(IEnumerable<string> inputLines) : base(2015, 12, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetNumberSum(string.Concat(inputLines), false);

		protected override IConvertible PartTwo() => GetNumberSum(string.Concat(inputLines), true);

		private static int GetNumberSum(string input, bool ignoreRed)
		{
			var sum = 0;

			if (input.StartsWith('['))
			{
				var jsonArray = JsonConvert.DeserializeObject<JArray>(input);
				foreach (var token in jsonArray)
				{
					sum += GetTokenSum(token, ignoreRed);
				}
			}
			else
			{
				var jsonObject = JsonConvert.DeserializeObject<JObject>(input);

				if (ignoreRed && jsonObject.Properties().Any(j => j.Value.ToString().Equals("red", StringComparison.InvariantCultureIgnoreCase)))
				{
					return 0;
				}

				foreach (var token in jsonObject.PropertyValues())
				{
					sum += GetTokenSum(token, ignoreRed);
				}
			}

			

			return sum;
		}

		private static int GetTokenSum(JToken input, bool ignoreRed)
		{
			var sum = 0;

			if (input is JArray jarr)
			{
				foreach (var token in jarr)
				{
					sum += GetTokenSum(token, ignoreRed);
				}
			}
			else if (input is JObject jobj)
			{
				if (ignoreRed && jobj.Properties().Any(j => j.Value.ToString().Equals("red", StringComparison.InvariantCultureIgnoreCase)))
				{
					return 0;
				}

				foreach (var token in jobj.PropertyValues())
				{
					sum += GetTokenSum(token, ignoreRed);
				}
			}
			else if (input is JValue jval)
			{
				try { sum += (int)input; } catch { }
			}

			return sum;
		}
	}
}
