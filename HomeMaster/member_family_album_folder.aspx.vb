Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_family_album_folder
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        family_folder()
    End Sub

    '################################################# THEME SETUP ###################################################################
    Private Sub member_family_album_folder_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ###################################################################

    '############################################### MAKE GRIDVIEW SELECTABLE ###########################################################
    Private Sub GridView_select_folder_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_folder.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_folder, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_folder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_folder.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_folder.Rows
            If row.RowIndex = GridView_select_folder.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next

    End Sub
    '############################################### END OF MAKE GRIDVIEW SELECTABLE ###########################################################

    '############################################## BIND TO GRIDVIEW ###########################################################################
    Private Sub family_folder()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " SELECT * from family_album_tbl where family_id= @familyID and album_status='active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_folder.DataSource = dt
        GridView_select_folder.DataBind()
        con.Close()
    End Sub
    '############################################## END OF BIND TO GRIDVIEW ####################################################################

    '############################################## INSERT NEW FOLDER ##########################################################################
    Private Sub btn_new_folder_Click(sender As Object, e As EventArgs) Handles btn_new_folder.Click
        If txtbx_new_folder.Text = "" Then
            lbl_validation.Text = "Enter folder name"
        Else
            insert_folder()
        End If
    End Sub
    Private Sub insert_folder()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into family_album_tbl(album_name , album_pic , album_status , family_id ) values (@name , @pic , 'active' , @familyID )"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@name", txtbx_new_folder.Text)
        sqlCmd1.Parameters.AddWithValue("@pic", "Images/familyAlbumPrev/folderPrev.png")
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        family_folder()
    End Sub
    '############################################## END OF INSERT NEW FOLDER #########################################################################

    '############################################## RENAME FOLDER ####################################################################################
    Private Sub btn_edit_folder_Click(sender As Object, e As EventArgs) Handles btn_edit_folder.Click
        If GridView_select_folder.SelectedIndex = -1 Then
            lbl_validation.Text = "select a folder to rename"
        ElseIf GridView_select_folder.Rows.Count = 0 Then
            lbl_validation.Text = "No folder"
        ElseIf txtbx_edit_folder.Text = "" Then
            lbl_validation.Text = "Enter new folder name to rename"
        Else
            rename_folder()
        End If
    End Sub
    Private Sub rename_folder()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update family_album_tbl set album_name = @name where album_id = @id"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@name", txtbx_edit_folder.Text)
        sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_folder.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        family_folder()
    End Sub
    '############################################## END OF RENAME FOLDER ####################################################################################

    '############################################# DELETE FOLDER ############################################################################################
    Private Sub btn_delete_folder_Click(sender As Object, e As EventArgs) Handles btn_delete_folder.Click
        If GridView_select_folder.SelectedIndex = -1 Then
            lbl_validation.Text = "select a folder to delete"
        ElseIf GridView_select_folder.Rows.Count = 0 Then
            lbl_validation.Text = "No folder"
        Else
            delete_folder()
        End If
    End Sub
    Private Sub delete_folder()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update family_album_tbl set album_status = 'deactive' where album_id = @id"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_folder.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        family_folder()
        GridView_select_folder.SelectedIndex = -1
    End Sub
    '############################################# END OF DELETE FOLDER ####################################################################################

    Private Sub btn_open_folder_Click(sender As Object, e As EventArgs) Handles btn_open_folder.Click
        If GridView_select_folder.SelectedIndex = -1 Then
            lbl_validation.Text = "select a folder to open"
        ElseIf GridView_select_folder.Rows.Count = 0 Then
            lbl_validation.Text = "No folder"
        Else
            Session("album_id") = GridView_select_folder.SelectedRow.Cells(0).Text
            Session("album_name") = GridView_select_folder.SelectedRow.Cells(2).Text
            Response.Redirect("./member_family_album_photo.aspx")
        End If
    End Sub

    '################################################ PAGING IN GRIDVIEW ################################################################################
    Private Sub GridView_select_folder_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_folder.PageIndexChanging
        GridView_select_folder.PageIndex = e.NewPageIndex
        Me.family_folder()
    End Sub
    '################################################ END OF PAGING IN GRIDVIEW ################################################################################


End Class