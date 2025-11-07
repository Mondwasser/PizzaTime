namespace PizzaTime.Enums
{
    internal enum FileHandelingResult
    {
        Success,
        FileAlreadyExists,
        FileDoesNotExist,
        InvalidFileFormat,
        CantRemoveStandardTrack,
        TooManyTracks,
        FileSizeExceedsLimit,
        UnknownError
    }
}
