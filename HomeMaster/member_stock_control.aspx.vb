Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_stock_control
    Inherits System.Web.UI.Page

    Dim Vcat_id As Integer
    Dim shopLIst_id As Integer
    Dim prod_id As Integer
    Dim Vname As String
    Dim Vunit As Decimal
    Dim Vquantity As Decimal
    Dim prodCat_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            notify_decrease_product()
        End If
        bind_to_gridview_preview_asset()
        bind_to_chart()

        txtbx_date_created.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
        txtbx_finish_date1.Text = Format(DateAndTime.Today.AddMonths(1), "dd/MM/yyyy").ToString
    End Sub

    '################################### THEME SETUP #############################################################################
    Private Sub member_stock_control_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################### END OF THEME SETUP #############################################################################

    '##################################### BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################
    Private Sub bind_to_gridview_preview_asset()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select product_name ,sum( product_quantity) as stock from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id =sl.shopping_list_id where purchase_status = 'Purchased' and shopping_list_type='private_list' and family_id = @familyID group by product_name  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_stock_control.DataSource = dt
        GridView_stock_control.DataBind()
        con.Close()
    End Sub
    '##################################### END OF BIND DATA TO GRIDVIEW/DETAILVIEW ############################################################

    '####################################### NOTIFY PRODUCT DECREASE ##########################################################################
    Private Sub notify_decrease_product()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select product_name ,sum( product_quantity) as stock from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id =sl.shopping_list_id where purchase_status = 'Purchased' and shopping_list_type='private_list'  and family_id = @familyID group by product_name having sum(product_quantity) <= 2"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            bind_to_gridview_decrease_prod()
            con2.Close()
            lbl_notify_decrease_prod.Text = "the following products are about to finish"
            'update_member_notif_status()
        ElseIf reader2.Read() = False Then
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select product_name ,sum( product_quantity) as stock from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id =sl.shopping_list_id where purchase_status = 'Purchased' and shopping_list_type='private_list' and family_id = @familyID group by product_name having sum(product_quantity) <= 2 "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            con.Open()
            Dim sqladap = New SqlDataAdapter(sqlCmd)
            Dim dt = New DataTable
            sqladap.Fill(dt)
            GridView_decrease_product.DataSource = dt
            GridView_decrease_product.DataSource = Nothing
            GridView_decrease_product.DataBind()
            con.Close()
            lbl_notify_decrease_prod.Text = ""
            btn_save.Visible = False
            btn_merge_list.Visible = False
        End If
    End Sub
    Private Sub bind_to_gridview_decrease_prod()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select product_name ,sum( product_quantity) as stock from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id =sl.shopping_list_id where purchase_status = 'Purchased' and shopping_list_type='private_list' and family_id = @familyID group by product_name having sum(product_quantity) <= 2 "
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
    '####################################### END OF NOTIFY PRODUCT DECREASE ##########################################################################

    '######################################## NOTIFY MEMBER ##########################################################################################
    'Private Sub update_member_notif_status()
    '    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
    '    Dim sql1 = "update family_tbl set noti_status = 'new-notif' where family_id = @famID"
    '    Dim sqlCmd1 As New SqlCommand(sql1, con1)
    '    sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
    '    con1.Open()
    '    sqlCmd1.ExecuteNonQuery()
    '    con1.Close()
    'End Sub
    '######################################## END OF NOTIFY MEMBER ##########################################################################################

    '######################################## MAKE GRIDVIEW SELECTABLE ################################################################################
    Private Sub GridView_decrease_product_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_decrease_product.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_decrease_product, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_decrease_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_decrease_product.SelectedIndexChanged
        For Each row As GridViewRow In GridView_decrease_product.Rows
            If row.RowIndex = GridView_decrease_product.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub GridView_merge_list_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_merge_list.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_merge_list, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_merge_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_merge_list.SelectedIndexChanged
        For Each row As GridViewRow In GridView_merge_list.Rows
            If row.RowIndex = GridView_merge_list.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '######################################## END OF MAKE GRIDVIEW SELECTABLE ################################################################################

    '######################################### SAVE NEW LIST ############################################################################################
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Panel_save_list.Visible = False Then
            Panel_save_list.Visible = True
        ElseIf Panel_save_list.Visible = True Then
            Panel_save_list.Visible = False
        End If
    End Sub
    Private Sub btn_save_list_Click(sender As Object, e As EventArgs) Handles btn_save_list.Click
        If txtbx_listName.Text = "" Then
            lbl_validate_check.Text = "Enter your list name"
        ElseIf txtbx_finish_date1.Text = "" Then
            lbl_validate_check.Text = "Enter a valid date like DD/MM/YYYY"
        ElseIf txtbx_estimated_butget.Text = "" Then
            lbl_validate_check.Text = "Enter an estimated budget"
        ElseIf validation_for_budget.IsValid = True And validation_for_finishDate1.IsValid = True Then
            check_list_name()

            For Each row As GridViewRow In GridView_decrease_product.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                    If chkRow.Checked = True Then

                        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                        Dim sql2 = " select * from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id where purchase_status = 'Purchased' and product_name = @listName order by unit_price DESC"
                        Dim sqlCmd2 As New SqlCommand(sql2, con2)
                        sqlCmd2.Parameters.AddWithValue("@listName", row.Cells(1).Text)
                        con2.Open()
                        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
                        If reader2.Read() Then
                            Vname = reader2("product_name")
                            Vunit = reader2("unit_price")
                            Vquantity = reader2("product_quantity")
                            prodCat_id = CInt(reader2("category_id"))
                        End If
                        con2.Close()
                        insert_new_prod()
                        get_prod_id()

                        Dim constring As String = "Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True"
                        Using con As New SqlConnection(constring)
                            Using cmd As New SqlCommand("insert into shopping_product_tbl (shopping_list_id , product_id) values (@shopID , @prodID )", con)
                                cmd.Parameters.AddWithValue("@shopID", shopLIst_id)
                                cmd.Parameters.AddWithValue("@prodID", prod_id)

                                con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End Using
                        End Using
                        change_pur_state()
                        'Dim storid As String = row.Cells(1).Text
                        'Dim storname As String = row.Cells(2).Text
                        'Dim state As String = row.Cells(3).Text
                        lbl_validate_check.Text = "product save in list"
                    End If
                End If
            Next

        End If
    End Sub
    Private Sub check_list_name()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from Shopping_list_tbl where list_name = LOWER(@listname) and family_id = @famID and list_status = 'active' and shopping_list_type = 'private_list'"
        Dim sqlCmd As New SqlCommand(sql, con1)
        sqlCmd.Parameters.AddWithValue("@listname", txtbx_listName.Text)
        sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        con1.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            lbl_validate_check.Text = "List name already exsist please enter another name"
        ElseIf reader.Read() = False Then
            check_cat()
            add_list_name()
        End If
    End Sub
    Private Sub check_cat()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from shopping_category_tbl where category = 'categorized'"
        Dim sqlCmd As New SqlCommand(sql, con)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vcat_id = CInt(reader("shopping_category_id"))
            con.Close()
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into shopping_category_tbl(category) values ('categorized')"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_cat_id()
        End If
    End Sub
    Private Sub get_cat_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from shopping_category_tbl where category = categorized"
        Dim sqlCmd As New SqlCommand(sql, con)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vcat_id = CInt(reader("shopping_category_id"))
            con.Close()
        End If
    End Sub
    Private Sub add_list_name()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into Shopping_list_tbl(family_id , shopping_category_id , list_name , shopping_list_type , date_created , list_status ,  date_finish, estimated_budget ) values (@familyID , @catID , LOWER(@listName) , 'private_list' , convert(date,@datetaken,103) , 'active' , convert(date,@datefinish,103) , @budget)"
        'Convert(DATE,...,103 DOES NOT AFFECT HIS CODE IT WILL WORK IF BUY DIRECT @DATETAKEN)
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd1.Parameters.AddWithValue("@catID", Vcat_id)
        sqlCmd1.Parameters.AddWithValue("@listName", txtbx_listName.Text)
        sqlCmd1.Parameters.AddWithValue("@datetaken", DateAndTime.Today)
        sqlCmd1.Parameters.AddWithValue("@datefinish", txtbx_finish_date1.Text)
        sqlCmd1.Parameters.AddWithValue("@budget", txtbx_estimated_butget.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        select_new_Lname_id()
    End Sub
    Private Sub select_new_Lname_id()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from Shopping_list_tbl where list_name = LOWER(@listname) and family_id = @famID and list_status = 'active' and shopping_list_type = 'private_list'"
        Dim sqlCmd As New SqlCommand(sql, con1)
        sqlCmd.Parameters.AddWithValue("@listname", txtbx_listName.Text)
        sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        con1.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            shopLIst_id = CInt(reader("shopping_list_id"))
        End If
    End Sub
    Private Sub insert_new_prod()
        Dim constring As String = "Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True"
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("insert into product_tbl (product_name , unit_price , product_quantity ,category_id , purchase_status) values (@prodName , @unit , @quan , @catID , 'gen' )", con)
                cmd.Parameters.AddWithValue("@prodName", Vname)
                cmd.Parameters.AddWithValue("@unit", Vunit)
                cmd.Parameters.AddWithValue("@quan", Vquantity)
                cmd.Parameters.AddWithValue("@catID", prodCat_id)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
    Private Sub get_prod_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from product_tbl where product_name = @listName and unit_price = @unit and product_quantity = @quan and category_id = @prodCat and purchase_status = 'gen' "
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@listName", Vname)
        sqlCmd2.Parameters.AddWithValue("@unit", Vunit)
        sqlCmd2.Parameters.AddWithValue("@quan", Vquantity)
        sqlCmd2.Parameters.AddWithValue("@prodCat", prodCat_id)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() Then
            prod_id = reader2("product_id")
        End If
        con2.Close()
    End Sub
    Private Sub change_pur_state()
        Dim constring As String = "Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True"
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("update product_tbl set purchase_status = 'not purchased' where purchase_status = 'gen'", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
    '######################################### SAVE NEW LIST ############################################################################################

    '############################################### MERGE LIST ################################################################################################
    Private Sub btn_merge_list_Click(sender As Object, e As EventArgs) Handles btn_merge_list.Click
        If panel_merge_list.Visible = False Then
            panel_merge_list.Visible = True
        ElseIf panel_merge_list.Visible = True Then
            panel_merge_list.Visible = False
        End If
        bind_gridview_merge_list()
    End Sub
    Private Sub bind_gridview_merge_list()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list] , FORMAT(date_created , 'dd/MM/yyyy') as [date created] , estimated_budget as [budget] from Shopping_list_tbl where family_id = @familyID and shopping_list_type = 'private_list' and list_status = 'active' order by shopping_list_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_merge_list.DataSource = dt
        GridView_merge_list.DataBind()
        con.Close()
    End Sub
    Private Sub btn_merge_prod_Click(sender As Object, e As EventArgs) Handles btn_merge_prod.Click
        If GridView_merge_list.SelectedIndex = -1 Then
            lbl_validate_check.Text = "Select a list to add"
        ElseIf GridView_merge_list.Rows.Count = 0 Then
            lbl_validate_check.Text = "No list created by user"
        Else
            For Each row As GridViewRow In GridView_decrease_product.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkCtrl"), CheckBox)
                    If chkRow.Checked = True Then
                        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                        Dim sql = " select * from product_tbl as p inner join product_category_tbl as c on c.category_id = p.category_id inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as s on s.shopping_list_id = sp.shopping_list_id inner join family_tbl as f on s.family_id = f.family_id where f.family_id = @famID and s.shopping_list_id = @listID and list_name = @listname and product_name = LOWER(@prodname)  "
                        Dim sqlCmd As New SqlCommand(sql, con)
                        sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
                        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_merge_list.SelectedRow.Cells(0).Text))
                        sqlCmd.Parameters.AddWithValue("@listname", GridView_merge_list.SelectedRow.Cells(1).Text)
                        sqlCmd.Parameters.AddWithValue("@prodname", row.Cells(1).Text)
                        con.Open()
                        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
                        If reader.Read() Then
                            lbl_validate_check.Text = "prod in listzz"
                            panel_merge_list.Visible = False

                        ElseIf reader.Read() = False Then
                            Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                            Dim sql2 = " select * from product_tbl as p inner join product_category_tbl as c on p.category_id = c.category_id where purchase_status = 'Purchased'  and product_name = @listName order by unit_price DESC"
                            Dim sqlCmd2 As New SqlCommand(sql2, con2)
                            sqlCmd2.Parameters.AddWithValue("@listName", row.Cells(1).Text)
                            con2.Open()
                            Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
                            If reader2.Read() Then
                                Vname = reader2("product_name")
                                Vunit = reader2("unit_price")
                                Vquantity = reader2("product_quantity")
                                prodCat_id = CInt(reader2("category_id"))
                            End If
                            con2.Close()

                            check_cat()
                            select_list()
                            insert_new_prod()
                            get_prod_id()

                            add_into_shp_prd()
                            panel_merge_list.Visible = False
                            lbl_validate_check.Text = "list merged"
                        End If
                    End If
                End If
            Next
            GridView_merge_list.SelectedIndex = -1
        End If
    End Sub
    Private Sub select_list()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select * from Shopping_list_tbl where list_name = LOWER(@listname) and family_id = @famID and list_status = 'active' and shopping_list_type = 'private_list' and shopping_list_id = @shopLid"
        Dim sqlCmd As New SqlCommand(sql, con1)
        sqlCmd.Parameters.AddWithValue("@listname", GridView_merge_list.SelectedRow.Cells(1).Text)
        sqlCmd.Parameters.AddWithValue("@shopLid", CInt(GridView_merge_list.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        con1.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            shopLIst_id = CInt(reader("shopping_list_id"))
        End If
    End Sub
    Private Sub add_into_shp_prd()
        Dim constring As String = "Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True"
        Using con As New SqlConnection(constring)
            Using cmd As New SqlCommand("insert into shopping_product_tbl (shopping_list_id , product_id) values (@shopID , @prodID )", con)
                cmd.Parameters.AddWithValue("@shopID", shopLIst_id)
                cmd.Parameters.AddWithValue("@prodID", prod_id)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
        change_pur_state()
    End Sub
    '############################################### END OF MERGE LIST ################################################################################################

    '############################################### CHART DISPLAY ######################################################################################
    Private Sub bind_to_chart()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select product_name ,sum( product_quantity) as stock from product_tbl as p inner join shopping_product_tbl as sp on p.product_id = sp.product_id inner join Shopping_list_tbl as sl on sp.shopping_list_id =sl.shopping_list_id where purchase_status = 'Purchased' and shopping_list_type='private_list' and family_id = @familyID group by product_name  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        Chart_view_stock.DataSource = dt
        Chart_view_stock.Series("Series2").XValueMember = "product_name"
        Chart_view_stock.Series("Series2").YValueMembers = "stock"
        'Chart1.Legends.Add(New Legend("Legend1"))
        'Chart1.Series("Series1").LegendText = "Pesky Monkeys"
        'Chart1.Series("Series2").LegendText = "Juicy Bananas"

        'Dim tmpSeriesArray(Chart1.Series.Count - 1) As Charting.Series    ' create array '
        'Chart1.Series.CopyTo(tmpSeriesArray, 0) ' copy all series in SeriesCollection to array '
        'Chart1.Series.Clear() ' clear the Charts SeriesCollection '
        'Chart1.Series.Add(tmpSeriesArray(1))    ' Add Bananas back in first (so it goes to the bottom) '
        'Chart1.Series.Add(tmpSeriesArray(0))    ' Add Monkeys last so that appears on top '
        Chart_view_stock.DataBind()
        con.Close()
    End Sub
    '############################################### END OF CHART DISPLAY ######################################################################################

    '########################################### PAGING IN GRIDVIEW #########################################################################################
    Private Sub GridView_merge_list_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_merge_list.PageIndexChanging
        GridView_merge_list.PageIndex = e.NewPageIndex
        Me.bind_gridview_merge_list()
    End Sub
    Private Sub GridView_stock_control_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_stock_control.PageIndexChanging
        GridView_stock_control.PageIndex = e.NewPageIndex
        Me.bind_to_gridview_preview_asset()
    End Sub
    '########################################### END OF PAGING IN GRIDVIEW #########################################################################################
End Class