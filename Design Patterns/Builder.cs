namespace DesignPattern.Design_Patterns
{
	using System;

	class Builder
	{
		void HowtoTest()
		{
			IBedBuilder builder = new Simons();
			Director director = new Director();
			Bed bed = director.Construct(builder);

			Console.WriteLine(bed.ToString());
		}
	}

	public interface IBedBuilder
	{
		void MakeFrame();

		void MakeMattress();

		void MakeSheet(string sheet);

		void MakePillow(int size);

		Bed Build();
	}

	// Concrete Builder
	public class Simons: IBedBuilder
	{
		private Bed bed = new Bed();

		private int PillowSize { get; set; } = 0;

		private string SheetName { get; set; }

		public Bed Build()
		{
			bed.Pillow = $"Pillow Size #{PillowSize}";
			bed.Sheet = $"Sheet {SheetName}";

			return bed;
		}

		public void MakeFrame()
		{
			bed.Frame = (DateTime.Now.Month > 5 && DateTime.Now.Month < 9) ? "Simons Summer Frame" : "Simons Wood Frame";
		}

		public void MakeMattress()
		{
			bed.Mattress = "Simmons Mattress";
		}

		public void MakePillow(int size)
		{
			this.PillowSize = size;
		}

		public void MakeSheet(string sheet)
		{
			this.SheetName = sheet;
		}
	}

	public class Bed
	{
		public string Frame { get; set; }

		public string Mattress { get; set; }

		public string Pillow { get; set; }

		public string Sheet { get; set; }

		public override string ToString()
		{
			return $"{Frame}, {Mattress}, {Pillow}, {Sheet}";
		}
	}

	// Director class
	public class Director
	{
		public Bed Construct(IBedBuilder builder)
		{
			builder.MakeFrame();
			builder.MakeMattress();
			builder.MakeSheet("White");

			return builder.Build();
		}
	}

}
