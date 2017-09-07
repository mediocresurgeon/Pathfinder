using NUnitLite;
using System.Reflection;

namespace Core.Domain.UnitTests
{
    public class TestRunner
    {
		public static int Main(string[] args)
		{
            Assembly thisAssembly = typeof(TestRunner).Assembly;
			return new AutoRun(thisAssembly).Execute(args);
		}
    }
}