using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AggregatorContext
{
    public class ContextFactory:IDesignTimeDbContextFactory<AggregatorDBContext>
    {
        public AggregatorDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AggregatorDBContext>();
            builder.UseSqlServer(
                "Server=DESKTOP-PPBUNVU;Database=testDB;user id=sa; password=samanvitha");
            builder.EnableSensitiveDataLogging();

            return new AggregatorDBContext(builder.Options);
        }
    }
}
