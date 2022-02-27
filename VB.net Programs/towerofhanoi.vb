Module Module1

    Sub Main()
        Dim _from, _to As Integer

        Dim toh As Game
        toh = New Game

        Do
            toh.Display()
            If toh.Check Then
                Exit Do
            End If
            Console.Write("From >")
            _from = Console.ReadLine()
            Console.Write("To >")
            _to = Console.ReadLine
            toh.Move(_from, _to)
        Loop
        Console.WriteLine("Complete!")
        Console.ReadKey()
    End Sub

    Class Game
        Private Tower1, Tower2, Tower3 As New List(Of Integer)

        Public Sub New()
            Tower1.Add(3)
            Tower1.Add(2)
            Tower1.Add(1)
        End Sub

        Public Sub Display()
            Console.Clear()
            Console.WriteLine("Tower 1:")
            For i = Tower1.Count - 1 To 0 Step -1
                For ii = 1 To Tower1(i)
                    Console.Write("#")
                Next
                Console.WriteLine()
            Next
            Console.WriteLine(vbNewLine & "Tower 2:")
            For i = Tower2.Count - 1 To 0 Step -1
                For ii = 1 To Tower2(i)
                    Console.Write("#")
                Next
                Console.WriteLine()
            Next
            Console.WriteLine(vbNewLine & "Tower 3:")
            For i = Tower3.Count - 1 To 0 Step -1
                For ii = 1 To Tower3(i)
                    Console.Write("#")
                Next
                Console.WriteLine()
            Next
            Console.WriteLine()
        End Sub

        Public Sub Move(ByVal source As Integer, destination As Integer)
            Dim tailNo As Integer
            Dim temp As Integer
            Select Case source
                Case 1
                    tailNo = Tower1.Count - 1
                    temp = Tower1(tailNo)
                    Tower1.RemoveAt(tailNo)
                Case 2
                    tailNo = Tower2.Count - 1
                    temp = Tower2(tailNo)
                    Tower2.RemoveAt(tailNo)
                Case 3
                    tailNo = Tower3.Count - 1
                    temp = Tower3(tailNo)
                    Tower3.RemoveAt(tailNo)
            End Select
            Select Case destination
                Case 1
                    Tower1.Add(temp)
                Case 2
                    Tower2.Add(temp)
                Case 3
                    Tower3.Add(temp)
            End Select
        End Sub

        Public Function Check()
            Try
                If Tower3(2) = "1" And Tower3(1) = "2" And Tower3(0) = "3" Then
                    Return True
                End If
                If Tower2(2) = "1" And Tower2(1) = "2" And Tower2(0) = "3" Then
                    Return True
                End If
            Catch
                Return False
            End Try
            Return False
        End Function
    End Class

End Module
