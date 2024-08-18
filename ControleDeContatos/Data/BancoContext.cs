using System;
using ControleDeContatos.Data;
using ControleDeContatos.Migrations;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeContatos.Data
{
    // Utilizado para realizar o mapeamento e migração do Banco de Dados
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

