using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneYönetimSistemi
{
    public partial class FormKitaplar : Form
    {

        SqlConnection baglanti = new SqlConnection(@"Data Source =.\SQLEXPRESS01;Initial Catalog=DbBsKutuphane; Integrated Security = True");
        public FormKitaplar()
        {
            InitializeComponent();
        }

        private void buttonKitapEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TableKitaplar" +
                "(KitapAdi,YazarAdi,YazarSoyadi,ISBN,Durum,KitapTurKodu) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", textBoxKitapAdı.Text);
                sqlCommand.Parameters.AddWithValue("@P2", textBoxYazarAdı.Text);
                sqlCommand.Parameters.AddWithValue("@P3", textBoxYazarSoyAd.Text);
                sqlCommand.Parameters.AddWithValue("@P4", textBoxISBN.Text);
                sqlCommand.Parameters.AddWithValue("@P5", "True");
                sqlCommand.Parameters.AddWithValue("@P6", textBoxKitapTurKodu.Text);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("kitap eklenirken hata oluştu " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            verileriGsöter();
        }

        private void verileriGsöter()
        {
            try
            {
                baglanti.Open();
                string q = "SELECT * FROM TableKitaplar ";
               
                SqlDataAdapter da = new SqlDataAdapter(q, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewKitaplar.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();

            }


        }
        private void FormKitaplar_Load(object sender, EventArgs e)
        {
            verileriGsöter();

        }

        private void dataGridViewKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelGecikmeBedeli.Text = "0";
            int secilenSatır = dataGridViewKitaplar.SelectedCells[0].RowIndex;
            labelID.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[0].Value.ToString();
            textBoxKitapAdı.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[1].Value.ToString();
            textBoxYazarAdı.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[2].Value.ToString();
            textBoxYazarSoyAd.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[3].Value.ToString();
            textBoxISBN.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[4].Value.ToString();
            textBoxKitapTurKodu.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[8].Value.ToString();

            textBoxOduncAlan.Text = dataGridViewKitaplar.Rows[secilenSatır].Cells[6].Value.ToString();
            if (dataGridViewKitaplar.Rows[secilenSatır].Cells[7].Value != DBNull.Value)
                dateTimePickerOduncAlmaTarihi.Value = (DateTime)dataGridViewKitaplar.Rows[secilenSatır].Cells[7].Value;
        }

        private void buttonKitapBİlgiGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE TableKitaplar SET KitapAdi = @P1, YazarAdi = @P2, YazarSoyadi = @P3, ISBN = @P4, KitapTurKodu = @P5 " +
                                                        " WHERE ID = @P6", baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", textBoxKitapAdı.Text);
                sqlCommand.Parameters.AddWithValue("@P2", textBoxYazarAdı.Text);
                sqlCommand.Parameters.AddWithValue("@P3", textBoxYazarSoyAd.Text);
                sqlCommand.Parameters.AddWithValue("@P4", textBoxISBN.Text);
                sqlCommand.Parameters.AddWithValue("@P5", textBoxKitapTurKodu.Text);
                sqlCommand.Parameters.AddWithValue("@P6", labelID.Text);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("kitap güncellerniken hata oluştu " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            verileriGsöter();
        }

        private void buttonKitapOdunc_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "-")
            {

                try
                {
                    baglanti.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE TableKitaplar SET OduncAlan = @P1, OduncAlmaTarihi = @P2, Durum = @P3  WHERE ID = @P4", baglanti);



                    sqlCommand.Parameters.AddWithValue("@P1", textBoxOduncAlan.Text);
                    sqlCommand.Parameters.Add("@P2", SqlDbType.Date).Value = dateTimePickerOduncAlmaTarihi.Value.Date;
                    sqlCommand.Parameters.AddWithValue("@P3", "False");
                    sqlCommand.Parameters.AddWithValue("@P4", labelID.Text);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("kitap ödünç alırken hata oluştu " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
                verileriGsöter();
            }
            else
            {
                MessageBox.Show("Lütfen bir kitap seçiniz");
            }
        }

        private void buttonGecikmeBedeliHesapla_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "-")
            {
                DateTime bugununTarihi = DateTime.Now;
                int gunFarki = (int)(bugununTarihi - dateTimePickerOduncAlmaTarihi.Value.Date).TotalDays;
                if (gunFarki > 10)
                {
                    int gecikmeBedeli = (gunFarki - 10) * 2;
                    labelGecikmeBedeli.Text = gecikmeBedeli.ToString();
                }

            }
        }

        private void buttonKitabıİadeEt_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "-")
            {

                try
                {
                    baglanti.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE TableKitaplar SET OduncAlan = @P1, OduncAlmaTarihi = @P2, Durum = @P3  WHERE ID = @P4", baglanti);



                    sqlCommand.Parameters.AddWithValue("@P1", " ");
                    sqlCommand.Parameters.Add("@P2", SqlDbType.Date).Value = DBNull.Value;
                    sqlCommand.Parameters.AddWithValue("@P3", "False");
                    sqlCommand.Parameters.AddWithValue("@P4", labelID.Text);
                    sqlCommand.ExecuteNonQuery();
                    textBoxOduncAlan.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("kitap iade alırken hata oluştu " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
                verileriGsöter();
            }

        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            labelID.Text = " ";
            textBoxKitapAdı.Text = " ";
            textBoxYazarAdı.Text = " ";
            textBoxYazarSoyAd.Text = "";
            textBoxISBN.Text = "";
            textBoxKitapTurKodu.Text = "";
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            aramaSonuclarınıGsöter();
        }

        private void aramaSonuclarınıGsöter()
        {
            try
            {
                baglanti.Open();
                
                string q = "SELECT * FROM TableKitaplar WHERE KitaplarAdi LIKE  '" + textBoxKitapAdı.Text
                                                                     + "%'  AND YazarAdi LIKE ' " + textBoxYazarAdı.Text + "%' "
                                                                     + "  AND YazarSoyAdi LIKE ' " + textBoxYazarSoyAd.Text + "%' "
                                                                      + "  AND ISBN LIKE ' " + textBoxISBN.Text + "%' "
                                                                       + "  AND KitapTurKodu LIKE ' " + textBoxKitapTurKodu.Text + "%' "
                                                                        + "  AND OduncAlan LIKE ' " + textBoxOduncAlan.Text + "' ";
                SqlDataAdapter da = new SqlDataAdapter(q, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewKitaplar.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();

            }


        }
    }
}
