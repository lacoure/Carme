using System.ComponentModel.DataAnnotations;

namespace ThisIsCar.Models
{
	public class Model
	{

		public int Id {
			get;
			set;
		}

		[Required]
		[StringLength(50)]
		public string Name {
			get;
			set;
		}

	}
}
