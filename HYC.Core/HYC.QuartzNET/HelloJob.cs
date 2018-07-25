using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HYC.QuartzNET
{
    /// <summary>
    /// DisallowConcurrentExecution(并发限制)
    /// </summary>
    [DisallowConcurrentExecution]
    public class HelloJob:IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Greetings from HelloJob!");
            System.Threading.Thread.Sleep(5 * 1000);
        }
    }
}
