Imports System.Security.Cryptography
Imports System.Data.SqlClient

Public Class member_deactivate_account
    Inherits System.Web.UI.Page

    Dim VhashPswrd As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_display_user.Text = Session("user")
    End Sub


    '################################### THEME SETUP #############################################################################
    Private Sub member_deactivate_account_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #######################################################################

    Private Sub btn_confirm_deactivation_Click(sender As Object, e As EventArgs) Handles btn_confirm_deactivation.Click
        MultiView1.ActiveViewIndex = 1
    End Sub

    '################################################# HASH PASSWORD ALGORITHM ####################################################
    Private Sub hash_password_function()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_enter_password.Text)
            VhashPswrd = hash
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

    Private Sub btn_deactivate_Click(sender As Object, e As EventArgs) Handles btn_deactivate.Click
        If txtbx_enter_password.Text = "" Then
            lbl_validation.Text = "enter password"
        Else
            hash_password_function()
            Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql2 = "select * from user_tbl where family_id = @familyID and user_password = @curPswd  "
            Dim sqlCmd2 As New SqlCommand(sql2, con2)
            sqlCmd2.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd2.Parameters.AddWithValue("@curPswd", VhashPswrd)
            con2.Open()
            Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
            If reader2.Read() = True Then
                update_acct_status()
                con2.Close()
                Response.Redirect("./Default.aspx")
            ElseIf reader2.Read() = False Then
                lbl_validation.Text = "incorrect password try again"
            End If
        End If
    End Sub
    Private Sub update_acct_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update family_tbl set family_status = 'deactive' where family_id = @familyID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
End Class