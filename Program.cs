// Copyright (c) 2022 Yanderemine54
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

bool quit = false;
Board.LoadPositionFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
Board.Show();
while (quit != true) {
    Console.Write("> ");
    string? command = Console.ReadLine();
    if (command == null) {
        continue;
    } else if (command == "quit") {
        quit = true;
    } else if (command == "load") {
        string? fen = Console.ReadLine();
        if (fen == null) {
            continue;
        } else {
            Board.LoadPositionFromFEN(fen);
            Board.Show();
        }
    } else if (command == "move") {
        string? pieceToMove = Console.ReadLine();
        if (pieceToMove == null) {
            continue;
        } else {
            int row, col;
            Board.GetPostitionOfPiece(pieceToMove, out row, out col);
            Board.RemovePiece(row, col);
            string? move = Console.ReadLine();
            if (move == null) {
                continue;
            } else {
                Board.Move(move);
                Board.Show();
            }
        }
    } else if (command == "undo") {
        //Board.Undo();
        Board.Show();
    } else if (command == "redo") {
        //Board.Redo();
        Board.Show();
    } else if (command == "show") {
        Board.Show();
    } else if (command == "restart") {
        Board.LoadPositionFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
        Board.Show();
    } else if (command == "help") {
        Console.WriteLine("load <fen>");
        Console.WriteLine("move <move>");
        Console.WriteLine("undo");
        Console.WriteLine("redo");
        Console.WriteLine("show");
        Console.WriteLine("restart");
        Console.WriteLine("help");
        Console.WriteLine("quit");
    } else {
        Console.WriteLine("Unknown command: " + command);
    }
}