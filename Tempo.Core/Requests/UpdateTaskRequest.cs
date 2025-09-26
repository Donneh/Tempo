using System.ComponentModel.DataAnnotations;

namespace Tempo.Core.Requests;

public record UpdateTaskRequest(
    [Required(ErrorMessage = "Text is required")]
    [StringLength(500, ErrorMessage = "Text cannot exceed 500 characters")]
    string Text
);
