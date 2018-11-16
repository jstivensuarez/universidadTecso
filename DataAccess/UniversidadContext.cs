using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UniversidadContext: DbContext
    {
        public UniversidadContext(DbContextOptions<UniversidadContext>  options): base(options)
        {

        }
    }
}
