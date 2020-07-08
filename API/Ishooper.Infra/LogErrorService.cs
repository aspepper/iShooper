using data = Ishooper.Dal;
using System;
using Ishooper.Infra.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Ishooper.Infra
{
    public class LogErrorService : ILogErrorService
    {

        private readonly IConfiguration _configuration;

        public LogErrorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Insert(Exception e)
        {
            var context = new data.MongoContext(_configuration);
            var data = new data.ErrorLogRepository(context);
            try
            {
                _ = data.Add(new data.Models.ErrorLog
                {
                    ErrorCode = e.HResult,
                    Message = e.Message,
                    Source = e.Source,
                    StackTrace = e.StackTrace
                });
                _ = context.SaveChanges();
            }
            catch (Exception ex)
            {
                using StreamWriter writer = new StreamWriter(string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}{1}", AppContext.BaseDirectory, "error.log"), true);
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine(value: "Date : " + DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentCulture));
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
                throw;
            }
        }
    }
}
