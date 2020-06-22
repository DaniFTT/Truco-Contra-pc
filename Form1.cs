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
        const int X = 465, Y = 230, Y1 = 155;
        bool vez = true, cartaVirada = false;
        byte jogadas = 0;
        int indice = 0, indice2 = 0;
        List<string> repetidas = new List<string>();
        List<Cartas> cartas = new List<Cartas>();
        List<Image> cartasImagem = new List<Image>();
        private PictureBox[] pictures = new PictureBox[6];
        char[] naipes = { 'O', 'P', 'C', 'E' };
        Random rdn = new Random();
        int[] valorJogado = new int[2];

        public Form1()
        {
            InitializeComponent();

            Cartas.IniciarRecursos();
            pictures[0] = pb1;
            pictures[1] = pb2;
            pictures[2] = pb3;
            pictures[3] = pb4;
            pictures[4] = pb5;
            pictures[5] = pb6;



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
            int manilha;

            if (Cartas.Vira != 13)
                manilha = Cartas.Vira + 1;
            else
                manilha = 4;


            if (manilha >= 8)
            {
                var naipeManilha = Cartas.FormatarManilha(manilha);
                lblManilha.Text = naipeManilha;
            }
            else
            {
                lblManilha.Text = manilha.ToString();
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
            for (int i = 0; i <= 2; i++)
            {
                pictures[i].Image = Properties.Resources.Verso;
            }
        }

        private void Card(object sender, EventArgs e)
        {
            var pic = (PictureBox)sender;
            var tabIndex = int.Parse(String.Format("{0}", pic.Tag));

            if (vez && (tabIndex >= 3 && tabIndex <= 5) && cartas[tabIndex].Mao)
            {
                if (!cartaVirada)
                {
                    valorJogado[0] = cartas[tabIndex].Valor;
                    pic.Image = cartasImagem[tabIndex];
                    cartas[tabIndex].Mao = false;
                    indice = tabIndex;
                    jogadas++;
                }
                else
                {

                    valorJogado[0] = 0;
                    cartas[tabIndex].Mao = false;
                    indice = tabIndex;
                    jogadas++;

                }


                pic.Location = new Point(X, Y);

                if (jogadas == 2)
                {

                }
                else
                {

                    vez = false;

                }

            }
        }

    }
}
