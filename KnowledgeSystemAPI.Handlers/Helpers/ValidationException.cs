﻿using System;

namespace KnowledgeSystemAPI.Handlers.Helpers
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}