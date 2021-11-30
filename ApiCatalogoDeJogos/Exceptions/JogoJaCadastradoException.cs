using System;

namespace ApiCatalogoDeJogos.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() : base("Este jogo já está cadastrado!")
        {}
    }
}
