using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Patients.Enums;
using Patients.Models;

namespace Patients.Services
{
  public class PatientPicturesManager
  {
    public const string TempScreensDirectory = @"Screens\Temp";
    public const string ScreensDirectory = @"Screens";

    private readonly string _patientPicturesDirectory;
    private readonly Dictionary<string, PatientPictureStateModel> _picturesChangesTracker
      = new Dictionary<string, PatientPictureStateModel>();

    private List<string> _displayedPatientPicturePaths;
    private int _displayedPatientPictureIndex = 0;

    private bool _changesApplied = false;
    private bool _changesRejected = false;

    public PatientPicturesManager()
    {
      _patientPicturesDirectory = TempScreensDirectory;

      UpdateDisplayedPicturePaths();
    }

    public PatientPicturesManager(Guid patientID)
    {
      _patientPicturesDirectory = Path.Combine(ScreensDirectory, patientID.ToString());

      if (!Directory.Exists(_patientPicturesDirectory))
      {
        Directory.CreateDirectory(_patientPicturesDirectory);
      }

      var originalPatientPicturePaths = Directory.GetFiles(_patientPicturesDirectory)
        .Where(str => str.EndsWith(".jpg") || str.EndsWith(".jpeg") || str.EndsWith(".png"));

      foreach (string picturePath in originalPatientPicturePaths)
      {
        _picturesChangesTracker.TryAdd(picturePath, new PatientPictureStateModel { PictureState = PictureState.Original });
      }

      UpdateDisplayedPicturePaths();
    }

    public int DisplayedPatientPicturesCount => _displayedPatientPicturePaths.Count;
    public int DisplayedPatientPictureNumber => _displayedPatientPictureIndex + 1;

    public string CurrentlyDisplayedPatientPicture =>
      _displayedPatientPictureIndex >= 0 && _displayedPatientPictureIndex < DisplayedPatientPicturesCount
      ? _displayedPatientPicturePaths[_displayedPatientPictureIndex]
      : null;

    public void AddPatientPictures(string[] newPicturePaths)
    {
      int pictureNumber = 0;

      foreach (string newPicturePath in newPicturePaths)
      {
        string patientPictureName = DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss_") + pictureNumber++ + Path.GetExtension(newPicturePath);
        string patientPicturePath = Path.Combine(_patientPicturesDirectory, patientPictureName);
        File.Copy(newPicturePath, patientPicturePath);

        if (_picturesChangesTracker.TryGetValue(patientPicturePath, out var patientPictureState))
        {
          patientPictureState.PictureState = PictureState.Added;
        }
        else
        {
          _picturesChangesTracker.TryAdd(patientPicturePath,
            new PatientPictureStateModel { PictureState = PictureState.Added });
        }
      }

      UpdateDisplayedPicturePaths();
    }

    public void DeleteDisplayedPatientPicture()
    {
      if (_displayedPatientPicturePaths.Count > 0)
      {
        if (_picturesChangesTracker.TryGetValue(
          CurrentlyDisplayedPatientPicture, out var patientPictureState))
        {
          patientPictureState.PictureState = PictureState.Deleted;
        }

        UpdateDisplayedPicturePaths();

        SetDisplayedPatientPictureIndex(0);
      }
    }

    public void NextPatientPicture()
    {
      SetDisplayedPatientPictureIndex(++_displayedPatientPictureIndex);
    }

    public void PreviousPatientPicture()
    {
      SetDisplayedPatientPictureIndex(--_displayedPatientPictureIndex);
    }

    public void ApplyChanges()
    {
      if (_changesRejected || _changesApplied)
      {
        return;
      }

      var deletedPatientPicturePaths = _picturesChangesTracker.Where(
        pair => pair.Value.PictureState == PictureState.Deleted).Select(pair => pair.Key);

      foreach (string deletedPicturePath in deletedPatientPicturePaths)
      {
        File.Delete(deletedPicturePath);
        _picturesChangesTracker.Remove(deletedPicturePath);
      }

      _changesApplied = true;
    }

    public void RejectChanges()
    {
      if (_changesRejected || _changesApplied)
      {
        return;
      }

      var addedPatientPicturePaths = _picturesChangesTracker.Where(
        pair => pair.Value.PictureState == PictureState.Added).Select(pair => pair.Key);

      foreach (string addedPicturePath in addedPatientPicturePaths)
      {
        File.Delete(addedPicturePath);
        _picturesChangesTracker.Remove(addedPicturePath);
      }

      _changesRejected = true;
    }

    public void MoveDisplayedPicturesToPatientDirectory(Guid patientID)
    {
      string patientPicturesDirectory = Path.Combine(ScreensDirectory, patientID.ToString());
      Directory.CreateDirectory(patientPicturesDirectory);

      UpdateDisplayedPicturePaths();

      foreach (string displayedPicturePath in _displayedPatientPicturePaths)
      {
        string fileName = Path.GetFileName(displayedPicturePath);
        File.Move(displayedPicturePath, Path.Combine(patientPicturesDirectory, fileName));
      }
    }

    private void SetDisplayedPatientPictureIndex(int index)
    {
      if (index >= DisplayedPatientPicturesCount)
      {
        index = DisplayedPatientPicturesCount - 1;
      }

      if (index < 0)
      {
        index = 0;
      }

      _displayedPatientPictureIndex = index;
    }

    private void UpdateDisplayedPicturePaths()
    {
      _displayedPatientPicturePaths = _picturesChangesTracker.Where(
        pair => pair.Value.PictureState != PictureState.Deleted).Select(pair => pair.Key).ToList();
    }
  }
}
