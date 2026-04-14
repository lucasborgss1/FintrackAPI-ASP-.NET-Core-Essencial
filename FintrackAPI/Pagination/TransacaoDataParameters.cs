using FintrackAPI.Models;

namespace FintrackAPI.Pagination;

public class TransacaoDataParameters : QueryStringParameters
{
    public DateOnly? Data { get; set; }
    public DataCriterio? DataCriterio { get; set; }
}
