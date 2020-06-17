using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Jogo_de_Truco
{
    public partial class Form1 : Form
    {
        bool vez = true;
        List<string> repetidas = new List<string>();
        List<Cartas> cartas = new List<Cartas>();
        List<Image> cartasImagem = new List<Image>();
        private PictureBox[] pictures = new PictureBox[6];
        char[] naipes = { 'O', 'P', 'C', 'E' };
        Random rdn = new Random();

        public Form1()
        {
            InitializeComponent();

            Cartas.IniciarRecursos();
            pictures[3] = pb1;
            pictures[4] = pb2;
            pictures[5] = pb3;
            pictures[0] = pb4;
            pictures[1] = pb5;
            pictures[2] = pb6;



            SortearVira();
            SortearVez();
        }

        private void SortearVez()
        {
            var sorteio = rdn.Next(0, 2);
            vez = sorteio == 0;

            if (!vez)
            {
                //jogada do computador -  Metodo
            }
            
        }

        private void SortearVira()
        {// sorteia uma carta do baralho para ser a vira e define a manilha

            var newNaipe = naipes[rdn.Next(0, naipes.Length)];
            var valor = rdn.Next(4, 14);
            Cartas vira = new Cartas(newNaipe, valor);
            pbVira.Image = vira.MostrarImagem(newNaipe, valor);
            repetidas.Add(newNaipe.ToString() + valor.ToString());
            Cartas.Vira = valor;

            var Manilha = Cartas.Vira != 13 ? Cartas.Vira + 1 : 4;
            
            if(Manilha >= 8)
            {
                var naipeManilha = Cartas.FormatarManilha(Manilha);
                lblManilha.Text = naipeManilha;
            }
            else
            {
                lblManilha.Text = Manilha.ToString();
            }


            SortearCartas();
        }

        private void SortearCartas()
        {
            {
                for (int i = 0; i <= 5; i++)
                {
                    bool achou = false;

                    while (!achou)
                    {
                        var newNaipe = naipes[rdn.Next(0, naipes.Length)];
                        var valor = rdn.Next(4, 14);

                        if(!repetidas.Contains(newNaipe.ToString() + valor.ToString()))
                        {
                            cartas.Add(new Cartas(newNaipe, valor));
                            pictures[i].Image = cartas[i].MostrarImagem(newNaipe, valor);
                            repetidas.Add(newNaipe.ToString() + valor.ToString());
                            achou = true;
                            cartasImagem.Add(pictures[i].Image);
                        }
                    }
                }
            }

            VirasCartasPC();
        }

        private void VirasCartasPC()
        {
            for (int i = 3; i <= 5; i++)
            {
                pictures[i].Image = Properties.Resources.Verso;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
