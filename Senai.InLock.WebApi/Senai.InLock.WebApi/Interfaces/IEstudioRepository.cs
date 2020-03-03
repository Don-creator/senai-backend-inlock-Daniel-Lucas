using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int id);

        void Cadastrar(EstudioDomain novoEstudio);

        void AtualizarIdCorpo(EstudioDomain estudio);

        void AtualizarIdUrl(int id, EstudioDomain estudio);

        void Deletar(int id);


    }
}
