using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaBus.DAO.Builder
{
    public interface IBuilder<T>
    {
        T Build(DataRow row);
    }
}
