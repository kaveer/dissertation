Imports System.Data.SqlClient

Public Class member_add_note
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtbx_note_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
    End Sub

    '################################################# THEME SETUP ###################################################################
    Private Sub member_add_note_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ###################################################################

    '############################################## ADD NOTE #################################################################################
    Private Sub btn_add_note_Click(sender As Object, e As EventArgs) Handles btn_add_note.Click
        If txtbx_note_name.Text = "" Then
            lbl_validation.Text = "Enter note name"
        ElseIf txtbx_note_date.Text = "" Then
            lbl_validation.Text = "Enter date"
        ElseIf validation_date.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into note_tbl(note_name , note_date , note_descrip , note_status , family_id) values (@name , convert(date,@date,103) , @desc , 'active' , @familyID)"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_note_name.Text)
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_note_date.Text)
            sqlCmd1.Parameters.AddWithValue("@desc", txtbx_note_description.Text)
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation.Text = "New note added"
        End If
    End Sub
    '############################################## END OF ADD NOTE #################################################################################

    Private Sub btn_view_note_Click(sender As Object, e As EventArgs) Handles btn_view_note.Click
        Response.Redirect("./member_home_form.aspx")
    End Sub


End Class