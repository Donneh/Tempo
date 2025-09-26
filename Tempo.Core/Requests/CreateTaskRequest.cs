using System.ComponentModel.DataAnnotations;

namespace Tempo.Core.Requests;

public record CreateTaskRequest(
    [Required(ErrorMessage = "Text is required")]
    [StringLength(500, ErrorMessage = "Text cannot exceed 500 characters")]
    string Text,

    [Range(0, int.MaxValue, ErrorMessage = "Order must be a positive number")]
    int Order
);
