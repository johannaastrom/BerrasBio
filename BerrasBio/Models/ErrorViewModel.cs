using System;

namespace BerrasBio.Models // här läggs alla modellklasser in
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
		
    }
}