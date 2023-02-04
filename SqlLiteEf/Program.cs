
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Context;

Console.WriteLine("Hello, World!");

public class ContextFactory : IDesignTimeDbContextFactory<ThePlayerContext>
{
    public ThePlayerContext CreateDbContext(string[] args)
        => new(null, new DbContextOptionsBuilder<ThePlayerContext>().UseSqlite(args[0]).Options);
}