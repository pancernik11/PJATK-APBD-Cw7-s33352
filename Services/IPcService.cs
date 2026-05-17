using PcManager.DTOs;

namespace PcManager.Services;

public interface IPcService
{
    Task<IEnumerable<PcListDto>> GetAllAsync();
    Task<PcWithComponentsDto?> GetByIdWithComponentsAsync(int id);
    Task<PcListDto> CreateAsync(CreatePcDto dto);
    Task<PcListDto?> UpdateAsync(int id, UpdatePcDto dto);
    Task<bool> DeleteAsync(int id);
}
