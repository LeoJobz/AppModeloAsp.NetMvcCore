﻿using DevIOUI.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIOUI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
