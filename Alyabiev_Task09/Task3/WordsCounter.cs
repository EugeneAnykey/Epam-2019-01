using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Alyabiev.Task09.Task3
{
	public class WordsCounter
	{
		const string WordsPattern = @"([А-Яа-яA-Za-z\d][А-Яа-яA-Za-z\d'-]*)";

		readonly string text;
		public string Text => text;

		Dictionary<string, int> dick = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

		public WordsCounter(string text)
		{
			this.text = text ?? throw new ArgumentNullException();
		}

		public void Count()
		{
			Count(GetLines());
		}

		string[] GetLines()
		{
			var matches = Regex.Matches(text, WordsPattern);

			var lines = matches.OfType<Match>().Select(m => m.Value);

			return lines.ToArray<string>();
		}

		void Count(string[] lines)
		{
			foreach (var item in lines)
			{
				if (dick.ContainsKey(item))
					dick[item] += 1;
				else
					dick.Add(item, 1);
			}
		}

		public void SortDict()
		{
			var sortedDict = from item in dick orderby item.Value descending select item;
			
			dick = sortedDict.ToDictionary(x => x.Key, x=> x.Value);
		}

		public string[] GetResultLines()
		{
			var res = new string[dick.Count];

			int i = 0;
			foreach (var item in dick)
			{
				res[i++] = string.Format($"{item.Key} = {item.Value}");
			}

			return res;
		}

		public string Summary()
		{
			return $"Total / unique words: {dick.Select(i => i.Value).Sum()} / {dick.Count}";
		}

		public string[] FirstFiveMostPopularWords()
		{
			var list = (from item in dick orderby item.Value descending select item).Take(5).ToList();
			return list.Select(i => i.Key).ToArray();
		}
	}
}