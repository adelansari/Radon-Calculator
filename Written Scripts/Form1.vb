Public Class Form1

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form2.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim about As String
        Dim spacee As String
        Dim about2 As String
        Dim Credit As String

        about = "Radon Health Risk Information"
        spacee = ""
        about2 = "Radon is the second leading cause of lung cancer after smoking. The U.S. Environmental Protection Agency (EPA) and the Surgeon General strongly recommend that further action be taken when a home’s radon test results are 148 Bq/m³ or greater. The national average indoor radon level is about 48.1 Bq/m³. The higher the home’s radon level, the greater the health risk to you and your family. Reducing your radon levels can be done easily, effectively and fairly inexpensively. Even homes with very high radon levels can be reduced below 148 Bq/m³. Please refer to the EPA web site at www.epa.gov/radon for further information to assist you in evaluating your test results or deciding if further action is needed."
        Credit = "Developed by: Adel Ansari, Ahmed Ishag, Ahmed Aljassmi and Owais Anas"

        MsgBox(about & vbCrLf & vbCrLf & about2 & vbCrLf & vbCrLf & vbCrLf & Credit)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim tbx = {TextBox1, TextBox7, TextBox8, TextBox9, TextBox10, TextBox11, TextBox12}
        For Each tb In tbx
            If tb.Text = "" Then
                MsgBox("All Fields Are Required", MsgBoxStyle.Information)
                Exit Sub
            ElseIf tb.Text.Contains(" "c) Then
                MsgBox("Spaces not allowed", MsgBoxStyle.Information)
                Exit Sub
            ElseIf Val(tb.Text) < 0 Then
                MsgBox("All values must be positive.", MsgBoxStyle.Information)
                Exit Sub
            ElseIf Val(TextBox9.Text) > 23 Or Val(TextBox12.Text) > 23 Then
                MsgBox("The timestamps must be in 24 hour format.", MsgBoxStyle.Information)
                TextBox14.Text = "..."
                TextBox13.Text = "..."
                Exit Sub
            ElseIf Val(TextBox8.Text) > 59 Or Val(TextBox11.Text) > 59 Then
                MsgBox("The timestamps must be a period of time of 60 minutes.", MsgBoxStyle.Information)
                TextBox14.Text = "..."
                TextBox13.Text = "..."
                Exit Sub
            ElseIf Not IsNumeric(tb.Text) Then
                MsgBox("The input entered is not a numeric value.", MsgBoxStyle.Information)
                Return
            End If
            TextBox14.Text = "..."
            TextBox13.Text = "..."
        Next

        Dim A, B, CF, MRV, G, BG, Radon, InitialVolt, FinalVolt, time1, time2, durationx As Double
        Dim date1, date2 As Date
        Dim duration As TimeSpan

        time1 = TextBox9.Text + ((TextBox8.Text) / 60)
        time2 = TextBox12.Text + ((TextBox11.Text) / 60)

        date1 = Convert.ToDateTime(DateTimePicker1.Value).AddHours(time1)
        date2 = Convert.ToDateTime(DateTimePicker2.Value).AddHours(time2)
        duration = date2 - date1
        durationx = duration.TotalDays

        If ComboBox1.SelectedItem = "SST" Then
            A = 1.69776
            B = 0.0005742
            InitialVolt = Convert.ToDouble(TextBox7.Text)
            FinalVolt = Convert.ToDouble(TextBox10.Text)
            MRV = (InitialVolt + FinalVolt) / 2
            CF = A + (B * MRV)
            G = 0.087
        ElseIf ComboBox1.SelectedItem = "SLT" Then
            A = 0.14
            B = 0.0000525
            InitialVolt = Convert.ToDouble(TextBox7.Text)
            FinalVolt = Convert.ToDouble(TextBox10.Text)
            MRV = (InitialVolt + FinalVolt) / 2
            CF = A + (B * MRV)
            G = 0.087
        End If

        'BG = 6.2 uR/hr
        '1 Gy = 115 R
        BG = (Convert.ToDouble(TextBox1.Text)) * 0.115  'Converting nGy/hr to uR/hr

        Radon = ((((InitialVolt - FinalVolt) - (0.066667 * durationx)) / (CF * durationx)) - (BG * G)) * 37
        '37 is the conversion factor from pCi/L to Bq/m³

        TextBox14.Text = Convert.ToString(CF)
        TextBox13.Text = Convert.ToString(Radon)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub
End Class
