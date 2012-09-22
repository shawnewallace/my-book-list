using Griz.Core;
using Griz.Core.Data;
using Ninject.Modules;

namespace Griz.BookList.Lib.Data
{
	public class RepositoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUnitOfWork>().To<GrizBookListUnitOfWork>();
			Bind<IValidator>().To<DataAnnotationsValidator>();
		}
	}
}