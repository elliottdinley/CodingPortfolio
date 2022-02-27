Imports System.IO
Module Module1
    Dim path As String
    Sub Main()
        Dim speed As Integer
        Dim usefiles As String
        path = "C:\Users\ellio\Documents\conway\conway.txt"
        Dim sizex, sizey As Integer
        Dim gol As gol

        Console.WriteLine("Use file [y/n] >")
        usefiles = Console.ReadLine


        If usefiles <> "y" Then
            Console.WriteLine("Enter size x >")
            sizex = Console.ReadLine
            Console.WriteLine("Enter size y >")
            sizey = Console.ReadLine
            Console.WriteLine("Tick speed (ms)>")
            speed = Console.ReadLine
            gol = New gol(sizex, sizey)
            gol.SetUp(False)
        Else
            Console.WriteLine("Set up file [y/n] >")
            If Console.ReadLine = "y" Then
                Console.WriteLine("Enter size x >")
                sizex = Console.ReadLine
                Console.WriteLine("Enter size y >")
                sizey = Console.ReadLine

                Dim file As StreamWriter
                file = New StreamWriter(path)

                For i = 0 To sizey
                    For j = 0 To sizex
                        file.Write("0")
                    Next
                    file.WriteLine()
                Next

                file.Close()
                End

            End If
            Console.WriteLine("Tick speed (ms)>")
            speed = Console.ReadLine
            Dim lines() As String = File.ReadAllLines(path).ToArray
            Console.WriteLine($"lines:{File.ReadAllLines(path).Length} chars:{lines(0).Length}")
            Console.ReadKey()

            gol = New gol(lines(0).Length - 1, File.ReadAllLines(path).Length - 1)
            gol.SetUp(True)
        End If

        Do
            gol.Display()

            gol.Tick()

            System.Threading.Thread.Sleep(speed)
        Loop
    End Sub

    Class gol
        Private sizex, sizey As Integer
        Private grid As Char(,)
        Private add As Integer(,)

        Public Sub New(ByVal sizex As Integer, ByVal sizey As Integer)
            Me.sizex = sizex
            Me.sizey = sizey
            grid = New Char(sizey, sizex) {}
            add = New Integer(sizey, sizex) {}
        End Sub

        Public Sub SetUp(ByVal usefile As Boolean)
            Dim lines As String() = File.ReadAllLines("C:\Users\ellio\Documents\conway\conway.txt")
            Dim x As String
            Dim y As Integer
            If usefile = False Then
                Do
                    Display()
                    Console.Write("Enter x ['x' to exit, 'p' for preset] >")
                    x = Console.ReadLine
                    If x = "x" Then
                        Exit Do
                    Else
                        If x = "p" Then

                            Display()
                            Console.ReadKey()
                            Exit Do
                        End If
                    End If
                    Console.Write("Enter y >")
                    y = Console.ReadLine
                    Console.WriteLine($"   Pixel added at ({x}, {y})")
                    grid(y, CInt(x)) = "1"
                Loop
            Else
                For i = 0 To sizey
                    For j = 0 To sizex
                        If lines(i)(j) = "1" Then
                            grid(i, j) = "1"
                        End If
                    Next
                Next
                Display()
            End If
        End Sub

        Public Sub Display()
            Console.Clear()

            For i = 0 To sizey
                For j = 0 To sizex
                    If grid(i, j) = "1" Then
                        Console.Write("██")
                    Else
                        Console.Write("▒▒")
                    End If

                Next
                Console.WriteLine()
            Next
        End Sub

        Public Sub Tick()
            Dim neighbours As Integer
            Dim dead(sizey, sizex) As Integer

            For i = 0 To sizey
                For j = 0 To sizex
                    dead(i, j) = Nothing
                    add(i, j) = Nothing
                Next
            Next

            For i = 0 To sizey
                For j = 0 To sizex
                    neighbours = 0
                    For k = (i - 1) To (i + 1)
                        For l = (j - 1) To (j + 1)

                            If k >= 0 And l >= 0 And k <= sizey And l <= sizex Then
                                If grid(k, l) = "1" Then
                                    neighbours += 1
                                End If
                            End If

                        Next
                    Next


                    If grid(i, j) = "1" Then
                        neighbours -= 1
                        Select Case neighbours
                            Case < 2
                                dead(i, j) = "1"
                            Case > 3
                                dead(i, j) = "1"
                        End Select
                    Else
                        If neighbours = 3 Then
                            add(i, j) = "1"
                        End If

                    End If
                Next
            Next
            For i = 0 To sizey
                For j = 0 To sizex
                    If dead(i, j) = "1" Then
                        grid(i, j) = " "
                    End If
                    If add(i, j) = "1" Then
                        grid(i, j) = "1"
                    End If
                Next
            Next
        End Sub

    End Class

End Module
