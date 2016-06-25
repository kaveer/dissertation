Imports System.Data.SqlClient

Public Class children_username_setting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtbx_current_username.Text = Session("user")
    End Sub

    Private Sub children_username_setting_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

    '####################################### UPDATE USERNAME #####################################################################
    Private Sub btn_update_user_Click(sender As Object, e As EventArgs) Handles btn_update_user.Click
        If txtbx_new_username.Text = "" Then
            lbl_validation.Text = "enter username to update"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " SELECT * FROM user_tbl WHERE username = @Uname "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@Uname", txtbx_new_username.Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                lbl_validation.Text = "username already exists"
            ElseIf reader.Read() = False Then
                update_username()
            End If
            con.Close()
        End If
    End Sub
    Private Sub update_username()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update user_tbl set username = @newPswd where family_id = @familyID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd1.Parameters.AddWithValue("@newPswd", txtbx_new_username.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        Session("user") = txtbx_new_username.Text
        txtbx_current_username.Text = Session("user")
        Response.Redirect("./children_username_setting.aspx")
    End Sub
    '####################################### END OF UPDATE USERNAME #####################################################################
End Class