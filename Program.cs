using tabuleiro;
using xadrez;
using xadrez_console;

try
{
    //Tabuleiro tab = new Tabuleiro(8, 8);

    //tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
    //tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
    //tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 2));

    //Tela.ImprimirTabuleiro(tab);

    PosicaoXadrez pos = new PosicaoXadrez('a', 1);

    Console.WriteLine(pos);
    Console.WriteLine(pos.ToPosicao());

}
catch (TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex) 
{
    Console.WriteLine(ex.Message);
}