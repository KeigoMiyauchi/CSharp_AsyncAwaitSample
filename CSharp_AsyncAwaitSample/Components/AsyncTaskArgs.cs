using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_AsyncAwaitSample.Components
{
    public class AsyncTaskArgs
    {
        private object[] parameters = null;
        private object result = null;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="token"></param>
        /// <param name="parameters"></param>
        public AsyncTaskArgs(object[] parameters)
        {
            this.parameters = parameters;
        }

        public object[] GetParameters()
        {
            return parameters;
        }

        public void SetResult(object result)
        {
            this.result = result;
        }

        public object GetResult()
        {
            return this.result;
        }
    }
}
