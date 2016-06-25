Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class guest
    Inherits System.Web.UI.MasterPage
    Dim userstring As String
    Dim memberpassword As String
    Dim after_hash_pwd As String

    '########################################################### LOGIN FUNCTION ##################################################################################################
    Private Sub login()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select u.username , u.user_password , f.family_status, ft.family_type, f.family_id , ft.family_type_id from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id where u.username = @usernameT and u.user_password = @passwordT and f.family_status='active' and ft.family_type = 'admin'"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@usernameT", username_txtbx.Text)
        sqlCmd.Parameters.AddWithValue("@passwordT", after_hash_pwd)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Session("user") = reader("username").ToString()
            Session("family_id") = reader("family_id").ToString()
            Response.Redirect("member_home_form.aspx")
            con.Close()
        ElseIf reader.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "select u.username , u.user_password , f.family_status, ft.family_type, f.family_id , ft.family_type_id from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id where u.username = @fusername and u.user_password = @fpassword and f.family_status='active' and ft.family_type = 'Children' "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@fusername", username_txtbx.Text)
            sqlCmd1.Parameters.AddWithValue("@fpassword", after_hash_pwd)
            con1.Open()
            Dim reader1 As SqlDataReader = sqlCmd1.ExecuteReader()
            If reader1.Read() Then
                Session("user") = reader1("username").ToString()
                Session("family_id") = reader1("family_id").ToString()
                Response.Redirect("./children_home_form.aspx")
                con1.Close()
            ElseIf reader1.Read() = False Then
                Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql2 = "select u.username , u.user_password , f.family_status, ft.family_type, f.family_id , ft.family_type_id from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id where u.username = @fusername and u.user_password = @fpassword and f.family_status='active' and (ft.family_type = 'Wife' or ft.family_type = 'Husband')"
                Dim sqlCmd2 As New SqlCommand(sql2, con2)
                sqlCmd2.Parameters.AddWithValue("@fusername", username_txtbx.Text)
                sqlCmd2.Parameters.AddWithValue("@fpassword", after_hash_pwd)
                con2.Open()
                Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
                If reader2.Read() Then
                    Session("user") = reader2("username").ToString
                    Session("family_id") = reader2("family_id").ToString()
                    Response.Redirect("./family_home_form.aspx")
                    con1.Close()
                ElseIf reader2.Read = False Then
                    Dim con3 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                    Dim sql3 = "select u.username , u.user_password , f.family_status, ft.family_type, f.family_id , ft.family_type_id from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join family_type_tbl as ft on f.family_type_id = ft.family_type_id where u.username = @fusername and u.user_password = @fpassword and f.family_status='active'"
                    Dim sqlCmd3 As New SqlCommand(sql3, con3)
                    sqlCmd3.Parameters.AddWithValue("@fusername", username_txtbx.Text)
                    sqlCmd3.Parameters.AddWithValue("@fpassword", after_hash_pwd)
                    con3.Open()
                    Dim reader3 As SqlDataReader = sqlCmd3.ExecuteReader()
                    If reader3.Read() Then
                        Session("user") = reader3("username").ToString
                        Session("family_id") = reader3("family_id").ToString()
                        Response.Redirect("./family_home_form.aspx")
                        con1.Close()
                    Else
                        username_txtbx.Text = ""
                        password_txtbx.Text = ""
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertMessage", "alert('Incorrect Username or Password, please try again');", True)
                    End If
                End If
            End If
        End If


    End Sub
    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        remember_me()
        hash_password_function()
        login()
    End Sub
    '########################################################### END OF LOGIN FUNCTION ##################################################################################################

    '################################################# HASH PASSWORD ALGORITHM ####################################################
    Private Sub hash_password_function()
        Using md5Hash As MD5 = MD5.Create()
            Dim hash As String = GetMd5Hash(md5Hash, password_txtbx.Text)
            after_hash_pwd = hash
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

    '############################################################  REMEMBER ME FUNCTION #############################################################################################
    Private Sub remember_me()
        If remember_ckbx.Checked = True Then
            Response.Cookies("cookiesUsername").Expires = DateAndTime.Now.AddDays(15)
            Response.Cookies("cookiesPassword").Expires = DateAndTime.Now.AddDays(15)
        Else
            Response.Cookies("cookiesUsername").Expires = DateTime.Now.AddDays(-1)
            Response.Cookies("cookiesPassword").Expires = DateTime.Now.AddDays(-1)
        End If
        Response.Cookies("cookiesUsername").Value = username_txtbx.Text
        Response.Cookies("cookiesPassword").Value = password_txtbx.Text
    End Sub
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If ((Not (Request.Cookies("cookiesUsername")) Is Nothing) AndAlso (Not (Request.Cookies("cookiesPassword")) Is Nothing)) Then
                username_txtbx.Text = Request.Cookies("cookiesUsername").Value
                password_txtbx.Attributes("value") = Request.Cookies("cookiesPassword").Value
                'Response.Redirect("./user_home_form.aspx")
            End If
        End If
        '"Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True" = "Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True"
    End Sub
    '############################################################ END OF  REMEMBER ME FUNCTION #############################################################################################

End Class