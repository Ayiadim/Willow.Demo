namespace Willow.Demo.Service.Responses
{
    using System.Collections.Generic;

    public class BaseResponse<T>
    {
        public ICollection<T> Items { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
