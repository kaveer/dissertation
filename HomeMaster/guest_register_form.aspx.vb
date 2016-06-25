Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail

Public Class guest_register_form
    Inherits System.Web.UI.Page

    Dim Vfamily_id As Integer
    Dim Vfamily_type_id As Integer
    Dim hashPWD As String
    Dim sg As String
    Dim sg2 As String
    Dim Vsecret_code As String
    Dim Vhashed_secret_code As String
    Shared random As New Random()



    Private Sub guest_register_form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from family_tbl as f inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id where f.family_status = 'active' and ft.family_type = 'admin'"
        Dim sqlCmd As New SqlCommand(sql, con)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() = True Then
            Dim message As String = "Admin already registered"
            Dim url As String = "./Default.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
        End If
    End Sub

    '############################################## CHECK USER DUPLICATION ####################################################################
    Public Sub check_user_val_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles check_user_val.ServerValidate
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select username from user_tbl where username = @usernameT "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@usernameT", args.Value)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader
        If reader.HasRows Then
            args.IsValid = False
        Else
            args.IsValid = True
            'registeruser()
            'Session.Add("user", username_txtbx.Text)
            'Response.Redirect("user_home_form.aspx")
        End If
        con.Close()
    End Sub
    Private Sub checkuser_btn_Click(sender As Object, e As EventArgs) Handles checkuser_btn.Click
        suggestion_pnl.Visible = True
        Dim genrate_num1 As String = CStr(CInt(Int((100 * Rnd()) + 1)))
        Dim genrate_num2 As String = CStr(CInt(Int((100 * Rnd()) + 1)))


        string_generator()
        string_generator2()

        If check_user_val.IsValid = False Then
            check_user_lbl.Text = "Username already exists"
            suggest_username_lbl.Text = username_txtbx.Text + genrate_num1 + "<br />" + username_txtbx.Text + genrate_num2 + "<br />" + username_txtbx.Text + "_" + sg + genrate_num1 + "<br />" + username_txtbx.Text + "_" + sg2 + genrate_num2 + "<br />" + username_txtbx.Text + "_" + sg + "<br />" + username_txtbx.Text + "_" + sg2
        ElseIf check_user_val.IsValid = True Then
            check_user_lbl.Text = "Username available"
        End If

        If username_txtbx.Text = "" Then
            check_user_lbl.Visible = False
        Else
            check_user_lbl.Visible = True
        End If
    End Sub
    '############################################## END OF CHECK USER DUPLICATION ####################################################################

    '##################################################### INSERT USER INFORMATION ###########################################################################
    Private Sub register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        If term_condition_ckbx.Checked = False Then
            'javascrip alert msg
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Check the term and condition to register');", True)
        End If
        If check_user_val.IsValid = True And req_username_val.IsValid = True And req_email_val.IsValid = True And req_password_val.IsValid = True And comp_password_val.IsValid = True And confirm_req_pass_val.IsValid = True Then
            registeruser()
            Session.Add("user", username_txtbx.Text)
            Session("family_id") = CStr(Vfamily_id)
            checkConnection()

            Dim message As String = "Check your mail for activation code"
            Dim url As String = "./Default.aspx"
            Dim script As String = "window.onload = function(){ alert('"
            script += message
            script += "');"
            script += "window.location = '"
            script += url
            script += "'; }"
            ClientScript.RegisterStartupScript(Me.GetType(), "Redirect", script, True)
        Else
            
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert(' registration failed');", True)
        End If
    End Sub
    Private Sub registeruser()
        insert_family_typeTBL()
        insert_familyTBL()
        obtain_family_id()
        insert_userTBL()
        insert_emailTBL()
    End Sub
    Private Sub insert_family_typeTBL()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = " select family_type_id , family_type from family_type_tbl where family_type = 'admin' "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read = True Then
            Vfamily_type_id = CInt(reader2("family_type_id"))
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into family_type_tbl( family_type) values ( 'admin')"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            obtain_family_typeID()
        End If
    End Sub
    Private Sub obtain_family_typeID()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = " select family_type_id , family_type from family_type_tbl where family_type = 'admin' "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read = True Then
            Vfamily_type_id = CInt(reader2("family_type_id"))
        End If
        con2.Close()
    End Sub
    Private Sub insert_familyTBL()
        Vsecret_code = Convert.ToString(random.Next(1, 10000))
        hash_secret_code()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into family_tbl ( family_status , question_verif , answer_verif , family_type_id , is_activated , secret_code) values ('active', @questionT, @answerT , @famTypeT , 'no' , @secret_code )"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        'sqlCmd.Parameters.AddWithValue("@usernameT", username_txtbx.Text)
        'sqlCmd.Parameters.AddWithValue("@emailT", email_txtbx.Text)
        'sqlCmd.Parameters.AddWithValue("@user_passwordT", password_txtbx.Text)
        sqlCmd1.Parameters.AddWithValue("@questionT", question_ddl.SelectedItem.Text)
        sqlCmd1.Parameters.AddWithValue("@answerT", answer_txtbx.Text)
        sqlCmd1.Parameters.AddWithValue("@famTypeT", Vfamily_type_id)
        sqlCmd1.Parameters.AddWithValue("@secret_code", Vhashed_secret_code)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub obtain_family_id()
        Dim con5 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql5 = "select family_status , family_id , question_verif , answer_verif  from family_tbl where family_status = 'active' and question_verif = @quesT and answer_verif = @ansT and secret_code = @secret_code   "
        Dim sqlCmd5 As New SqlCommand(sql5, con5)
        sqlCmd5.Parameters.AddWithValue("@quesT", question_ddl.SelectedItem.Text)
        sqlCmd5.Parameters.AddWithValue("@ansT", answer_txtbx.Text)
        sqlCmd5.Parameters.AddWithValue("@secret_code", Vhashed_secret_code)
        con5.Open()
        Dim reader5 As SqlDataReader = sqlCmd5.ExecuteReader()
        If reader5.Read = True Then
            Vfamily_id = CInt(reader5("family_id"))
        End If
        con5.Close()
    End Sub
    Private Sub insert_userTBL()
        hash_password_function()
        Dim con3 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql3 = "insert into user_tbl(username , user_password , family_id) values (@usernameT , @user_passwordT,@family_id )"
        Dim sqlCmd3 As New SqlCommand(sql3, con3)
        sqlCmd3.Parameters.AddWithValue("@usernameT", username_txtbx.Text)
        sqlCmd3.Parameters.AddWithValue("@user_passwordT", hashPWD)
        sqlCmd3.Parameters.AddWithValue("@family_id", Vfamily_id)
        con3.Open()
        sqlCmd3.ExecuteNonQuery()
        con3.Close()
    End Sub
    Private Sub insert_emailTBL()
        Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql4 = "insert into email_tbl(email_address , family_id , email_primary , email_status) values (@EusernameT , @family_id , 'yes' , 'active')"
        Dim sqlCmd4 As New SqlCommand(sql4, con4)
        sqlCmd4.Parameters.AddWithValue("@EusernameT", email_txtbx.Text)
        sqlCmd4.Parameters.AddWithValue("@family_id", Vfamily_id)
        con4.Open()
        sqlCmd4.ExecuteNonQuery()
        con4.Close()
    End Sub
    '##################################################### END OF INSERT USER INFORMATION ###########################################################################

    '########################################################## HASH SECRET CODE ########################################################################
    Private Sub hash_secret_code()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, Vsecret_code)
            Vhashed_secret_code = hash
        End Using
    End Sub
    '########################################################## HASH SECRET CODE ########################################################################

    '################################################# HASH PASSWORD ALGORITHM ####################################################
    Private Sub hash_password_function()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, password_txtbx.Text)
            hashPWD = hash
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

    '##################################################### GENERATE CHARACTER TO SUGGEST USER ##############################################
    Public Sub string_generator()
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim string_gen As New StringBuilder
        For i As Integer = 1 To 4
            Dim idx As Integer = r.Next(0, 35)
            string_gen.Append(s.Substring(idx, 1))
        Next
        sg = string_gen.ToString

    End Sub
    Public Sub string_generator2()
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim string_gen As New StringBuilder
        For i As Integer = 1 To 2
            Dim idx As Integer = r.Next(0, 35)
            string_gen.Append(s.Substring(idx, 1))
        Next

        sg2 = string_gen.ToString
    End Sub
    '##################################################### END OF GENERATE CHARACTER TO SUGGEST USER #########################################

    '################################### THEME SETUP #############################################################################
    Private Sub guest_register_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #############################################################################

    '#################################################### SENT MAIL FUNCTION ############################################################
    Private Sub checkConnection()
        Dim client As New WebClient()
        Dim datasize As Byte() = Nothing
        Try
            datasize = client.DownloadData("http://www.google.com")
        Catch ex As Exception
        End Try
        If datasize IsNot Nothing AndAlso datasize.Length > 0 Then
            sentmail()
        Else
            lbl_validation.Text = "no internet"
        End If
    End Sub
    Private Sub sentmail()
        Dim mm As New MailMessage("kaveer.rajcoomar@gmail.com", email_txtbx.Text)
        mm.Subject = "HomeMaster password"
        Dim body As String = "Dear user"
        body += "<br />Thank your for registering at HomeMaster please note down your username and activation code "
        body += "<br /> use the following activation code to activate your account at HomeMaster website "
        body += "<br />Username is :" + username_txtbx.Text
        body += "<br />Activation code is :" + Vsecret_code
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
    End Sub
    '#################################################### SENT MAIL FUNCTION ############################################################


End Class