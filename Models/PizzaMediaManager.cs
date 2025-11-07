using Microsoft.AspNetCore.Components.Forms;
using PizzaTime.Enums;

namespace PizzaTime.Models
{
    internal class PizzaMediaManager
    {
        public Dictionary<string, PizzaSong> MediaFiles { get; set; } = new Dictionary<string, PizzaSong>();

        public bool IsUsingStandardTrack => _selectedTrack.IsStandardTrack;

        private PizzaSong _selectedTrack;

        private const string _selectedTrackSettingsName = "SelectedTrack";

        private const int _maxAllowedMediaFileSize = 51200000;

        private const int _maxNumberOfMediaFiles = 4;

        public PizzaMediaManager()
        {
            MediaFiles.Add(PizzaSettings.StandardTrackName, new PizzaSong(PizzaSettings.StandardTrackName, PizzaSettings.StandardTrackPath, true));

            foreach (var media in Directory.GetFiles(FileSystem.AppDataDirectory, "*.mp3"))
            {
                if (!MediaFiles.ContainsKey(Path.GetFileNameWithoutExtension(media)))
                {
                    PizzaSong newSong = new PizzaSong(Path.GetFileNameWithoutExtension(media), Path.GetFullPath(media), false);
                    MediaFiles.Add(newSong.TrackName, newSong);
                }
            }

            string loadedTrackName = Preferences.Default.Get(_selectedTrackSettingsName, PizzaSettings.StandardTrackName);
            if (MediaFiles.ContainsKey(loadedTrackName))
            {
                _selectedTrack = MediaFiles[loadedTrackName];
            }
            else
            {
                _selectedTrack = MediaFiles[PizzaSettings.StandardTrackName];
            }
        }

        public void SetSelectedTrack(string trackName)
        {
            if (MediaFiles.ContainsKey(trackName))
            {
                _selectedTrack = MediaFiles[trackName];
                Preferences.Default.Set(_selectedTrackSettingsName, trackName);
            }
        }

        public void SetSelectedTrackToStandard()
        {
            _selectedTrack = MediaFiles[PizzaSettings.StandardTrackName];
            Preferences.Default.Set(_selectedTrackSettingsName, PizzaSettings.StandardTrackName);
        }

        public string GetSelectedTrackName()
        {
            return _selectedTrack.TrackName;
        }

        public string GetSelectedTrackPath()
        {
            return _selectedTrack.TrackName;
        }

        public Stream LoadSelectedTrack()
        {
            try
            {
                if (_selectedTrack.IsStandardTrack)
                {
                    return FileSystem.OpenAppPackageFileAsync(_selectedTrack.TrackPath).Result;
                }

                return File.OpenRead(_selectedTrack.TrackPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FEHLER: {ex.GetType().Name}: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack: {ex.StackTrace}");
                return null;
            }
        }

        public FileHandelingResult AddMedia(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var destinationPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            if (File.Exists(destinationPath))
            {
                return FileHandelingResult.FileAlreadyExists;
            }

            if (Path.GetExtension(fileName).ToLower() != ".mp3")
            {
                return FileHandelingResult.InvalidFileFormat;
            }

            try
            {
                File.Copy(filePath, destinationPath);
            }
            catch (Exception)
            {
                return FileHandelingResult.UnknownError;
            }

            PizzaSong newSong = new PizzaSong(Path.GetFileNameWithoutExtension(fileName), destinationPath, false);
            MediaFiles.Add(newSong.TrackName, newSong);

            return FileHandelingResult.Success;
        }

        public FileHandelingResult RemoveMedia(string fileName)
        {
            if (!MediaFiles.ContainsKey(fileName))
            {
                return FileHandelingResult.FileDoesNotExist;
            }

            PizzaSong songToRemove = MediaFiles[fileName];

            if (songToRemove.IsStandardTrack)
            {
                return FileHandelingResult.CantRemoveStandardTrack;
            }

            if (!File.Exists(songToRemove.TrackPath))
            {

                return FileHandelingResult.FileDoesNotExist;
            }

            try
            {
                File.Delete(songToRemove.TrackPath);
                MediaFiles.Remove(fileName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FEHLER: {ex.GetType().Name}: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack: {ex.StackTrace}");
                return FileHandelingResult.UnknownError;
            }

            return FileHandelingResult.Success;
        }
    }
}
