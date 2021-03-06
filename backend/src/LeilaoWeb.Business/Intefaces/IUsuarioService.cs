﻿using System;
using System.Threading.Tasks;
using LeilaoWeb.Business.Models;

namespace LeilaoWeb.Business.Intefaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(Guid id);
    }
}