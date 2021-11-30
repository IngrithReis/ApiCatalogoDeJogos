using System;

namespace ApiCatalogoDeJogos.Exceptions
{
    public class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException() : base("Jogo não cadastro!")
        { }
    }
}
