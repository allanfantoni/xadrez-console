﻿using tabuleiro;

namespace xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override string? ToString()
        {
            return "B";
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

            // noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
    }
}