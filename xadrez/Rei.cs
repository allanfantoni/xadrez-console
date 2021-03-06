using Tabuleiro;

namespace Xadrez
{
    public class Rei : Peca
    {
        private readonly PartidaDeXadrez partida;

        public Rei(Cor cor, Tabuleiro.Tabuleiro tabuleiro, PartidaDeXadrez partida) : base(cor, tabuleiro)
        {
            this.partida = partida;
        }

        public override string? ToString() => "R";

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            // norte
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // leste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // sul
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // oeste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            // noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            if (QteMovimentos == 0 && !partida.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new(Posicao.Linha, Posicao.Coluna + 3);

                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }

                // #jogadaespecial roque grande
                Posicao posT2 = new(Posicao.Linha, Posicao.Coluna - 4);

                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }
            }

            return mat;
        }
    }
}