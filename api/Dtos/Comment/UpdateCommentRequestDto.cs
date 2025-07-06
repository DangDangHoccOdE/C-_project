using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Title must not exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        [MinLength(10, ErrorMessage = "Content must be at least 10 characters long.")]
        [MaxLength(1000, ErrorMessage = "Content must not exceed 1000 characters.")]
        public string Content { get; set; } = string.Empty;
    }
}