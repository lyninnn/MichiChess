using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichiChess.Models
{
    public class ChessPiece
    {
        public string PieceType { get; set; } // Tipo: Pawn, Rook, etc.
        public string PieceColor { get; set; }
        public bool HasMoved { get; set; } // Indica si la pieza se ha movido (para reglas especiales)

        // Opcional: Para almacenar la posición de la pieza (esto es útil en algunos casos)
        public (int Row, int Col) Position { get; set; }

        // Método opcional para verificar si el movimiento es válido (esto se implementaría según las reglas del ajedrez)
        public bool IsValidMove(int toRow, int toCol)
        {
            // Implementar las reglas de movimiento específicas de cada pieza aquí
            return true; // Esto es solo un ejemplo, las reglas deben ser agregadas para cada tipo de pieza.
        }

        // Opcional: Imagen para representar la pieza (si deseas usar imágenes en lugar de texto)
        public string ImageSource
        {
            get
            {
                string imagePath = $"Resources/Images/{this.PieceColor}{this.PieceType}.png";
                System.Diagnostics.Debug.WriteLine($"Image Path: {imagePath}");  // Usa Debug.WriteLine para la salida de depuración
                return imagePath;
            }
        }

    }

}
