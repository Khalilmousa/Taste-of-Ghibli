using GhibliFoodApi.Models;

namespace GhibliFoodApi.Services;

public interface IGhibliFoodService
{
    Task<IEnumerable<GhibliFood>> GetGhibliFoodAsync();
}