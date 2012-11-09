using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Griz.Core
{
	public class DataAnnotationsValidator : IValidator
	{
		public ICollection<ValidationResult> ErrorCollection { get; private set; }

		public bool TryValidate(object @object)
		{
			var context = new ValidationContext(@object
				, serviceProvider: null
				, items: null);

			ErrorCollection = new List<ValidationResult>();

			return Validator.TryValidateObject(@object
				, context
				, ErrorCollection
				, validateAllProperties: true);
		}
	}
}