using System.Collections.Generic;
using System.Threading.Tasks;
using PeikkoDesigner.Models;

namespace PeikkoDesigner.Interfaces
{
	public interface IComputeService
	{
		Task<int> InputCheck(InputData data);
	}
}
