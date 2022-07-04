// Copyright (c) 2022 Yanderemine54
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

public static class Board {
    public static int[] BoardArray = new int[64];

    public static void LoadPositionFromFEN(string fen) {
        Board.ClearBoard();
        Dictionary<char, int> pieceMap = new Dictionary<char, int> {
            { 'K', Piece.King | Piece.White },
            { 'Q', Piece.Queen | Piece.White },
            { 'R', Piece.Rook | Piece.White },
            { 'B', Piece.Bishop | Piece.White },
            { 'N', Piece.Knight | Piece.White },
            { 'P', Piece.Pawn | Piece.White },
            { 'k', Piece.King | Piece.Black },
            { 'q', Piece.Queen | Piece.Black },
            { 'r', Piece.Rook | Piece.Black },
            { 'b', Piece.Bishop | Piece.Black },
            { 'n', Piece.Knight | Piece.Black },
            { 'p', Piece.Pawn | Piece.Black },
            { '1', Piece.None },
            { '2', Piece.None },
            { '3', Piece.None },
            { '4', Piece.None },
            { '5', Piece.None },
            { '6', Piece.None },
            { '7', Piece.None },
            { '8', Piece.None },
            { '/', Piece.None },
            { ' ', Piece.None }
        };
        string[] rows = fen.Split('/');
        int row = 0;
        foreach (string rowStr in rows) {
            int col = 0;
            foreach (char c in rowStr) {
                if (pieceMap.ContainsKey(c)) {
                    if (pieceMap[c] != Piece.None) {
                        Board.BoardArray[row * 8 + col] = pieceMap[c];
                        col++;
                    } else {
                        col += Int32.Parse(c.ToString());
                    }
                } else {
                    Console.WriteLine("Invalid FEN: " + c);
                }
            }
            row++;
        }
    }
    public static void Show() {
        string rank = "";
        foreach (int piece in BoardArray) {
            Dictionary<int, char> pieceMap = new Dictionary<int, char> {
                { Piece.None, ' ' },
                { Piece.King | Piece.White, 'K' },
                { Piece.Queen | Piece.White, 'Q' },
                { Piece.Rook | Piece.White, 'R' },
                { Piece.Bishop | Piece.White, 'B' },
                { Piece.Knight | Piece.White, 'N' },
                { Piece.Pawn | Piece.White, 'P' },
                { Piece.King | Piece.Black, 'k' },
                { Piece.Queen | Piece.Black, 'q' },
                { Piece.Rook | Piece.Black, 'r' },
                { Piece.Bishop | Piece.Black, 'b' },
                { Piece.Knight | Piece.Black, 'n' },
                { Piece.Pawn | Piece.Black, 'p' }
            };
            rank = rank + pieceMap[piece];
            if (rank.Length == 8) {
                Console.WriteLine(rank);
                rank = "";
            }
        }
    }

    public static void  ClearBoard() {
        for (int i = 0; i < 64; i++) {
            BoardArray[i] = Piece.None;
        }
    }
    public static void SetPiece(int row, int col, int piece) {
        BoardArray[row * 8 + col] = piece;
    }

    public static int GetPiece(int row, int col) {
        return BoardArray[row * 8 + col];
    }
    public static int GetPiece(int index) {
        return BoardArray[index];
    }
    public static int GetPiece(int row, int col, int piece) {
        return BoardArray[row * 8 + col] & piece;
    }  
    public static void RemovePiece(int row, int col) {
        BoardArray[row * 8 + col] = Piece.None;
    }
    public static void RemovePiece(int index) {
        BoardArray[index] = Piece.None;
    }
    public static void GetPostitionOfPiece(string piece, out int row, out int col) {
        row = col = 0;
        foreach (char c in piece) {
            if (c == ' ') {
                break;
            }
            if (c == '-') {
                continue;
            }
            if (c >= 'a' && c <= 'h') {
                col = c - 'a';
            } else if (c >= '1' && c <= '8') {
                row = c - '1';
            } else {
                Console.WriteLine("Invalid piece: " + c);
            }
        }
    }
    public static void Move(string move) {
        Dictionary<char, int> pieceMap = new Dictionary<char, int> {
            { 'K', Piece.King | Piece.White },
            { 'Q', Piece.Queen | Piece.White },
            { 'R', Piece.Rook | Piece.White },
            { 'B', Piece.Bishop | Piece.White },
            { 'N', Piece.Knight | Piece.White },
            { 'P', Piece.Pawn | Piece.White },
            { 'k', Piece.King | Piece.Black },
            { 'q', Piece.Queen | Piece.Black },
            { 'r', Piece.Rook | Piece.Black },
            { 'b', Piece.Bishop | Piece.Black },
            { 'n', Piece.Knight | Piece.Black },
            { 'p', Piece.Pawn | Piece.Black }
        };
        int row, col, piece;
        col = row = piece = 0;
        foreach (char c in move) {
            if (c == ' ') {
                break;
            }
            if (c == '-') {
                continue;
            }
            if (c >= 'a' && c <= 'h') {
                col = c - 'a';
            } else if (c >= '1' && c <= '8') {
                row = c - '1';
            } else {
                piece = c;
            }
        }
        // Move the piece
        int index = row * 8 + col;
        Board.RemovePiece(row, col);
        Board.SetPiece(row, col, pieceMap[(char)piece]);

    }
}