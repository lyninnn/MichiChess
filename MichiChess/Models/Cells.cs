using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichiChess.Models
{
    public class Cells
    {
        public ChessPiece Piece { get; set; } // La pieza que está en la celda
        public string BackgroundColor { get; set; } // Color de fondo de la celda (Blanco o Negro)
    }
}
