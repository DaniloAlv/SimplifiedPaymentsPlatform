using System.Text.Json.Serialization;

namespace SimplifiedPaymentsPlatform.API.ViewModels;

public class Result
{
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Data { get; set; }

    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Error? Error { get; set; }


    public static Result Success<T>(T data) => new Result(data);
    public static Result Failure(Error error) => new Result(error);

    public Result(object data)
    {
        Data = data;
    }

    public Result(Error error)
    {
        Error = error;
    }
}