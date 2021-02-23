using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafe21.Data
{
    public class KafeVeri : DbContext
    {
        public KafeVeri() : base("name=KafeVeri")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SiparisDetay>() // SiparisDetay entity'sinin
                .HasRequired(x => x.Urun) // Zorunlu olarak bir Urun'u vardır
                .WithMany(x => x.SiparisDetaylar) // Ki bu Urun birden çok SiparisDetay'da bulunabilir
                .HasForeignKey(x => x.UrunId) // SiparisDetay'dan Urun'e referans veren FK'sı UrunId alanıdır
                .WillCascadeOnDelete(false); // Urun silinirse bağlı olduğu SiparisDetay'i otomatik silme
        }

        public int MasaAdet { get; set; } = 20;
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }
    }
}
