Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports System.Security
Imports System.IO

Public Class _Default
    Inherits System.Web.UI.Page
    Dim hashPWD As String

    Shared random As New Random()
    Dim vtest As Decimal

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim genrate_num1 As String = CStr(CInt(Int((100000 * Rnd()) + 1)))
        'Label1.Text = genrate_num1
        'displayImg()
        'detailview_test()
       
    End Sub
    'Private Sub detailview_test()
    '    Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
    '    'Dim sql = "select  sent_to , message_body from user_tbl as u inner join family_tbl as f on u.family_id = f.family_id inner join messaging_tbl as m on m.family_id = f.family_id "
    '    Dim sql = "select username from user_tbl"
    '    Dim sqlCmd As New SqlCommand(sql, con)
    '    con.Open()
    '    Dim sqladap = New SqlDataAdapter(sqlCmd)
    '    Dim dt = New DataTable
    '    sqladap.Fill(dt)
    '    DetailsView1.DataSource = dt
    '    DetailsView1.DataBind()
    '    con.Close()
    'End Sub


    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

  


  
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Using md5Hash As MD5 = MD5.Create()
    '        Dim hash As String = GetMd5Hash(md5Hash, TextBox1.Text)
    '        Label1.Text = hash
    '        hashPWD = hash
    '    End Using

    '    Label3.Text = hashPWD
    'End Sub
    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    'Using md5Hash As MD5 = MD5.Create()
    '    '    Dim hash As String = GetMd5Hash(md5Hash, TextBox2.Text)
    '    '    Label2.Text = hash
    '    'End Using
    '    TextBox2.Text = Label2.Text
    'End Sub

    'Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

    '    ' Convert the input string to a byte array and compute the hash.
    '    Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

    '    ' Create a new Stringbuilder to collect the bytes
    '    ' and create a string.
    '    Dim sBuilder As New StringBuilder()

    '    ' Loop through each byte of the hashed data 
    '    ' and format each one as a hexadecimal string.
    '    Dim i As Integer
    '    For i = 0 To data.Length - 1
    '        sBuilder.Append(data(i).ToString("x2"))
    '    Next i

    '    ' Return the hexadecimal string.
    '    Return sBuilder.ToString()

    'End Function 'GetMd5Hash

    '' Verify a hash against a string.
    'Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
    '    ' Hash the input.
    '    Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

    '    ' Create a StringComparer an compare the hashes.
    '    Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

    '    If 0 = comparer.Compare(hashOfInput, hash) Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function 'VerifyMd5Hash


    'Private Sub DetailsView1_PageIndexChanging(sender As Object, e As DetailsViewPageEventArgs) Handles DetailsView1.PageIndexChanging
    '    DetailsView1.PageIndex = e.NewPageIndex
    '    Me.detailview_test()
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    '    Dim genrate_num1 As String = Convert.ToString(random.Next(1, 1000))
    '    If FileUpload1.HasFile Then
    '        Dim fileName As String = FileUpload1.PostedFile.FileName
    '        Dim fileExtension As String = Path.GetExtension(fileName).ToLower()

    '        Dim extensionsAllowed As String() = {".jpg", ".png"}

    '        If extensionsAllowed.Contains(fileExtension) Then

    '            Dim filePath As String = Server.MapPath("~/UploadImages/insurancePic/" + genrate_num1 + "_" + fileName)
    '            FileUpload1.PostedFile.SaveAs(filePath)

    '            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
    '            Dim sql1 = "insert into test_tbl(picUrl) values (@Path)"
    '            Dim sqlCmd1 As New SqlCommand(sql1, con1)
    '            sqlCmd1.Parameters.AddWithValue("@Path", "UploadImages/pic/" + genrate_num1 + "_" + fileName)
    '            sqlCmd1.CommandType = CommandType.Text
    '            lbl_validation.Text = "File successfully uploaded and file path saved in database"
    '            Try
    '                con1.Open()
    '                sqlCmd1.ExecuteNonQuery()
    '            Catch ex As Exception
    '                lbl_validation.Text = "Unable to insert file data in database"
    '            Finally
    '                con1.Close()
    '            End Try
    '            Try
    '            Catch ex As Exception
    '                lbl_validation.Text = "Unable to upload file"
    '            End Try
    '        Else
    '            lbl_validation.Text = "File extension " + fileExtension + " is not allowed"
    '        End If
    '    End If
    '    displayImg()
    'End Sub
    'Private Sub displayImg()
    '    Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
    '    Dim sql As String = "select picUrl from test_tbl "
    '    Dim cmd As New SqlCommand(sql, con)
    '    Dim myReader As SqlDataReader
    '    con.Open()
    '    myReader = cmd.ExecuteReader
    '    Repeater1.DataSource = myReader
    '    Repeater1.DataBind()
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
    '    Dim sql2 = "select sum(m_amount) as [total paid] from moveable_asset_repay_tbl where m_asset_id = 5"
    '    Dim sqlCmd2 As New SqlCommand(sql2, con2)
    '    con2.Open()
    '    Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
    '    If reader2.Read() = True Then
    '        vtest = reader2("total paid")
    '        con2.Close()
    '    End If
    '    Label2.Text = CStr(vtest)
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If TextBox2.Text = "" Then
    '        TextBox2.Text = TextBox1.Text
    '    Else
    '        TextBox2.Text = TextBox2.Text + Environment.NewLine + TextBox1.Text
    '    End If

    'End Sub
End Class