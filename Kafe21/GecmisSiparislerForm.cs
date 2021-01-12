using Kafe21.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kafe21
{
    public partial class GecmisSiparislerForm : Form
    {
        private readonly KafeVeri kafeVeri;

        public GecmisSiparislerForm(KafeVeri kafeVeri)
        {
            this.kafeVeri = kafeVeri;
            InitializeComponent();
            dgvSiparisler.DataSource = kafeVeri.GecmisSiparisler;
        }

        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count == 0)
            {
                dgvSiparisDetaylar.DataSource = null;
                return;
            }

            DataGridViewRow satir = dgvSiparisler.SelectedRows[0]; // seçili satırı al
            Siparis siparis = (Siparis)satir.DataBoundItem; // satırdaki bağlı nesneyi al
            dgvSiparisDetaylar.DataSource = siparis.SiparisDetaylar;
        }

        private void GecmisSiparislerForm_Load(object sender, EventArgs e)
        {
            dgvSiparisler.ClearSelection();
        }
    }
}
