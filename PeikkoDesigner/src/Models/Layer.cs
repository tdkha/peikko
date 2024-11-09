using System.Text.Json.Serialization;

public class Layer
{
	//---------------------------------------------
	// Properties
	//---------------------------------------------
	public string Name { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public int Thickness { get; set; }

	//---------------------------------------------
	// Constructor 
	//---------------------------------------------
	public Layer(string name, int x, int y, int width, int height, int thickness)
	{
		Name = name;
		X = x;
		Y = y;
		Width = width;
		Height = height;
		Thickness = thickness;
	}
	
	//---------------------------------------------
	// Methods 
	//---------------------------------------------
	public virtual void Print()
	{
		Console.WriteLine("------------------------");
		Console.WriteLine($"{Name}:");
		Console.WriteLine("------------------------");
		Console.WriteLine($"X: {X}");
		Console.WriteLine($"Y: {Y}");
		Console.WriteLine($"Width: {Width}");
		Console.WriteLine($"Height: {Height}");
		Console.WriteLine($"Thickness: {Thickness}");
	} 
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HolePosition
{
    Internal, External, Both
}

public class Hole : Layer
{
	//---------------------------------------------
	// Properties
	//---------------------------------------------
	public HolePosition Position { get; set; }

	//---------------------------------------------
	// Constructor 
	//---------------------------------------------
	public Hole(string name, int x, int y, int width, int height, HolePosition position)
		: base(name, x, y, width, height, 0)
	{
		Position = position;
	}

	//---------------------------------------------
	// Methods 
	//---------------------------------------------
	public int SetThickness(
		Layer externalLayer,
		Layer internalLayer,
		Layer? insulatedLayer)
	{
		switch (Position)
		{
			case HolePosition.Internal:
				Thickness = internalLayer.Thickness;
				return Thickness;
			case HolePosition.External:
				Thickness = externalLayer.Thickness;
				return Thickness;
			case HolePosition.Both:
				int thickness = 0;
				if (internalLayer != null)
					thickness += internalLayer.Thickness;
				if (insulatedLayer != null)
					thickness += insulatedLayer.Thickness;
				if (externalLayer != null)
					thickness += externalLayer.Thickness;
				Thickness = thickness;
				return Thickness;
			default:
				return 0;
		}
	}

	public override void Print()
	{
		base.Print();
		Console.WriteLine($"Position: {Position}");
	}
}