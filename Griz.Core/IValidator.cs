using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Griz.Core
{
	public interface IValidator
	{
		ICollection<ValidationResult> ErrorCollection { get; }
		bool TryValidate(object @object);
	}
}