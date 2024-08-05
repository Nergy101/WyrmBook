namespace WyrmBook.Core.Exceptions;

/// <summary>
///     Exception thrown when something expected to be found wasn't found
/// </summary>
/// <param name="message"></param>
public class NotFoundException(string message) : Exception(message);