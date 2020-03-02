using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogosRepository
    {
        List<JogosDomain> Listar();

        JogosDomain BuscarPorId(int id);

        void Cadastrar(JogosDomain novoJogo);

        void Atualizar(int id, JogosDomain jogos);

        void Deletar(int id);

        List<JogosDomain> BuscarPorTitulo(string busca);
    }
}
