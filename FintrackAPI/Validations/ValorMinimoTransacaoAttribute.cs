using System.ComponentModel.DataAnnotations;

namespace FintrackAPI.Validations;

public class ValorMinimoTransacaoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var configuration = (IConfiguration?)validationContext.GetService(typeof(IConfiguration));
        if (value is decimal valor && valor <= 0)
        {
            var moeda = configuration?["configuracao:moeda"] ?? string.Empty;
            return new ValidationResult($"O valor da transação deve ser maior do que 0,00 {moeda}");
        }
        return ValidationResult.Success;
    }
}