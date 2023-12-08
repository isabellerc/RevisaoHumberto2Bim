using AutoMapper;
using Revisao.Data.Providers.MongoDB.Collections;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.AutoMapper
{
    public class CollectionToDomain : Profile
    {
        public CollectionToDomain()
        {
            CreateMap<CartasCollection, Carta>()
            .ConstructUsing(X => new Carta(X.Nome, X.Rua, X.Numero, X.Bairro, X.Cidade, X.Estado, X.Idade, X.Texto));
        }
    }
}
