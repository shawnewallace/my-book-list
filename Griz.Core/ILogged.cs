using System;

namespace Griz.Core
{
	public interface ILogged
	{
		DateTime WhenCreated { get; set; }
		DateTime WhenModified { get; set; }
	}
}