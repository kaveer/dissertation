Imports System.Data.SqlClient

Public Class family_security_setting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub family_security_setting_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

    '####################################### UPDATE SECURITY QUESTION #####################################################################
    Private Sub btn_update_answer_Click(sender As Object, e As EventArgs) Handles btn_update_answer.Click
        If txtbx_answer.Text = "" Then
            lbl_validation.Text = "enter answer to save"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update family_tbl set question_verif = @ques , answer_verif = @answer where family_id = @familyID "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@answer", txtbx_answer.Text)
            sqlCmd1.Parameters.AddWithValue("@ques", ddl_question.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation.Text = "security question updated"
        End If
    End Sub
    '####################################### END OF UPDATE SECURITY QUESTION #####################################################################
End Class