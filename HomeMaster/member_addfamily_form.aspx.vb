Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail

Public Class member_addfamily_form
    Inherits System.Web.UI.Page
    Dim Vfamily_id As Integer
    Dim Vfamily_type_id As Integer
    Dim sg As String
    Dim sg2 As String
    Dim member_id As String
    Dim hashPWD As String
    Shared random As New Random()
    Dim secret_code_genrate As String
    Dim hash_secret_code_genrate As String

    '####################################### ADD USER FUNCTION\BUTTON ############################################################################
    Private Sub registerUser()
        hash_password_function()
        check_member_type()

        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into family_tbl( name , surname , gender , family_status , family_type_id , is_activated , secret_code , dob) values( @nameT , '@tochange' , @gender , 'active' , @familyType , 'no' , @secret_code , convert(date,@DOB,103) )"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@nameT", name_txtbx.Text)
        sqlCmd1.Parameters.AddWithValue("@gender", gender_ddl.SelectedItem.Text)
        sqlCmd1.Parameters.AddWithValue("@familyType", CInt(Vfamily_type_id))
        sqlCmd1.Parameters.AddWithValue("@secret_code", hash_secret_code_genrate)
        sqlCmd1.Parameters.AddWithValue("@DOB", dob_txtbx.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()

        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select family_id from family_tbl where family_status = 'active' and name = @nameT and surname = '@tochange' and gender = @gender   "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@nameT", name_txtbx.Text)
        sqlCmd2.Parameters.AddWithValue("@gender", gender_ddl.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vfamily_id = CInt(reader2("family_id"))
            'mobilenum_txtbx.Text = CStr(reader2("family_id"))
        End If
        con2.Close()

        change_surname_back()

        Dim con3 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql3 = "insert into user_tbl(username , user_password , family_id) values (@usernameT , @user_passwordT, @family_id )"
        Dim sqlCmd3 As New SqlCommand(sql3, con3)
        sqlCmd3.Parameters.AddWithValue("@usernameT", username_txtbx.Text)
        sqlCmd3.Parameters.AddWithValue("@user_passwordT", hashPWD)
        sqlCmd3.Parameters.AddWithValue("@family_id", Vfamily_id)
        con3.Open()
        sqlCmd3.ExecuteNonQuery()
        con3.Close()

        Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql4 = "insert into email_tbl(email_address , family_id , email_primary , email_status) values (@EusernameT , @family_id , 'yes' , 'active')"
        Dim sqlCmd4 As New SqlCommand(sql4, con4)
        sqlCmd4.Parameters.AddWithValue("@EusernameT", email_txtbx.Text)
        sqlCmd4.Parameters.AddWithValue("@family_id", Vfamily_id)
        con4.Open()
        sqlCmd4.ExecuteNonQuery()
        con4.Close()
    End Sub
    Private Sub change_surname_back()
        Dim con4 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql4 = "update family_tbl set surname = @surnameT where family_id = @family_id"
        Dim sqlCmd4 As New SqlCommand(sql4, con4)
        sqlCmd4.Parameters.AddWithValue("@surnameT", surname_txtbx.Text)
        sqlCmd4.Parameters.AddWithValue("@family_id", Vfamily_id)
        con4.Open()
        sqlCmd4.ExecuteNonQuery()
        con4.Close()
    End Sub
    Private Sub register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        Dim genrate_num1 As String = CStr(CInt(Int((100 * Rnd()) + 1)))
        Dim genrate_num2 As String = CStr(CInt(Int((100 * Rnd()) + 1)))
        string_generator()
        string_generator2()

        If username_txtbx.Text = "" Then
            check_user_lbl.Visible = False
        Else
            check_user_lbl.Visible = True
        End If

        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " SELECT * FROM user_tbl WHERE username = @Uname "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@Uname", username_txtbx.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            suggestion_pnl.Visible = True
            check_user_lbl.Text = "Username already exists"
            suggest_username_lbl.Text = username_txtbx.Text + genrate_num1 + "<br />" + username_txtbx.Text + genrate_num2 + "<br />" + username_txtbx.Text + "_" + sg + genrate_num1 + "<br />" + username_txtbx.Text + "_" + sg2 + genrate_num2 + "<br />" + username_txtbx.Text + "_" + sg + "<br />" + username_txtbx.Text + "_" + sg2
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Fail to add family member, Check for available username');", True)
        ElseIf reader.Read() = False Then
            If req_username_val.IsValid = True And requ_exp_email.IsValid = True And req_mail_val.IsValid = True And req_password_val.IsValid = True And cmpPwd.IsValid = True And req_name_val.IsValid = True And RegularExpressionValidator_name.IsValid = True And RegularExpressionValidator_surname.IsValid = True And req_dob_val.IsValid = True And validation_for_dob.IsValid = True And RegularExpressionValidator_phoneNum.IsValid = True Then
                secret_code_genrate = Convert.ToString(random.Next(1, 10000))
                generate_secret_code()
                check_user_lbl.Text = "Username available"
                registerUser()
                checkConnection()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('New member added please check mail');", True)
            End If
        End If
        con.Close()
    End Sub
    '####################################### ADD USER FUNCTION\BUTTON ############################################################################

    '########################################### CHECK USERNAME FOR DUPLICATION ##############################################
    Private Sub checkuser_btn_Click(sender As Object, e As EventArgs) Handles checkuser_btn.Click
        suggestion_pnl.Visible = True
        Dim genrate_num1 As String = CStr(CInt(Int((100 * Rnd()) + 1)))
        Dim genrate_num2 As String = CStr(CInt(Int((100 * Rnd()) + 1)))
        string_generator()
        string_generator2()

        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " SELECT * FROM user_tbl WHERE username = @Uname "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@Uname", username_txtbx.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            check_user_lbl.Text = "Username already exists"
            suggest_username_lbl.Text = username_txtbx.Text + genrate_num1 + "<br />" + username_txtbx.Text + genrate_num2 + "<br />" + username_txtbx.Text + "_" + sg + genrate_num1 + "<br />" + username_txtbx.Text + "_" + sg2 + genrate_num2 + "<br />" + username_txtbx.Text + "_" + sg + "<br />" + username_txtbx.Text + "_" + sg2
        ElseIf reader.Read() = False Then
            check_user_lbl.Text = "Username available"
        End If
        con.Close()

        If username_txtbx.Text = "" Then
            check_user_lbl.Visible = False
        Else
            check_user_lbl.Visible = True
        End If
    End Sub
    '########################################### END OF CHECK USERNAME FOR DUPLICATION ##############################################

    '################################################ GENERATE CHARACTER TO SUGGEST USERNAME ##############################
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
    '################################################ END OF GENERATE CHARACTER TO SUGGEST USERNAME ##############################

    '###################################################### THEME SETUP ###################################################
    Private Sub member_addfamily_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '###################################################### END OF THEME SETUP ###############################################

    '############################################ CHECK RELATIONSHIP TYPE AND GET THE ID #####################################
    Private Sub check_member_type()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from family_type_tbl where family_type =  @familyT "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@familyT", relationship_ddl.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vfamily_type_id = CInt(reader2("family_type_id"))
            'mobilenum_txtbx.Text = CStr(reader2("family_id"))
            con2.Close()
        Else
            Dim con5 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql5 = "insert into family_type_tbl(family_type) values (@familyT )"
            Dim sqlCmd5 As New SqlCommand(sql5, con5)
            sqlCmd5.Parameters.AddWithValue("@familyT", relationship_ddl.SelectedItem.Text)
            con5.Open()
            sqlCmd5.ExecuteNonQuery()
            con5.Close()
            Add_new_family_type()
        End If
    End Sub
    Private Sub Add_new_family_type()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from family_type_tbl where family_type =  @familyT "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@familyT", relationship_ddl.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vfamily_type_id = CInt(reader2("family_type_id"))
            'mobilenum_txtbx.Text = CStr(reader2("family_id"))
            con2.Close()
        End If
    End Sub
    '############################################ END OF CHECK RELATIONSHIP TYPE AND GET THE ID #####################################

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

    '#################################################### GENERATE SECRET CODE AND HASH ###########################################
    Private Sub generate_secret_code()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, secret_code_genrate)
            hash_secret_code_genrate = hash
        End Using
    End Sub
    '#################################################### END OF GENERATE SECRET CODE AND HASH ###########################################

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
            lbl_check.Text = "no internet"
        End If
    End Sub
    Private Sub sentmail()
        Dim mm As New MailMessage("kaveer.rajcoomar@gmail.com", email_txtbx.Text)
        mm.Subject = "HomeMaster password"
        Dim body As String = "Dear user"
        body += "<br />Thank your for registering at HomeMaster please note down your username and activation code "
        body += "<br /> use the following activation code to activate your account at HomeMaster website "
        body += "<br />Username is :" + username_txtbx.Text
        body += "<br />Activation code is :" + secret_code_genrate
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
        lbl_check.Text = "mail sent"
    End Sub
    '#################################################### SENT MAIL FUNCTION ############################################################
End Class