﻿using AutoMapper;
using Revisao.Application.ViewModels;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.AutoMapper
{
	public class ApplicationToDomain : Profile
	{
        public ApplicationToDomain()
        {

            CreateMap<CartaViewModel, Carta>()
               .ConstructUsing(q => new Carta(q.Nome, q.Rua, q.Numero, q.Bairro, q.Cidade, q.Estado, q.Idade, q.Texto));

            CreateMap<NovaCartaViewModel, Carta>()
               .ConstructUsing(q => new Carta(q.Nome, q.Rua, q.Numero, q.Bairro, q.Cidade, q.Estado, q.Idade, q.Texto));

        }
    }
}
