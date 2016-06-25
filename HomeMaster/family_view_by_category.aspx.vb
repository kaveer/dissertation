Imports System.Data.SqlClient

Public Class family_view_by_category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_data_to_ddl_category()
    End Sub

    '########################################### THEME SETUP #####################################################
    Private Sub family_view_by_category_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '########################################### END OF THEME SETUP ##################################################

    '########################################## BIND DATA TO DDL CATAGORY ##########################################
    Private Sub bind_data_to_ddl_category()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select category from product_category_tbl ", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_select_category.DataSource = ds
                ddl_select_category.DataTextField = "category"
                ddl_select_category.DataValueField = "category"
                ddl_select_category.DataBind()
                ddl_select_category.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub after_postback_bind_category()
        Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("select category from product_category_tbl ", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            ddl_select_category.DataSource = ds
            ddl_select_category.DataTextField = "category"
            ddl_select_category.DataValueField = "category"
            ddl_select_category.DataBind()
            ddl_select_category.Items.Insert(0, New ListItem("--Select type--", "0"))
            con.Close()
        End Using
    End Sub
    '######################################## END OF BIND DATA TO DDL CATAGORY ##########################################

    '####################################### BIND DATA TO GRIDVIEW #####################################################
    Private Sub bind_data_gridview()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select product_name as [Product name] , unit_price as [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , list_name as [From list] , FORMAT(date_created , 'dd/MM/yyyy') as [Date created] , purchase_status as [purchase status]    from product_tbl as p inner join product_category_tbl as c  on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where category = @catName and f.family_id = @familyID and list_status = 'active' and shopping_list_type = 'private_list' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@catName", ddl_select_category.SelectedItem.Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        gridview_by_category.DataSource = dt
        gridview_by_category.DataBind()
        con.Close()
    End Sub
    '####################################### END OF BIND DATA TO GRIDVIEW #####################################################

    '########################################## SELECT BY CATEGORY DDL ######################################################
    Private Sub btn_select_by_category_Click(sender As Object, e As EventArgs) Handles btn_select_by_category.Click
        If ddl_select_category.SelectedIndex = 0 Then
            lbl_validation_select_category.Text = " No category selected"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select product_name as [Product name] , unit_price as [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , list_name as [From list] , FORMAT(date_created , 'dd/MM/yyyy') as [Date created] , purchase_status as [purchase status]   from product_tbl as p inner join product_category_tbl as c  on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where category = @catName and f.family_id = @familyID and list_status = 'active' and shopping_list_type = 'private_list'  "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@catName", ddl_select_category.SelectedItem.Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                bind_data_gridview()
                lbl_validation_select_category.Text = ""
                Panel1.Visible = True
            ElseIf reader.Read() = False Then
                lbl_validation_select_category.Text = "No product in this category"
                'bind_data_gridview()
                Panel1.Visible = False
            End If
        End If
    End Sub
    '########################################## END OF SELECT BY CATEGORY DDL ######################################################

    '############################################## SORT GRIDVIEW ################################################################
    Private Sub btn_sort_Click(sender As Object, e As EventArgs) Handles btn_sort.Click
        If ddl_sort_category_list.SelectedIndex = 0 Then
            lbl_validation_for_sort.Text = "select sorting method"
        ElseIf ddl_sort_category_list.SelectedIndex = 1 Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select product_name as [Product name] , unit_price as [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , list_name as [From list] , FORMAT(date_created , 'dd/MM/yyyy') as [Date created] , purchase_status as [purchase status]   from product_tbl as p inner join product_category_tbl as c  on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where category = @catName and f.family_id = @familyID and list_status = 'active' and shopping_list_type = 'private_list' order by product_name "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@catName", ddl_select_category.SelectedItem.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            gridview_by_category.DataSource = dt
            gridview_by_category.DataBind()
            con.Close()
            lbl_validation_for_sort.Text = ""
        ElseIf ddl_sort_category_list.SelectedIndex = 2 Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select product_name as [Product name] , unit_price as [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , list_name as [From list] , FORMAT(date_created , 'dd/MM/yyyy') as [Date created] , purchase_status as [purchase status]   from product_tbl as p inner join product_category_tbl as c  on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where category = @catName and f.family_id = @familyID and list_status = 'active' and shopping_list_type = 'private_list' order by date_created "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@catName", ddl_select_category.SelectedItem.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            gridview_by_category.DataSource = dt
            gridview_by_category.DataBind()
            con.Close()
            lbl_validation_for_sort.Text = ""
        ElseIf ddl_sort_category_list.SelectedIndex = 3 Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select product_name as [Product name] , unit_price as [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , list_name as [From list] , FORMAT(date_created , 'dd/MM/yyyy') as [Date created] , purchase_status as [purchase status]    from product_tbl as p inner join product_category_tbl as c  on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where category = @catName and f.family_id = @familyID and list_status = 'active' and shopping_list_type = 'private_list' order by list_name "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@catName", ddl_select_category.SelectedItem.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            gridview_by_category.DataSource = dt
            gridview_by_category.DataBind()
            con.Close()
            lbl_validation_for_sort.Text = ""
        End If
    End Sub
    '############################################## END OF SORT GRIDVIEW ############################################################

    '################################################### SEARCH ###################################################################
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If txtbx_search.Text = "" Then
            lbl_valitation_for_search.Text = "Enter somthing to search"
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = " select product_name as [Product name] , unit_price as [Unit price] , product_quantity as [Quantity] , (unit_price * product_quantity) as [Total price] , list_name as [From list] , FORMAT(date_created , 'dd/MM/yyyy') as [Date created] , purchase_status as [purchase status]   from product_tbl as p inner join product_category_tbl as c  on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on sl.family_id = f.family_id where category = @catName and f.family_id = @familyID and list_status = 'active' and shopping_list_type = 'private_list' and product_name like '%' + @search + '%' or list_name like '%' + @search + '%' "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd.Parameters.AddWithValue("@catName", ddl_select_category.SelectedItem.Text)
            sqlCmd.Parameters.AddWithValue("@search", txtbx_search.Text)
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            gridview_by_category.DataSource = dt
            gridview_by_category.DataBind()
            con.Close()
        End If
    End Sub
    '###################################################  END OF SEARCH ###################################################################

    '########################################### PAGING IN GRIDVIEW #########################################################################################
    Private Sub gridview_by_category_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gridview_by_category.PageIndexChanging
        gridview_by_category.PageIndex = e.NewPageIndex
        Me.bind_data_gridview()
    End Sub
    '########################################### END OF PAGING IN GRIDVIEW #########################################################################################
End Class