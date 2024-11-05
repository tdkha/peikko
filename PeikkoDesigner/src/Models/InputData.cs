
public class InputData
{
	//---------------------------------------------
	// Properties
	//---------------------------------------------
	public Layer ExternalLayer { get; set; }
	public Layer InternalLayer { get; set; }
	public int InsulatedLayerThickness { get; set; }
	public Hole Hole { get; set; }
	public Layer InsulatedLayer { get; private set; }
	
	//---------------------------------------------
	// Constructor 
	//---------------------------------------------
	public InputData(Layer externalLayer, Layer internalLayer, int insulatedLayerThickness, Hole hole)
	{
		ExternalLayer = externalLayer;
		InternalLayer = internalLayer;
		InsulatedLayer = new Layer(
			"InsulatedLayer",
			internalLayer.X,
			internalLayer.Y,
			internalLayer.Width,
			internalLayer.Height,
			insulatedLayerThickness);
		Hole = hole;
		hole.SetThickness(ExternalLayer, InternalLayer, InsulatedLayer);
	}
	//---------------------------------------------
	// Methods 
	//---------------------------------------------
	public bool	Check()
	{
		if (ValidateCenterGravity(ExternalLayer, InternalLayer))
			return (true);
		return (false);
	}

	public void PrintLayers()
	{
		ExternalLayer.Print();
		InternalLayer.Print();
		InsulatedLayer.Print();
		Hole.Print();
	}

	//---------------------------------------------
	// Helper functions 
	//---------------------------------------------s
	private static bool ValidateCenterGravity(Layer eLayer, Layer iLayer)
	{
		int externalCenterX = eLayer.X + (eLayer.Width / 2);
		int externalCenterY = eLayer.Y + (eLayer.Height / 2);
		return (iLayer.X <= externalCenterX && externalCenterX <= iLayer.X + iLayer.Width)
			&& (iLayer.Y <= externalCenterY && externalCenterY <= iLayer.Y + iLayer.Height);
	}

}
