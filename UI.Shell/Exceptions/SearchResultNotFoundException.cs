using System;

namespace Shell.Exceptions
{
    public class SearchResultNotFoundException : Exception
    {
        public string ItemName { get; }

        public SearchResultNotFoundException(string itemName)
        {
            ItemName = itemName;
        }

        public SearchResultNotFoundException(string message, string itemName) : base(message)
        {
            ItemName = itemName;
        }

        public SearchResultNotFoundException(string message, Exception innerException, string itemName) : base(message, innerException)
        {
            ItemName = itemName;
        }
    }
}
