using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		private	 ComputeDto.LayerLoadsDto ComputeLayerLoads(Layer layer, double holeArea) 
		{
			double surfaceArea = ((layer.Width * layer.Height) / 1_000_000 - holeArea);
			double volume = surfaceArea * (layer.Thickness / 1000);
			double density = 2400f;
			double weightKg = volume * density;
			double weightKn = weightKg * 0.01;
			return new ComputeDto.LayerLoadsDto 
			{
				Name = layer.Name,
				SurfaceArea = surfaceArea,
				Volume = volume,
				WeightKg = weightKg,
				WeightKn = weightKn
			};
		}
	}
}