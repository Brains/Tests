using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace Testing
{
	[TestFixture]
    public class Tests
    {
		//------------------------------------------------------------------
		[Test]
		public void Test ()
		{
			var fale = NSubstitute.Substitute.For<ITest>();

			Console.WriteLine(fale);
		}

		//------------------------------------------------------------------
		public class MyClass : ITest
		{
			public object Clone ()
			{
				throw new NotImplementedException();
			}

			public override string ToString ()
			{
				return "SHI";
			}
		}
    }

	public interface ITest {}
}
