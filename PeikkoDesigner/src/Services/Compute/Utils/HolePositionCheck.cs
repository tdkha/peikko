using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		private bool HolePositionCheck(InputData data)
		{
			bool CheckHoleAllowedPosition(Hole hole, HolePosition overlapPosition)
			{
				if ((hole.Position != HolePosition.Both)
					&& (overlapPosition == HolePosition.Both))
				{
					return (false);
				}
				return (true);
			}
			Nullable<HolePosition>	 overlapPosition = HoleOverlapPosition(data);
			if (overlapPosition == null)
				return (false);
			if (!CheckHoleAllowedPosition(data.Hole, overlapPosition.Value))
				return (false);
			return (true);	
		}
	}
}