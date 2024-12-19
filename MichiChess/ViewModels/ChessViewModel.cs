using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MichiChess.Models;
using System.Collections.Generic;

namespace MichiChess.ViewModels
{
    public class ChessViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Cells> _cells; // Cambié de 'Cells' a 'Cell'
        private ChessBoard _chessBoard; // Referencia al tablero de ajedrez

        // Propiedad que expone las celdas (y no las piezas directamente)
        public ObservableCollection<Cells> Cells
        {
            get => _cells;
            set
            {
                _cells = value;
                OnPropertyChanged();
            }
        }

        public ChessViewModel()
        {
            _chessBoard = new ChessBoard(); // Crear el tablero de ajedrez
            _cells = new ObservableCollection<Cells>(GetCellsForView()); // Inicializar las celdas para la vista
        }

        // Propiedad que dispara la notificación cuando cambia
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para disparar el evento de cambio de propiedad
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Este método obtiene las celdas del tablero para la vista (se usa para inicializar el estado)
        private List<Cells> GetCellsForView()
        {
            var cellsForView = new List<Cells>();

            // Convertir el tablero 8x8 en una lista plana de celdas
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var piece = _chessBoard.Board[i, j];
                    var cells = new Cells
                    {
                        Piece = piece,
                        BackgroundColor = (i + j) % 2 == 0 ? "LightGoldenrodYellow" : "DarkOliveGreen" // Asignar fondo alternado
                    };
                    cellsForView.Add(cells);
                }
            }

            return cellsForView;
        }

        // Método para mover una pieza
        public bool MovePiece(int fromRow, int fromCol, int toRow, int toCol)
        {
            // Realizar el movimiento en el modelo de datos (ChessBoard)
            bool moveSuccessful = _chessBoard.MovePiece(fromRow, fromCol, toRow, toCol);

            if (moveSuccessful)
            {
                // Si el movimiento es exitoso, actualizamos la lista de celdas para la vista
                Cells.Clear();
                foreach (var cell in GetCellsForView())
                {
                    Cells.Add(cell); // Actualizar las celdas en la vista
                }
            }

            return moveSuccessful; // Retorna si el movimiento fue exitoso o no
        }
    }
}
