namespace Griz.Core
{
	public interface IId<TKey>
	{
		TKey Id { get; set; }
	}
}