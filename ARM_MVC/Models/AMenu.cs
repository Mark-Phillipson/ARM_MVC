using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSPApplication.Shared.Models
{
    // [Keyless]
    [System.ComponentModel.DataAnnotations.Schema.Table("A_Menu")]
    public partial class AMenu
    {
		[Key]
        [Column("MenuID")]
        public int MenuId { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;
        public int? Order { get; set; }
        [Required]
        public bool? Active { get; set; }
        [Column("URL")]
        [StringLength(255)]
        public string? Url { get; set; }
        [StringLength(50)]
        public string? Icon { get; set; }
        public bool? Override { get; set; }

    }
}
