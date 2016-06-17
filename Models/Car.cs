using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThisIsCar.Models
{
	public class Car
	{

		public int Id {
			get;
			set;
		}

		[Required]
		public int ManufacturerId {
			get;
			set;
		}

		[Required]
		public int ModelId {
			get;
			set;
		}

		[Required]
		public int ModificationId {
			get;
			set;
		}

		[Required]
		public int Year {
			get;
			set;
		}

		public virtual Manufacturer Manufacturer {
			get; set;
		}

		public virtual Model Model {
			get; set;
		}

		public virtual Modification Modification {
			get; set;
		}

		public virtual IEnumerable<Comment> Comments {
			get; set;
		}

	}
}
