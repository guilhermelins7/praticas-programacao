using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_01.Classes;

namespace TP_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tratarBotoes(object sender, EventArgs e)
        {
            Button generico = (Button)sender;
            string dispositivoTag = generico.Tag.ToString(); // Identificador do dispositivo

            if (generico.Text == "Ligar")
            {
                generico.Text = "Desligar";
                ArduinoBLL.ligaDispositivo(dispositivoTag);
            }
            else
            {
                generico.Text = "Ligar";
                ArduinoBLL.desligaDispositivo(dispositivoTag);
            }
            // Atualiza o display visual
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ArduinoBLL.setDisplay(0);
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            LigarBotoes();
        }

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    ArduinoBLL.alarme();
        //    textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
        //}

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    ArduinoBLL.sequencial();
        //    textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
        //}

        private async void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                ArduinoBLL.alarmeStep(true);
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                DesligarBotoes();
                await Task.Delay(2000);

                ArduinoBLL.alarmeStep(false);
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                LigarBotoes();
                await Task.Delay(2000);
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            ArduinoBLL.setDisplay(0);
            for (int i = 1; i <= 8; i++)
            {
                ArduinoBLL.ligaDispositivo(i.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());

                // Pega o botão dinamicamente usando o índice 'i' e altera o texto para "Ligar"
                Button button = (Button)this.Controls["button" + i]; // Acessa o botão pelo nome "button1", "button2", etc.
                button.Text = "Desligar"; // Altera o texto do botão para "Ligar"

                await Task.Delay(500); // Intervalo de tempo entre cada ação (500ms)
            }

        }

        private void LigarBotoes()
        {
            button1.Text = "Ligar";
            button2.Text = "Ligar";
            button3.Text = "Ligar";
            button4.Text = "Ligar";
            button8.Text = "Ligar";
            button7.Text = "Ligar";
            button6.Text = "Ligar";
            button5.Text = "Ligar";
        }

        private void DesligarBotoes()
        {
            button1.Text = "Desligar";
            button2.Text = "Desligar";
            button3.Text = "Desligar";
            button4.Text = "Desligar";
            button8.Text = "Desligar";
            button7.Text = "Desligar";
            button6.Text = "Desligar";
            button5.Text = "Desligar";
        }
    }
}
