using System;

namespace Griz.Core
{
	public class DateTimeOverrider : IDisposable
	{

		public DateTimeOverrider(DateTime overriddenTime)
		{
			DateTimeHelper.OverridenDateTime = overriddenTime;
		}

		public void Dispose()
		{
			DateTimeHelper.OverridenDateTime = null;
		}
	}
}