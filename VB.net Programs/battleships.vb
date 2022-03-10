Module Module1

    Sub Main()
        Console.WriteLine("
                                     |__
                                     |\/
                                     ---
                                     / | [
                              !      | |||
                            _/|     _/|-++'
                        +  +--|    |--|--|_ |-
                     { /|__|  |/\__|  |--- |||__/
                    +---------------___[}-_===_.'____                 /\
                ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _
  _..._____--==/___]_|__|_____________________________[___\==--____,------' .7
 |                                                                     BB-61/ 
  \________________________________________________________________________| 
                                                                             
 █████████████████████████████████████████████████████████████████████████████
 ████████▄─▄─▀██▀▄─██─▄─▄─█─▄─▄─█▄─▄███▄─▄▄─█─▄▄▄▄█─█─█▄─▄█▄─▄▄─█─▄▄▄▄████████
 █████████─▄─▀██─▀─████─█████─████─██▀██─▄█▀█▄▄▄▄─█─▄─██─███─▄▄▄█▄▄▄▄─████████
 ▀▀▀▀▀▀▀▀▄▄▄▄▀▀▄▄▀▄▄▀▀▄▄▄▀▀▀▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▀▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▄▄▀▀▀▀▀▀▀▀")
        Console.ReadKey()
        Dim bs As New battleships
        bs.Game()
    End Sub

    Class battleships
        Private placing As Boolean
        Private playergrid(9, 9) As Integer
        Private compgrid(9, 9) As Integer
        Private playerguess(9, 9) As Integer
        Private compguess(9, 9) As Integer

        Private curx, cury As Integer
        Private selectedship As Integer = 1
        Private direction As Char = "Q"
        Private noofships As Integer

        Private winner As String

        Public Sub New()
            noofships = 0
            placing = True
            Do
                Display()
                Console.WriteLine($"
Keys (Current: {selectedship})          Direction (Current: {direction})
1  Destroyer   ## (2)      Q  North
2  Cruiser     ### (3)     W  East
3  Battleship  #### (4)    E  South
4  Carrier     ##### (5)   R  West")
                Console.SetCursorPosition(curx * 2 + 2, cury + 1)
                InputKey(Console.ReadKey.Key)
            Loop While placing
            CompGen()
        End Sub

        Public Sub InputKey(key As ConsoleKey)
            Select Case key
                Case ConsoleKey.UpArrow
                    If cury > 0 Then
                        cury -= 1
                    End If
                Case ConsoleKey.DownArrow
                    If cury < 9 Then
                        cury += 1
                    End If
                Case ConsoleKey.LeftArrow
                    If curx > 0 Then
                        curx -= 1
                    End If
                Case ConsoleKey.RightArrow
                    If curx < 9 Then
                        curx += 1
                    End If
                Case Else
                    If placing Then
                        Select Case key
                            Case ConsoleKey.Enter
                                If ValidShipPos(curx, cury, direction, selectedship) Then
                                    PlaceShip(curx, cury, direction, selectedship, True)
                                End If
                            Case ConsoleKey.D1
                                selectedship = 1
                            Case ConsoleKey.D2
                                selectedship = 2
                            Case ConsoleKey.D3
                                selectedship = 3
                            Case ConsoleKey.D4
                                selectedship = 4
                            Case ConsoleKey.Q
                                direction = "Q"
                            Case ConsoleKey.W
                                direction = "W"
                            Case ConsoleKey.E
                                direction = "E"
                            Case ConsoleKey.R
                                direction = "R"
                            Case ConsoleKey.X
                                placing = False
                        End Select
                    Else
                        GuessShip(curx, cury)
                    End If
            End Select
        End Sub

        Public Function ValidShipPos(x, y, direction, shiptype)
            Select Case direction
                Case "Q"
                    For i = y To y - shiptype Step -1
                        If i = -1 Then
                            Return False
                        End If
                        If playergrid(i, x) = 1 Then
                            Return False
                        End If
                    Next
                Case "W"
                    For i = x To x + shiptype
                        If i = 10 Then
                            Return False
                        End If
                        If playergrid(y, i) = 1 Then
                            Return False
                        End If
                    Next
                Case "E"
                    For i = y To y + shiptype
                        If i = 10 Then
                            Return False
                        End If
                        If playergrid(i, x) = 1 Then
                            Return False
                        End If
                    Next
                Case "R"
                    For i = x To x - shiptype Step -1
                        If i = -1 Then
                            Return False
                        End If
                        If playergrid(y, i) = 1 Then
                            Return False
                        End If
                    Next
            End Select
            Return True
        End Function

        Public Sub PlaceShip(x, y, direction, shiptype, player)
            Select Case direction
                Case "Q"
                    For i = y To y - shiptype Step -1
                        If player Then
                            playergrid(i, x) = 1
                        Else
                            compgrid(i, x) = 1
                        End If
                    Next
                Case "W"
                    For i = x To x + shiptype
                        If player Then
                            playergrid(y, i) = 1
                        Else
                            compgrid(y, i) = 1
                        End If
                    Next
                Case "E"
                    For i = y To y + shiptype
                        If player Then
                            playergrid(i, x) = 1
                        Else
                            compgrid(i, x) = 1
                        End If
                    Next
                Case "R"
                    For i = x To x - shiptype Step -1
                        If player Then
                            playergrid(y, i) = 1
                        Else
                            compgrid(y, i) = 1
                        End If
                    Next
            End Select
            noofships += 1
        End Sub

        Public Sub Display(Optional playing = False)
            Console.Clear()
            If playing Then
                Console.WriteLine("  A B C D E F G H I J")
                For i = 0 To 9
                    Console.Write(i)
                    For j = 0 To 9
                        Console.Write(" ")
                        If playerguess(i, j) = 2 Then
                            Console.Write("X")
                        Else
                            If playerguess(i, j) = 1 Then
                                Console.Write("O")
                            Else
                                Console.Write("~")
                            End If
                        End If
                    Next
                    Console.WriteLine()
                Next
                Console.WriteLine()
            End If
            Console.WriteLine("  A B C D E F G H I J")
            For i = 0 To 9
                Console.Write(i)
                For j = 0 To 9
                    Console.Write(" ")
                    If compguess(i, j) = 2 Then
                        Console.Write("X")
                    Else
                        If compguess(i, j) = 1 Then
                            Console.Write("O")
                        Else
                            If playergrid(i, j) = 1 Then
                                Console.Write("#")
                            Else
                                Console.Write("~")
                            End If
                        End If

                    End If

                Next
                Console.WriteLine()
            Next
            Console.WriteLine()
        End Sub

        Public Sub CompGen()
            Dim genx, geny, genshiptype As Integer
            Dim gendir As Integer
            Dim gendirchar As Char
            For i = 0 To 4
                Do
                    Randomize()
                    genx = Rnd() * 9
                    Randomize()
                    geny = Rnd() * 9
                    Randomize()
                    gendir = Rnd() * 3
                    Select Case gendir
                        Case 0
                            gendirchar = "Q"
                        Case 1
                            gendirchar = "W"
                        Case 2
                            gendirchar = "E"
                        Case 3
                            gendirchar = "R"
                    End Select
                    If i = 4 Then
                        genshiptype = 3
                    Else
                        genshiptype = i
                    End If
                Loop Until ValidShipPos(genx, geny, direction, genshiptype)
                PlaceShip(genx, geny, direction, genshiptype, False)
            Next
        End Sub

        Public Sub Game()
            Do
                Display(True)
                If GameOver() Then
                    Exit Do
                End If
                Console.SetCursorPosition(curx * 2 + 2, cury + 1)
                InputKey(Console.ReadKey.Key)
            Loop
            Console.WriteLine($"Winner: {winner}")
            Console.ReadKey()
        End Sub

        Public Sub GuessShip(x, y)
            If playerguess(y, x) = Nothing Then
                If compgrid(y, x) = 1 Then
                    compgrid(y, x) = 0
                    playerguess(y, x) = 2
                Else
                    playerguess(y, x) = 1
                End If
                CompGuessShip()
            End If
        End Sub

        Public Sub CompGuessShip()
            Dim x, y As Integer
            Do
                Randomize()
                x = Rnd() * 9
                Randomize()
                y = Rnd() * 9
            Loop Until playergrid(y, x) = Nothing
            If playergrid(y, x) = 1 Then
                playergrid(y, x) = 0
                compguess(y, x) = 2
            Else
                compguess(y, x) = 1
            End If
        End Sub

        Public Function GameOver()
            Dim playerempty As Boolean = True
            Dim compempty As Boolean = True
            For i = 0 To 9
                For j = 0 To 9
                    If playergrid(i, j) = 1 Then
                        playerempty = False
                    End If
                    If compgrid(i, j) = 1 Then
                        compempty = False

                    End If
                Next
            Next
            If playerempty And compempty Then
                Return False
            End If
            If playerempty Then
                winner = "Computer"
            End If
            If compempty Then
                winner = "Player"
            End If
            Return True
        End Function

    End Class

End Module
