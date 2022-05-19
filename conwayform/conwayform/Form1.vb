Public Class Form1
    Dim Height As Integer
    Dim Width As Integer
    Dim Grid(,) As Integer
    Dim Add(,) As Integer
    Dim Scale As Integer
    Dim Timer1 As New Timer()

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Draw_Grid_Lines()
    End Sub

    Private Sub Draw_Grid_Lines()
        Dim g As Graphics = CreateGraphics()
        Dim pen As New Pen(Color.Black, 1)
        For x = 0 To 400 Step Scale
            g.DrawLine(pen, x, 0, x, 400)
        Next
        For y = 0 To 400 Step Scale
            g.DrawLine(pen, 0, y, 400, y)
        Next
    End Sub

    Private Sub Draw_Cell(x, y)
        Dim g As Graphics = CreateGraphics()
        Dim blackcell As New SolidBrush(Color.Black)
        Dim whitecell As New SolidBrush(SystemColors.Control)
        If Grid(y, x) = 1 Then
            g.FillRectangle(blackcell, x * Scale, y * Scale, Scale, Scale)
        Else
            g.FillRectangle(whitecell, x * Scale, y * Scale, Scale, Scale)
        End If
        Draw_Grid_Lines()
    End Sub

    Private Sub Draw_All_Cells()
        Dim g As Graphics = CreateGraphics()
        Dim blackcell As New SolidBrush(Color.Black)
        Dim whitecell As New SolidBrush(SystemColors.Control)
        For y = 0 To Height - 1
            For x = 0 To Width - 1
                If Grid(y, x) = 1 Then
                    g.FillRectangle(blackcell, x * Scale, y * Scale, Scale, Scale)
                Else
                    g.FillRectangle(whitecell, x * Scale, y * Scale, Scale, Scale)
                End If
            Next
        Next

        Draw_Grid_Lines()
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim GridX As Integer = e.X \ Scale
        Dim GridY As Integer = e.Y \ Scale
        If e.X <= 400 Then
            If Grid(GridY, GridX) = 1 Then
                Grid(GridY, GridX) = 0
            Else
                Grid(GridY, GridX) = 1
            End If
            Draw_Cell(GridX, GridY)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Scale = 20
        Height = 40
        Width = 40
        ReDim Grid(Height - 1, Width - 1)
        ReDim Add(Height - 1, Width - 1)
        AddHandler Timer1.Tick, AddressOf Next_Frame
        Timer1.Interval = 1000
    End Sub

    Private Sub Next_Frame()
        Dim Neighbours As Integer
        Dim Dead(Height, Width) As Integer

        For i = 0 To Height - 1
            For j = 0 To Width - 1
                Dead(i, j) = Nothing
                Add(i, j) = Nothing
            Next
        Next

        For i = 0 To Height - 1
            For j = 0 To Width - 1
                Neighbours = 0
                For k = (i - 1) To (i + 1)
                    For l = (j - 1) To (j + 1)

                        If k >= 0 And l >= 0 And k <= Height - 1 And l <= Width - 1 Then
                            If Grid(k, l) = "1" Then
                                Neighbours += 1
                            End If
                        End If

                    Next
                Next

                If Grid(i, j) = "1" Then
                    Neighbours -= 1
                    Select Case Neighbours
                        Case < 2
                            Dead(i, j) = "1"
                        Case > 3
                            Dead(i, j) = "1"
                    End Select
                Else
                    If Neighbours = 3 Then
                        Add(i, j) = "1"
                    End If

                End If
            Next
        Next
        For i = 0 To Height - 1
            For j = 0 To Width - 1
                If Dead(i, j) = "1" Then
                    Grid(i, j) = "0"
                End If
                If Add(i, j) = "1" Then
                    Grid(i, j) = "1"
                End If
            Next
        Next

        Draw_All_Cells()
    End Sub

    Private Sub CMDNext_Click(sender As Object, e As EventArgs) Handles CMDNext.Click
        Next_Frame()
    End Sub

    Private Sub CMDClear_Click(sender As Object, e As EventArgs) Handles CMDClear.Click
        For Row = 0 To Height - 1
            For Col = 0 To Width - 1
                Grid(Row, Col) = 0
            Next
        Next
        Draw_All_Cells()
    End Sub

    Private Sub CBXAuto_CheckedChanged(sender As Object, e As EventArgs) Handles CBXAuto.CheckedChanged
        If CBXAuto.Checked = True Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

End Class