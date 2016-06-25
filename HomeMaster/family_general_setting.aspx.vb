Imports System.Data.SqlClient

Public Class family_general_setting
    Inherits System.Web.UI.Page

    Dim Vname As String
    Dim Vsurname As String
    Dim Vgender As String
    Dim vdob As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_into_to_variable()
        If Not IsPostBack Then
            If Vgender = "Male" Then
                ddl_dob.SelectedIndex = 0
            ElseIf Vgender = "Female" Then
                ddl_dob.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub family_general_setting_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

    '######################################### DATA TO VARIABLES #######################################################################
    Private Sub get_into_to_variable()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from family_tbl WHERE family_id = @familyID "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            If IsDBNull(reader2("name")) Then
                Vname = "no name"
            Else
                Vname = reader2("name")
            End If
            If IsDBNull(reader2("surname")) Then
                Vsurname = "no surname"
            Else
                Vsurname = reader2("surname")
            End If
            If IsDBNull(reader2("gender")) Then
                Vgender = "no gender"
            Else
                Vgender = reader2("gender")
            End If
            If IsDBNull(reader2("dob")) Then
                vdob = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            Else
                vdob = reader2("dob")
            End If
            con2.Close()
        End If
    End Sub
    '######################################### END OF DATA TO VARIABLES #######################################################################

    '######################################## UPDATE USER INFORMATION ############################################################################
    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If validation_date.IsValid = True Then
            If txtbx_name.Text = "" Then
                txtbx_name.Text = Vname
            End If
            If txtbx_surname.Text = "" Then
                txtbx_surname.Text = Vsurname
            End If
            If txtbx_dob.Text = "" Then
                txtbx_dob.Text = vdob
            End If

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "UPDATE family_tbl set name = @name , surname = @surname , gender = @gen , dob = convert(date,@dob,103)  where family_id = @famID"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_name.Text)
            sqlCmd1.Parameters.AddWithValue("@surname", txtbx_surname.Text)
            sqlCmd1.Parameters.AddWithValue("@gen", ddl_dob.SelectedItem.Text)
            sqlCmd1.Parameters.AddWithValue("@dob", txtbx_dob.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()

            txtbx_name.Text = ""
            txtbx_surname.Text = ""
            txtbx_dob.Text = ""
            lbl_validation.Text = "User information updated"
        End If
    End Sub
    '######################################## END OF UPDATE USER INFORMATION ######################################################################
End Class