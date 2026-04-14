using System.ComponentModel.DataAnnotations;

namespace FintrackAPI.Validations;

/// <summary>
/// Valida que o valor de uma transação é maior que zero.
/// Exibe a moeda configurada em <c>configuracao:moeda</c> no appsettings na mensagem de erro.
/// </summary>
public class ValorMinimoTransacaoAttribute : ValidationAttribute
{
    /// <inheritdoc />
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