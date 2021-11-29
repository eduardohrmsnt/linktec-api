using System;

namespace LinkTec.Api.Enums
{
    [Flags]
    public enum ETipoServico
    {
        FrontEnd = 1, BackEnd = 2, DevOps = 4, DatabaseAdmnistrator = 8
    }
}
