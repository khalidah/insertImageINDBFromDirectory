using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertANDInsertImage
{
    [Table("SELECTECandidate")]
    //[Keyless]
    public partial class SELECTECandidate
    {
        
        public Double? Roll { get; set; }
        [Key]
        public long ApplicantionId { get; set; }
        public string? Name { get; set; }
        public byte[]? ApplicantImage{get;set;}
        public string? ApplicantImagePath { get;set;}
        public byte[]? ApplicantSignature { get;set;}
        public string? ApplicantSignaturePath { get; set; }
    }
}
