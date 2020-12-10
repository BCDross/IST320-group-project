using System;

namespace BurnBuilder.Models
{
    /// <summary>
    /// This is the error properties. 
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
