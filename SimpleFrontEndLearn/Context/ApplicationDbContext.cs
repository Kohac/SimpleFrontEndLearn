﻿using Microsoft.EntityFrameworkCore;
using SimpleFrontEndLearn.Models;

namespace SimpleFrontEndLearn.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        public DbSet<Category>  Categories { get; set; }

    }
}
