Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_add_maint
    Inherits System.Web.UI.Page

    Dim Vmaint_type_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_maint_type_ddl()
    End Sub

    '################################### THEME SETUP #############################################################################
    Private Sub family_add_maint_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #############################################################################

    '##################################### BIND DATA TO DROPDOWNLIST ###################################################################
    Private Sub ddl_select_obj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_select_obj.SelectedIndexChanged
        If ddl_select_obj.SelectedItem.Text = "immovable property" Then
            clear_gridview_movable()
            GridView_select_propty_asset.Visible = True
            GridView_select_movable.Visible = False
            gridview_property()
        ElseIf ddl_select_obj.SelectedItem.Text = "movable asset" Then
            clear_gridview_property()
            GridView_select_movable.Visible = True
            GridView_select_propty_asset.Visible = False
            gridview_movable_asset()
        ElseIf ddl_select_obj.SelectedItem.Text = "--select type--" Then
            clear_gridview_property()
            clear_gridview_movable()
        End If
    End Sub
    Private Sub gridview_movable_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [ref] , m_item_name as [Name] , m_location as [Location] , m_category as [Category] , purchase_method as [Purchase method] from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' order by m_asset_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_movable.DataSource = dt
        GridView_select_movable.DataBind()
        con.Close()
    End Sub
    Private Sub gridview_property()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  i_property_id as [ref no] , i_name as [Name] , i_cat_name as [Category] , i_purchase_method as [Purchase method] from immovable_property_tbl as i inner join family_tbl as f on i.family_id = f.family_id inner join immovable_property_category as c on i.i_category_id = c.i_category_id inner join immovable_purchase_method_tbl as p on i.i_purchase_method_id =p.i_purchase_method_id where i.family_id = @familyID and i_status = 'active' order by i_property_id desc "
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
        Dim sql = " select m_asset_id as [ref] , m_item_name , m_location , m_category , purchase_method from moveable_asset_tbl as a inner join moveable_asset_location_tbl as l on a.m_loction_id = l.m_loction_id inner join moveable_asset_category_tbl as c on a.m_category_id = c.m_category_id inner join moveable_asset_purch_mtd_tbl as p on a.m_purchase_method_id = p.m_purchase_method_id where m_status = 'active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_movable.DataSource = dt
        GridView_select_movable.DataSource = Nothing
        GridView_select_movable.DataBind()
        con.Close()
    End Sub
    Private Sub bind_maint_type_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from maintenance_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_maint_type.DataSource = ds
                ddl_maint_type.DataTextField = "maint_type"
                ddl_maint_type.DataValueField = "maint_type"
                ddl_maint_type.DataBind()
                ddl_maint_type.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '##################################### BIND DATA TO DROPDOWNLIST ###################################################################

    '########################################## SAVE DATA/GET ID FROM ALL DROPDOWNLIST ########################################
    Private Sub check_maint_type()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from maintenance_type_tbl where maint_type = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_maint_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vmaint_type_id = reader2("maint_type_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into maintenance_type_tbl(maint_type) values (LOWER(@cat))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@cat", ddl_maint_type.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_maint_type_id()
        End If
    End Sub
    Private Sub get_maint_type_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from maintenance_type_tbl where maint_type = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_maint_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vmaint_type_id = reader2("maint_type_id")
            con2.Close()
        End If
    End Sub
    Private Sub btn_add_maint_type_Click(sender As Object, e As EventArgs) Handles btn_add_maint_type.Click
        If txtbx_add_maint_type.Text = "" Then
            lbl_validation.Text = "enter maintenance type to add"
        Else
            ddl_maint_type.SelectedItem.Text = txtbx_add_maint_type.Text
        End If
    End Sub


    '########################################## SAVE DATA/GET ID FROM ALL DROPDOWNLIST ########################################

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


    Private Sub GridView_select_movable_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_movable.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_movable, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_movable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_movable.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_movable.Rows
            If row.RowIndex = GridView_select_movable.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '############################################ MAKE GRIDVIEW SELECTABLE #############################################################

    '############################################# SAVE MAINENANCE ######################################################################
    Private Sub btn_save_maintenance_Click(sender As Object, e As EventArgs) Handles btn_save_maintenance.Click
        If ddl_select_obj.SelectedItem.Text = "immovable property" Then
            If GridView_select_propty_asset.SelectedIndex = -1 Then
                lbl_validation.Text = "select asset for maintenance"
            ElseIf ddl_maint_type.SelectedItem.Text = "--Select type--" Then
                lbl_validation.Text = "select maintenance type"
            ElseIf txtbx_maint_desc.Text = "" Then
                lbl_validation.Text = "Enter maintenance descrption"
            ElseIf validation_completed_date.IsValid = True And validation_maint_cost.IsValid = True And validation_start_date.IsValid = True Then
                check_maint_type()
                If txtbx_maint_cost.Text = "" Then
                    txtbx_maint_cost.Text = 0
                End If
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "insert into maintenance_tbl(date_start , date_completion , maint_cost , i_property_id , maint_descrip , maint_type_id , maint_worker , matetial_used , maint_status) values (convert(date,@strtdate,103) , convert(date,@compdate,103) , @cost , @id , @desc , @type_id , @wrker , @mtrl , 'active')"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@strtdate", txtbx_start_date.Text)
                sqlCmd1.Parameters.AddWithValue("@compdate", txtbx_completed_date.Text)
                sqlCmd1.Parameters.AddWithValue("@cost", CDec(txtbx_maint_cost.Text))
                sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_propty_asset.SelectedRow.Cells(0).Text))
                sqlCmd1.Parameters.AddWithValue("@desc", txtbx_maint_desc.Text)
                sqlCmd1.Parameters.AddWithValue("@type_id", Vmaint_type_id)
                sqlCmd1.Parameters.AddWithValue("@wrker", txtbx_maint_worker.Text)
                sqlCmd1.Parameters.AddWithValue("@mtrl", txtbx_material_used.Text)
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                GridView_select_propty_asset.SelectedIndex = -1
                lbl_validation.Text = "property maintenance added"
            End If
        ElseIf ddl_select_obj.SelectedItem.Text = "movable asset" Then
            If GridView_select_movable.SelectedIndex = -1 Then
                lbl_validation.Text = "select asset for maintenance"
            ElseIf ddl_maint_type.SelectedItem.Text = "--Select type--" Then
                lbl_validation.Text = "select maintenance type"
            ElseIf txtbx_maint_desc.Text = "" Then
                lbl_validation.Text = "Enter maintenance descrption"
            ElseIf validation_completed_date.IsValid = True And validation_maint_cost.IsValid = True And validation_start_date.IsValid = True Then
                check_maint_type()
                If txtbx_maint_cost.Text = "" Then
                    txtbx_maint_cost.Text = 0
                End If
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "insert into maintenance_tbl(date_start , date_completion , maint_cost , m_asset_id , maint_descrip , maint_type_id , maint_worker , matetial_used , maint_status) values (convert(date,@strtdate,103) , convert(date,@compdate,103) , @cost , @id , @desc , @type_id , @wrker , @mtrl , 'active')"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@strtdate", txtbx_start_date.Text)
                sqlCmd1.Parameters.AddWithValue("@compdate", txtbx_completed_date.Text)
                sqlCmd1.Parameters.AddWithValue("@cost", CDec(txtbx_maint_cost.Text))
                sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_movable.SelectedRow.Cells(0).Text))
                sqlCmd1.Parameters.AddWithValue("@desc", txtbx_maint_desc.Text)
                sqlCmd1.Parameters.AddWithValue("@type_id", Vmaint_type_id)
                sqlCmd1.Parameters.AddWithValue("@wrker", txtbx_maint_worker.Text)
                sqlCmd1.Parameters.AddWithValue("@mtrl", txtbx_material_used.Text)
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                GridView_select_movable.SelectedIndex = -1
                lbl_validation.Text = "movable asset maintenance added"
            End If
        ElseIf ddl_select_obj.SelectedItem.Text = "--select type--" Then
            lbl_validation.Text = "select object for maintenance"
        End If
    End Sub
    '############################################# END OF SAVE MAINENANCE ######################################################################

    '############################################ PAGING FOR GRIDVIEW ############################################################################
    Private Sub GridView_select_movable_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_movable.PageIndexChanging
        GridView_select_movable.PageIndex = e.NewPageIndex
        Me.gridview_movable_asset()
    End Sub
    Private Sub GridView_select_propty_asset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_propty_asset.PageIndexChanging
        GridView_select_propty_asset.PageIndex = e.NewPageIndex
        Me.gridview_property()
    End Sub
    '############################################ END FOR PAGING FOR GRIDVIEW ############################################################################


    Private Sub btn_add_immv_prop_Click(sender As Object, e As EventArgs) Handles btn_add_immv_prop.Click
        Response.Redirect("./family_add_immova_property.aspx")
    End Sub

    Private Sub btn_add_mov_asset_Click(sender As Object, e As EventArgs) Handles btn_add_mov_asset.Click
        Response.Redirect("./family_add_move_asset.aspx")
    End Sub
End Class