﻿using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Domain.Interfaces
{
    public interface ICartaRepository
    {
        IEnumerable<Carta> ObterTodos();

        Task Adicionar(Carta documentosCarta);
    }
}
