namespace DesignPattern.Design_Patterns
{
	using System;
	using System.Collections.Concurrent;

	public class MyConnection
	{
		public MyConnection()
		{

		}
	}


	// Object Pool class
	public class MyConnectionPool
	{
		// Thread-safe collection
		private readonly ConcurrentBag<MyConnection> pool = new ConcurrentBag<MyConnection>();

		public MyConnection GetObject()
		{
			MyConnection obj;
			if (pool.TryTake(out obj))
			{
				// 기존 객체 return
				return obj;
			}
			else
			{
				// 새 객체 return
				return new MyConnection();
			}
		}

		public void ReleaseObject(MyConnection conn)
		{
			// Release하면 pool에 추가
			pool.Add(conn);
			Console.WriteLine($"Release: {conn.GetHashCode()}");
		}
	}
}
