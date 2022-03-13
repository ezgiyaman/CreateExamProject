using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Interface
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; }

        DateTime? UpdateDate { get; }

        DateTime? DeleteDate { get; }

        Status Status { get; }

    }
}
