namespace Griz.Core
{
	public interface ICommand<T>
	{
		T Execute();
	}

	public interface ICommand
	{
		void Execute();
	}
}
