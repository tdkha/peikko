using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		private bool CenterGravityCheck(InputData data)
		{
			Layer	iLayer = data.InternalLayer;
			Layer	eLayer = data.ExternalLayer;
			double 	externalCenterX = eLayer.X + (eLayer.Width / 2);
			double 	externalCenterY = eLayer.Y + (eLayer.Height / 2);

			return (iLayer.X <= externalCenterX && externalCenterX <= iLayer.X + iLayer.Width)
				&& (iLayer.Y <= externalCenterY && externalCenterY <= iLayer.Y + iLayer.Height);
		}
	}
}