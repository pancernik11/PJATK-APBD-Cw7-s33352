using Microsoft.EntityFrameworkCore;
using PcManager.Data;
using PcManager.Models;

namespace PcManager.Repositories;

public class PcRepository : IPcRepository
{
    private readonly AppDbContext _context;

    public PcRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PC>> GetAllAsync()
    {
        return await _context.PCs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PC?> GetByIdWithComponentsAsync(int id)
    {
        return await _context.PCs
            .AsNoTracking()
            .Include(p => p.PCComponents)
                .ThenInclude(pc => pc.Component)
                    .ThenInclude(c => c.Manufacturer)
            .Include(p => p.PCComponents)
                .ThenInclude(pc => pc.Component)
                    .ThenInclude(c => c.Type)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<PC> CreateAsync(PC pc)
    {
        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();
        return pc;
    }

    public async Task<PC?> UpdateAsync(int id, PC updatedPc)
    {
        var existing = await _context.PCs.FindAsync(id);
        if (existing is null) return null;

        existing.Name = updatedPc.Name;
        existing.Weight = updatedPc.Weight;
        existing.Warranty = updatedPc.Warranty;
        existing.CreatedAt = updatedPc.CreatedAt;
        existing.Stock = updatedPc.Stock;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc is null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}
