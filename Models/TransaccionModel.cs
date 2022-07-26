using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jQueryAjaxCRUDinASP.NETCoreMVC.Models
{
    public class TransaccionModel
    {
        [Key]
        public int TransaccionId { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage ="Este campo es requerido.")]
        [Column(TypeName ="nvarchar(12)")]
        [DisplayName("Numero de Cuenta")]
        public string NumeroCuenta { get; set; }
                
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nombre de Beneficiario")]
        public string NombreBeneficiario { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nombre de Banco")]
        public string NombreBanco { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("Codigo SWIFT")]
        public string CodigoSWIFT { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Monto { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha { get; set; }
    }
}
