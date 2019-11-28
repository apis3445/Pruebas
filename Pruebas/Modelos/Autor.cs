using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pruebas.Modelos
{
    public class Autor
    {
        /// <summary>
        /// Ids
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        /// <summary>
        /// Clave
        /// </summary>
        public int Clave { get; set; }

        [Required(ErrorMessage = "Required")]
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Calficación que le han dado los usuarios
        /// </summary>
        public decimal Calificacion { get; set; }
        
    }
}
