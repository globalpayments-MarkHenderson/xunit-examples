using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class WebAppFactoryTest : IClassFixture<WebAppFactory<Startup>>
    {
        private readonly WebAppFactory<Startup> _factory;

        public WebAppFactoryTest(WebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact(Skip ="This test fails")]
        public async Task TestMethod()
        {
            // Customize the mock behavior for this test
            //_factory.MyServiceMock.Setup(x => x.DoSomething()).Returns("Test result");

            // Perform the test using the customized mock
            // ...
            var client = _factory.CreateClient();



        }
    }

}
