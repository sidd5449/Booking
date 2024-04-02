﻿using Booking.Models;
using Microsoft.EntityFrameworkCore;
namespace Booking.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slot> Slots { get; set; }
    }
}
