using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
    public class ComputeService : IComputeService
    {

		private bool CenterGravityCheck(InputData data)
		{
			Layer	iLayer = data.InternalLayer;
			Layer	eLayer = data.ExternalLayer;
			int 	externalCenterX = eLayer.X + (eLayer.Width / 2);
			int 	externalCenterY = eLayer.Y + (eLayer.Height / 2);

			return (iLayer.X <= externalCenterX && externalCenterX <= iLayer.X + iLayer.Width)
				&& (iLayer.Y <= externalCenterY && externalCenterY <= iLayer.Y + iLayer.Height);
		}
		private bool InsulatedLayerCheck(InputData data)
		{
			int	thickness = data.InsulatedLayer.Thickness;

			if (thickness < 40 || thickness > 390)
				return (false);
			return (true);
		}
		
		private bool HolePositionCheck(InputData data)
		{
			int HoleOverlapping(Hole hole, Layer layer)
			{
				int	overlapX = Math.Max(layer.X, hole.X);
				int	overlapY = Math.Max(layer.Y, hole.Y);
				int	overlapWidth = Math.Max(0, Math.Min(layer.X + layer.Width, hole.X + hole.Width) - overlapX);
				int	overlapHeight = Math.Max(0, Math.Min(layer.Y + layer.Height, hole.X + hole.Height) - overlapY);
				int	overlapArea = (overlapWidth * overlapHeight) / 1_000_000;
				return (overlapArea);
			}
			bool CheckHoleAllowedPosition(Hole hole, HolePosition overlapPosition)
			{
				if ((hole.Position != HolePosition.Both)
					&& (overlapPosition == HolePosition.Both))
				{
					return (false);
				}
				return (true);
			}
			//---------------------------------
			// Function body
			//---------------------------------
			int	internalOverlap = HoleOverlapping(data.Hole, data.InternalLayer);
			int	externalOverlap = HoleOverlapping(data.Hole, data.ExternalLayer);
			HolePosition	overlapPosition;
			if (internalOverlap > 0 && externalOverlap > 0)
				overlapPosition = HolePosition.Both;
        	else if (internalOverlap > 0)
				overlapPosition = HolePosition.Internal;
        	else if (externalOverlap > 0)
				overlapPosition = HolePosition.External;
        	else
				return (false);
			if (!CheckHoleAllowedPosition(data.Hole, overlapPosition))
				return (false);
			return (true);	
		}

		public string InputCheck(InputData data)
		{
			if (!CenterGravityCheck(data))
				return ("Centre of gravity outside of internal layer");
			if (!InsulatedLayerCheck(data))
				return ("Invalid thickness of insulation");
			if (!HolePositionCheck(data))
				return ("Invalid hole position");
			return (null);
		}
    }
}
