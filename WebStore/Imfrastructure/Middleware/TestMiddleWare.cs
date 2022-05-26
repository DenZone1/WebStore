using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Imfrastructure.Middleware;
    public class TestMiddleWare 
    { 
        private readonly RequestDelegate _Next;
        public TestMiddleWare(RequestDelegate Next) { _Next = Next;}

        public async Task Invoke(HttpContext Context)
        {
                //обработка данных внутри Context
                //Context.Request
                //Context.Response.

                await _Next(Context);
            // постобработка данных из Context.Response.
        }

}
