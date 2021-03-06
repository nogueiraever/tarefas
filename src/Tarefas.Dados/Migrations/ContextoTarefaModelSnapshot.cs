﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarefas.Dados;

namespace Tarefas.Dados.Migrations
{
    [DbContext(typeof(ContextoTarefa))]
    partial class ContextoTarefaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tarefas.Dominio.Tarefa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataConclusao");

                    b.Property<DateTime?>("DataRemocao");

                    b.Property<DateTime?>("DataUltimaAlteracao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
