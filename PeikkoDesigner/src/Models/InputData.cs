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
		InsulatedLayerThickness = insulatedLayerThickness;  // Assign thickness to the property
		InitInsulatedLayer(InternalLayer, ExternalLayer, InsulatedLayerThickness);
		Hole = hole;
		hole.SetThickness(ExternalLayer, InternalLayer, InsulatedLayer);
	}

	//---------------------------------------------
	// Methods 
	//---------------------------------------------
	public void PrintLayers()
	{
		ExternalLayer.Print();
		InternalLayer.Print();
		InsulatedLayer.Print();
		Hole.Print();
	}

	private void InitInsulatedLayer(Layer iLayer, Layer eLayer, int thickness)
	{
		InsulatedLayer = new Layer(
			"InsulatedLayer",
			Math.Max(iLayer.X, eLayer.X),
			Math.Max(iLayer.Y, eLayer.Y),
			Math.Min(iLayer.X + iLayer.Width, eLayer.X + eLayer.Width) - Math.Max(iLayer.X, eLayer.X),
			Math.Min(iLayer.Y + iLayer.Height, eLayer.Y + eLayer.Height) - Math.Max(iLayer.Y, eLayer.Y),
			thickness  // Use the parameter for thickness
		);
	}
}
