﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using folder_structure.Models;

namespace folder_structure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<folder_structure.Models.Product> Product { get; set; } = default!;
        public DbSet<folder_structure.Models.Student> Students { get; set; } = default!;

        public DbSet<folder_structure.Models.Employee> Employees { get; set; } = default!;
        public DbSet<folder_structure.Models.Department> Departments { get; set; } = default!;
    }
}
