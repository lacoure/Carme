using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using ThisIsCar.Models;

namespace ThisIsCar.DAL
{
	public class ManufacturerInitializer : System.Data.Entity.CreateDatabaseIfNotExists<CarContext>
	{

		private Collection<string> Process() {
			WebClient wc = new WebClient();
			byte[] raw = wc.DownloadData("https://en.wikipedia.org/wiki/List_of_current_automobile_manufacturers_(alphabetical)");
			string webData = Encoding.UTF8.GetString(raw);
			var sb = new Collection<string>();
			Regex liExpression = new Regex(@"<li>(.*)flagicon(.*)title=(.*)>(.*)<\/a>(.*)<\/li>");
			Regex innerMatch = new Regex(@"\[\d*\]");
			foreach (Match itemMatch in liExpression.Matches(webData)) {
				if (itemMatch.Groups.Count < 4 || innerMatch.IsMatch(itemMatch.ToString())) {
					continue;
				}
				string manufacturer = itemMatch.Groups[4].ToString();
				sb.Add(manufacturer);
			}
			return sb;
		}

		protected override void Seed(CarContext context) {
			var manufacturers = new List<Manufacturer>();
			int id = 1;
			foreach (string manufacturer in Process()) {
				manufacturers.Add(new Manufacturer {Id = id, Name = manufacturer});
				id = id++;
			}

			manufacturers.ForEach(s => context.Manufacturers.Add(s));
			context.SaveChanges();
		}
	}
}
