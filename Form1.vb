Public Class Form1
    'Declaring the variables so that it can be accessed by all methods in the class
    Private savedUsername As String = ""
    Private savedPassword As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When the form is loaded, populate the username and password textboxes with the saved username and password  
        If Not String.IsNullOrEmpty(savedUsername) Then
            UsernameTextBox.Text = savedUsername
            PasswordTextBox.Text = savedPassword
            radioRemember.Checked = True
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text
        Dim remember As Boolean = radioRemember.Checked

        'Check if username and password are valid
        If username = "" Or password = "" Then
            MessageBox.Show("Please enter a username and password", "Error")
        ElseIf username = "admin" AndAlso password = "password123" Then
            If radioRemember.Checked Then
                savedUsername = ""
                savedPassword = ""
            Else
                savedUsername = username
                savedPassword = password

            End If

            'Show a success message and close the form
            MessageBox.Show("Login successful!", "Success")
            Me.Close()
        Else
            'Show an error message if the username or password is incorrect
            MessageBox.Show("Invalid username or password", "Error")
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Uncheck and clear the textbox and radio button
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        radioRemember.Checked = False
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Close the application
        Me.Close()
    End Sub

    Private Sub UsernameTextBox_KeyPresst(sender As Object, e As KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        'Only allow letters and numbers to be typed in the username textbox  
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub PasswordTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        'Only allow letters and numbers to be typed in the password textbox
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        PasswordTextBox.UseSystemPasswordChar = True

    End Sub
    Private Sub radioRemember_CheckedChanged(sender As Object, e As EventArgs) Handles radioRemember.CheckedChanged
        'Show a message if the rememberme button is clicked
        If radioRemember.Checked Then
            MessageBox.Show("Your login details will be saved", "Remember Me")
        End If
    End Sub

End Class
