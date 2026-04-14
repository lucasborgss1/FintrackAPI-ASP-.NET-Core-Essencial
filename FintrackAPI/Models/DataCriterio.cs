namespace FintrackAPI.Models;

public enum DataCriterio
{
    /// <summary>Transações com data anterior à informada</summary>
    AntesDe,
    /// <summary>Transações com data posterior à informada</summary>
    DepoisDe,
    /// <summary>Transações com data igual à informada</summary>
    IgualA
}