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
    private IDentalRecordsRepository _dentalRecordsRepository;
    private IPaymentsRepository _paymentsRepository;
    private ITeethRepository _teethRepository;
    private IPatientTeethRepository _patientTeethRepository;
    private bool _disposed = false;

    public UnitOfWork(AppDbContext context)
    {
      _context = context;
    }

    public IPatientsRepository Patients => _patientsRepository ??= new PatientsRepository(_context);
    public IDiaryRecordsRepository DiaryRecords => _diaryRecordsRepository ??= new DiaryRecordsRepository(_context);
    public IDentalRecordsRepository DentalRecords => _dentalRecordsRepository ??= new DentalRecordsRepository(_context);
    public IPaymentsRepository Payments => _paymentsRepository ??= new PaymentsRepository(_context);
    public ITeethRepository Teeth => _teethRepository ??= new TeethRepository(_context);
    public IPatientTeethRepository PatientTeeth => _patientTeethRepository ??= new PatientTeethRepository(_context);

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }

    public IDbContextTransaction BeginTransaction()
    {
      return _context.Database.BeginTransaction();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }

        _disposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
    }
  }
}
