Module Module1

    Sub Find_Anagrams(ByVal str As String, ByVal find As String)
        Dim find_list As New List(Of Char)
        Dim temp As String = ""
        Dim output As String = ""
        For i = 0 To str.Length - find.Length
            temp = ""
            For j = 0 To find.Length - 1
                If Not find_list.Contains(find(j)) Then
                    find_list.Add(find(j))
                End If
                temp &= str(j + i)
            Next
            For j = 0 To find.Length - 1
                If find_list.Contains(temp(j)) Then
                    find_list.Remove(temp(j))
                End If
            Next
            If find_list.Count = 0 Then
                output &= temp & " "
            End If
        Next
        Console.WriteLine(output)
    End Sub

    Sub Main()
        Dim input As String
        Dim find_input As String
        input = Console.ReadLine
        find_input = Console.ReadLine
        Find_Anagrams(input, find_input)

        Console.ReadLine()
    End Sub

End Module
