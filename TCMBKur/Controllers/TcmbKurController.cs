using Microsoft.AspNetCore.Mvc;
using TCMBKur.Business.Repository;
using TCMBKur.Dtos;

namespace TCMBKur.Controllers;

[ApiController]
[Route("[controller]")]
public class TcmbKurController: ControllerBase
{
    private readonly IGeneralRepository _generalRepository;

    public TcmbKurController(IGeneralRepository generalRepository)
    {
        _generalRepository = generalRepository;
    }

    [HttpGet]
    public async Task<ForeignCurrencyDto> Get()
    {
        return await _generalRepository.GetForeignCurrency();
    }
}