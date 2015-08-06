using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Example.Models.Helpers
{
    public static class Async<T>
    {
        public static Task<T> FromResult(T result)
        {
            var taskSource = new TaskCompletionSource<T>();
            taskSource.SetResult(result);
            return taskSource.Task;
        }
    }

    public static class Async
    {
        public static Task Empty()
        {
            return Async<bool>.FromResult(true);
        }
    }
}
