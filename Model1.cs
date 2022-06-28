using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SchoolsMarks
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=SchoolsMarksDataBase")
        {
        }

        public virtual DbSet<Egzaminy> Egzaminies { get; set; }
        public virtual DbSet<Frekwencja> Frekwencjas { get; set; }
        public virtual DbSet<Klasy> Klasies { get; set; }
        public virtual DbSet<Nagrody> Nagrodies { get; set; }
        public virtual DbSet<OcenyKońcowe> OcenyKońcowe { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Przedmioty> Przedmioties { get; set; }
        public virtual DbSet<Samorząd> Samorząd { get; set; }
        public virtual DbSet<Uczniowie> Uczniowies { get; set; }
        public virtual DbSet<Wyniki> Wynikis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Egzaminy>()
                .HasMany(e => e.Wynikis)
                .WithOptional(e => e.Egzaminy)
                .HasForeignKey(e => e.ID_Egzaminu);

            modelBuilder.Entity<Frekwencja>()
                .Property(e => e.Frekwencja1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Klasy>()
                .HasMany(e => e.Uczniowies)
                .WithOptional(e => e.Klasy)
                .HasForeignKey(e => e.ID_Klasy);

            modelBuilder.Entity<Przedmioty>()
                .HasMany(e => e.OcenyKońcowe)
                .WithOptional(e => e.Przedmioty)
                .HasForeignKey(e => e.ID_Przedmiotu);

            modelBuilder.Entity<Uczniowie>()
                .HasMany(e => e.Frekwencjas)
                .WithOptional(e => e.Uczniowie)
                .HasForeignKey(e => e.ID_Ucznia);

            modelBuilder.Entity<Uczniowie>()
                .HasMany(e => e.OcenyKońcowe)
                .WithOptional(e => e.Uczniowie)
                .HasForeignKey(e => e.ID_Ucznia);

            modelBuilder.Entity<Uczniowie>()
                .HasMany(e => e.Samorząd)
                .WithOptional(e => e.Uczniowie)
                .HasForeignKey(e => e.ID_Ucznia);

            modelBuilder.Entity<Uczniowie>()
                .HasMany(e => e.Wynikis)
                .WithOptional(e => e.Uczniowie)
                .HasForeignKey(e => e.ID_Ucznia);

            modelBuilder.Entity<Wyniki>()
                .Property(e => e.Wynik)
                .HasPrecision(8, 2);
        }
    }
}
