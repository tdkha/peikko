public class Layer
{
	public string Name { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public int Thickness { get; set; }

	public Layer(string name, int x, int y, int width, int height, int thickness)
    {
        Name = name;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Thickness = thickness;
    }
	public void Print()
    {
        Console.WriteLine($"{Name}:");
        Console.WriteLine($"  X: {X}");
        Console.WriteLine($"  Y: {Y}");
        Console.WriteLine($"  Width: {Width}");
        Console.WriteLine($"  Height: {Height}");
        Console.WriteLine($"  Thickness: {Thickness}");
    } 
}

public class InputData
{
    public Layer ExternalLayer { get; set; }
    public Layer InternalLayer { get; set; }
    public Layer InsulatedLayer { get; set; }
    public Layer Hole { get; set; }

    public InputData(Layer externalLayer, Layer internalLayer, Layer insulatedLayer, Layer hole)
    {
        ExternalLayer = externalLayer;
        InternalLayer = internalLayer;
        InsulatedLayer = insulatedLayer;
        Hole = hole;
    }
	public void PrintLayers()
    {
		ExternalLayer.Print();
		InternalLayer.Print();
		InsulatedLayer.Print();
		Hole.Print();
    }
}
