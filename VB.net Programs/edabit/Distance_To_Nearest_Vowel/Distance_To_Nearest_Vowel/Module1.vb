Module Module1

    Sub Main()
        Dim raw As String
        Console.WriteLine("Enter string:")
        raw = Console.ReadLine.ToLower
        disttovowel(raw)
        Console.ReadLine()
    End Sub

    Sub disttovowel(str As String)
        Dim vowel() As Char = {"a", "e", "i", "o", "u"}
        Dim smallest As Integer
        Dim count As Integer
        Dim found As Boolean
        For i = 0 To str.Length - 1
            found = False
            count = 0
            For j = i To str.Length - 1
                If vowel.Contains(str(j)) Then
                    If Not found Then
                        smallest = count
                        found = True
                    End If
                End If
                    count += 1
            Next
            count = 0
            For j = i To 0 Step -1
                If vowel.Contains(str(j)) Then
                    If smallest > count Or found = False Then
                        smallest = count
                        found = True
                    End If
                End If
                count += 1
            Next
            Console.WriteLine(smallest)
        Next
    End Sub

End Module
