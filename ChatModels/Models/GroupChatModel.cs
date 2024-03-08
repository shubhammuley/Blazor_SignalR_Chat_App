
using System.ComponentModel.DataAnnotations;

namespace ChatModels.Models
{


    public class GroupChatModel
    {

        public int Id { get; set; }
        [Required]
        public string? SenderId { get; set; }

        [Required]
        public string? Message { get; set; }

        public DateTime DateTime { get; set; }

    }
}
