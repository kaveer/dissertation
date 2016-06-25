Imports System.Data.SqlClient
Imports System.Drawing

Public Class children_view_note
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_detail_view_note()
    End Sub

    '########################################## THEME SETUP #################################################################
    Private Sub children_view_note_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '########################################## END OF THEME SETUP #################################################################

    '############################################ VIEW NOTE #########################################################################
    Private Sub bind_detail_view_note()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select note_name as [Note title] , FORMAT(note_date , 'dd/MM/yyyy') as [Date] , note_descrip as [Notes] from note_tbl where family_id = @familyID and note_status = 'active' order by note_date desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailView_view_note.DataSource = dt
        DetailView_view_note.DataBind()
        con.Close()
    End Sub
    '############################################ END OF VIEW NOTE #########################################################################

    '########################################## REMOVE NOTE ########################################################################
    Private Sub btn_remove_note_panel_Click(sender As Object, e As EventArgs) Handles btn_remove_note_panel.Click
        Panel_remove_note.Visible = True
        bind_gridview_remove()
    End Sub
    Private Sub bind_gridview_remove()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select note_id as [ref no] , note_name as [Notes title] ,   FORMAT(note_date , 'dd/MM/yyyy') as [Date] , note_descrip as [Notes] from note_tbl where family_id = @familyID and note_status = 'active' order by note_date "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_remove_note.DataSource = dt
        GridView_remove_note.DataBind()
        con.Close()
    End Sub
    Private Sub btn_remove_note_Click(sender As Object, e As EventArgs) Handles btn_remove_note.Click
        If GridView_remove_note.SelectedIndex = -1 Then
            lbl_validation_remove.Text = "Select note to remove"
        ElseIf GridView_remove_note.Rows.Count = 0 Then
            lbl_validation_remove.Text = "no note in your account"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update note_tbl set note_status = 'deactive' where note_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_remove_note.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_remove()
            bind_detail_view_note()
            Panel_remove_note.Visible = False
        End If
    End Sub
    Private Sub btn_cancel_remove_Click(sender As Object, e As EventArgs) Handles btn_cancel_remove.Click
        Panel_remove_note.Visible = False
    End Sub
    '########################################## END OF REMOVE NOTE ########################################################################

    '######################################### PAGING ####################################################################################
    Private Sub GridView_remove_note_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_remove_note.PageIndexChanging
        GridView_remove_note.PageIndex = e.NewPageIndex
        Me.bind_gridview_remove()
    End Sub
    Private Sub DetailView_view_note_PageIndexChanging(sender As Object, e As DetailsViewPageEventArgs) Handles DetailView_view_note.PageIndexChanging
        DetailView_view_note.PageIndex = e.NewPageIndex
        Me.bind_detail_view_note()
    End Sub
    '######################################### END OF PAGING ####################################################################################

    '########################################### MAKE GRIDVIEW SELECTABLE ##################################################################
    Private Sub GridView_remove_note_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_remove_note.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_remove_note, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_remove_note_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_remove_note.SelectedIndexChanged
        For Each row As GridViewRow In GridView_remove_note.Rows
            If row.RowIndex = GridView_remove_note.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '########################################### END OF MAKE GRIDVIEW SELECTABLE ##################################################################

    
    Private Sub btn_add_notes_Click(sender As Object, e As EventArgs) Handles btn_add_notes.Click
        Response.Redirect("./children_add_note.aspx")
    End Sub
End Class