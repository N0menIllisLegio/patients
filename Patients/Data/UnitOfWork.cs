﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Patients.Data.Repositories;
using Patients.Data.Repositories.Interfaces;

namespace Patients.Data
{
  public class UnitOfWork
  {
    private readonly AppDbContext _context;
    private IPatientsRepository _patientsRepository;
    private IDiaryRecordsRepository _diaryRecordsRepository;
    private bool _disposedValue = false;

    public UnitOfWork(AppDbContext context)
    {
      _context = context;
    }

    public IPatientsRepository Patients => _patientsRepository = _patientsRepository ?? new PatientsRepository(_context);
    public IDiaryRecordsRepository DiaryRecords => _diaryRecordsRepository = _diaryRecordsRepository ?? new DiaryRecordsRepository(_context);

    public async Task<bool> SaveAsync()
    {
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public IDbContextTransaction BeginTransaction()
    {
      return _context.Database.BeginTransaction();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposedValue)
      {
        if (disposing)
        {
          _context.Dispose();
        }

        _disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~UnitOfWork()
    // {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    public void Dispose()
    {
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }
  }
}