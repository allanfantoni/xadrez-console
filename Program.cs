using tabuleiro;
using xadrez;
using xadrez_console;

try
{
    Tabuleiro tab = new Tabuleiro(8, 8);

    tab.ColocarPeca(new Torre(Cor.Amarela, tab), new Posicao(0, 0));
    tab.ColocarPeca(new Torre(Cor.Amarela, tab), new Posicao(1, 3));
    tab.ColocarPeca(new Rei(Cor.Amarela, tab), new Posicao(0, 2));

    tab.ColocarPeca(new Torre(Cor.Branca, tab), new Posicao(3, 5));

    Tela.ImprimirTabuleiro(tab);
}
catch (TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex) 
{
    Console.WriteLine(ex.Message);
}