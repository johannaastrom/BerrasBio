using System;

namespace BerrasBio.Models // h�r l�ggs alla modellklasser in
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
		
    }
}