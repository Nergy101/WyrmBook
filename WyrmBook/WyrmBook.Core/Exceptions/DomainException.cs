namespace WyrmBook.Core.Exceptions;

/// <summary>
///     Exception thrown when some domain specific exception happens
/// </summary>
/// <param name="message"></param>
public class DomainException(string message) : Exception(message);