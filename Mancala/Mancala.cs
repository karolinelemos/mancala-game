using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mancala
{
  
    public partial class Mancala : Form
    {
        Random sorteio = new Random();
        int[] campo = { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0 };
        int i;
        int dep_pc = 13;
        int min, max, op = 0;
        bool jog = false;
        bool semJog = false, vez_pc = false, entrou12 = false, maior1 = false;

        public Mancala()
        {
            InitializeComponent();
        }
        /* AVISO DE SAIR */
        private void Mancala_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o jogo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bt_sair_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* INICIAR */
        private void bt_iniciar_Click(object sender, EventArgs e)
        {
            novos_valores(campo);
            jog_1.Enabled = true;
            jog_2.Enabled = true;
            jog_3.Enabled = true;
            jog_4.Enabled = true;
            jog_5.Enabled = true;
            jog_6.Enabled = true;
            lb_mensagem.Text = "É a sua vez! ";
        }
        /* Botão REINICIAR */
        private void bt_reiniciar_Click(object sender, EventArgs e)
        {
            reiniciar();
        }

        /* REINICIAR */
        public void reiniciar()
        {
            for (int a = 0; a <= 13; a++)
            {
                campo[a] = 4;
            }
            campo[6] = 0;
            campo[13] = 0;
            i = 0;
            min = 0;
            max = 0;
            novos_valores(campo);
            lb_mensagem.Text = "Jogo reiniciado. É a sua vez!";
            lb_fim.Text = "";
            vez_pc = false;
            controle_campo(vez_pc);
            
        }

        /* CLIQUES DO JOGADOR */
        private void jog_1_Click(object sender, EventArgs e)
        {
            i = -1;
            if (campo[0] == 1 && (campo[1] > 1 || campo[2] > 1 || campo[3] > 1 || campo[4] > 1 || campo[5] > 1))
            {
                lb_mensagem.Text = "Escolha um campo com mais de uma semente.";
            }
            else
            {
                max = campo[0];
                campo[0] = 0;

                for (min = 1; min <= max; min++)
                {
                    if (min >= dep_pc)
                    {
                        i = 0;
                        if (min == 13)
                        {
                            i = 0;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                verificacasaoposta();
                zerou_pc();
                if (semJog)
                {
                    fim_jogo();
                }

                else if (jog)
                {
                    lb_mensagem.Text = "Faça uma jogada que passe sementes ao computador!";
                    jogadaplus_jog();
                }
                else
                {
                    novos_valores(campo);
                    /* verifica se aplica a regra de nova jogada */
                    if (max == 6 || i == 6)
                    {
                        lb_mensagem.Text = "Você tem uma nova jogada";
                        jogadaplus_jog();
                    }
                    else
                    {
                        vezpc();
                    }
                }
            }
        }

        private void jog_2_Click(object sender, EventArgs e)
        {
            i = -1;
            if (campo[1] == 1 && (campo[0] > 1 || campo[2] > 1 || campo[3] > 1 || campo[4] > 1 || campo[5] > 1))
            {
                lb_mensagem.Text = "Escolha um campo com mais de uma semente.";
            }
            else
            {
                max = campo[1] + 1;
                campo[1] = 0;

                for (min = 2; min <= max; min++)
                {
                    if (min >= dep_pc)
                    {
                        i = 0;
                        if (min == 13)
                        {
                            i = 0;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                verificacasaoposta();
                zerou_pc();
                if (semJog)
                {
                    fim_jogo();
                }

                else if (jog)
                {
                    lb_mensagem.Text = "Faça uma jogada que passe sementes ao computador!";
                    jogadaplus_jog();
                }
                else
                {
                    novos_valores(campo);

                    /* verifica se aplica a regra de nova jogada */
                    if (max == 6 || i == 6)
                    {
                        lb_mensagem.Text = "Você tem uma nova jogada";
                        jogadaplus_jog();
                    }
                    else
                    {
                        vezpc();
                    }
                }
            }
        }

        private void jog_3_Click(object sender, EventArgs e)
        {
            i = -1;
            if (campo[2] == 1 && (campo[1] > 1 || campo[0] > 1 || campo[3] > 1 || campo[4] > 1 || campo[5] > 1))
            {
                lb_mensagem.Text = "Escolha um campo com mais de uma semente.";
            }
            else
            {
                max = campo[2] + 2;
                campo[2] = 0;

                for (min = 3; min <= max; min++)
                {
                    if (min >= dep_pc)
                    {
                        i = 0;
                        if (min == 13)
                        {
                            i = 0;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                verificacasaoposta();
                zerou_pc();
                if (semJog)
                {
                    fim_jogo();
                }

                else if (jog)
                {
                    lb_mensagem.Text = "Faça uma jogada que passe sementes ao computador!";
                    jogadaplus_jog();
                }
                else
                {
                    novos_valores(campo);

                    /* verifica se aplica a regra de nova jogada */
                    if (max == 6 || i == 6)
                    {
                        lb_mensagem.Text = "Você tem uma nova jogada";
                        jogadaplus_jog();
                    }
                    else
                    {
                        vezpc();
                    }
                }
            }
        }

        private void jog_4_Click(object sender, EventArgs e)
        {
            i = -1;
            if (campo[3] == 1 && (campo[1] > 1 || campo[2] > 1 || campo[0] > 1 || campo[4] > 1 || campo[5] > 1))
            {
                lb_mensagem.Text = "Escolha um campo com mais de uma semente.";
            }
            else
            {
                max = campo[3] + 3;
                campo[3] = 0;

                for (min = 4; min <= max; min++)
                {
                    if (min >= dep_pc)
                    {
                        i = 0;
                        if (min == 13)
                        {
                            i = 0;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                verificacasaoposta();
                zerou_pc();
                if (semJog)
                {
                    fim_jogo();
                }

                else if (jog)
                {
                    lb_mensagem.Text = "Faça uma jogada que passe sementes ao computador!";
                    jogadaplus_jog();
                }
                else
                {
                    novos_valores(campo);

                    /* verifica se aplica a regra de nova jogada */
                    if (max == 6 || i == 6)
                    {
                        lb_mensagem.Text = "Você tem uma nova jogada";
                        jogadaplus_jog();
                    }
                    else
                    {
                        vezpc();
                    }
                }
            }
        }

        private void jog_5_Click(object sender, EventArgs e)
        {
            i = -1;
            if (campo[4] == 1 && (campo[1] > 1 || campo[2] > 1 || campo[3] > 1 || campo[0] > 1 || campo[5] > 1))
            {
                lb_mensagem.Text = "Escolha um campo com mais de uma semente.";
            }

            else
            {
                max = campo[4] + 4;
                campo[4] = 0;

                for (min = 5; min <= max; min++)
                {
                    if (min >= dep_pc)
                    {
                        if (min == 13)
                        {
                            i = 0;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                verificacasaoposta();
                zerou_pc();
                if (semJog)
                {
                    fim_jogo();
                }

                else if (jog)
                {
                    lb_mensagem.Text = "Faça uma jogada que passe sementes ao computador!";
                    jogadaplus_jog();
                }
                else
                {
                    novos_valores(campo);

                    /* verifica se aplica a regra de nova jogada */
                    if (max == 6 || i == 6)
                    {
                        lb_mensagem.Text = "Você tem uma nova jogada";
                        jogadaplus_jog();
                    }
                    else
                    {
                        vezpc();
                    }
                }
            }
        }

        private void jog_6_Click(object sender, EventArgs e)
        {
            i = -1;
            if (campo[5] == 1 && (campo[1] > 1 || campo[2] > 1 || campo[3] > 1 || campo[4] > 1 || campo[0] > 1))
            {
                lb_mensagem.Text = "Escolha um campo com mais de uma semente.";
            }

            else
            {
                max = campo[5] + 5;
                campo[5] = 0;

                for (min = 6; min <= max; min++)
                {
                    if (min >= dep_pc)
                    {
                        if (min == 13)
                        {
                            i = 0;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                verificacasaoposta();
                zerou_pc();
                if (semJog)
                {
                    fim_jogo();
                }

                else if (jog)
                {
                    lb_mensagem.Text = "Faça uma jogada que passe sementes ao computador!";
                    jogadaplus_jog();
                }
                else
                {
                    novos_valores(campo);

                    /* verifica se aplica a regra de nova jogada */
                    if (max == 6 || i == 6)
                    {
                        lb_mensagem.Text = "Você tem uma nova jogada";
                        jogadaplus_jog();
                    }
                    else
                    {
                        vezpc();
                    }
                }
            }
        }
        /* JOGADA COMPUTADOR */
        public void jogada_pc()
        {
            /*OPÇÕES A SEREM CONSIDERADAS*/
            int p, x;
            vez_pc = true;
            controle_campo(vez_pc);

            for (p = 7; p < 13; p++)
            {
                verificavalores(p);
                // se cair no depósito - escolhe 
                x = 13 - p;
                if (x - campo[p] == 0)
                {
                    op = p;
                    break;
                }
                // se cair em um zerado e no meu campo - escolhe - recebe valores da casa oposta
                else if (((7 <= max && max <= 12) || (7 <= i && i <= 12) || (21 <= i && i <= 26) || (35 <= i && i <= 40)) && (campo[p] != 0))
                {
                    verificamaior1();

                    if (maior1)
                    {
                        if (campo[p] > 1)
                        {
                            if (max >= dep_pc)
                            {
                                if (campo[i - 1] == 0 && ((i - 1) != 6))
                                {
                                    campo[13] = campo[13] + campo[(i - 12) * -1];
                                    campo[(i - 12) * -1] = 0;
                                    op = p;
                                    break;
                                }
                            }
                            else
                            {
                                if ((campo[max] == 0) && (max != 6))
                                {
                                    campo[13] = campo[13] + campo[(max - 12) * -1];
                                    campo[(max - 12) * -1] = 0;
                                    op = p;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int s = 0; ; s++)
                            {
                                op = sorteio.Next(7, 13);

                                if ((campo[op] != 0) && (campo[op] > 1))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if(maior1 == false)
                    {
                        if (max >= dep_pc)
                        {
                            if (campo[i - 1] == 0 && ((i - 1) != 6))
                            {
                                campo[13] = campo[13] + campo[(i - 12) * -1];
                                campo[(i - 12) * -1] = 0;
                                op = p;
                                break;
                            }
                        }
                        else
                        {
                            if ((campo[max] == 0) && (max != 6))
                            {
                                campo[13] = campo[13] + campo[(max - 12) * -1];
                                campo[(max - 12) * -1] = 0;
                                op = p;
                                break;
                            }
                        }
                    }
                }

                //  sorteia
                else
                {
                    for(int s=0; ;s++)
                    {
                        op = sorteio.Next(7, 13);
                        
                        if(campo[op] != 0)
                        {
                            break;
                        }
                    }
                }
            }

            if(entrou12)
            {
                for (int s = 0; ; s++)
                {
                    op = sorteio.Next(7, 13);

                    if (campo[op] != 0)
                    {
                        break;
                    }
                }
            }
            zerou_jg();
            //fazer a jogada que passa pro jogdor caso zere
            if(semJog)
            {
                fim_jogo();
            }
            else if(jog) //tem jogada ainda
            {
                for(p = 7; p < 12; p++)
                {
                    if(campo[p] > campo[p+1])
                    {
                        op = p;
                    }
                }
            }
            // se escolheu uma casa com valor 1, tendo casas com valores mais altos
            for (int s = 7; s < 13; s++)
            {
                if(campo[op] == 1 && campo[s] > 1)
                {
                        for (s = 0; ; s++)
                        {
                            op = sorteio.Next(7, 13);

                            if (campo[op] != 0 && campo[op] != 1) //sorteia novamente
                            {
                                break;
                            }
                        }
                }                
            }
            lb_op.Text = Convert.ToString(op);
            valor_anterior.Text = Convert.ToString(campo[op]);
            /*OP ESCOLHIDA*/
            switch (op) {
                case 7:
                    pc_casa7();
                    break;
                case 8:
                    pc_casa8();
                    break;
                case 9:
                    pc_casa9();
                    break;
                case 10:
                    pc_casa10();
                    break;
                case 11:
                    pc_casa11();
                    break;
                case 12:
                    pc_casa12();
                    break;
            }

            i = 0;
        }

        /* CASAS DO PC */
        public void pc_casa7()
        {
            i = 0;
            //Escolha um campo com mais de uma semente.
            if (campo[7] == 1 && (campo[8] > 1 || campo[9] > 1 || campo[10] > 1 || campo[11] > 1 || campo[12] > 1))
            {
                lb_mensagem.Text = "PC tem uma nova jogada\n";
                vezpc();
            }
            else
            {
                max = campo[7] + 7;
                campo[7] = 0;

                for (min = 8; min <= max; min++)
                {
                    if (min > dep_pc)
                    {
                        if (i == 6)
                        {
                            i++;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                novos_valores(campo);

                /* verifica se aplica a regra de nova jogada */
                if (max == 13 || i == 13)
                {
                    lb_mensagem.Text = "PC tem uma nova jogada\n";
                    vezpc();
                }

                else
                {
                    vez_pc = false;
                    controle_campo(vez_pc);
                }
            }
        }

        public void pc_casa8()
        {
            i = 0;
            if (campo[8] == 1 && (campo[7] > 1 || campo[9] > 1 || campo[10] > 1 || campo[11] > 1 || campo[12] > 1))
            {
                lb_mensagem.Text = "PC tem uma nova jogada\n";
                vezpc();
            }
            else
            {
                max = campo[8] + 8;
                campo[8] = 0;

                for (min = 9; min <= max; min++)
                {
                    if (min > dep_pc)
                    {
                        if (i == 6)
                        {
                            i++;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                novos_valores(campo);

                /* verifica se aplica a regra de nova jogada */
                if (max == 13 || i == 13)
                {
                    lb_mensagem.Text = "PC tem uma nova jogada\n";
                    vezpc();
                }
                else
                {
                    vez_pc = false;
                    controle_campo(vez_pc);
                }
            }
        }
        public void pc_casa9()
        {
            i = 0;
            if (campo[9] == 1 && (campo[8] > 1 || campo[7] > 1 || campo[10] > 1 || campo[11] > 1 || campo[12] > 1))
            {
                lb_mensagem.Text = "PC tem uma nova jogada\n";
                vezpc();
            }
            else
            {
                max = campo[9] + 9;
                campo[9] = 0;

                for (min = 10; min <= max; min++)
                {
                    if (min > dep_pc)
                    {
                        if (i == 6)
                        {
                            i++;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                novos_valores(campo);

                /* verifica se aplica a regra de nova jogada */
                if (max == 13 || i == 13)
                {
                    lb_mensagem.Text = "PC tem uma nova jogada\n";
                    vezpc();
                }
                else
                {
                    vez_pc = false;
                    controle_campo(vez_pc);
                }
            }
        }
        public void pc_casa10()
        {
            i = 0;
            if (campo[10] == 1 && (campo[8] > 1 || campo[9] > 1 || campo[7] > 1 || campo[11] > 1 || campo[12] > 1))
            {
                lb_mensagem.Text = "PC tem uma nova jogada\n";
                vezpc();
            }
            else
            {
                max = campo[10] + 10;
                campo[10] = 0;

                for (min = 11; min <= max; min++)
                {
                    if (min > dep_pc)
                    {
                        if (i == 6)
                        {
                            i++;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                novos_valores(campo);

                /* verifica se aplica a regra de nova jogada */
                if (max == 13 || i == 13)
                {
                    lb_mensagem.Text = "PC tem uma nova jogada\n";
                    vezpc();
                }
                else
                {
                    vez_pc = false;
                    controle_campo(vez_pc);
                }
            }
        }

        public void pc_casa11()
        {
            i = 0;
            if (campo[11] == 1 && (campo[8] > 1 || campo[9] > 1 || campo[10] > 1 || campo[12] > 1 || campo[12] > 1))
            {
                lb_mensagem.Text = "PC tem uma nova jogada\n";
                vezpc();

            }
            else
            {
                max = campo[11] + 11;
                campo[11] = 0;

                for (min = 12; min <= max; min++)
                {
                    if (min > dep_pc)
                    {
                        if (i == 6)
                        {
                            i++;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }

                novos_valores(campo);

                /* verifica se aplica a regra de nova jogada */
                if (max == 13 || i == 13)
                {
                    lb_mensagem.Text = "PC tem uma nova jogada\n";
                    vezpc();
                }
                else
                {
                    vez_pc = false;
                    controle_campo(vez_pc);
                }
            }
        }
        public void pc_casa12()
        {
            i = 0;
            if (campo[12] == 1 && (campo[8] > 1 || campo[9] > 1 || campo[10] > 1 || campo[11] > 1 || campo[7] > 1))
            {
                lb_mensagem.Text = "PC tem uma nova jogada\n";
                vezpc();
                entrou12 = true;
            }
            else
            {
                max = campo[12] + 12;
                campo[12] = 0;

                for (min = 13; min <= max; min++)
                {
                    if (min > dep_pc)
                    {
                        if (i == 6)
                        {
                            i++;
                        }
                        campo[i] = campo[i] + 1;
                        i++;
   
                    }

                    else
                    {
                        campo[min] = campo[min] + 1;
                    }
                }
                novos_valores(campo);

                /* verifica se aplica a regra de nova jogada */
                if (max == 13 || i == 13)
                {
                    lb_mensagem.Text = "PC tem uma nova jogada\n";
                    vezpc();
                }
                else
                {
                    vez_pc = false;
                    controle_campo(vez_pc);
                }
            }
        }

        /* VETOR DE VALORES */
        public void novos_valores(int[] vetor)
        {
            lb_jog1.Text = Convert.ToString(vetor[0]);
            lb_jog2.Text = Convert.ToString(vetor[1]);
            lb_jog3.Text = Convert.ToString(vetor[2]);
            lb_jog4.Text = Convert.ToString(vetor[3]);
            lb_jog5.Text = Convert.ToString(vetor[4]);
            lb_jog6.Text = Convert.ToString(vetor[5]);
            deposito_jog.Text = Convert.ToString(vetor[6]);
            lb_pc1.Text = Convert.ToString(vetor[12]);
            lb_pc2.Text = Convert.ToString(vetor[11]);
            lb_pcc3.Text = Convert.ToString(vetor[10]);
            lb_pcc4.Text = Convert.ToString(vetor[9]);
            lb_pcc5.Text = Convert.ToString(vetor[8]);
            lb_pcc6.Text = Convert.ToString(vetor[7]);
            deposito_pc.Text = Convert.ToString(vetor[13]);
        }

        /* Se a última “semente” do movimento for no depósito o jogador pode fazer uma nova jogada. */
        public void jogadaplus_jog()
        {
            vez_pc = false;
            controle_campo(vez_pc);
        }

        /* Se a última “semente” do movimento cair em uma casa vazia que seja do seu campo, e a casa oposta do campo do adversário tiver “sementes”, estas vão para o seu depósito.*/
        public void verificacasaoposta()
        {
            if ((0 <= max && max <= 5) || (1 <= i && i <= 5) || (14 <= i && i <= 19) || (28 <= i && i <= 33))
            {
                if (max >= dep_pc)
                {
                    if ((campo[i - 1] == 1) && (i != 6))
                    {
                        campo[6] = campo[6] + campo[13 - i];
                        campo[13 - i] = 0;

                    }
                }
                else
                {
                    if ((campo[max] == 1) && (max != 6))
                    {
                        campo[6] = campo[6] + campo[12 - max];
                        campo[12 - max] = 0;

                    }
                }
            }
        }

        /* Se um jogador, ao realizar um movimento, ficar sem “sementes”, o adversário é obrigado a fazer uma jogada que coloque pelo menos uma semente no seu lado (se tal for possível).*/
        public void zerou_pc()
        {
            jog = false;

            if ((campo[7] == 0 && campo[8] == 0) && (campo[9] == 0 && campo[10] == 0) && (campo[11] == 0 && campo[12] == 0))
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (campo[j] > (7 - campo[j]))
                    {
                        jog = true;
                        break;
                    }
                }

                if (jog != true)
                {
                    lb_mensagem.Text = "Fim de jogo! ";
                    for (int j = 0; j <= 5; j++)
                    {
                        campo[6] = campo[6] + campo[j];
                        campo[j] = 0;
                        novos_valores(campo);
                    }

                    if (campo[6] > campo[13])
                    {
                        lb_fim.Text = lb_mensagem.Text + "Você ganhou. =) ";
                    }
                    else if (campo[6] < campo[13])
                    {
                        lb_fim.Text = lb_mensagem.Text + "Computador ganhou. =(";
                    }
                    else
                    {
                        lb_fim.Text = lb_mensagem.Text + "Empatou!";
                    }

                    semJog = true;
                }
            }
            else
            {
                semJog = false;
            }
        }

        private void b_jogadapc_Click(object sender, EventArgs e)
        {
            zerou_pc();
            if (semJog)
            {
                fim_jogo();
            }
            else
            jogada_pc();
        }

        public void zerou_jg()
        {
            jog = false; 

            if ((campo[0] == 0 && campo[1] == 0) && (campo[2] == 0 && campo[3] == 0) && (campo[4] == 0 && campo[5] == 0))
            {
                for (int j = 7; j <= 12; j++)
                {
                    if (campo[j] > (13 - campo[j]))
                    {
                        jog = true;
                        break;
                    }
                }

                if (jog != true)
                {
                    lb_mensagem.Text = "Fim de jogo! ";
                    for (int j = 7; j <= 12; j++)
                    {
                        campo[13] = campo[13] + campo[j];
                        campo[j] = 0;
                        novos_valores(campo);
                    }

                    if (campo[6] > campo[13])
                    {
                        lb_fim.Text = lb_mensagem.Text + "Computador ganhou. =(";
                    }
                    else if (campo[6] < campo[13])
                    {
                        lb_fim.Text = lb_mensagem.Text + "Você ganhou. =)";
                    }
                    else
                    {
                        lb_fim.Text = lb_mensagem.Text + "Empatou!";
                    }

                semJog = true;
               }
            }

            else
            {
                semJog = false;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            lb_op.Text = lb_op.Text;
            valor_anterior.Text = valor_anterior.Text;
        }

        private void pc_5_Click(object sender, EventArgs e)
        {

        }

        private void bt_sobre_Click(object sender, EventArgs e)
        {
            lb_about.Text = "Jogo desenvolvido para a disciplina de \nInteligência Artificial com o objetivo \nde aplicar os conhecimentos adquiridos \nem sala sobre Busca heurística.\n\n\n Nome: Karoline Lemos\n Professor: Paulo Marcondes Bousfield";
        }

        /*CAMPO */
        public void controle_campo(bool vez_pc)
        {
            if (vez_pc)
            {
                jog_1.Enabled = false;
                jog_2.Enabled = false;
                jog_3.Enabled = false;
                jog_4.Enabled = false;
                jog_5.Enabled = false;
                jog_6.Enabled = false;
            }
            else
            {
                lb_mensagem.Text = "Você tem uma nova jogada.";
                b_jogadapc.Enabled = false;
                jog_1.Enabled = true;
                jog_2.Enabled = true;
                jog_3.Enabled = true;
                jog_4.Enabled = true;
                jog_5.Enabled = true;
                jog_6.Enabled = true;
            }
        }

        public void fim_jogo()
        {
            lb_mensagem.Text = "";
            lb_fim.Text = lb_fim.Text;
        }

        public void verificavalores(int p)
        {  //descobrir os valores de max e i previamente.
            max = campo[p] + p;
            for (min = 8; min <= max; min++)
            {
                if (min > dep_pc)
                {
                    i = 0;
                    if (i == 6)
                    {
                        i++;
                    }
                    i++;
                }
            }
        }

        public void verificamaior1()
        {
            maior1 = false;
            for (int s = 7; s < 13; s++)
            {
                if (campo[s] > 1)
                {
                    maior1 = true;
                    break;
                }
            }
        }

        public void vezpc()
        {
            lb_mensagem.Text = "Clique no botão para PC jogar.";
            b_jogadapc.Enabled = true;
            jog_1.Enabled = false;
            jog_2.Enabled = false;
            jog_3.Enabled = false;
            jog_4.Enabled = false;
            jog_5.Enabled = false;
            jog_6.Enabled = false;

        }
    }
}