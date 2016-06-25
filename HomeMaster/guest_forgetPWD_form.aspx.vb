Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Imports System.Security.Cryptography

Public Class guest_forgetPWD_form
    Inherits System.Web.UI.Page

    Shared random As New Random()
    Shared Vfamily_id As Integer
    Shared Vsecret_code As String
    Shared Vusername As String
    Shared Vhashed_secret_code As String
    Shared Vhashed_verif_code As String
    Dim Vpassword As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '################################################ THEME SETUP ###########################################################################
    Private Sub guest_forgetPWD_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################################ END OF THEME SETUP ########################################################################

    '############################################ CHECK FOR DATA ENTERED ###############################################################################
    Private Sub btn_next_view_select_method_Click(sender As Object, e As EventArgs) Handles btn_next_view_select_method.Click
        If txtbx_enter_mail.Text = "" Then
            lbl_validation_view1.Text = "enter email address"
        ElseIf txtbx_answer.Text = "" Then
            lbl_validation_view1.Text = "enter answer to selected question"
        ElseIf validation_mail.IsValid = True Then
            If ddl_select_type.SelectedIndex = 0 And ddl_select_method.SelectedIndex = 0 Then
                password_online_function()
            ElseIf ddl_select_type.SelectedIndex = 0 And ddl_select_method.SelectedIndex = 1 Then
                password_offline_function()
            ElseIf ddl_select_type.SelectedIndex = 1 And ddl_select_method.SelectedIndex = 0 Then
                username_online()
            ElseIf ddl_select_type.SelectedIndex = 1 And ddl_select_method.SelectedIndex = 1 Then
                username_offline_function()
            End If
        End If
    End Sub
    '############################################ END OF CHECK FOR DATA ENTERED ###############################################################################

    '############################################ GET USERNAME OFFLINE #############################################################################
    Private Sub username_offline_function()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join email_tbl as e on e.family_id = f.family_id where email_address = @email and question_verif = @ques and answer_verif = @answer "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@email", txtbx_enter_mail.Text)
        sqlCmd.Parameters.AddWithValue("@ques", ddl_question.SelectedItem.Text)
        sqlCmd.Parameters.AddWithValue("@answer", txtbx_answer.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            lbl_offline_username_msg.Visible = True
            lbl_offline_username.Visible = True
            lbl_offline_username.Text = reader("username")
            con.Close()
        ElseIf reader.Read() = False Then
            lbl_offline_username_msg.Visible = False
            lbl_offline_username.Visible = False
            lbl_validation_view1.Text = "No user found"
        End If
    End Sub
    '############################################ END OF GET USERNAME OFFLINE #############################################################################

    '############################################ GET PASSWORD OFFLINE #################################################################################
    Private Sub password_offline_function()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join email_tbl as e on e.family_id = f.family_id where email_address = @email and question_verif = @ques and answer_verif = @answer "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@email", txtbx_enter_mail.Text)
        sqlCmd.Parameters.AddWithValue("@ques", ddl_question.SelectedItem.Text)
        sqlCmd.Parameters.AddWithValue("@answer", txtbx_answer.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vfamily_id = CInt(reader("family_id"))
            MultiView1.ActiveViewIndex = 1
        ElseIf reader.Read() = False Then
            lbl_offline_username_msg.Visible = False
            lbl_offline_username.Visible = False
            lbl_validation_view1.Text = "No user found"
        End If
    End Sub
    '############################################ END OF GET PASSWORD OFFLINE #################################################################################

    '################################################## GET PASSWORD ONLINE ################################################################################
    Private Sub password_online_function()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join email_tbl as e on e.family_id = f.family_id where email_address = @email and question_verif = @ques and answer_verif = @answer "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@email", txtbx_enter_mail.Text)
        sqlCmd.Parameters.AddWithValue("@ques", ddl_question.SelectedItem.Text)
        sqlCmd.Parameters.AddWithValue("@answer", txtbx_answer.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vfamily_id = CInt(reader("family_id"))
            Vusername = reader("username")
            checkConnection()
            MultiView1.ActiveViewIndex = 2
        ElseIf reader.Read() = False Then
            lbl_offline_username_msg.Visible = False
            lbl_offline_username.Visible = False
            lbl_validation_view1.Text = "No user found"
        End If
    End Sub
    Private Sub checkConnection()
        Dim client As New WebClient()
        Dim datasize As Byte() = Nothing
        Try
            datasize = client.DownloadData("http://www.google.com")
        Catch ex As Exception
        End Try
        If datasize IsNot Nothing AndAlso datasize.Length > 0 Then
            Vsecret_code = Convert.ToString(random.Next(1, 10000))
            hashed_secret_code()
            update_family_activation_code()
            sentmail()
        Else
            lbl_validation_view1.Text = "no internet"
        End If
    End Sub
    Private Sub sentmail()
        Dim mm As New MailMessage("kaveer.rajcoomar@gmail.com", txtbx_enter_mail.Text)
        mm.Subject = "HomeMaster activation code"
        Dim body As String = "Dear user"
        body += "<br />you have resently ask to resent your activtion code via your email "
        body += "<br /> use the following activation code to activate your account at HomeMaster website "
        body += "<br />Username is :" + Vusername
        body += "<br />Activation code is :" + Vsecret_code
        body += "<br /><br />Thanks you "
        body += "<br />regards "
        body += "<br />HomeMaster team "
        body += "<br /><br />FIMID" + CStr(Vfamily_id)
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
        lbl_validation_view33.Text = "mail sent check for validation code"
    End Sub
    Private Sub hashed_secret_code()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, Vsecret_code)
            Vhashed_secret_code = hash
        End Using
    End Sub
    Private Sub update_family_activation_code()
        Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql4 = "update family_tbl set  secret_code = @code where family_id = @famID"
        Dim sqlCmd4 As New SqlCommand(sql4, con4)
        sqlCmd4.Parameters.AddWithValue("@famID", Vfamily_id)
        sqlCmd4.Parameters.AddWithValue("@code", Vhashed_secret_code)
        con4.Open()
        sqlCmd4.ExecuteNonQuery()
        con4.Close()
    End Sub
    Private Sub hashed_verification_code()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_activation_code.Text)
            Vhashed_verif_code = hash
        End Using
    End Sub
    Private Sub btn_activation_code_Click(sender As Object, e As EventArgs) Handles btn_activation_code.Click
        hashed_verification_code()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from family_tbl where secret_code = @code and family_id = @id "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@id", Vfamily_id)
        sqlCmd.Parameters.AddWithValue("@code", Vhashed_verif_code)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            MultiView1.ActiveViewIndex = 1
        ElseIf reader.Read() = False Then
            lbl_offline_username_msg.Visible = False
            lbl_offline_username.Visible = False
            lbl_validation_view33.Text = "Wrong activation code"
        End If
    End Sub
    Private Sub btn_resent_code_Click(sender As Object, e As EventArgs) Handles btn_resent_code.Click
        password_online_function()
        lbl_validation_view33.Text = "mail resent"
    End Sub
    '################################################## END OF GET PASSWORD ONLINE ################################################################################

    '################################################## CHANGE PASSWORD #######################################################################################################
    Private Sub btn_change_password_Click(sender As Object, e As EventArgs) Handles btn_change_password.Click
        If txtbx_new_password.Text = "" Then
            lbl_validation_view2.Text = "Enter new password"
        ElseIf txtbx_confirm_passwrd.Text = "" Then
            lbl_validation_view2.Text = "Enter password to confirm"
        ElseIf validation_compare_passwrod.IsValid = True Then
            hash_password_function()
            Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql4 = "update user_tbl set user_password = @pwd where family_id = @famID"
            Dim sqlCmd4 As New SqlCommand(sql4, con4)
            sqlCmd4.Parameters.AddWithValue("@famID", Vfamily_id)
            sqlCmd4.Parameters.AddWithValue("@pwd", Vpassword)
            con4.Open()
            sqlCmd4.ExecuteNonQuery()
            con4.Close()
            Response.Redirect("./Default.aspx")
        End If
    End Sub
    '################################################## END OF CHANGE PASSWORD ##########################################################

    '########################################################### GET USERNAME ONLINE #######################################################
    Private Sub username_online()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join email_tbl as e on e.family_id = f.family_id where email_address = @email and question_verif = @ques and answer_verif = @answer "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@email", txtbx_enter_mail.Text)
        sqlCmd.Parameters.AddWithValue("@ques", ddl_question.SelectedItem.Text)
        sqlCmd.Parameters.AddWithValue("@answer", txtbx_answer.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vfamily_id = CInt(reader("family_id"))
            Vusername = reader("username")
            check_connection_username()
            'lbl_validation_view1.Text = "check mail for uername"
        ElseIf reader.Read() = False Then
            lbl_offline_username_msg.Visible = False
            lbl_offline_username.Visible = False
            lbl_validation_view1.Text = "No user found"
        End If
    End Sub
    Private Sub check_connection_username()
        Dim client As New WebClient()
        Dim datasize As Byte() = Nothing
        Try
            datasize = client.DownloadData("http://www.google.com")
        Catch ex As Exception
        End Try
        If datasize IsNot Nothing AndAlso datasize.Length > 0 Then
            sentmail_username()
            lbl_validation_view1.Text = "check mail for username"
        Else
            lbl_validation_view1.Text = "no internet"
        End If
    End Sub
    Private Sub sentmail_username()
        Dim mm As New MailMessage("kaveer.rajcoomar@gmail.com", txtbx_enter_mail.Text)
        mm.Subject = "HomeMaster activation code"
        Dim body As String = "Dear user"
        body += "<br />you have resently ask to resent your username via your email "
        body += "<br /> use the following username to access your account at HomeMaster website "
        body += "<br />Username is :" + Vusername
        body += "<br /><br />Thanks you "
        body += "<br />regards "
        body += "<br />HomeMaster team "
        body += "<br /><br />refno" + CStr(Vfamily_id)
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

    End Sub
    '########################################################### END OF GET USERNAME ONLINE #######################################################

    '################################################# HASH PASSWORD ALGORITHM ####################################################
    Private Sub hash_password_function()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, txtbx_new_password.Text)
            Vpassword = hash
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

   

    
End Class