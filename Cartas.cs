using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Projeto_Jogo_de_Truco
{
    class Cartas
    {
        
        public char Naipe { get; set; }
        public int Valor { get; set; }
        public bool Mao { get; set; }
        public bool Mesa { get; set; }
        private Image Imagem;
        static public int Vira;
        static IDictionary<string, Image> Baralho = new Dictionary<string, Image>();

        public Cartas(char naipe, int valor)
        {
            Naipe = naipe;
            Valor = valor;
            Mao = true;
            Mesa = false;
            Valor = ChecarManilha(Valor, Naipe);
        }

        private int ChecarManilha(int valor, char naipe)
        {// Checar se a carta eh manilha de acordo com a carta virada

            if(Vira == (valor - 1) || (valor == 4 && Vira == 13))
            {

                switch (naipe)
                {
                    case 'O':
                        valor = 14;
                        break;
                    case'E':
                        valor = 15;
                        break;
                    case 'C':
                        valor = 16;
                        break;
                    case 'P':
                        valor = 17;
                        break;
                }
            }
            else
            {
                var value = valor;
                valor = value;
            }
            return valor;
        }

        public static void IniciarRecursos()
        {// Armazena as imagens das carttas do jogo no baralho

            ResourceSet res = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            foreach(DictionaryEntry de in res)
            {
                string nomeArquivo = de.Key.ToString();
                object imagemArquivo = de.Value;

                if(imagemArquivo is Bitmap && nomeArquivo != "Verso")
                {
                    Baralho.Add(nomeArquivo, (Image)imagemArquivo);
                }
            }
        }

        public Image MostrarImagem(char naipe, int valor)
        {// Exibe a imagem da carta correspondente ao naipe e ao valor, na Picturebox

            string chave = naipe.ToString() + valor.ToString();
            return Imagem = Baralho[chave];
        }
        
        public static string FormatarManilha(int man)
        {// Formata a manilha de exibição ddo jogo se for carta de figura

            // var novaManilha = man == 8 ? "Q" : (man == 9 ? "J" : (man == 10 ? "K" : (man == 11 ? "A" : (man == 12 ? "2" : "3"))));
            string novaManilha = "Q";

            if (man == 8)
                novaManilha = "Q";
            else if (man == 9)
                novaManilha = "J";
            else if (man == 10)
                novaManilha = "K";
            else if (man == 11)
                novaManilha = "A";
            else if (man == 12)
                novaManilha = "2";
            else if (man == 13)
                novaManilha = "3";


            return novaManilha;
        }
    }
}
