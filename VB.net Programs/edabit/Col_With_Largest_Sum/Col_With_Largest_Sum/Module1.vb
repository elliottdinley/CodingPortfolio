Module Module1

    Sub Main()
        Dim biggest As Integer = 0
        Dim sum As Integer = 0

        Console.Write("Enter numbers >")
        Dim num() As String = Console.ReadLine.Split(", ")

        Console.Write("Enter number of rows >")
        Dim num_of_rows As Integer = CInt(Console.ReadLine)

        Dim polybius(Math.Ceiling(num.Length / num_of_rows) - 1, num_of_rows - 1) As Integer

        For i = 0 To num.Length - 1
            polybius(i \ Math.Ceiling(num.Length / num_of_rows) - 1, i Mod num_of_rows) = num(i)
        Next

        For col = 0 To Math.Ceiling(num.Length / num_of_rows) - 1
            sum = 0
            For row = 0 To num_of_rows - 1
                sum += polybius(col, row)
            Next
            If sum > biggest Then
                biggest = sum
            End If
        Next

        Console.WriteLine(biggest)
        Console.ReadLine()
    End Sub

End Module
