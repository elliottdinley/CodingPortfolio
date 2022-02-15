Module Module1
    Dim flags(8, 8) As Char
    Sub Main()
        Dim ms As New ms
        Dim temp As String
        Dim y, x As Integer
        Do
            ms.Display()

            temp = CStr(Console.ReadKey.KeyChar.ToString)
            If temp = "f" Then
                x = CInt(Console.ReadKey.KeyChar.ToString)
                y = CInt(Console.ReadKey.KeyChar.ToString)
                ms.Flag(y - 1, x - 1)
            Else
                x = CInt(temp)
                y = CInt(Console.ReadKey.KeyChar.ToString)
                If flags(y - 1, x - 1) <> "F" Then
                    If ms.onMine(y - 1, x - 1) Then
                        ms.Display()
                        Exit Do
                    End If
                    ms.Reveal(y - 1, x - 1)
                End If
            End If
        Loop
        Console.WriteLine("You lose")
        Console.ReadKey()
    End Sub

    Class ms
        Private board(8, 8) As Char
        Private bombs(8, 8) As Integer
        Private numbers(8, 8) As Integer
        Private vis(8, 8) As Integer

        Private probability As Decimal
        Private ran As Decimal
        Public Sub New()
            Console.BackgroundColor = ConsoleColor.Gray
            Console.Clear()
            Console.ForegroundColor = ConsoleColor.White
            probability = 0.12345679012
            For i = 0 To 8
                For j = 0 To 8
                    Randomize()
                    ran = Rnd()
                    If ran <= probability Then
                        bombs(i, j) = 1
                    End If
                    board(i, j) = "#"
                Next
            Next

            For i = 0 To 8
                For j = 0 To 8
                    If bombs(i, j) = 1 Then
                        For k = (i - 1) To (i + 1)
                            For l = (j - 1) To (j + 1)
                                Try
                                    If bombs(k, l) = 1 Then
                                        numbers(k, l) = 9
                                    Else
                                        numbers(k, l) += 1
                                    End If
                                Catch
                                End Try
                            Next
                        Next
                        bombs(i, j) = "1"
                    End If
                Next
            Next

            For i = 0 To 8
                For j = 0 To 8
                    If numbers(i, j) = Nothing Then
                        numbers(i, j) = 0
                    End If
                Next
            Next
        End Sub

        Public Sub Display()
            Console.Clear()
            Console.ForegroundColor = ConsoleColor.Black
            Console.WriteLine("  1 2 3 4 5 6 7 8 9")
            Console.ForegroundColor = ConsoleColor.White
            For i = 0 To 8
                Console.ForegroundColor = ConsoleColor.Black
                Console.Write($"{i + 1} ")
                Console.ForegroundColor = ConsoleColor.White
                For j = 0 To 8
                    If vis(i, j) = 1 Then
                        If board(i, j) = "*" Then
                            Console.ForegroundColor = ConsoleColor.DarkGray
                        Else

                            Select Case numbers(i, j)
                                Case 1
                                    Console.ForegroundColor = ConsoleColor.Blue
                                Case 2
                                    Console.ForegroundColor = ConsoleColor.Green
                                Case 3
                                    Console.ForegroundColor = ConsoleColor.Red
                                Case 4
                                    Console.ForegroundColor = ConsoleColor.DarkBlue
                                Case 5
                                    Console.ForegroundColor = ConsoleColor.DarkRed
                                Case 6
                                    Console.ForegroundColor = ConsoleColor.Cyan
                                Case 7
                                    Console.ForegroundColor = ConsoleColor.Red
                            End Select
                        End If
                    End If
                        Console.Write($"{board(i, j)} ")
                    Console.ForegroundColor = ConsoleColor.White
                Next
                Console.WriteLine()
            Next
        End Sub

        Public Function onMine(ByVal y As Integer, x As Integer)
            If bombs(y, x) = 1 Then
                For i = 0 To 8
                    For j = 0 To 8
                        If bombs(i, j) = 1 Then
                            board(i, j) = "*"
                        End If
                    Next
                Next
                Return True
            End If
            Return False
        End Function

        Public Sub Flag(ByVal y As Integer, x As Integer)
            If flags(y, x) = "F" Then
                flags(y, x) = "#"
            Else
                flags(y, x) = "F"
            End If

            board(y, x) = flags(y, x)
        End Sub

        Public Function Reveal(ByVal y As Integer, x As Integer)

            If vis(y, x) <> 1 Then
                    vis(y, x) = 1

                If numbers(y, x) = 0 Then
                    board(y, x) = CStr(numbers(y, x))
                    If y > 0 Then
                        Reveal(y - 1, x)
                    End If
                    If y < 8 Then
                        Reveal(y + 1, x)
                    End If
                    If x > 0 Then
                        Reveal(y, x - 1)
                    End If
                    If x < 8 Then
                        Reveal(y, x + 1)
                    End If
                    If y > 0 And x > 0 Then
                        Reveal(y - 1, x - 1)
                    End If
                    If y > 0 And x < 8 Then
                        Reveal(y - 1, x + 1)
                    End If
                    If y < 8 And x > 0 Then
                        Reveal(y + 1, x - 1)
                    End If
                    If y < 8 And x < 8 Then
                        Reveal(y + 1, x + 1)
                    End If
                End If
                If numbers(y, x) <> 0 Then
                        board(y, x) = CStr(numbers(y, x))
                    End If
                End If
                Return False
        End Function

        Public Sub EndGame()
            For i = 0 To 8
                For j = 0 To 8
                    If bombs(i, j) = 1 Then
                        board(i, j) = "*"
                    End If
                Next
            Next
            Display()
        End Sub

    End Class

End Module
