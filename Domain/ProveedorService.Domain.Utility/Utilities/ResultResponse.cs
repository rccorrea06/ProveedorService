namespace ProveedorService.Domain.Utility.Utilities
{
    using System.Collections.ObjectModel;
    public class ResultResponse<T>
    {
        public bool Error { get; set; } = false;

        public Collection<T>? ResultData { get; set; }

        public string? Message { get; set; }

    }
}
