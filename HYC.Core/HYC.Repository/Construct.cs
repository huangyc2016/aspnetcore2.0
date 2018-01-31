using HYC.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Repository
{
    public class Construct
    {
        public readonly IOptions<SqlHelper> _optionsAccessor;
        public Construct(IOptions<SqlHelper> optionsAccessor)
        {
            this._optionsAccessor = optionsAccessor;
        }
    }
}
