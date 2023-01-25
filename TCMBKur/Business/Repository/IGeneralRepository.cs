using TCMBKur.Dtos;

namespace TCMBKur.Business.Repository;

public interface IGeneralRepository
{
    public Task<ForeignCurrencyDto> GetForeignCurrency();
}