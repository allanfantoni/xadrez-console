﻿using tabuleiro;

namespace xadrez
{
    public class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override string? ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // norte
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Linha = pos.Linha - 1;
            }

            // sul
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Linha = pos.Linha + 1;
            }

            // leste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Coluna = pos.Coluna + 1;
            }

            // oeste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
    }
}