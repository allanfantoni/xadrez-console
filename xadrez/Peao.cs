﻿using Tabuleiro;

namespace Xadrez
{
    public class Peao : Peca
    {
        private readonly PartidaDeXadrez partida;

        public Peao(Cor cor, Tabuleiro.Tabuleiro tabuleiro, PartidaDeXadrez partida) : base(cor, tabuleiro)
        {
            this.partida = partida;
        }

        public override string? ToString() => "P";

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos) => Tabuleiro.Peca(pos) == null;

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == partida.VulneravelEnPassant)
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;

                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == partida.VulneravelEnPassant)
                        mat[direita.Linha - 1, direita.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == partida.VulneravelEnPassant)
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;

                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == partida.VulneravelEnPassant)
                        mat[direita.Linha + 1, direita.Coluna] = true;
                }
            }

            return mat;
        }
    }
}