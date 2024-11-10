using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		public string CheckGeometry(InputData data)
		{
			if (!CenterGravityCheck(data))
				return ("Centre of gravity outside of internal layer");
			if (!InsulatedLayerCheck(data))
				return ("Invalid thickness of insulation");
			if (!HolePositionCheck(data))
				return ("Invalid hole position");
			return (null);
		}

		public List<ComputeDto.LayerLoadsDto> ComputeLoads(InputData data)
		{
			double							overlap;
			ComputeDto.LayerLoadsDto	internalLoads;
			ComputeDto.LayerLoadsDto	externalLoads;

			if (data.Hole.Position == HolePosition.Internal)
			{
				overlap = HoleOverlap(data.Hole, data.InternalLayer);
				internalLoads = ComputeLayerLoads(data.InternalLayer, overlap);
				externalLoads = ComputeLayerLoads(data.ExternalLayer, 0);
			}
			else if (data.Hole.Position == HolePosition.External)
			{
				overlap = HoleOverlap(data.Hole, data.ExternalLayer);
				internalLoads = ComputeLayerLoads(data.InternalLayer, 0);
				externalLoads = ComputeLayerLoads(data.ExternalLayer, overlap);
			}
			else
			{
				overlap = HoleOverlap(data.Hole, data.InternalLayer);
				internalLoads = ComputeLayerLoads(data.InternalLayer, overlap);
				overlap = HoleOverlap(data.Hole, data.InternalLayer);
				externalLoads = ComputeLayerLoads(data.ExternalLayer, overlap);
			}
			return ([internalLoads, externalLoads]);
		}
	}
}
