namespace WyrmBook.Api.Results.Models;

public record VoidResultResponseModel(bool IsSuccess, List<string?> Errors);