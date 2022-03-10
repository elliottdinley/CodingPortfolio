Imports System.IO
Module Module1

    Sub Main()
        Dim wordle As New wordle
        Dim guess As String
        wordle.GenerateWord()

        guess = ""

        Do
            wordle.DisplayGrid()
            If wordle.GameOver(guess) = 1 Then
                Console.WriteLine($"The word was {wordle.word}")
                Exit Do
            Else
                If wordle.GameOver(guess) = 2 Then
                    Console.WriteLine("Correct!")
                    Exit Do
                End If
            End If
            guess = Console.ReadLine().ToUpper
            wordle.Guess(guess)
        Loop
        Console.ReadLine()
    End Sub

    Class wordle
        Private grid(6, 4) As Char
        Private ind(6, 4) As Integer '1-green, 2-yellow
        Private guessno As Integer = 1
        Private solpath As String = "C:\Users\ellio\Documents\solutions_wordle.txt"
        Private allpath As String = "C:\Users\ellio\Documents\allowed_wordle.txt"
        Private solutions() As String = File.ReadAllLines(solpath).ToArray
        Private allowed() As String = File.ReadAllLines(allpath).ToArray
        Public word As String

        Public Sub GenerateWord()
            Randomize()
            word = solutions(Int(Rnd() * solutions.Length)).ToUpper
            For i = 0 To 4
                Me.grid(0, i) = word(i)
            Next
        End Sub

        Public Sub DisplayGrid()
            Console.Clear()

            For i = 1 To 6
                If grid(i, 0) <> Nothing Then

                    For j = 0 To 4
                        If ind(i, j) = 1 Then
                            Console.BackgroundColor = ConsoleColor.Green
                        Else
                            If ind(i, j) = 2 Then
                                Console.BackgroundColor = ConsoleColor.DarkYellow
                            End If
                        End If
                        Console.Write(Me.grid(i, j))
                        Console.ResetColor()
                    Next
                    Console.WriteLine()
                End If
            Next
        End Sub

        Public Sub Guess(ByVal guess As String)
            If allowed.Contains(guess.ToLower) Or solutions.Contains(guess.ToLower) Then
                For i = 0 To 4
                    Me.grid(guessno, i) = guess(i)
                    If guess(i) = word(i) Then
                        Me.ind(guessno, i) = 1
                    Else
                        If word.Contains(guess(i)) Then
                            Me.ind(guessno, i) = 2
                        End If
                    End If
                Next
                guessno += 1
            End If
        End Sub

        Public Function GameOver(ByVal guess As String)
            If guess = Me.word Then
                Return 2
            Else
                If guessno = 7 Then
                    Return 1
                End If
            End If
            Return False
        End Function


    End Class

End Module
