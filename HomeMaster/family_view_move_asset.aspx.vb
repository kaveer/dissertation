Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_view_move_asset
    Inherits System.Web.UI.Page

    Dim Vfamily_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_to_gridview_preview_asset()
        End If
        bind_to_deactive_gridview()
        bind_location_ddl()
        bind_category_ddl()
        bind_user_ddl()
    End Sub

    '################################## THEME SETUP #########################################################################
    Private Sub family_view_move_asset_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #################################################################

    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_to_gridview_preview_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name as [Item] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' order by m_asset_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_view_active_preview_assets.DataSource = dt
        GridView_view_active_preview_assets.DataBind()
        con.Close()
    End Sub
    Private Sub bind_active_detailview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] ,  m_item_name as [Name] , m_retailer as [Retailer] , m_current_value as [Current value] , m_purchase_cost as [Purchase cost] , FORMAT(m_purchase_date , 'dd/MM/yyyy') as [Purchase Date]  , m_quantity as [Quantity] , m_make as [Make] , m_model as [Model] , m_serial_num as [Serial no] , m_warrenty_period as [Warrenty period] , m_note as [Note] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' and m_asset_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_active_asset.DataSource = dt
        DetailsView_active_asset.DataBind()
        con.Close()
    End Sub
    Private Sub bind_to_deactive_gridview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name as [Item] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'deactive' order by m_asset_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_deactivated_asset.DataSource = dt
        GridView_deactivated_asset.DataBind()
        con.Close()
    End Sub

    
    '##################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################

    '#################################### MAKE GRIDVIEW SELECTABLE ##################################################################
    Private Sub GridView_view_active_preview_assets_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_view_active_preview_assets.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_view_active_preview_assets, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_view_active_preview_assets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_view_active_preview_assets.SelectedIndexChanged
        For Each row As GridViewRow In GridView_view_active_preview_assets.Rows
            If row.RowIndex = GridView_view_active_preview_assets.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        bind_active_detailview()
        displayImg()
        Panel_view_img.Visible = True
    End Sub

   
    Private Sub GridView_deactivated_asset_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_deactivated_asset.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_deactivated_asset, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub

    
    Private Sub GridView_deactivated_asset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_deactivated_asset.SelectedIndexChanged
        For Each row As GridViewRow In GridView_deactivated_asset.Rows
            If row.RowIndex = GridView_deactivated_asset.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '#################################### END OF MAKE GRIDVIEW SELECTABLE ##################################################################

    '######################################### DISPLAY IMAGE TO REPEATER ###################################################################
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id where p.m_asset_id = @ID and  pic_status = 'active' "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater1.DataSource = myReader
        Repeater1.DataBind()
    End Sub
    Private Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        If e.CommandName = "open_gallery" Then
            Panel_open_gallery.Visible = True
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql As String = "select picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id where p.m_asset_id = @ID and  pic_status = 'active' "
            Dim cmd As New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@ID", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
            Dim myReader As SqlDataReader
            con.Open()
            myReader = cmd.ExecuteReader
            GridView_open_gallery.DataSource = myReader
            GridView_open_gallery.DataBind()
        End If
    End Sub
    '######################################### END OF DISPLAY IMAGE TO REPEATER ###################################################################

    '################################################# SEARCH ASSET #############################################################################
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If ddl_category.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select category"
        ElseIf ddl_location.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select location"
        ElseIf ddl_member_added.SelectedItem.Text = "All members" Then
            clear_detailview()
            clear_repeater()
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select m_asset_id as [ref] ,  m_item_name as [Item] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' and m_location = @location and m_category = @category "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@location", ddl_location.SelectedItem.Text)
            sqlCmd.Parameters.AddWithValue("@category", ddl_category.SelectedItem.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_view_active_preview_assets.DataSource = dt
            GridView_view_active_preview_assets.DataBind()
            con.Close()
            GridView_view_active_preview_assets.SelectedIndex = -1
        Else
            get_family_id()
            clear_detailview()
            clear_repeater()
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select m_asset_id as [ref] ,  m_item_name as [Item] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' and m_location = @location and m_category = @category and family_id = @fam"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@location", ddl_location.SelectedItem.Text)
            sqlCmd.Parameters.AddWithValue("@category", ddl_category.SelectedItem.Text)
            sqlCmd.Parameters.AddWithValue("@fam", Vfamily_id)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_view_active_preview_assets.DataSource = dt
            GridView_view_active_preview_assets.DataBind()
            con.Close()
            GridView_view_active_preview_assets.SelectedIndex = -1
        End If
    End Sub
    Private Sub clear_detailview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name , m_retailer , m_current_value , m_purchase_cost , m_purchase_date , m_quantity , m_make , m_model , m_serial_num , m_warrenty_period , m_note , m_location , m_category , purchase_method from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        dt.Clear()
        DetailsView_active_asset.DataSource = dt
        DetailsView_active_asset.DataSource = Nothing
        DetailsView_active_asset.DataBind()
        con.Close()
    End Sub
    Private Sub clear_repeater()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id  "
        Dim cmd As New SqlCommand(sql, con)
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater1.DataSource = myReader
        Repeater1.DataSource = Nothing
        Repeater1.DataBind()
    End Sub
    Private Sub get_family_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select family_id from user_tbl where username = @username"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@username", ddl_member_added.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vfamily_id = CInt(reader2("family_id"))
            con2.Close()
        End If
    End Sub
    '################################################# END OF SEARCH ASSET #############################################################################

    '########################################### BIND DATA TO DROPDOWNLIST #############################################
    Private Sub bind_location_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from moveable_asset_location_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_location.DataSource = ds
                ddl_location.DataTextField = "m_location"
                ddl_location.DataValueField = "m_location"
                ddl_location.DataBind()
                ddl_location.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_category_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from moveable_asset_category_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_category.DataSource = ds
                ddl_category.DataTextField = "m_category"
                ddl_category.DataValueField = "m_category"
                ddl_category.DataBind()
                ddl_category.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_user_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from user_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_member_added.DataSource = ds
                ddl_member_added.DataTextField = "username"
                ddl_member_added.DataValueField = "username"
                ddl_member_added.DataBind()
                ddl_member_added.Items.Insert(0, New ListItem("All members", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '########################################### END OF BIND DATA TO DROPDOWNLIST #############################################

    Private Sub btn_add_mve_asset_Click(sender As Object, e As EventArgs) Handles btn_add_mve_asset.Click
        Response.Redirect("./family_add_move_asset.aspx")
    End Sub

    '########################################## ACTIVATE AND DEACTIVATE ASSET #################################################
    Private Sub btn_remove_asset_Click(sender As Object, e As EventArgs) Handles btn_remove_asset.Click
        If GridView_view_active_preview_assets.SelectedIndex = -1 Then
            lbl_validation_remove.Text = "select asset to remove"
        Else
            clear_detailview()
            clear_repeater()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update moveable_asset_tbl set m_status = 'deactive' where m_asset_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_view_active_preview_assets.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_to_gridview_preview_asset()
            bind_to_deactive_gridview()
        End If
    End Sub
    Private Sub btn_reactivate_Click(sender As Object, e As EventArgs) Handles btn_reactivate.Click
        If GridView_deactivated_asset.SelectedIndex = -1 Then
            lbl_validation_reactivate.Text = "select asset to reactivate"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update moveable_asset_tbl set m_status = 'active' where m_asset_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_deactivated_asset.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            GridView_deactivated_asset.SelectedIndex = -1
            bind_to_gridview_preview_asset()
            bind_to_deactive_gridview()
        End If
    End Sub
    '########################################## END OF ACTIVATE AND DEACTIVATE ASSET #################################################

    Private Sub btn_add_repayment_Click(sender As Object, e As EventArgs) Handles btn_add_repayment.Click
        Response.Redirect("./fanily_add_mv_asset_repay.aspx")
    End Sub

    '############################################ PAGING FOR GRIDVIEW #################################################################
    Private Sub GridView_view_active_preview_assets_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_view_active_preview_assets.PageIndexChanging
        GridView_view_active_preview_assets.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_preview_asset()
    End Sub
    Private Sub GridView_deactivated_asset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_deactivated_asset.PageIndexChanging
        GridView_deactivated_asset.PageIndex = e.NewPageIndex
        Me.bind_to_deactive_gridview()
    End Sub
    '############################################ END OF PAGING FOR GRIDVIEW #################################################################

    Private Sub btn_close_gallery_Click(sender As Object, e As EventArgs) Handles btn_close_gallery.Click
        Panel_open_gallery.Visible = False
    End Sub
End Class