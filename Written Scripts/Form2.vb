Public Class Form2

    Inherits System.Windows.Forms.Form
    Public myCaller As Form1

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
        Dim setting As New My.MySettings()
        If TextBox1.Text = "SDPass" And TextBox2.Text = setting.pass Then
            Form1.Show()
        Else
            MsgBox("Incorrect Credentials")
        End If
    End Sub

    Private Sub LineShape3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineShape3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class