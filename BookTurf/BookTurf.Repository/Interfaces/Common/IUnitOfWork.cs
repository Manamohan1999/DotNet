﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookTurf.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        void Dispose(bool disposing);
    }
}
