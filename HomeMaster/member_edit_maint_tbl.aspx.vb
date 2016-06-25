Imports System.Drawing
Imports System.Data.SqlClient

Public Class member_edit_maint_tbl
    Inherits System.Web.UI.Page

    Dim Vmaint_type_id As Integer
    Dim Vdescrip As String
    Dim Vstart_date As String
    Dim Vcompleted_date As String
    Dim Vcost As Decimal
    Dim Vworker As String
    Dim Vmaterial As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_maint_type_ddl()
    End Sub

    '################################### THEME SETUP #############################################################################
    Private Sub member_edit_maint_tbl_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
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
            bind_gridview_property()
        ElseIf ddl_select_obj.SelectedItem.Text = "movable asset" Then
            bind_gridview_movable()
        ElseIf ddl_select_obj.SelectedItem.Text = "--select type--" Then
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
        End If
    End Sub
    Private Sub bind_gridview_property()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select maint_id as [ref no] , maint_descrip as [Description] , FORMAT(date_start , 'dd/MM/yyyy') as [Date start] , FORMAT(date_completion , 'dd/MM/yyyy') as [Date complete]  , maint_cost as [Cost]  , maint_worker as [Worker] , maint_type as [Type] , i_name as [Property name] from maintenance_tbl as m inner join maintenance_type_tbl as t on t.maint_type_id = m.maint_type_id inner join immovable_property_tbl as p on m.i_property_id = p.i_property_id inner join family_tbl as f on p.family_id = f.family_id where maint_status = 'active' and f.family_id = @familyID order by maint_id desc "
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
    Private Sub bind_gridview_movable()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select maint_id as [ref no] , maint_descrip as [Description] , FORMAT(date_start , 'dd/MM/yyyy') as [Date start] , FORMAT(date_completion , 'dd/MM/yyyy') as [Date complete]  , maint_cost as [Cost]  , maint_worker as [Worker] , maint_type as [Type] , m_item_name as [Asset] from maintenance_tbl as m inner join maintenance_type_tbl as t on t.maint_type_id = m.maint_type_id inner join moveable_asset_tbl as a on m.m_asset_id = a.m_asset_id where maint_status = 'active' order by maint_id desc "
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
    '############################################ MAKE GRIDVIEW SELECTABLE #############################################################

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

    '############################################ TRANSFER DATA TO VARIABLES ##################################################
    Private Sub get_data_to_variables()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from maintenance_tbl as m inner join maintenance_type_tbl as t on m.maint_type_id = t.maint_type_id where maint_id = @id"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@id", CInt(GridView_select_propty_asset.SelectedRow.Cells(0).Text))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vmaint_type_id = reader2("maint_type_id")
            Vdescrip = reader2("maint_descrip")
            Vstart_date = reader2("date_start")
            Vcompleted_date = reader2("date_completion")
            Vcost = reader2("maint_cost")
            Vworker = reader2("maint_worker")
            Vmaterial = reader2("matetial_used")
            con2.Close()
        End If
    End Sub
    '############################################ END OF TRANSFER DATA TO VARIABLES ##################################################

    '############################################# UPDATE MAINTENANCE ##################################################################
    Private Sub btn_update_maint_Click(sender As Object, e As EventArgs) Handles btn_update_maint.Click
        If ddl_select_obj.SelectedItem.Text = "--select type--" Then
            lbl_validation.Text = "select type of object"
        ElseIf GridView_select_propty_asset.SelectedIndex = -1 Then
            lbl_validation.Text = "select maintenance from gridview"
        ElseIf validation_completed_date.IsValid = True And validation_maint_cost.IsValid = True And validation_start_date.IsValid = True Then
            get_data_to_variables()
            If Not ddl_maint_type.SelectedItem.Text = "--Select type--" Then
                check_maint_type()
            End If
            If txtbx_maint_desc.Text = "" Then
                txtbx_maint_desc.Text = Vdescrip
            End If
            If txtbx_start_date.Text = "" Then
                txtbx_start_date.Text = Vstart_date
            End If
            If txtbx_completed_date.Text = "" Then
                txtbx_completed_date.Text = Vcompleted_date
            End If
            If txtbx_maint_cost.Text = "" Then
                txtbx_maint_cost.Text = CStr(Vcost)
            End If
            If txtbx_maint_worker.Text = "" Then
                txtbx_maint_worker.Text = Vworker
            End If
            If txtbx_material_used.Text = "" Then
                txtbx_material_used.Text = Vmaterial
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update maintenance_tbl set date_start = convert(date,@date,103) , date_completion = convert(date,@Cdate,103)  , maint_cost = @cost , maint_descrip = @desc , maint_type_id = @typeID , maint_worker = @wrk , matetial_used = @material where maint_id = @id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@id", CInt(GridView_select_propty_asset.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_start_date.Text)
            sqlCmd1.Parameters.AddWithValue("@Cdate", txtbx_completed_date.Text)
            sqlCmd1.Parameters.AddWithValue("@cost", CDec(txtbx_maint_cost.Text))
            sqlCmd1.Parameters.AddWithValue("@desc", txtbx_maint_desc.Text)
            sqlCmd1.Parameters.AddWithValue("@typeID", Vmaint_type_id)
            sqlCmd1.Parameters.AddWithValue("@wrk", txtbx_maint_worker.Text)
            sqlCmd1.Parameters.AddWithValue("@material", txtbx_material_used.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            select_obj()
            txtbx_maint_desc.Text = ""
            txtbx_start_date.Text = ""
            txtbx_completed_date.Text = ""
            txtbx_maint_cost.Text = ""
            txtbx_maint_worker.Text = ""
            txtbx_material_used.Text = ""
            GridView_select_propty_asset.SelectedIndex = -1
            lbl_validation.Text = "maintenance updated"
        End If
    End Sub
    '############################################# END OF UPDATE MAINTENANCE ##################################################################

    '############################################ PAGING FOR GRIDVIEW ############################################################################
    Private Sub GridView_select_propty_asset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_propty_asset.PageIndexChanging
        If ddl_select_obj.SelectedItem.Text = "immovable property" Then
            GridView_select_propty_asset.PageIndex = e.NewPageIndex
            Me.bind_gridview_property()
        ElseIf ddl_select_obj.SelectedItem.Text = "movable asset" Then
            GridView_select_propty_asset.PageIndex = e.NewPageIndex
            Me.bind_gridview_movable()
        End If
    End Sub
    '############################################ END OF PAGING FOR GRIDVIEW ############################################################################
End Class

