namespace Ozoterija.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<dogadjaj> dogadjaj { get; set; }
        public virtual DbSet<dogadjaj_ponuda> dogadjaj_ponuda { get; set; }
        public virtual DbSet<grad> grad { get; set; }
        public virtual DbSet<najam> najam { get; set; }
        public virtual DbSet<natjecaj> natjecaj { get; set; }
        public virtual DbSet<natjecaj_ponuda> natjecaj_ponuda { get; set; }
        public virtual DbSet<oprema> oprema { get; set; }
        public virtual DbSet<oprema_dogadjaj> oprema_dogadjaj { get; set; }
        public virtual DbSet<oprema_najam> oprema_najam { get; set; }
        public virtual DbSet<ponuda> ponuda { get; set; }
        public virtual DbSet<ponuda_referentni_tip> ponuda_referentni_tip { get; set; }
        public virtual DbSet<ponuda_uloga> ponuda_uloga { get; set; }
        public virtual DbSet<radnik> radnik { get; set; }
        public virtual DbSet<radnik_dogadjaj> radnik_dogadjaj { get; set; }
        public virtual DbSet<radnik_najam> radnik_najam { get; set; }
        public virtual DbSet<radnik_uloga> radnik_uloga { get; set; }
        public virtual DbSet<referetni_tip> referetni_tip { get; set; }
        public virtual DbSet<servis> servis { get; set; }
        public virtual DbSet<skladiste> skladiste { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<uloga> uloga { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dogadjaj>()
                .Property(e => e.naziv_dogadjaja)
                .IsUnicode(false);

            modelBuilder.Entity<dogadjaj>()
                .HasMany(e => e.dogadjaj_ponuda)
                .WithRequired(e => e.dogadjaj)
                .HasForeignKey(e => e.fk_dogadjaj)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dogadjaj>()
                .HasMany(e => e.oprema_dogadjaj)
                .WithRequired(e => e.dogadjaj)
                .HasForeignKey(e => e.fk_dogadjaj)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dogadjaj>()
                .HasMany(e => e.radnik_dogadjaj)
                .WithRequired(e => e.dogadjaj)
                .HasForeignKey(e => e.fk_dogadjaj)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<grad>()
                .Property(e => e.ime_grada)
                .IsUnicode(false);

            modelBuilder.Entity<grad>()
                .HasMany(e => e.dogadjaj)
                .WithRequired(e => e.grad)
                .HasForeignKey(e => e.fk_grad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<grad>()
                .HasMany(e => e.radnik)
                .WithRequired(e => e.grad)
                .HasForeignKey(e => e.fk_grad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<grad>()
                .HasMany(e => e.skladiste)
                .WithRequired(e => e.grad)
                .HasForeignKey(e => e.fk_grad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<najam>()
                .Property(e => e.naziv_najma)
                .IsUnicode(false);

            modelBuilder.Entity<najam>()
                .Property(e => e.tip_najma)
                .IsUnicode(false);

            modelBuilder.Entity<najam>()
                .HasMany(e => e.oprema_najam)
                .WithRequired(e => e.najam)
                .HasForeignKey(e => e.fk_najam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<najam>()
                .HasMany(e => e.radnik_najam)
                .WithRequired(e => e.najam)
                .HasForeignKey(e => e.fk_najam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<natjecaj>()
                .Property(e => e.tip_natjecaja)
                .IsUnicode(false);

            modelBuilder.Entity<natjecaj>()
                .Property(e => e.ime_natjecaja)
                .IsUnicode(false);

            modelBuilder.Entity<natjecaj>()
                .HasMany(e => e.natjecaj_ponuda)
                .WithRequired(e => e.natjecaj)
                .HasForeignKey(e => e.fk_natjecaj)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<oprema>()
                .Property(e => e.ime_opreme)
                .IsUnicode(false);

            modelBuilder.Entity<oprema>()
                .Property(e => e.trenutno_stanje)
                .IsUnicode(false);

            modelBuilder.Entity<oprema>()
                .HasMany(e => e.oprema_dogadjaj)
                .WithRequired(e => e.oprema)
                .HasForeignKey(e => e.fk_oprema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<oprema>()
                .HasMany(e => e.oprema_najam)
                .WithRequired(e => e.oprema)
                .HasForeignKey(e => e.fk_oprema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<oprema>()
                .HasMany(e => e.servis)
                .WithRequired(e => e.oprema)
                .HasForeignKey(e => e.fk_oprema)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ponuda>()
                .Property(e => e.cijena_ponude)
                .IsUnicode(false);

            modelBuilder.Entity<ponuda>()
                .HasMany(e => e.dogadjaj_ponuda)
                .WithRequired(e => e.ponuda)
                .HasForeignKey(e => e.fk_ponuda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ponuda>()
                .HasMany(e => e.natjecaj_ponuda)
                .WithRequired(e => e.ponuda)
                .HasForeignKey(e => e.fk_ponuda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ponuda>()
                .HasMany(e => e.ponuda_referentni_tip)
                .WithRequired(e => e.ponuda)
                .HasForeignKey(e => e.fk_ponuda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ponuda>()
                .HasMany(e => e.ponuda_uloga)
                .WithRequired(e => e.ponuda)
                .HasForeignKey(e => e.fk_ponuda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<radnik>()
                .Property(e => e.ime_radnika)
                .IsUnicode(false);

            modelBuilder.Entity<radnik>()
                .Property(e => e.prezime_radnika)
                .IsUnicode(false);

            modelBuilder.Entity<radnik>()
                .Property(e => e.certifikat_radnika)
                .IsUnicode(false);

            modelBuilder.Entity<radnik>()
                .HasMany(e => e.radnik_dogadjaj)
                .WithRequired(e => e.radnik)
                .HasForeignKey(e => e.fk_radnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<radnik>()
                .HasMany(e => e.radnik_najam)
                .WithRequired(e => e.radnik)
                .HasForeignKey(e => e.fk_radnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<radnik>()
                .HasMany(e => e.radnik_uloga)
                .WithRequired(e => e.radnik)
                .HasForeignKey(e => e.fk_radnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<radnik_dogadjaj>()
                .Property(e => e.uloga)
                .IsUnicode(false);

            modelBuilder.Entity<radnik_najam>()
                .Property(e => e.uloga)
                .IsUnicode(false);

            modelBuilder.Entity<referetni_tip>()
                .Property(e => e.ime_referetni_tip)
                .IsUnicode(false);

            modelBuilder.Entity<referetni_tip>()
                .HasMany(e => e.oprema)
                .WithRequired(e => e.referetni_tip)
                .HasForeignKey(e => e.fk_referetni_tip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<referetni_tip>()
                .HasMany(e => e.ponuda_referentni_tip)
                .WithRequired(e => e.referetni_tip)
                .HasForeignKey(e => e.fk_referentni_tip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<servis>()
                .Property(e => e.dijelovi)
                .IsUnicode(false);

            modelBuilder.Entity<skladiste>()
                .Property(e => e.ime_sklaldista)
                .IsUnicode(false);

            modelBuilder.Entity<skladiste>()
                .HasMany(e => e.oprema)
                .WithRequired(e => e.skladiste)
                .HasForeignKey(e => e.fk_skladiste)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<uloga>()
                .Property(e => e.ime_uloge)
                .IsUnicode(false);

            modelBuilder.Entity<uloga>()
                .HasMany(e => e.ponuda_uloga)
                .WithRequired(e => e.uloga)
                .HasForeignKey(e => e.fk_uloga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<uloga>()
                .HasMany(e => e.radnik_uloga)
                .WithRequired(e => e.uloga)
                .HasForeignKey(e => e.fk_uloga)
                .WillCascadeOnDelete(false);
        }
    }
}
