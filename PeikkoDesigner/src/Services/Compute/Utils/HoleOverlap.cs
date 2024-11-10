using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		private double HoleOverlap(Hole hole, Layer layer)
		{
			double	overlapX = Math.Max(layer.X, hole.X);
			double	overlapY = Math.Max(layer.Y, hole.Y);
			double	overlapWidth = Math.Max(0, Math.Min(layer.X + layer.Width, hole.X + hole.Width) - overlapX);
			double	overlapHeight = Math.Max(0, Math.Min(layer.Y + layer.Height, hole.X + hole.Height) - overlapY);
			double	overlapArea = (overlapWidth * overlapHeight) / 1_000_000;
			return (overlapArea);
		}
	}
}