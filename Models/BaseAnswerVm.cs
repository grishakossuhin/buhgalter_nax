namespace BuhUchetApi.Models
{
    public class BaseAnswerVm<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }
}
