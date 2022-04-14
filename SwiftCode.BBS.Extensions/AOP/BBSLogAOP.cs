using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Extensions.AOP
{
    public class BBSLogAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var dataIntercept = $"{DateTime.Now.ToString("yyyyMMddHHmmss")} " +
                             $"The current execution method：{ invocation.Method.Name} " +
                             $"The parameter is： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";

            //it is only for non asyco task/ methode
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                dataIntercept += ($"An exception occurred during method execution：{ex.Message}");
            }


            dataIntercept += ($"The intercepted method finishes executing and returns the result：{invocation.ReturnValue}");

            #region 输出到当前项目日志
            var path = Directory.GetCurrentDirectory() + @"\Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";

            StreamWriter sw = File.AppendText(fileName);
            sw.WriteLine(dataIntercept);
            sw.Close();
            #endregion

        }
    }
}