Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_view_immov_property
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_to_gridview_preview_asset()
        End If
        bind_purchase_method_ddl()
        bind_category_ddl()
        bind_to_deactive_gridview()
    End Sub

    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedItem.Value
    End Sub

    '################################## THEME SETUP #########################################################################
    Private Sub family_view_immov_property_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #################################################################

    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_to_gridview_preview_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  i_property_id as [ref no] , i_name as [Name] , i_cat_name as [Category] , i_purchase_method as [Purchase method] from immovable_property_tbl as i inner join family_tbl as f on i.family_id = f.family_id inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id =p.i_purchase_method_id where i.family_id = @familyID and i_status = 'active' order by i_property_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_active_immov.DataSource = dt
        GridView_active_immov.DataBind()
        con.Close()
    End Sub
    Private Sub bind_active_property_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_name as [Name] , i_location as [Location] , i_current_value as [Current value] , i_purchase_cost as [Purchase cost] , FORMAT(i_purchase_date , 'dd/MM/yyyy') as [Purchase date]  , i_length as [Length] , i_width as [Width] , i_note as [Note] , i_cat_name as [Category] , i_purchase_method as [Purchase method]  from immovable_property_tbl as i inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id = p.i_purchase_method_id where i_property_id = @ID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@ID", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_property_detail.DataSource = dt
        DetailsView_property_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_to_gridview_room_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_room_id as [ref no] , i_room_id as [ref no] , room_name as [Room] , room_length as [Length] , room_width as [Width] , room_note as [Note] from immovable_room as r inner join immovable_property_tbl as p on r.i_property_id = p.i_property_id where r.i_property_id = @id and room_status='active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@id", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_room_detail.DataSource = dt
        GridView_room_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_to_deactive_gridview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  i_property_id as [ref no] , i_name as [Name], i_cat_name as [Category] , i_purchase_method as [Purchase method] from immovable_property_tbl as i inner join family_tbl as f on i.family_id = f.family_id inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id =p.i_purchase_method_id where i.family_id = @familyID and i_status = 'deactive' order by i_property_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_deactivated_property.DataSource = dt
        GridView_deactivated_property.DataBind()
        con.Close()
    End Sub
    '##################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################

    '#################################### MAKE GRIDVIEW SELECTABLE ##################################################################
    Private Sub GridView_active_immov_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_active_immov.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_active_immov, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_active_immov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_active_immov.SelectedIndexChanged
        For Each row As GridViewRow In GridView_active_immov.Rows
            If row.RowIndex = GridView_active_immov.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        bind_active_property_detail()
        displayImg()
        bind_to_gridview_room_detail()
    End Sub
    Private Sub GridView_room_detail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_room_detail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_room_detail, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_room_detail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_room_detail.SelectedIndexChanged
        For Each row As GridViewRow In GridView_room_detail.Rows
            If row.RowIndex = GridView_room_detail.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        dispaly_room_img()
    End Sub
    Private Sub GridView_deactivated_property_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_deactivated_property.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_deactivated_property, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_deactivated_property_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_deactivated_property.SelectedIndexChanged
        For Each row As GridViewRow In GridView_deactivated_property.Rows
            If row.RowIndex = GridView_deactivated_property.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '#################################### END OF MAKE GRIDVIEW SELECTABLE ##################################################################

    '##################################### BIND DATA TO ALL REPEATERS #########################################################################
    Private Sub displayImg()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select * from immovable_property_photo_tbl as p inner join immovable_property_tbl as ip on ip.i_property_id = p.i_property_id where ip.i_property_id = @ID and i_pic_status = 'active' "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_property_gallery.DataSource = myReader
        Repeater_property_gallery.DataBind()
    End Sub
    Private Sub dispaly_room_img()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select * from room_photo_tbl as p inner join immovable_room as r on p.i_room_id = r.i_room_id where p.i_room_id = @ID and room_pic_status = 'active' "
        Dim cmd As New SqlCommand(sql, con)
        cmd.Parameters.AddWithValue("@ID", CInt(GridView_room_detail.SelectedRow.Cells(0).Text))
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_room_img.DataSource = myReader
        Repeater_room_img.DataBind()
    End Sub

    '##################################### END OF BIND DATA TO ALL REPEATERS #########################################################################

    '########################################### BIND DATA TO DROPDOWNLIST #############################################
    Private Sub bind_purchase_method_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from immovable_purchase_method_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_purchase_method.DataSource = ds
                ddl_purchase_method.DataTextField = "i_purchase_method"
                ddl_purchase_method.DataValueField = "i_purchase_method"
                ddl_purchase_method.DataBind()
                ddl_purchase_method.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_category_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from immovable_property_category", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_category.DataSource = ds
                ddl_category.DataTextField = "i_cat_name"
                ddl_category.DataValueField = "i_cat_name"
                ddl_category.DataBind()
                ddl_category.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '########################################### END OF BIND DATA TO DROPDOWNLIST #############################################

    '################################################# SEARCH ASSET #############################################################################
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If ddl_category.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select category"
        ElseIf ddl_purchase_method.SelectedItem.Text = "--Select type--" Then
            lbl_validation.Text = "select purchase method"
        Else
            clear_detailview()
            clear_repeater()
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select  i_property_id as [ref no] , i_name , i_cat_name , i_purchase_method from immovable_property_tbl as i inner join family_tbl as f on i.family_id = f.family_id inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id =p.i_purchase_method_id where i.family_id = @familyID and i_status = 'active' and i_cat_name = @category and i_purchase_method = @purM"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@purM", ddl_purchase_method.SelectedItem.Text)
            sqlCmd.Parameters.AddWithValue("@category", ddl_category.SelectedItem.Text)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_active_immov.DataSource = dt
            GridView_active_immov.DataBind()
            con.Close()
            GridView_active_immov.SelectedIndex = -1
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
        DetailsView_property_detail.DataSource = dt
        DetailsView_property_detail.DataSource = Nothing
        DetailsView_property_detail.DataBind()
        con.Close()
        clear_gridview()
    End Sub
    Private Sub clear_gridview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name , m_retailer , m_current_value , m_purchase_cost , m_purchase_date , m_quantity , m_make , m_model , m_serial_num , m_warrenty_period , m_note , m_location , m_category , purchase_method from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        dt.Clear()
        GridView_room_detail.DataSource = dt
        GridView_room_detail.DataSource = Nothing
        GridView_room_detail.DataBind()
        con.Close()
    End Sub
    Private Sub clear_repeater()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql As String = "select picUrl from moveable_asset_photo_tbl as p inner join moveable_asset_tbl as a on a.m_asset_id = p.m_asset_id  "
        Dim cmd As New SqlCommand(sql, con)
        Dim myReader As SqlDataReader
        con.Open()
        myReader = cmd.ExecuteReader
        Repeater_property_gallery.DataSource = myReader
        Repeater_property_gallery.DataSource = Nothing
        Repeater_property_gallery.DataBind()
        Repeater_room_img.DataSource = Nothing
        Repeater_room_img.DataBind()
    End Sub
    '################################################# END OF SEARCH ASSET #############################################################################

    '########################################## ACTIVATE AND DEACTIVATE ASSET #################################################
    Private Sub btn_remove_property_Click(sender As Object, e As EventArgs) Handles btn_remove_property.Click
        If GridView_active_immov.SelectedIndex = -1 Then
            lbl_validation_remove.Text = "select asset to remove"
        Else
            clear_detailview()
            clear_repeater()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update immovable_property_tbl set i_status = 'deactive' where i_property_id = @id  "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_active_immov.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_to_gridview_preview_asset()
            bind_to_deactive_gridview()
        End If
    End Sub
    Private Sub btn_reactivate_Click(sender As Object, e As EventArgs) Handles btn_reactivate.Click
        If GridView_deactivated_property.SelectedIndex = -1 Then
            lbl_validation_reactivate.Text = "select asset to reactivate"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update immovable_property_tbl set i_status = 'active' where i_property_id = @id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_deactivated_property.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            GridView_deactivated_property.SelectedIndex = -1
            bind_to_gridview_preview_asset()
            bind_to_deactive_gridview()
        End If
    End Sub
    '########################################## END OF ACTIVATE AND DEACTIVATE ASSET #################################################


    '############################################ PAGING FOR GRIDVIEW #################################################################
    Private Sub GridView_active_immov_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_active_immov.PageIndexChanging
        GridView_active_immov.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_preview_asset()
    End Sub
    Private Sub GridView_room_detail_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_room_detail.PageIndexChanging
        GridView_room_detail.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_room_detail()
    End Sub
    Private Sub GridView_deactivated_property_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_deactivated_property.PageIndexChanging
        GridView_deactivated_property.PageIndex = e.NewPageIndex
        Me.bind_to_deactive_gridview()
    End Sub
    '############################################ END OF PAGING FOR GRIDVIEW #################################################################



    Private Sub btn_add_repayment_Click(sender As Object, e As EventArgs) Handles btn_add_repayment.Click
        Response.Redirect("./family_add_immov_repay.aspx")
    End Sub


    Private Sub btn_add_immov_property_Click(sender As Object, e As EventArgs) Handles btn_add_immov_property.Click
        Response.Redirect("./family_add_immova_property.aspx")
    End Sub
End Class