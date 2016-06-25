Imports System.Data.SqlClient
Imports System.Drawing

Public Class children_home_form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        check_online_validation()
        bind_detail_view_note()
        bind_chart()
        bind_to_gridview_decrease_prod()
    End Sub



    '################################################ THEME SETUP ###########################################################################
    Private Sub children_home_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################################ END OF THEME SETUP ########################################################################

    '################################################# CHECK ONLINE VALIDATION ##################################################################
    Private Sub check_online_validation()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from family_tbl where family_id = @famID and is_activated = 'no'"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Response.Redirect("./children_online_activation.aspx")
            con.Close()
        End If
    End Sub
    '################################################# END OF CHECK ONLINE VALIDATION ##################################################################

    '############################################ VIEW NOTE #########################################################################
    Private Sub bind_detail_view_note()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select note_name  as [Note title] ,  FORMAT(note_date , 'dd/MM/yyyy') as [Date]  , note_descrip as [Description] from note_tbl where family_id = @familyID and note_status = 'active' order by note_date desc "
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
        Dim sql = "select note_id as [ref no] , note_name as [Notes title] , FORMAT(note_date , 'dd/MM/yyyy') as [Date]  , note_descrip as [Notes] from note_tbl where family_id = @familyID and note_status = 'active' order by note_date "
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

    '############################################# BIND DATA TO CHART ###############################################################
    Private Sub bind_chart()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from finance_tbl as f inner join finance_type_tbl as t on f.finance_type_id = t.finance_type_id inner join finance_category_tbl as c on f.finance_category_id = c.finance_category_id inner join finance_mean_payment_tbl as p on p.finance_payment_id = f.finance_payment_id where finance_status='active' and finance_type= 'expense' and family_id = @familyID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_expense.DataSource = dt
        Chart_view_expense.Series("Series2").XValueMember = "finance_category"
        Chart_view_expense.Series("Series2").YValueMembers = "finance_amount"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"
        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_expense.DataBind()
    End Sub
    '############################################# END OF BIND DATA TO CHART ###############################################################

    '############################################### BIND TO GRIDVIEW #####################################################################
    Private Sub bind_to_gridview_decrease_prod()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select product_name as [name] ,sum( product_quantity) as stock from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id =sl.shopping_list_id where purchase_status = 'Purchased' and shopping_list_type='private_list' and family_id = @familyID group by product_name having sum(product_quantity) <= 2 "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_decrease_product.DataSource = dt
        GridView_decrease_product.DataBind()
        con.Close()
    End Sub
    '############################################### BIND TO GRIDVIEW #####################################################################


    Private Sub btn_add_notes_Click(sender As Object, e As EventArgs) Handles btn_add_notes.Click
        Response.Redirect("./children_add_note.aspx")
    End Sub
    Private Sub GridView_decrease_product_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_decrease_product.PageIndexChanging
        GridView_decrease_product.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_decrease_prod()
    End Sub

    Private Sub btn_open_family_album_Click(sender As Object, e As EventArgs) Handles btn_open_family_album.Click
        Response.Redirect("./children_family_album_folder.aspx")
    End Sub
End Class