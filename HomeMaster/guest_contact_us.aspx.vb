Imports System.Data.SqlClient

Public Class guest_contact_us
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '###################################### THEME SETUP ###################################################################
    Private Sub guest_contact_us_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '###################################### THEME SETUP ###################################################################


    '##################################### CONTACT US FUNCTION #######################################################################
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txtbx_name.Text = "" Then
            lbl_validation.Text = "enter name"
        ElseIf txtbx_email.Text = "" Then
            lbl_validation.Text = "Enter email"
        ElseIf txtbx_message.Text = "" Then
            lbl_validation.Text = "enter message"
        ElseIf validation_email.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into contact_us_tbl (cont_name , cont_email , cont_msg ) values (@name , @email , @msg )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_name.Text)
            sqlCmd1.Parameters.AddWithValue("@email", txtbx_email.Text)
            sqlCmd1.Parameters.AddWithValue("@msg", txtbx_message.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation.Text = "message sent"
        End If
    End Sub
    '##################################### END IF CONTACT US FUNCTION #######################################################################
End Class