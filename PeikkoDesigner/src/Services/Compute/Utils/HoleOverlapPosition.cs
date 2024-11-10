using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		private HolePosition? HoleOverlapPosition(InputData data)
		{
			double	internalOverlap = HoleOverlap(data.Hole, data.InternalLayer);
			double	externalOverlap = HoleOverlap(data.Hole, data.ExternalLayer);
			HolePosition	overlapPosition;
			
			if (internalOverlap > 0 && externalOverlap > 0)
				overlapPosition = HolePosition.Both;
			else if (internalOverlap > 0)
				overlapPosition = HolePosition.Internal;
			else if (externalOverlap > 0)
				overlapPosition = HolePosition.External;
			else
				return (null);
			return (overlapPosition);
		}
	}
}