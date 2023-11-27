using System.Data.SqlClient;


namespace KutuphaneYönetimSistemi
{
    public partial class FormGiris : Form
    {
        FormKitaplar formKitaplar;
        public FormGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source =.\SQLEXPRESS01;Initial Catalog=DbBsKutuphane; Integrated Security = True");
        private void buttonGiris_Click(object sender, EventArgs e)
        {
            string sifre = "";
            try
            {
                baglanti.Open();
                SqlCommand sqlKomut = new SqlCommand(" SELECT Sifre FROM TableKutuphaneYoneticileri WHERE  KullaniciAdi = @p1", baglanti);
                sqlKomut.Parameters.AddWithValue("@p1", textBoxKullanıcıAdi.Text);
                SqlDataReader sqlDataReader = sqlKomut.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    sifre = sqlDataReader[0].ToString();

                }
                if (sifre == textBoxSifre.Text)
                {
                    label3.Text = "sifre doğru";
                    formKitaplar = new FormKitaplar();
                    formKitaplar.Show();
                }
                else
                {
                    MessageBox.Show("kullanıcı adı veya şifre yanlış !");
                    textBoxSifre.Text = "";
                    textBoxKullanıcıAdi.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("bağlantı hatası" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}