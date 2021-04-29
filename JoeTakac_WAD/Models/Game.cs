using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JoeTakac_WAD.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Developer { get; set; }

        [Required]
        public String Publisher { get; set; }

        [Required]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public String Genre { get; set; }

        [Required]
        public String Engine { get; set; }

        [Required]
        public String Rating { get; set; }

        [Required]
        public String Platforms { get; set; }

        [Required]
        public String Requirements { get; set; }

        [Column(TypeName = "varchar(100)")]
        public String Image { get; set; }


    }
}
