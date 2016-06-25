Imports System.Data.SqlClient
Imports System.Drawing

Public Class memeber_view_maint_tbl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '################################### THEME SETUP #############################################################################
    Private Sub memeber_view_maint_tbl_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #############################################################################

    '##################################### BIND DATA TO DROPDOWNLIST ###################################################################
    Private Sub ddl_select_obj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_select_obj.SelectedIndexChanged
        select_obj()
    End Sub
    Private Sub select_obj()
        If ddl_select_obj.SelectedItem.Text = "immovable property" Then
            gridview_property()
            clear_gridview_movable()
        ElseIf ddl_select_obj.SelectedItem.Text = "movable asset" Then
            gridview_movable()
            clear_gridview_property()
        ElseIf ddl_select_obj.SelectedItem.Text = "--select type--" Then
            clear_gridview_property()
            clear_gridview_movable()
        End If
    End Sub
    Private Sub gridview_property()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select maint_id as [ref no] , maint_descrip as [Description] ,  FORMAT(date_start , 'dd/MM/yyyy') as [Date start] ,  FORMAT(date_completion , 'dd/MM/yyyy') as [Date complete] , maint_cost as [Cost]  , maint_worker as [Workers] , maint_type as [Type] , i_name as [Property name] from maintenance_tbl as m inner join maintenance_type_tbl as t on t.maint_type_id = m.maint_type_id inner join immovable_property_tbl as p on m.i_property_id = p.i_property_id inner join family_tbl as f on p.family_id = f.family_id where maint_status = 'active' and f.family_id = @familyID  order by maint_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_propty_asset.DataSource = dt
        GridView_select_propty_asset.DataBind()
        con.Close()
    End Sub
    Private Sub gridview_movable()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select maint_id as [ref no] ,maint_descrip as [Description] ,  FORMAT(date_start , 'dd/MM/yyyy') as [Date start]  , FORMAT(date_completion , 'dd/MM/yyyy') as [Date complete] ,  maint_cost as [Cost]   , maint_worker as [Worker] , maint_type as [Type] , m_item_name as [Assets] from maintenance_tbl as m inner join maintenance_type_tbl as t on t.maint_type_id = m.maint_type_id inner join moveable_asset_tbl as a on m.m_asset_id = a.m_asset_id where maint_status = 'active' order by maint_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_movable_asset.DataSource = dt
        GridView_movable_asset.DataBind()
        con.Close()
    End Sub
    Private Sub clear_gridview_property()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name , m_location , m_category , purchase_method from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_propty_asset.DataSource = dt
        GridView_select_propty_asset.DataSource = Nothing
        GridView_select_propty_asset.DataBind()
        con.Close()
    End Sub
    Private Sub clear_gridview_movable()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select maint_id as [ref no] , maint_descrip , date_start , date_completion , maint_cost  , maint_worker , maint_type , m_item_name from maintenance_tbl as m inner join maintenance_type_tbl as t on t.maint_type_id = m.maint_type_id inner join moveable_asset_tbl as a on m.m_asset_id = a.m_asset_id where maint_status = 'active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_movable_asset.DataSource = dt
        GridView_movable_asset.DataSource = Nothing
        GridView_movable_asset.DataBind()
        con.Close()
    End Sub
    
    '##################################### BIND DATA TO DROPDOWNLIST ###################################################################

    '############################################ MAKE GRIDVIEW SELECTABLE #############################################################
    Private Sub GridView_select_propty_asset_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_propty_asset.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_propty_asset, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_propty_asset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_propty_asset.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_propty_asset.Rows
            If row.RowIndex = GridView_select_propty_asset.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub

    
    Private Sub GridView_movable_asset_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_movable_asset.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_movable_asset, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub

    Private Sub GridView_movable_asset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_movable_asset.SelectedIndexChanged
        For Each row As GridViewRow In GridView_movable_asset.Rows
            If row.RowIndex = GridView_movable_asset.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '############################################ MAKE GRIDVIEW SELECTABLE #############################################################

    '############################################ DELETE MAINTENANCE ############################################################
    Private Sub btn_delete_maint_Click(sender As Object, e As EventArgs) Handles btn_delete_maint.Click
        If ddl_select_obj.SelectedItem.Text = "immovable property" Then
            If GridView_select_propty_asset.SelectedIndex = -1 Then
                lbl_validation.Text = "select maintenace from property to delete"
            Else
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "update maintenance_tbl set maint_status = 'deactive' where maint_id = @id"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_propty_asset.SelectedRow.Cells(0).Text))
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                lbl_validation.Text = "maintenance delete"
                select_obj()
                GridView_select_propty_asset.SelectedIndex = -1
            End If
        ElseIf ddl_select_obj.SelectedItem.Text = "movable asset" Then
            If GridView_movable_asset.SelectedIndex = -1 Then
                lbl_validation.Text = "select maintenace from asset to delete"
            Else
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "update maintenance_tbl set maint_status = 'deactive' where maint_id = @id"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_movable_asset.SelectedRow.Cells(0).Text))
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                lbl_validation.Text = "maintenance delete"
                select_obj()
                GridView_movable_asset.SelectedIndex = -1
            End If
        ElseIf ddl_select_obj.SelectedItem.Text = "--select type--" Then
            lbl_validation.Text = "select maintenance type to  delete"
        End If


       
    End Sub
    '############################################ DELETE MAINTENANCE ############################################################

    '################################################### PAGING FOR GRIDVIEW ######################################################
    Private Sub GridView_select_propty_asset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_propty_asset.PageIndexChanging
        GridView_select_propty_asset.PageIndex = e.NewPageIndex
        Me.gridview_property()
    End Sub
    Private Sub GridView_movable_asset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_movable_asset.PageIndexChanging
        GridView_movable_asset.PageIndex = e.NewPageIndex
        Me.gridview_movable()
    End Sub
    '################################################### END OF PAGING FOR GRIDVIEW ######################################################
End Class