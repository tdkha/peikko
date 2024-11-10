namespace PeikkoDesigner.Interfaces
{
	public interface IComputeService
	{
		string CheckGeometry(InputData data);
		List<ComputeDto.LayerLoadsDto> ComputeLoads(InputData data);
	}
}
