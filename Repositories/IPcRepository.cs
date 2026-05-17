using PcManager.Models;

namespace PcManager.Repositories;

public interface IPcRepository
{
    Task<IEnumerable<PC>> GetAllAsync();
    Task<PC?> GetByIdWithComponentsAsync(int id);
    Task<PC> CreateAsync(PC pc);
    Task<PC?> UpdateAsync(int id, PC pc);
    Task<bool> DeleteAsync(int id);
}
