using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserName { get; }
    }
}
