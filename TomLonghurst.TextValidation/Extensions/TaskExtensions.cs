using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomLonghurst.TextValidation.Extensions
{
    internal static class TaskExtensions
    {
        internal static async Task<bool> AllAsync(this IEnumerable<Task<bool>> source)
        {
            var tasks = source.ToList();

            while (tasks.Count != 0)
            {
                var finishedTask = await Task.WhenAny(tasks);

                if (!finishedTask.Result)
                {
                    return false;
                }

                tasks.Remove(finishedTask);
            }

            return true;
        }
    }
}