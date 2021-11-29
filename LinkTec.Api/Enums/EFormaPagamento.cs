using System;

namespace LinkTec.Api.Enums
{
    [Flags]
    public enum EFormaPagamento
    {
        CartaoDeCredito = 1, Boleto = 2, Pix = 4, Dinheiro = 8
    }
}
