using System;
using System.Collections.Generic;

namespace Domain.Exceptions
{
    public class ValidationDTOException : Exception
    {
        public IList<string> Errors { get; set; }

        public ValidationDTOException(IList<string> errors) 
        {
            this.Errors = errors;
        }
    }
}
