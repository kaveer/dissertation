Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class family_password_setting
    Inherits System.Web.UI.Page

    Dim Vcurrent_pswd As String
    Dim Vhash_current_password As String
    Dim Vnew_passwrd As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub family_password_setting_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub


    '################################################# HASH PASSWORD ALGORITHM ####################################################
    Private Sub hash_password_function()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_current_passwrd.Text)
            Vhash_current_password = hash
        End Using
    End Sub
    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()
        'GetMd5Hash
    End Function
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash
    '################################################# END OF HASH PASSWORD ALGORITHM ####################################################

    '############################################### UPDATE PASSWORD #####################################################################
    Private Sub btn_update_passrd_Click(sender As Object, e As EventArgs) Handles btn_update_passrd.Click
        If txtbx_current_passwrd.Text = "" Then
            lbl_validation.Text = "enter current password"
        ElseIf txtbx_new_password.Text = "" Then
            lbl_validation.Text = "enter new password"
        ElseIf txtbx_confirm_passwrd.Text = "" Then
            lbl_validation.Text = "enter password again"
        ElseIf validation_confirm_password.IsValid = True Then
            hash_password_function()
            Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql2 = "select * from user_tbl where family_id = @familyID and user_password = @curPswd  "
            Dim sqlCmd2 As New SqlCommand(sql2, con2)
            sqlCmd2.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd2.Parameters.AddWithValue("@curPswd", Vhash_current_password)
            con2.Open()
            Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
            If reader2.Read() = True Then
                hash_new_passwrd()
                update_new_passwrd()
                con2.Close()
                lbl_validation.Text = "password updated"
            ElseIf reader2.Read() = False Then
                lbl_validation.Text = "incorrect password try again"
            End If
        End If
    End Sub
    Private Sub hash_new_passwrd()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_new_password.Text)
            Vnew_passwrd = hash
        End Using
    End Sub
    Private Sub update_new_passwrd()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update user_tbl set user_password = @newPswd where family_id = @familyID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd1.Parameters.AddWithValue("@newPswd", Vnew_passwrd)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '############################################### END OF UPDATE PASSWORD #####################################################################
End Class