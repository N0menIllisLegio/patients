using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Patients.Data.Entities;

namespace Patients.Helpers
{
  class DiaryRecordsEqualityComparer: IEqualityComparer<DiaryRecord>
  {
    public bool Equals(DiaryRecord x, DiaryRecord y)
    {
      if ((x is null && y is not null) || (y is null && x is not null))
      {
        return false;
      }

      return x?.ID == y?.ID;
    }

    public int GetHashCode([DisallowNull] DiaryRecord obj)
    {
      throw new NotImplementedException();
    }
  }
}
