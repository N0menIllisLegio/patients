using System;
using System.Threading.Tasks;
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
    private IDentalRecordsRepository _dentalRecordsRepository;
    private IPaymentsRepository _paymentsRepository;
    private bool _disposedValue = false;

    public UnitOfWork(AppDbContext context)
    {
      _context = context;
    }

    public IPatientsRepository Patients => _patientsRepository = _patientsRepository ?? new PatientsRepository(_context);
    public IDiaryRecordsRepository DiaryRecords => _diaryRecordsRepository = _diaryRecordsRepository ?? new DiaryRecordsRepository(_context);
    public IDentalRecordsRepository DentalRecords => _dentalRecordsRepository = _dentalRecordsRepository ?? new DentalRecordsRepository(_context);
    public IPaymentsRepository Payments => _paymentsRepository = _paymentsRepository ?? new PaymentsRepository(_context);

    public async Task<bool> SaveAsync()
    {
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
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

    public void Dispose()
    {
      Dispose(true);
    }
  }
}
