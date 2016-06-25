Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail

Public Class member_online_activation
    Inherits System.Web.UI.Page

    Dim Vsecret_code As String
    Shared random As New Random()
    Dim Vresent_secret_code As String
    Dim Vhashed_resent_scret_code As String
    Dim Vpassword_offline As String
    Dim Vnew_password As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '############################################## THEME SETUP ############################################################################
    Private Sub member_online_activation_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################## END OF THEME SETUP ############################################################################

    '############################################### CHECK ACTIVATION CODE #################################################################
    Private Sub btn_activation_code_Click(sender As Object, e As EventArgs) Handles btn_activation_code.Click
        If txtbx_activation_code.Text = "" Then
            lbl_validation_view1.Text = "enter activation code"
        Else
            hash_password_function()
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select * from family_tbl where family_id = @famID and secret_code = @secretCode"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@secretCode", Vsecret_code)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                MultiView1.ActiveViewIndex = 2
                con.Close()
            ElseIf reader.Read() = False Then
                lbl_validation_view1.Text = "Wrong secret code"
            End If
        End If
    End Sub
    '############################################### END OF CHECK ACTIVATION CODE #################################################################

    '################################################# HASH PASSWORD ALGORITHM ####################################################
    Private Sub hash_password_function()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_activation_code.Text)
            Vsecret_code = hash
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

    '################################################## RESENT ACTIVATION CODE ############################################################
    Private Sub btn_resent_code_Click(sender As Object, e As EventArgs) Handles btn_resent_code.Click
        If txtbx_resent_code.Text = "" Then
            lbl_validation_view1.Text = "Enter mail"
        ElseIf validation_mail.IsValid = True Then
            checkConnection()
        End If
    End Sub
    Private Sub hash_resent_code()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, Vresent_secret_code)
            Vhashed_resent_scret_code = hash
        End Using
    End Sub
    '################################################## RESENT ACTIVATION CODE ############################################################

    '##################################################### UPDATE USER ACTIVATION CODE ####################################################
    Private Sub update_family_activation_code()
        Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql4 = "update family_tbl set  secret_code = @code where family_id = @famID"
        Dim sqlCmd4 As New SqlCommand(sql4, con4)
        sqlCmd4.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        sqlCmd4.Parameters.AddWithValue("@code", Vhashed_resent_scret_code)
        con4.Open()
        sqlCmd4.ExecuteNonQuery()
        con4.Close()
    End Sub
    '##################################################### END OF UPDATE USER ACTIVATION CODE ####################################################

    '#################################################### SENT MAIL FUNCTION ############################################################
    Private Sub checkConnection()
        Dim client As New WebClient()
        Dim datasize As Byte() = Nothing
        Try
            datasize = client.DownloadData("http://www.google.com")
        Catch ex As Exception
        End Try
        If datasize IsNot Nothing AndAlso datasize.Length > 0 Then
            Vresent_secret_code = Convert.ToString(Random.Next(1, 10000))
            hash_resent_code()
            update_family_activation_code()
            sentmail()
        Else
            lbl_validation_view1.Text = "no internet"
        End If
    End Sub
    Private Sub sentmail()
        Dim mm As New MailMessage("kaveer.rajcoomar@gmail.com", txtbx_resent_code.Text)
        mm.Subject = "HomeMaster activation code"
        Dim body As String = "Dear user"
        body += "<br />you have resently ask to resent your activtion code via your email "
        body += "<br /> use the following activation code to activate your account at HomeMaster website "
        body += "<br />Username is :" + Session("user")
        body += "<br />Activation code is :" + Vresent_secret_code
        body += "<br /><br />Thanks you "
        body += "<br />regards "
        body += "<br />HomeMaster team "
        mm.Body = body
        mm.IsBodyHtml = True
        Dim smtp As New SmtpClient()
        smtp.Host = "smtp.gmail.com"
        smtp.EnableSsl = True
        Dim NetworkCred As New NetworkCredential("kaveer.rajcoomar@gmail.com", "kaveer30sep1991")
        smtp.UseDefaultCredentials = True
        smtp.Credentials = NetworkCred
        smtp.Port = 587
        smtp.Send(mm)
        lbl_validation_view1.Text = "mail sent"
    End Sub
    '#################################################### END OF SENT MAIL FUNCTION ######################################################

    '#################################################### NAVIGATION ##################################################################
    Private Sub btn_offline_activation_Click(sender As Object, e As EventArgs) Handles btn_offline_activation.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    '#################################################### END OF NAVIGATION ##################################################################

    '##################################################### OFFLINE ACTIVATION ################################################################
    Private Sub btn_view_offfline_activation_Click(sender As Object, e As EventArgs) Handles btn_view_offfline_activation.Click
        If txtbx_offline_username.Text = "" Then
            lbl_validation_view2.Text = "Enter username"
        ElseIf txtbx_offline_username.Text <> Session("user") Then
            lbl_validation_view2.Text = "username does not match this account"
        ElseIf txtbx_offline_email.Text = "" Then
            lbl_validation_view2.Text = "Enter email"
        ElseIf txtbx_offline_password.Text = "" Then
            lbl_validation_view2.Text = "Enter password"
        ElseIf validation_offline_mail.IsValid = True Then
            hash_password_offline_activation()
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select * from user_tbl u inner join family_tbl as f on f.family_id = u.family_id inner join email_tbl as e on f.family_id = e.family_id where username = @user and email_address = @email and user_password = @pswd and f.family_id = @famID"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@user", txtbx_offline_username.Text)
            sqlCmd.Parameters.AddWithValue("@email", txtbx_offline_email.Text)
            sqlCmd.Parameters.AddWithValue("@pswd", Vpassword_offline)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                MultiView1.ActiveViewIndex = 2
                con.Close()
            ElseIf reader.Read() = False Then
                lbl_validation_view2.Text = "account not match data entered"
            End If
        End If
    End Sub
    Private Sub hash_password_offline_activation()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_offline_password.Text)
            Vpassword_offline = hash
        End Using
    End Sub
    '##################################################### END OF OFFLINE ACTIVATION ################################################################

    '#################################################### CHANGE PASSWORD FUNCTION ################################################################
    Private Sub btn_change_password_Click(sender As Object, e As EventArgs) Handles btn_change_password.Click
        If txtbx_new_password.Text = "" Then
            lbl_validation_view3.Text = "Enter new password"
        ElseIf txtbx_confirm_passwrd.Text = "" Then
            lbl_validation_view3.Text = "Enter password to confirm"
        ElseIf validation_compare_passwrod.IsValid = True Then
            hash_change_password()
            Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql4 = "update user_tbl set user_password = @passwrd where family_id = @famID "
            Dim sqlCmd4 As New SqlCommand(sql4, con4)
            sqlCmd4.Parameters.AddWithValue("@passwrd", Vnew_password)
            sqlCmd4.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con4.Open()
            sqlCmd4.ExecuteNonQuery()
            con4.Close()
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub hash_change_password()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_new_password.Text)
            Vnew_password = hash
        End Using
    End Sub
    '#################################################### END OF CHANGE PASSWORD FUNCTION ################################################################

    '################################################### ANSWER QUESTION AND ACTIVATE ACCOUNT ############################################################
    Private Sub btn_activate_acct_Click(sender As Object, e As EventArgs) Handles btn_activate_acct.Click
        If txtbx_answer.Text = "" Then
            lbl_validation_view4.Text = "enter answer to selected question"
        Else
            Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql4 = "update family_tbl set question_verif =  @ques , answer_verif = @answer  where family_id = @famID "
            Dim sqlCmd4 As New SqlCommand(sql4, con4)
            sqlCmd4.Parameters.AddWithValue("@answer", txtbx_answer.Text)
            sqlCmd4.Parameters.AddWithValue("@ques", ddl_question.SelectedItem.Text)
            sqlCmd4.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con4.Open()
            sqlCmd4.ExecuteNonQuery()
            con4.Close()
            update_isactivate_status()
        End If
    End Sub
    Private Sub update_isactivate_status()
        Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql4 = "update family_tbl set is_activated = 'yes'  where family_id = @famID "
        Dim sqlCmd4 As New SqlCommand(sql4, con4)
        sqlCmd4.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        con4.Open()
        sqlCmd4.ExecuteNonQuery()
        con4.Close()
        Response.Redirect("./member_home_form.aspx")
    End Sub
    '################################################### END OF ANSWER QUESTION AND ACTIVATE ACCOUNT ############################################################
End Class