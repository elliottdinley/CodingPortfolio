Module Module1

    Function Farey(count As Integer) As List(Of (Integer, Integer))
        Dim seq As New List(Of (Integer, Integer))
        Dim counter As Integer
        For d = 1 To count - 1
            For n = 0 To d
                If Not seq.Contains((n, d)) Then
                    counter = 0
                    If seq.Count = 0 Then
                        seq.Add((n, d))
                    Else
                        Do While counter < seq.Count And (n / d) > (seq(counter).Item1 / seq(counter).Item2)
                            counter += 1
                        Loop

                        seq.Insert(counter, (n, d))
                    End If

                End If
            Next
        Next
        Return seq
    End Function

    Sub Main()
        For Each fraction In Farey(Console.ReadLine)
            Console.WriteLine(fraction.Item1 & "/" & fraction.Item2)
        Next
        Console.ReadLine()
    End Sub

End Module
