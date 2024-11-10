using System.Threading.Tasks;
using PeikkoDesigner.Models;
using PeikkoDesigner.Interfaces;

namespace PeikkoDesigner.Services
{
	public partial class ComputeService : IComputeService
	{
		private bool InsulatedLayerCheck(InputData data)
		{
			double	thickness = data.InsulatedLayer.Thickness;

			if (thickness < 40 || thickness > 390)
				return (false);
			return (true);
		}
	}
}