namespace Griz.Core
{
	public interface IRange<T>
	{
		T Minimum { get; set; }
		T Maximum { get; set; }
		bool IsInRange(T value);
	}
}
