Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class children_shoping_list
    Inherits System.Web.UI.Page

    Dim listNameId As Integer
    Dim listName As String
    Dim catID As Integer
    Dim prodID As Integer
    Dim total_amt As Integer
    Dim prod_id_del As Integer
    Dim mark_purchased As Integer
    Dim Vfamily_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'not_postback()

        bind_data_old_main()
        bind_data_category_ddl()
        bind_data_selectProduct_ddl()
        bind_share_to_ddl_postback()
        share_by_grid_bind()
        share_to_grid_bind()
        If Not IsPostBack Then
            bind_data_togrid()
            bind_gridview_mgt_all_prod()
            bind_gridview_mgt_purchase_prod()
        End If
    End Sub

    '#################################### THEME SETUP ################################################################
    Private Sub children_shoping_list_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '######################################## END IF THEME SETUP #######################################################

    '################################# BIND DATA TO DROPDOWN LIST FOR CATEGORY AND PRODUCT #########################
    Private Sub bind_data_selectProduct_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim sql = "select DISTINCT product_name from product_tbl"
                Dim cmd As New SqlCommand(sql, con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_product.DataSource = ds
                ddl_select_product.DataTextField = "product_name"
                ddl_select_product.DataValueField = "product_name"
                ddl_select_product.DataBind()
                ddl_select_product.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_data_category_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select category from product_category_tbl ", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_category_select.DataSource = ds
                ddl_category_select.DataTextField = "category"
                ddl_category_select.DataValueField = "category"
                ddl_category_select.DataBind()
                ddl_category_select.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub after_new_add_category()
        Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("select category from product_category_tbl ", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            ddl_category_select.DataSource = ds
            ddl_category_select.DataTextField = "category"
            ddl_category_select.DataValueField = "category"
            ddl_category_select.DataBind()
            ddl_category_select.Items.Insert(0, New ListItem("--Select type--", "0"))
            con.Close()
            lbl_check_category.Visible = True
            lbl_check_category.Text = "New category added"
            lbl_check_category.ForeColor = Color.Red
            txtbx_new_category.Text = ""
        End Using
    End Sub
    '################################# END OF BIND DATA TO DROPDOWN LIST FOR CATEGORY AND PRODUCT ###################

    '################################ ADD NEW PRODUCT TO DROPDOWNLIST PRODUCT #######################################
    Private Sub btn_add_new_pro_Click(sender As Object, e As EventArgs) Handles btn_add_new_pro.Click

        If txtbx_new_prob.Text = "" Then
            lbl_validation_add_new_prd.Text = "Enter new product name"
        Else
            lbl_validation_add_new_prd.Text = ""
            ddl_select_product.SelectedItem.Text = txtbx_new_prob.Text
            txtbx_new_prob.Text = ""
        End If
    End Sub
    '################################ END OF ADD NEW PRODUCT TO DROPDOWNLIST PRODUCT ################################

    '################################# BIND DATA TO GRIDVIEW  ############################
    Private Sub bind_data_togrid()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount]   from Shopping_list_tbl where family_id = @familyID and shopping_list_type = 'private_list' and list_status = 'active' order by shopping_list_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_private_list.DataSource = dt
        GridView_private_list.DataBind()
        con.Close()
    End Sub
    Private Sub not_postback()
        If Not IsPostBack Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount] , ((estimated_budget - total_amount) + 4000) as test  from Shopping_list_tbl where family_id = @familyID and shopping_list_type = 'private_list' and list_status = 'active'"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_private_list.DataSource = dt
            GridView_private_list.DataBind()
            con.Close()
        End If
    End Sub
    Private Sub bind_detail_list_togrid()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select p.product_id as [refno] , product_name as [product] , unit_price as [unit price] , product_quantity as [quantity] , (unit_price * product_quantity) as [total price] , category , purchase_status as [Purchase status] from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id inner join shopping_product_tbl as s on s.product_id = p.product_id inner join Shopping_list_tbl as l on l.shopping_list_id = s.shopping_list_id inner join family_tbl as f on f.family_id = l.family_id inner join user_tbl as u on u.family_id = f.family_id where list_name = @listname and l.shopping_list_id = @listID and f.family_id = @familyID and u.username = @username order by product_name"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@username", Session("user"))
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_list_detail.DataSource = dt
        GridView_list_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_mgt_all_prod()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select p.product_id as [ref no] , product_name as [product] , unit_price as [unit price] , product_quantity as [quantity] , (unit_price * product_quantity) as [total] , list_name as [list name] , category from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id=sl.shopping_list_id inner join product_category_tbl as c on c.category_id= p.category_id where purchase_status = 'not purchased' and family_id = @familyID and shopping_list_type='private_list' order by product_name "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_mgt_all_not_pur_prods.DataSource = dt
        GridView_mgt_all_not_pur_prods.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_mgt_purchase_prod()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select p.product_id as [ref no] , product_name as [product]  , unit_price as [unit price] , product_quantity as [quantity] , (unit_price * product_quantity) as [total] , list_name as [list name] , category from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id=sl.shopping_list_id inner join product_category_tbl as c on c.category_id= p.category_id where purchase_status = 'Purchased' and family_id = @familyID and shopping_list_type='private_list' order by product_name "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_purchased_product.DataSource = dt
        GridView_purchased_product.DataBind()
        con.Close()
    End Sub
    '################################# END OF BIND DATA TO GRIDVIEW ######################

    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedItem.Value
    End Sub

    '########################################## PAGING IN GRIDVIEW ############################################################################################
    Private Sub GridView_private_list_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_private_list.PageIndexChanging
        GridView_private_list.PageIndex = e.NewPageIndex
        Me.bind_data_togrid()
    End Sub
    Private Sub GridView_list_detail_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_list_detail.PageIndexChanging
        GridView_list_detail.PageIndex = e.NewPageIndex
        Me.bind_detail_list_togrid()
    End Sub
    Private Sub GridView_shared_by_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_shared_by.PageIndexChanging
        GridView_shared_by.PageIndex = e.NewPageIndex
        Me.share_by_grid_bind()
    End Sub
    Private Sub GridView_shared_to_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_shared_to.PageIndexChanging
        GridView_shared_to.PageIndex = e.NewPageIndex
        Me.share_to_grid_bind()
    End Sub
    Private Sub grid_view_share_to_pro_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grid_view_share_to_pro.PageIndexChanging
        grid_view_share_to_pro.PageIndex = e.NewPageIndex
        Me.bind_data_to_share_to_product()
    End Sub
    Private Sub GridView_old_main_list_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_old_main_list.PageIndexChanging
        GridView_old_main_list.PageIndex = e.NewPageIndex
        Me.bind_data_old_main()
    End Sub
    Private Sub GridView_sub_old_list_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_sub_old_list.PageIndexChanging
        GridView_sub_old_list.PageIndex = e.NewPageIndex
        Me.bind_to_sub_old_list()
    End Sub
    Private Sub GridView_mgt_all_not_pur_prods_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_mgt_all_not_pur_prods.PageIndexChanging
        GridView_mgt_all_not_pur_prods.PageIndex = e.NewPageIndex
        Me.bind_gridview_mgt_all_prod()
    End Sub
    Private Sub GridView_purchased_product_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_purchased_product.PageIndexChanging
        GridView_purchased_product.PageIndex = e.NewPageIndex
        Me.bind_gridview_mgt_purchase_prod()
    End Sub
    '########################################## END OF PAGING IN GRIDVIEW ############################################################################################

    '############################################## MAKE GRIDVIEW LIST SELECTABLE ########################################
    Private Sub GridView_private_list_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_private_list.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_private_list, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_private_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_private_list.SelectedIndexChanged
        For Each row As GridViewRow In GridView_private_list.Rows
            If row.RowIndex = GridView_private_list.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next

        panel_list_detail.Visible = True

        listNameId = CInt(GridView_private_list.SelectedRow.Cells(0).Text)
        listName = GridView_private_list.SelectedRow.Cells(1).Text
        GridView_list_detail.SelectedIndex = -1
        bind_detail_list_togrid()
    End Sub
    Private Sub GridView_mgt_all_not_pur_prods_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_mgt_all_not_pur_prods.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_mgt_all_not_pur_prods, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_mgt_all_not_pur_prods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_mgt_all_not_pur_prods.SelectedIndexChanged
        For Each row As GridViewRow In GridView_mgt_all_not_pur_prods.Rows
            If row.RowIndex = GridView_mgt_all_not_pur_prods.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub GridView_purchased_product_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_purchased_product.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_purchased_product, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_purchased_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_purchased_product.SelectedIndexChanged
        For Each row As GridViewRow In GridView_purchased_product.Rows
            If row.RowIndex = GridView_purchased_product.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub GridView_list_detail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_list_detail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_list_detail, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_list_detail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_list_detail.SelectedIndexChanged
        For Each row As GridViewRow In GridView_list_detail.Rows
            If row.RowIndex = GridView_list_detail.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '############################################## END OF MAKE GRIDVIEW LIST SELECTABLE ########################################

    '############################################## ADD NEW CATEGORY ####################################################
    Private Sub btn_new_category_Click(sender As Object, e As EventArgs) Handles btn_new_category.Click
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from product_category_tbl where category = LOWER(@newCat) "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@newCat", txtbx_new_category.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            lbl_check_category.Visible = True
            lbl_check_category.Text = "already in the list"
            lbl_check_category.ForeColor = Color.Red
            txtbx_new_category.Text = ""
        ElseIf reader.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into product_category_tbl(category) values (LOWER(@newCat))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@newCat", txtbx_new_category.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            after_new_add_category()
        End If
    End Sub
    '############################################## END OF ADD NEW CATEGORY ####################################################

    '############################################# ADD NEW PRODUCT ##########################################################
    Private Sub btn_add_new_product_Click(sender As Object, e As EventArgs) Handles btn_add_new_product.Click
        If ddl_category_select.SelectedIndex = 0 Then
            lbl_validation_all.Text = " No category selected"

        ElseIf ddl_select_product.SelectedItem.Text = "--Select type--" Then
            lbl_validation_all.Text = "no product name selected"

        ElseIf txtbx_unit_price.Text = "" Then
            lbl_validation_all.Text = "enter Unit price"
        ElseIf txtbx_quantity.Text = "" Then
            lbl_validation_all.Text = "enter quantity"
        ElseIf validation_for_unitP.IsValid = True And validation_for_quan.IsValid = True Then

            add_product_by_ddl()
            bind_gridview_mgt_all_prod()
            bind_gridview_mgt_purchase_prod()
        End If
    End Sub
    Private Sub add_product_by_ddl()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " SELECT * FROM product_tbl WHERE product_name = LOWER(@prodname) "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@prodname", ddl_select_product.SelectedItem.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            check_product_from_tbl()
        ElseIf reader.Read() = False Then
            get_catID()
            insert_product()
            get_prod_id()
            insert_shp_prd_tbl()
            bind_detail_list_togrid()
            update_date()
            reload_product_ddl()
            lbl_validation_all.Text = "New product added to this list "
            'Label4.Text = prodID.ToString
        End If
        con.Close()
    End Sub
    Private Sub check_product_from_tbl()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sl.shopping_list_id = sp.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where product_name = @prodname and f.family_id = @familyID and sl.shopping_list_id = @listID and sl.list_name = @listname "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@prodname", ddl_select_product.SelectedItem.Text)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            lbl_validation_all.Text = "Product already in this list"
        ElseIf reader.Read() = False Then
            get_catID()
            insert_product()
            get_prod_id()
            insert_shp_prd_tbl()
            bind_detail_list_togrid()
            update_date()
            reload_product_ddl()
            lbl_validation_all.Text = "New product added to this list "
        End If
    End Sub
    Private Sub get_catID()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select category_id from product_category_tbl where category = @catID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@catID", ddl_category_select.SelectedItem.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            catID = CInt(reader("category_id"))
        End If
    End Sub
    Private Sub insert_product()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into product_tbl(product_name , unit_price , product_quantity , category_id , purchase_status) values (LOWER(@prodName) , @unit , @quan , @catID , 'not purchased')"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodName", ddl_select_product.SelectedItem.Text)
        sqlCmd1.Parameters.AddWithValue("@unit", txtbx_unit_price.Text)
        sqlCmd1.Parameters.AddWithValue("@quan", txtbx_quantity.Text)
        sqlCmd1.Parameters.AddWithValue("@catID", catID)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub get_prod_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from product_tbl where product_name = LOWER(@prodName) and unit_price = @unit and product_quantity = @quan and category_id = @catID  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@prodName", ddl_select_product.SelectedItem.Text)
        sqlCmd.Parameters.AddWithValue("@unit", txtbx_unit_price.Text)
        sqlCmd.Parameters.AddWithValue("@quan", txtbx_quantity.Text)
        sqlCmd.Parameters.AddWithValue("@catID", catID)
        'and f.family_id = @familyID and sl.shopping_list_id = @listID and sl.list_name = @listname
        'sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        'sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        'sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            prodID = CInt(reader("product_id"))
        ElseIf reader.Read() = False Then

        End If
    End Sub
    Private Sub insert_shp_prd_tbl()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into shopping_product_tbl(shopping_list_id, product_id ) values ( @shpID, @prodID  )"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodID", prodID)
        sqlCmd1.Parameters.AddWithValue("@shpID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub update_date()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update Shopping_list_tbl set date_updated = @date where shopping_list_id = @shpID and list_name = @listname "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@date", DateAndTime.Now)
        sqlCmd1.Parameters.AddWithValue("@shpID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        sqlCmd1.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub reload_product_ddl()
        Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            con.Open()
            Dim sql = "select DISTINCT product_name from product_tbl"
            Dim cmd As New SqlCommand(sql, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            ddl_select_product.DataSource = ds
            ddl_select_product.DataTextField = "product_name"
            ddl_select_product.DataValueField = "product_name"
            ddl_select_product.DataBind()
            ddl_select_product.Items.Insert(0, New ListItem("--Select type--", "0"))
            con.Close()
        End Using
    End Sub
    '############################################# END OF ADD NEW PRODUCT ##########################################################

    '############################################### CALCULATE TOTAL OF EACH LIST ####################################
    Private Sub total_of_list()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select sum((unit_price * product_quantity))as total  from product_tbl as p inner join shopping_product_tbl as s on p.product_id = s.product_id inner join Shopping_list_tbl as sl on s.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on f.family_id = sl.family_id where list_name = @listname and f.family_id = @familyID and s.shopping_list_id = @listID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            If GridView_list_detail.Rows.Count = 0 Then
                lbl_total_cost.Text = "no prodeuct to calculate amount"
            Else
                total_amt = CInt(reader("total"))
                lbl_total_cost.Text = total_amt.ToString
            End If
        ElseIf reader.Read() = False Then
        End If
    End Sub
    Private Sub update_amount()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update Shopping_list_tbl set total_amount = @totalAMT where list_name = @listnam and shopping_list_id = @listID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@totalAMT", total_amt)
        sqlCmd1.Parameters.AddWithValue("@listnam", GridView_private_list.SelectedRow.Cells(1).Text)
        sqlCmd1.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        bind_data_togrid()
    End Sub
    Private Sub Btn_check_total_Click(sender As Object, e As EventArgs) Handles Btn_check_total.Click
        lbl_cost_msg.Visible = True
        lbl_total_cost.Visible = True
        total_of_list()
        update_amount()

    End Sub
    '############################################## END OF CALCULATE TOTAL OF EACH LIST #############################

    Private Sub link_add_new_product_Click(sender As Object, e As EventArgs) Handles link_add_new_product.Click
        If panel_add_new_product.Visible = False Then
            panel_add_new_product.Visible = True
        ElseIf panel_add_new_product.Visible = True Then
            panel_add_new_product.Visible = False
        End If
    End Sub

    '############################################## DELETE FROM PRIVATE/MAIN LIST ####################################
    Private Sub Btn_delete_list_Click(sender As Object, e As EventArgs) Handles Btn_delete_list.Click
        If GridView_private_list.SelectedIndex = -1 Then
            Label3.Text = "  Select a row to delete"
        ElseIf GridView_private_list.Rows.Count = 0 Then

            Label3.Text = "No more list to delete"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " UPDATE Shopping_list_tbl set list_status = 'deactive' where family_id =  @familyID and shopping_list_id = @shplistID and list_name = @listName "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@shplistID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@listName", GridView_private_list.SelectedRow.Cells(1).Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()

            bind_data_togrid()
            Response.Redirect("./children_shoping_list.aspx")
            'delete_batch_prod()
        End If

    End Sub
    '######################################## END OF DELETE FROM PRIVATE/MAIN LIST ####################################

    '################################### DELETE A PRODUCT FROM DETAIL LIST OF PRODUCT GRIDVIEW ##########################
    Private Sub btn_delete_product_Click(sender As Object, e As EventArgs) Handles btn_delete_product.Click
        If GridView_list_detail.SelectedIndex = -1 Then
            lbl_validation_detail_lst.Visible = True
            lbl_validation_detail_lst.Text = "  Select a row to delete"
        ElseIf GridView_list_detail.Rows.Count = 0 Then
            lbl_validation_detail_lst.Visible = True
            lbl_validation_detail_lst.Text = "  No more product in this list"
        Else
            get_product_id()
        End If
    End Sub
    Private Sub delete_product()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "delete from shopping_product_tbl where shopping_list_id = @shopID and product_id = @prodId "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@shopID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        sqlCmd1.Parameters.AddWithValue("@prodId", prod_id_del)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub get_product_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select p.product_id , product_name from product_tbl as p inner join shopping_product_tbl as s on p.product_id = s.product_id inner join Shopping_list_tbl as sl on s.shopping_list_id = sl.shopping_list_id where list_name = @listName and sl.shopping_list_id = @listID and product_name = @prodName and p.product_id = @prodid "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@prodid", GridView_list_detail.SelectedRow.Cells(0).Text)
        sqlCmd.Parameters.AddWithValue("@prodName", GridView_list_detail.SelectedRow.Cells(1).Text)
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@listName", GridView_private_list.SelectedRow.Cells(1).Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            prod_id_del = CInt(reader("product_id"))
            delete_product()
            bind_detail_list_togrid()
            GridView_list_detail.SelectedIndex = -1
        End If
    End Sub
    '############################ END OF DELETE A PRODUCT FROM DETAIL LIST OF PRODUCT GRIDVIEW ##########################



    '##################################### BIND DATA TO OLD MAIN LIST GRIDVIEW ##########################################
    Private Sub bind_data_old_main()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount]  from Shopping_list_tbl where family_id = @familyID and shopping_list_type = 'private_list' and list_status = 'deactive'"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_old_main_list.DataSource = dt
        GridView_old_main_list.DataBind()
        con.Close()
    End Sub


    '##################################### END OF BIND DATA TO OLD MAIN LIST GRIDVIEW ##########################################

    '###################################### MAKE OLD MAIN LIST GRIDVIEW SELECTABLE ##############################################
    Private Sub GridView_old_main_list_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_old_main_list.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_old_main_list, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_old_main_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_old_main_list.SelectedIndexChanged
        For Each row As GridViewRow In GridView_old_main_list.Rows
            If row.RowIndex = GridView_old_main_list.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        GridView_sub_old_list.Visible = True
        bind_to_sub_old_list()
        'panel_list_detail.Visible = True

        'listNameId = CInt(GridView_private_list.SelectedRow.Cells(0).Text)
        'listName = GridView_private_list.SelectedRow.Cells(1).Text

        'bind_detail_list_togrid()
    End Sub
    '###################################### END OF MAKE OLD MAIN LIST GRIDVIEW SELECTABLE ##############################################

    '################################### BIND DATA TO SUB OLD LIST GRIDVIEW ##################################################
    Private Sub bind_to_sub_old_list()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select product_name as [product] , unit_price as [unit price] , product_quantity as [quantity] , (unit_price * product_quantity) as [total price] , category from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id inner join shopping_product_tbl as s on s.product_id = p.product_id inner join Shopping_list_tbl as l on l.shopping_list_id = s.shopping_list_id inner join family_tbl as f on f.family_id = l.family_id inner join user_tbl as u on u.family_id = f.family_id where list_name = @listname and l.shopping_list_id = @listID and f.family_id = @familyID and u.username = @username "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@username", Session("user"))
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_old_main_list.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@listname", GridView_old_main_list.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_sub_old_list.DataSource = dt
        GridView_sub_old_list.DataBind()
        con.Close()
    End Sub
    '################################### END BIND DATA TO SUB OLD LIST GRIDVIEW ##################################################

    '################################### RESTORE OLD LIST #####################################################################
    Private Sub btn_restore_Click(sender As Object, e As EventArgs) Handles btn_restore.Click
        If GridView_old_main_list.SelectedIndex = -1 Then
            Label3.Text = "  Select a row to delete"
        ElseIf GridView_old_main_list.Rows.Count = 0 Then
            Label3.Text = "No more list to delete"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " UPDATE Shopping_list_tbl set list_status = 'active' where family_id =  @familyID and shopping_list_id = @shplistID and list_name = @listName "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@shplistID", CInt(GridView_old_main_list.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@listName", GridView_old_main_list.SelectedRow.Cells(1).Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            GridView_old_main_list.SelectedIndex = -1
            bind_data_old_main()
            GridView_sub_old_list.Visible = False
            bind_data_togrid()
            'Response.Redirect("./member_shop_list_form.aspx")
            'delete_batch_prod()
        End If
    End Sub
    '################################### END OFF RESTORE OLD LIST #####################################################################

    '########################################### MARK A PRODUCT AS PURCHASED ############################################################
    Private Sub btn_mark_purchased_Click(sender As Object, e As EventArgs) Handles btn_mark_purchased.Click
        If GridView_list_detail.SelectedIndex = -1 Then
            lbl_validation_detail_lst.Visible = True
            lbl_validation_detail_lst.Text = "  Select a product to mark as purchased"
        ElseIf GridView_list_detail.Rows.Count = 0 Then
            lbl_validation_detail_lst.Visible = True
            lbl_validation_detail_lst.Text = "  No product in this list"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select p.product_id , product_name from product_tbl as p inner join shopping_product_tbl as s on p.product_id = s.product_id inner join Shopping_list_tbl as sl on s.shopping_list_id = sl.shopping_list_id where list_name = @listName and sl.shopping_list_id = @listID and product_name = @prodName and p.product_id = @prodid"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@prodid", GridView_list_detail.SelectedRow.Cells(0).Text)
            sqlCmd.Parameters.AddWithValue("@prodName", GridView_list_detail.SelectedRow.Cells(1).Text)
            sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
            sqlCmd.Parameters.AddWithValue("@listName", GridView_private_list.SelectedRow.Cells(1).Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                mark_purchased = CInt(reader("product_id"))
                update_mark_purchased()
                bind_detail_list_togrid()
                GridView_list_detail.SelectedIndex = -1
                bind_gridview_mgt_all_prod()
                bind_gridview_mgt_purchase_prod()
            End If
        End If
    End Sub
    Private Sub update_mark_purchased()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update product_tbl set purchase_status = 'Purchased' where product_id = @prodId "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodId", mark_purchased)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '########################################### END OF MARK A PRODUCT AS PURCHASED ############################################################

    Private Sub btn_view_by_cat_Click(sender As Object, e As EventArgs) Handles btn_view_by_cat.Click
        Response.Redirect("./children_view_by_category.aspx")
    End Sub

    '########################################### SORTING FOR  DETAIL LIST ####################################################
    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click
        If ddl_sort_detail_list.SelectedIndex = 0 Then
            lbl_validation_sorting.Text = "select sorting method"
        ElseIf ddl_sort_detail_list.SelectedIndex = 1 Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select p.product_id as [Ref no] , product_name as [Products] , unit_price as [Unit price] , product_quantity as [Quantity]  , (unit_price * product_quantity) as [total price] , category , purchase_status as [Purchase status] from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id inner join shopping_product_tbl as s on s.product_id = p.product_id inner join Shopping_list_tbl as l on l.shopping_list_id = s.shopping_list_id inner join family_tbl as f on f.family_id = l.family_id inner join user_tbl as u on u.family_id = f.family_id where list_name = @listname and l.shopping_list_id = @listID and f.family_id = @familyID and u.username = @username order by product_name "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@username", Session("user"))
            sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
            sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_list_detail.DataSource = dt
            GridView_list_detail.DataBind()
            con.Close()
        ElseIf ddl_sort_detail_list.SelectedIndex = 2 Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select p.product_id as [Ref no] , product_name as [Products] , unit_price as [Unit price] , product_quantity as [Quantity]  , (unit_price * product_quantity) as [total price] , category , purchase_status as [Purchase status] from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id inner join shopping_product_tbl as s on s.product_id = p.product_id inner join Shopping_list_tbl as l on l.shopping_list_id = s.shopping_list_id inner join family_tbl as f on f.family_id = l.family_id inner join user_tbl as u on u.family_id = f.family_id where list_name = @listname and l.shopping_list_id = @listID and f.family_id = @familyID and u.username = @username order by category "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@username", Session("user"))
            sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
            sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_list_detail.DataSource = dt
            GridView_list_detail.DataBind()
            con.Close()
        End If
    End Sub
    '########################################### END OF SORTING FOR  DETAIL LIST ####################################################

    '################################################# SEARCH ################################################################
    Private Sub btn_search_private_list_Click(sender As Object, e As EventArgs) Handles btn_search_private_list.Click
        If txtbx_search.Text = "" Then
            Label3.Text = "Enter something to search"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount] , ((estimated_budget - total_amount) + 4000) as test  from Shopping_list_tbl where family_id = @familyID and shopping_list_type = 'private_list' and list_status = 'active' and list_name like '%' + @search + '%' "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@search", txtbx_search.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_private_list.DataSource = dt
            GridView_private_list.DataBind()
            con.Close()
        End If
    End Sub
    Private Sub btn_search_detail_ist_Click(sender As Object, e As EventArgs) Handles btn_search_detail_ist.Click
        If txtbx_search_detail_list.Text = "" Then
            lbl_validation_all.Text = "Enter something to search"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select p.product_id , product_name , unit_price , product_quantity , (unit_price * product_quantity) as [total price] , category , purchase_status as [Purchase status] from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id inner join shopping_product_tbl as s on s.product_id = p.product_id inner join Shopping_list_tbl as l on l.shopping_list_id = s.shopping_list_id inner join family_tbl as f on f.family_id = l.family_id inner join user_tbl as u on u.family_id = f.family_id where list_name = @listname and l.shopping_list_id = @listID and f.family_id = @familyID and u.username = @username and product_name like '%' + @search + '%' "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@username", Session("user"))
            sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
            sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
            sqlCmd.Parameters.AddWithValue("@search", txtbx_search_detail_list.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_list_detail.DataSource = dt
            GridView_list_detail.DataBind()
            con.Close()
        End If
    End Sub
    '################################################# END OF SEARCH ################################################################

    Private Sub btn_share_list_Click(sender As Object, e As EventArgs) Handles btn_share_list.Click
        If GridView_private_list.SelectedIndex = -1 Then
            Label3.Text = "select a list to share"
        Else
            panel_share_to.Visible = True
        End If

    End Sub

    '############################################ BIND DATA TO SHARE_TO DROPDOWNLIST ################################################
    Private Sub bind_share_to_ddl_postback()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select username from user_tbl where not username = @username and not family_id = @famID ", con)
                cmd.Parameters.AddWithValue("@username", Session("user"))
                cmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_share_to.DataSource = ds
                ddl_share_to.DataTextField = "username"
                ddl_share_to.DataValueField = "username"
                ddl_share_to.DataBind()
                ddl_share_to.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub after_postback_bind_shareTo()
        Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("select username from user_tbl where not username = @username and not family_id = @famID ", con)
            cmd.Parameters.AddWithValue("@username", Session("user"))
            cmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            ddl_share_to.DataSource = ds
            ddl_share_to.DataTextField = "username"
            ddl_share_to.DataValueField = "username"
            ddl_share_to.DataBind()
            ddl_share_to.Items.Insert(0, New ListItem("--Select type--", "0"))
            con.Close()
        End Using
    End Sub
    '############################################ END OF BIND DATA TO SHARE_TO DROPDOWNLIST ################################################

    '################################################ SHARE TO OPTION ####################################################################
    Private Sub btn_share_to_Click(sender As Object, e As EventArgs) Handles btn_share_to.Click
        If ddl_share_to.SelectedIndex = 0 Then
            lbl_validation_share_to.Text = "Select user to share with"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update Shopping_list_tbl set shopping_list_type = 'shared' , shared_by = @username , shared_to = @shareto , shared_notif = 'notify' where list_name = @listName and shopping_list_id = @shoplist_id and family_id = @famID"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@username", Session("user"))
            sqlCmd1.Parameters.AddWithValue("@shareto", ddl_share_to.SelectedItem.Text)
            sqlCmd1.Parameters.AddWithValue("@listName", GridView_private_list.SelectedRow.Cells(1).Text)
            sqlCmd1.Parameters.AddWithValue("@shoplist_id", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_data_togrid()
            get_family_id()
            GridView_private_list.SelectedIndex = -1
            panel_share_to.Visible = False
            panel_list_detail.Visible = False
        End If
    End Sub
    Private Sub get_family_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from user_tbl  as u inner join family_tbl as f on f.family_id = u.family_id where username = @shareto "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@shareto", ddl_share_to.SelectedItem.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vfamily_id = CInt(reader("family_id"))
        End If
        update_member_notif_status()
    End Sub
    Private Sub update_member_notif_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update family_tbl set noti_status = 'new-notif' where family_id = @famID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@famID", Vfamily_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################################ END OF SHARE TO OPTION ####################################################################

    '############################################### BIND DATA TO SHARE BY GRIDVIEW(RECEIVE FROM) ################################################
    Private Sub share_by_grid_bind()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount] , shared_by as [ Receive from ] from Shopping_list_tbl where shopping_list_type = 'shared' and shared_to = @shareTo  and list_status = 'active'"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@shareTo", Session("user"))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_shared_by.DataSource = dt
        GridView_shared_by.DataBind()
        con.Close()
    End Sub
    '############################################### END OF BIND DATA TO SHARE BY GRIDVIEW(RECEIVE FROM) ################################################

    '################################################### BIND TO SHARE TO(SENT T0) GRIDVIEW #########################################################
    Private Sub share_to_grid_bind()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount] , shared_to as [ Sent to ] from Shopping_list_tbl where shared_by = @shareby  and list_status = 'active' and shopping_list_type = 'shared'"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@shareby", Session("user"))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_shared_to.DataSource = dt
        GridView_shared_to.DataBind()
        con.Close()
    End Sub


    '################################################### END OF BIND TO SHARE TO(SENT T0) GRIDVIEW #########################################################

    '################################################### MAKE GRIDVIEW SHARE BY(RECEIVE FROM) SELECTABLE ##################################################
    Private Sub GridView_shared_by_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_shared_by.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_shared_by, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_shared_by_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_shared_by.SelectedIndexChanged
        For Each row As GridViewRow In GridView_shared_by.Rows
            If row.RowIndex = GridView_shared_by.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '################################################### END OF MAKE GRIDVIEW SHARE BY(RECEIVE FROM) SELECTABLE ##################################################

    '####################################################### SAVE SHARED BY LIST ##################################################################################
    Private Sub btn_save_shared_by_Click(sender As Object, e As EventArgs) Handles btn_save_shared_by.Click
        If GridView_shared_by.SelectedIndex = -1 Then
            lbl_validation_share_by.Text = "select a list to save"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update Shopping_list_tbl set shopping_list_type = 'private_list' , family_id = @famID where list_name = @listName and shopping_list_id = @shoplist_id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@username", Session("user"))
            sqlCmd1.Parameters.AddWithValue("@listName", GridView_shared_by.SelectedRow.Cells(1).Text)
            sqlCmd1.Parameters.AddWithValue("@shoplist_id", CInt(GridView_shared_by.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            share_by_grid_bind()
            GridView_shared_by.SelectedIndex = -1
            bind_data_togrid()
        End If
    End Sub


    '####################################################### END OF SAVE SHARED BY LIST ##################################################################################


    '################################################### MAKE GRIDVIEW SHARE TO(SENT TO) SELECTABLE ##################################################
    Private Sub GridView_shared_to_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_shared_to.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_shared_to, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub

    Private Sub GridView_shared_to_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_shared_to.SelectedIndexChanged
        For Each row As GridViewRow In GridView_shared_to.Rows
            If row.RowIndex = GridView_shared_to.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        panel_shared_to_product.Visible = True
        bind_data_to_share_to_product()
    End Sub
    Private Sub bind_data_to_share_to_product()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select product_name as [Name] , unit_price [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , category , purchase_status as [Purchase status] from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id inner join shopping_product_tbl as s on s.product_id = p.product_id inner join Shopping_list_tbl as l on l.shopping_list_id = s.shopping_list_id inner join family_tbl as f on f.family_id = l.family_id inner join user_tbl as u on u.family_id = f.family_id where list_name = @listname and l.shopping_list_id = @listID and f.family_id = @familyID and u.username = @username "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@username", Session("user"))
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_shared_to.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@listname", GridView_shared_to.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        grid_view_share_to_pro.DataSource = dt
        grid_view_share_to_pro.DataBind()
        con.Close()
    End Sub
    '################################################### END OF MAKE GRIDVIEW SHARE TO(SENT TO) SELECTABLE ##################################################

    '################################################# MARK PRODUCT AS PURCHASE FROM MANAGE PRODUCT #####################################################
    Private Sub btn_mark_pur_mgt_all_prd_Click(sender As Object, e As EventArgs) Handles btn_mark_pur_mgt_all_prd.Click
        If GridView_mgt_all_not_pur_prods.SelectedIndex = -1 Then
            lbl_validation_view4.Text = "select a product"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update product_tbl set purchase_status = 'Purchased' where product_id = @prodId "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_mgt_all_not_pur_prods.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_mgt_all_prod()
            bind_gridview_mgt_purchase_prod()
        End If
    End Sub
    Private Sub btn_mark_as_not_purchase_Click(sender As Object, e As EventArgs) Handles btn_mark_as_not_purchase.Click
        If GridView_purchased_product.SelectedIndex = -1 Then
            lbl_validation_view4_1.Text = "select a product"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update product_tbl set purchase_status = 'not purchased' where product_id = @prodId "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_purchased_product.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_mgt_all_prod()
            bind_gridview_mgt_purchase_prod()
        End If
    End Sub
    '################################################# END OF MARK PRODUCT AS PURCHASE FROM MANAGE PRODUCT #####################################################

    '################################################ DELETE FROM MANAGE PRODUCT #########################################################################
    Private Sub btn_delete_pur_mgt_all_prd_Click(sender As Object, e As EventArgs) Handles btn_delete_pur_mgt_all_prd.Click
        If GridView_mgt_all_not_pur_prods.SelectedIndex = -1 Then
            lbl_validation_view4.Text = "select product"
        Else
            delete_from_shop_prod_list()
        End If

    End Sub
    Private Sub delete_from_shop_prod_list()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "DELETE from shopping_product_tbl where product_id = @prodId "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_mgt_all_not_pur_prods.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        delete_from_prod_tbl()
    End Sub
    Private Sub delete_from_prod_tbl()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "delete from product_tbl where product_id = @prodId "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_mgt_all_not_pur_prods.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        bind_gridview_mgt_all_prod()
    End Sub
    Private Sub btn_delete_purchased_prod_Click(sender As Object, e As EventArgs) Handles btn_delete_purchased_prod.Click
        If GridView_purchased_product.SelectedIndex = -1 Then
            lbl_validation_view4_1.Text = "select product"
        Else
            delete_from_shp_prd_purchased_prod()
        End If
    End Sub
    Private Sub delete_from_shp_prd_purchased_prod()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "DELETE from shopping_product_tbl where product_id = @prodId "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_purchased_product.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        delete_from_prd_tbl_purchaed_prod()
    End Sub
    Private Sub delete_from_prd_tbl_purchaed_prod()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "delete from product_tbl where product_id = @prodId "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_purchased_product.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        bind_gridview_mgt_purchase_prod()
    End Sub
    '################################################ DELETE FROM MANAGE PRODUCT #########################################################################

    '#################################################### UPDATE QUANTITY FUNCTION #######################################################################
    Private Sub btn_update_quantity_Click(sender As Object, e As EventArgs) Handles btn_update_quantity.Click
        If GridView_mgt_all_not_pur_prods.SelectedIndex = -1 Then
            lbl_validation_view4.Text = "select product"
        ElseIf validation_update_quantity.IsValid = True Then
            If txtbx_update_quantity.Text = "" Then
                txtbx_update_quantity.Text = 0
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update product_tbl set product_quantity = @quan where product_id  = @prodId "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_mgt_all_not_pur_prods.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@quan", CDec(txtbx_update_quantity.Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_mgt_all_prod()
        End If
    End Sub
    Private Sub btn_update_quantity_purchased_prd_Click(sender As Object, e As EventArgs) Handles btn_update_quantity_purchased_prd.Click
        If GridView_purchased_product.SelectedIndex = -1 Then
            lbl_validation_view4_1.Text = "select product"
        ElseIf validation_update_quan_purchased_prd.IsValid = True Then
            If txtbx_update_quantity_purchased_prd.Text = "" Then
                txtbx_update_quantity_purchased_prd.Text = 0
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update product_tbl set product_quantity = @quan where product_id  = @prodId "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_purchased_product.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@quan", CDec(txtbx_update_quantity_purchased_prd.Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_mgt_purchase_prod()
        End If
    End Sub
    '#################################################### UPDATE QUANTITY FUNCTION #######################################################################

    '##################################################### UPDATE PRICE FUNCTION ##############################################################################
    Private Sub btn_update_price_Click(sender As Object, e As EventArgs) Handles btn_update_price.Click
        If GridView_mgt_all_not_pur_prods.SelectedIndex = -1 Then
            lbl_validation_view4.Text = "select product"
        ElseIf validation_update_price.IsValid = True Then
            If txtbx_update_price.Text = "" Then
                txtbx_update_price.Text = 0
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update product_tbl set unit_price  = @quan where product_id  = @prodId "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_mgt_all_not_pur_prods.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@quan", CDec(txtbx_update_price.Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_mgt_all_prod()
        End If
    End Sub
    Private Sub btn_update_price_purchased_prod_Click(sender As Object, e As EventArgs) Handles btn_update_price_purchased_prod.Click
        If GridView_purchased_product.SelectedIndex = -1 Then
            lbl_validation_view4_1.Text = "select product"
        ElseIf validation_update_price_purchased_prod.IsValid = True Then
            If txtbx_update_price_purchased_prod.Text = "" Then
                txtbx_update_price_purchased_prod.Text = 0
            End If
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update product_tbl set unit_price  = @quan where product_id  = @prodId "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@prodId", CInt(GridView_purchased_product.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@quan", CDec(txtbx_update_price_purchased_prod.Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            bind_gridview_mgt_purchase_prod()
        End If
    End Sub
    '##################################################### UPDATE PRICE FUNCTION ##############################################################################

    '##################################################### SEARCH FUNCTION #####################################################################################
    Private Sub btn_search_mgt_all_prd_Click(sender As Object, e As EventArgs) Handles btn_search_mgt_all_prd.Click
        If txtbx_search_mgt_all_prd.Text = "" Then
            lbl_validation_view4.Text = "enter name to search"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select p.product_id as [ref no] , product_name , unit_price , product_quantity , (unit_price * product_quantity) as [total] , list_name , category from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id=sl.shopping_list_id inner join product_category_tbl as c on c.category_id= p.category_id where purchase_status = 'not purchased' and family_id = @familyID and shopping_list_type='private_list' and product_name like '%' + @search + '%' "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@search", txtbx_search_mgt_all_prd.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_mgt_all_not_pur_prods.DataSource = dt
            GridView_mgt_all_not_pur_prods.DataBind()
            con.Close()
        End If

    End Sub
    Private Sub btn_search_purchased_prod_Click(sender As Object, e As EventArgs) Handles btn_search_purchased_prod.Click
        If txtbx_search_purchased_prod.Text = "" Then
            lbl_validation_view4_1.Text = "enter name to search"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select p.product_id as [ref no] , product_name , unit_price , product_quantity , (unit_price * product_quantity) as [total] , list_name , category from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id=sl.shopping_list_id inner join product_category_tbl as c on c.category_id= p.category_id where purchase_status = 'Purchased' and family_id = @familyID and shopping_list_type='private_list' and product_name like '%' + @search + '%' "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@search", txtbx_search_purchased_prod.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_purchased_product.DataSource = dt
            GridView_purchased_product.DataBind()
            con.Close()
        End If
    End Sub
    '##################################################### SEARCH FUNCTION #####################################################################################

    '######################################################## DOWNLOAD FUNCTION ####################################################################
    Private Sub btn_download_excel_Click(sender As Object, e As EventArgs) Handles btn_download_excel.Click
        If GridView_list_detail.Rows.Count = 0 Then
            lbl_validation_detail_lst.Visible = True
            lbl_validation_detail_lst.Text = "no product in list to download"
        Else
            lbl_validation_detail_lst.Visible = False
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Using sw As New StringWriter()
                Dim hw As New HtmlTextWriter(sw)

                'To Export all pages
                GridView_list_detail.AllowPaging = False
                Me.bind_detail_list_togrid()

                GridView_list_detail.HeaderRow.BackColor = Color.White
                For Each cell As TableCell In GridView_list_detail.HeaderRow.Cells
                    cell.BackColor = GridView_list_detail.HeaderStyle.BackColor
                Next
                For Each row As GridViewRow In GridView_list_detail.Rows
                    row.BackColor = Color.White
                    For Each cell As TableCell In row.Cells
                        If row.RowIndex Mod 2 = 0 Then
                            cell.BackColor = GridView_list_detail.AlternatingRowStyle.BackColor
                        Else
                            cell.BackColor = GridView_list_detail.RowStyle.BackColor
                        End If
                        cell.CssClass = "textmode"
                    Next
                Next

                GridView_list_detail.RenderControl(hw)
                ''style to format numbers to string
                Dim style As String = "<style> .textmode { } </style>"
                Response.Write(style)
                Response.Output.Write(sw.ToString())
                Response.Flush()
                Response.[End]()
            End Using
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub
    '######################################################## END OF DOWNLOAD FUNCTION ####################################################################

    
  
End Class