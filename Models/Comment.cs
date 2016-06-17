using System.ComponentModel.DataAnnotations;

namespace ThisIsCar.Models
{
	public class Comment
	{

		public int Id {
			get;
			set;
		}

		[Required]
		public string Content {
			get;
			set;
		}

		[Required]
		public int CarId {
			get;
			set;
		}

		public Car Car {
			get;
			set;
		}

	}
}
