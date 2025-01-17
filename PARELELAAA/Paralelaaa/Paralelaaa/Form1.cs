using System;
using System.Windows.Forms;

namespace PARALELAAA

{
    public partial class Form1 : Form
    {
        private Leds meusLeds;
        private CheckBox[] chkLeds;
        private PictureBox[] picLeds;

        public Form1()
        {
            InitializeComponent();
            meusLeds = new Leds(129);

            // Inicializando os arrays de CheckBox e PictureBox
            chkLeds = new[] { chkLed1, chkLed2, chkLed3, chkLed4, chkLed5, chkLed6, chkLed7, chkLed8 };
            picLeds = new[] { picLed1, picLed2, picLed3, picLed4, picLed5, picLed6, picLed7, picLed8 };

            atualizaInterface();
        }

        private void atualizaInterface()
        {
            txtDado.Text = meusLeds.getDado().ToString();
            txtDado2.Text = Convert.ToString(meusLeds.getDado(), 2);
            txtDado16.Text = Convert.ToString(meusLeds.getDado(), 16);

            for (int i = 0; i < 8; i++)
            {
                bool estadoLed = meusLeds.getLed(i + 1);
                chkLeds[i].Checked = estadoLed;
                picLeds[i].Image = estadoLed ? projLeds.Properties.Resources.acesa : projLeds.Properties.Resources.apagada;
            }
        }

        private void alterarEstadoLed(int ledIndex, bool acender)
        {
            if (acender)
                meusLeds.acender(ledIndex);
            else
                meusLeds.apagar(ledIndex);

            atualizaInterface();
        }

        private void btnLedON_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null && int.TryParse(botao.Tag.ToString(), out int ledIndex))
            {
                alterarEstadoLed(ledIndex, true);
            }
        }

        private void btnLedOFF_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null && int.TryParse(botao.Tag.ToString(), out int ledIndex))
            {
                alterarEstadoLed(ledIndex, false);
            }
        }
    }
}
