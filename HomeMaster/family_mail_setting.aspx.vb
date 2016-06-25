Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_mail_setting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_gridview_email()
    End Sub

    Private Sub family_mail_setting_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

    '################################### ADD MAIL #####################################################################################
    Private Sub btn_add_mail_Click(sender As Object, e As EventArgs) Handles btn_add_mail.Click
        If txtbx_add_mail.Text = "" Then
            lbl_validation_mail.Text = "Enter email address to add"
        ElseIf validation_email.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "INSERT into email_tbl(email_address , email_status , email_primary , family_id) values (@email , 'active' , 'no' , @familyID)"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@email", txtbx_add_mail.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_email()
        End If
    End Sub
    '################################### END OF ADD MAIL #####################################################################################

    '######################################## BIND TO GRIDVIEW ##############################################################################
    Private Sub bind_gridview_email()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select email_id as [ref no] , email_address as [email] , email_primary as [primary] from email_tbl where email_status = 'active'and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_email.DataSource = dt
        GridView_email.DataBind()
        con.Close()
    End Sub
    '######################################## END OF BIND TO GRIDVIEW ##############################################################################

    '################################################## MAKE GRIDVIEW SELECTABLE ########################################################################
    Private Sub GridView_email_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_email.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_email, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_email_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_email.SelectedIndexChanged
        For Each row As GridViewRow In GridView_email.Rows
            If row.RowIndex = GridView_email.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '################################################## END OF MAKE GRIDVIEW SELECTABLE ########################################################################

    '################################################### PAGING IN GRIDVIEW ##########################################################################
    Private Sub GridView_email_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_email.PageIndexChanging
        GridView_email.PageIndex = e.NewPageIndex
        Me.bind_gridview_email()
    End Sub
    '################################################### END OF PAGING IN GRIDVIEW ##########################################################################

    '#################################################### REMOVE MAIL #################################################################################
    Private Sub btn_remove_mail_Click(sender As Object, e As EventArgs) Handles btn_remove_mail.Click
        If GridView_email.SelectedIndex = -1 Then
            lbl_validation.Text = "select mail to remove"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update email_tbl set email_status = 'deactive' where email_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_email.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_email()
        End If
    End Sub
    '#################################################### END OF REMOVE MAIL #################################################################################

    '################################################### SET AS PRIMARY #######################################################################
    Private Sub btn_set_as_primary_Click(sender As Object, e As EventArgs) Handles btn_set_as_primary.Click
        If GridView_email.SelectedIndex = -1 Then
            lbl_validation.Text = "select mail to set as primary"
        Else
            set_primary_to_no()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update email_tbl set email_primary = 'yes' where email_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_email.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_email()
        End If
    End Sub
    Private Sub set_primary_to_no()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update email_tbl set email_primary = 'no' where family_id = @familyID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################### END OF SET AS PRIMARY #######################################################################
End Class