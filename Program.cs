using System;
using Newtonsoft.Json;
using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Repository;
using System.IO;
using System.Reflection;

namespace HelloLogentries {
	class Program {

		// Static instance of log4net logger
		private static readonly ILog log = LogManager.GetLogger(typeof(Program));

		static void demo_log4net() {
			// http://logging.apache.org/log4net/release/manual/configuration.html
			// https://docs.logentries.com/docs/log4net
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

			// Demo log record
			LogRecord lr = new LogRecord {
				Date = $"{DateTime.Now}",
						 From = "computer",
						 Msg = "hello computer"
			};

			// Marshaling log record to json
			//string json = JsonConvert.SerializeObject(lr, Formatting.Indented);
			string json = "Hello Tizen!";

			// Different types of loggin
			log.Info($"Log info: {json}");
			log.Debug($"Log Debug: {json}");
			Console.WriteLine($"Console WriteLine: {json}");
		}

		static void Main(string[] args) {
			demo_log4net();
		}
	}
}
