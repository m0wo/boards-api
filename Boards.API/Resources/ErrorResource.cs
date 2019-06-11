
namespace Boards.API.Resources
{
    public class ErrorResource
    {
        public string Error { get; }

        public ErrorResource(string message)
        {
            Error = message;
        }
    }
}