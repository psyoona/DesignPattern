namespace DesignPattern.Design_Patterns
{
	using System;

	public class Factory
	{
		ILogger logger = LoggerFacotry.Create("DB");
		// ...
	}

	public interface ILogger
	{

	}

	public class LoggerFacotry
	{
		// Static Factory Method
		// (loggerType을 enum으로 하는 것이 일반적)
		public static ILogger Create(string loggerType)
		{
			ILogger logger = null;

			switch (loggerType)
			{
				case "DB":
					logger = new DbLogger();
					break;
				case "XML":
					logger = new XmlLogger();
					break;
				case "JSON":
					logger = new JsonLogger();
					break;
				default:
					throw new InvalidOperationException();
			}

			return logger;
		}

		public class DbLogger : ILogger
		{
		}

		public class XmlLogger : ILogger
		{

		}

		public class JsonLogger : ILogger
		{

		}
	}

}
