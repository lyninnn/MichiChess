namespace MichiChess.Models
{
    public class ChessBoard
    {
        public ChessPiece[,] Board { get; private set; }

        // Constructor
        public ChessBoard()
        {
            Board = new ChessPiece[8, 8]; // Crear el tablero de ajedrez (8x8)
            InitializeBoard(); // Inicializar el tablero con las piezas en sus posiciones iniciales
        }

        // Método para inicializar las piezas en el tablero
        private void InitializeBoard()
        {
            // Inicializar los peones
            for (int i = 0; i < 8; i++)
            {
                Board[1, i] = new ChessPiece { PieceType = "pawn", PieceColor = "black", Position = (1, i) };
                Board[6, i] = new ChessPiece { PieceType = "pawn", PieceColor = "white", Position = (6, i) };
            }

            // Inicializar las piezas no peones (torres, caballos, etc.)
            InitializeOtherPieces();
        }

        // Método para inicializar las piezas restantes (torres, caballos, alfiles, etc.)
        private void InitializeOtherPieces()
        {
            // Torres
            Board[0, 0] = new ChessPiece { PieceType = "rook", PieceColor = "black",Position = (0, 0) };
            Board[0, 7] = new ChessPiece { PieceType = "rook", PieceColor = "black", Position = (0, 7) };
            Board[7, 0] = new ChessPiece { PieceType = "rook", PieceColor = "white", Position = (7, 0) };
            Board[7, 7] = new ChessPiece { PieceType = "rook", PieceColor = "white", Position = (7, 7) };

            // Caballos
            Board[0, 1] = new ChessPiece { PieceType = "knight", PieceColor = "black", Position = (0, 1) };
            Board[0, 6] = new ChessPiece { PieceType = "knight", PieceColor = "black", Position = (0, 6) };
            Board[7, 1] = new ChessPiece { PieceType = "knight", PieceColor = "white", Position = (7, 1) };
            Board[7, 6] = new ChessPiece { PieceType = "knight", PieceColor = "white", Position = (7, 6) };

            // Alfiles
            Board[0, 2] = new ChessPiece { PieceType = "bishop", PieceColor = "black", Position = (0, 2) };
            Board[0, 5] = new ChessPiece { PieceType = "bishop", PieceColor = "black", Position = (0, 5) };
            Board[7, 2] = new ChessPiece { PieceType = "bishop", PieceColor = "white", Position = (7, 2) };
            Board[7, 5] = new ChessPiece { PieceType = "bishop", PieceColor = "white", Position = (7, 5) };

            // Reinas
            Board[0, 3] = new ChessPiece { PieceType = "queen", PieceColor = "black", Position = (0, 3) };
            Board[7, 3] = new ChessPiece { PieceType = "queen", PieceColor = "white", Position = (7, 3) };

            // Reyes
            Board[0, 4] = new ChessPiece { PieceType = "king", PieceColor = "black", Position = (0, 4) };
            Board[7, 4] = new ChessPiece { PieceType = "King", PieceColor = "white", Position = (7, 4)};
        }

        // Método para mover una pieza en el tablero
        public bool MovePiece(int fromRow, int fromCol, int toRow, int toCol)
        {
            // Verifica si la celda de origen contiene una pieza
            var piece = Board[fromRow, fromCol];
            if (piece == null)
            {
                return false; // No hay pieza para mover
            }

            // Verificar si el movimiento es válido (según las reglas de la pieza)
            if (!piece.IsValidMove(toRow, toCol))
            {
                return false; // El movimiento no es válido según las reglas de la pieza
            }

            // Verificar si la celda de destino está vacía o contiene una pieza del color contrario
            var targetPiece = Board[toRow, toCol];
            if (targetPiece != null && targetPiece.PieceColor == piece.PieceColor)
            {
                return false; // No puede capturar una pieza de su propio color
            }

            // Realizar el movimiento
            Board[toRow, toCol] = piece; // Colocar la pieza en la nueva posición
            Board[fromRow, fromCol] = null; // Vaciar la posición original

            // Actualizar la posición de la pieza
            piece.Position = (toRow, toCol);

            // Marcar que la pieza se ha movido
            piece.HasMoved = true;

            return true; // El movimiento fue exitoso
        }
    }
}
