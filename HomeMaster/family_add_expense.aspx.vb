Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_add_expense
    Inherits System.Web.UI.Page

    Dim total_amt As Integer
    Dim Vcategory_id As Integer
    Dim Vtype_id As Integer
    Dim Vpayment_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_category_ddl()
        bind_finance_type()
        bind_finance_mean_payment()
        If Not IsPostBack Then
            ddl_finance_type.SelectedItem.Text = "expense"
        End If
    End Sub

    '################################################# THEME SETUP ###################################################################
    Private Sub family_add_expense_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ###################################################################

    Private Sub grid_movable_assets()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_asset_id as [Ref no], m_item_name as [Assets] , m_purchase_cost as [Cost] , m_retailer as [Retailer] , m_make as [Make] , m_model as [Model] , m_serial_num as [Serial no] , FORMAT(m_purchase_date , 'dd/MM/yyyy') as [Purchase date]    from moveable_asset_tbl where m_status = 'active' and m_expense_status = 'notadded' order by m_asset_id desc  "
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
    Private Sub grid_immovable_aseet()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_property_id as [Ref no], i_name as [Property] , i_purchase_cost as [Cost] , i_location as [Location] , i_length as [Length] , i_width as [Width] from immovable_property_tbl where i_status = 'active' and family_id = @familyID and i_expense_status = 'notadded' order by i_property_id desc  "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_immovable_property.DataSource = dt
        GridView_immovable_property.DataBind()
        con.Close()
    End Sub
    Private Sub grid_insurance_repay()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select payment_id as [Ref no] , policy_name as [Policy name] , policy_num as [Policy number] , amount_paid as [Amount paid] , amount_remain as [Amount remaining] from insurance_pay_tbl as p inner join insurance_policy_tbl as i on p.policy_id = i.policy_id where policy_status = 'active' and family_id = @familyID and insur_repay_status = 'active' and insur_expense_status = 'notadded' order by payment_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_insurance_repayment.DataSource = dt
        GridView_insurance_repayment.DataBind()
        con.Close()
    End Sub
    Private Sub grid_loan_repay()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select payment_id as [Ref no] , loan_name as [loan name] , capital_paid as [Capital paid] , interest_paid as [Interest paid] , FORMAT(payment_date , 'dd/MM/yyyy') as [Payment date]  , amount_given as [Amount given] from loan_pay_tbl as p inner join  loan_tbl as l on l.transaction_id = p.transaction_id where loan_status = 'active' and family_id = @familyID and loan_repay_status = 'active' and loan_expn_status = 'notadded' order by payment_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_loan_repayment.DataSource = dt
        GridView_loan_repayment.DataBind()
        con.Close()
    End Sub
    Private Sub grid_movable_asset_repay()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select m_repay_id as [Ref no], m_item_name as [Assets] , m_amount as [Amount] , m_purchase_cost as [Cost] , FORMAT(m_purchase_date , 'dd/MM/yyyy') as [Purchase date]  from moveable_asset_repay_tbl as p inner join moveable_asset_tbl as a on p.m_asset_id = a.m_asset_id where m_repay_status='active' and m_status = 'active' and family_id = @familyID and m_rep_expense_status = 'notadded' order by m_repay_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_movable_asset_repayment.DataSource = dt
        GridView_movable_asset_repayment.DataBind()
        con.Close()
    End Sub
    Private Sub grid_immovable_repay()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select i_repay_id as [Ref no], i_name as [Property] , i_amount as [Amount] , FORMAT(i_repay_date , 'dd/MM/yyyy') as [Repayment date] , i_purchase_cost as [Purchase cost] from immovable_property_repay as r inner join immovable_property_tbl as p on r.i_property_id = p.i_property_id where i_repay_status = 'active' and i_status = 'active'and family_id =  @familyID and i_rep_expn_status = 'notadded' order by i_repay_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_immov_property_repayment.DataSource = dt
        GridView_immov_property_repayment.DataBind()
        con.Close()
    End Sub

    '############################################### NAVIGATION #########################################################################
    Private Sub btn_next_to_view2_Click(sender As Object, e As EventArgs) Handles btn_next_to_view2.Click
        If RadioButtonList_select_expense.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "Selet an expense to continue"
        ElseIf RadioButtonList_select_expense.SelectedIndex = 0 Then
            Panel_movable_asset.Visible = True
            Panel_immovable_asset.Visible = False
            Panel_repayments.Visible = False
            Panel_shopping.Visible = False
            grid_movable_assets()
            MultiView1.ActiveViewIndex = 1
        ElseIf RadioButtonList_select_expense.SelectedIndex = 1 Then
            Panel_immovable_asset.Visible = True
            Panel_movable_asset.Visible = False
            Panel_repayments.Visible = False
            Panel_shopping.Visible = False
           grid_immovable_aseet()
            MultiView1.ActiveViewIndex = 1
        ElseIf RadioButtonList_select_expense.SelectedIndex = 2 Then
            Panel_movable_asset.Visible = False
            Panel_immovable_asset.Visible = False
            Panel_repayments.Visible = True
            Panel_shopping.Visible = False
            MultiView1.ActiveViewIndex = 1
        ElseIf RadioButtonList_select_expense.SelectedIndex = 3 Then
            Panel_movable_asset.Visible = False
            Panel_immovable_asset.Visible = False
            Panel_repayments.Visible = False
            Panel_shopping.Visible = True
            bind_data_togrid()
            MultiView1.ActiveViewIndex = 1
        ElseIf RadioButtonList_select_expense.SelectedIndex = 4 Then
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub bind_data_togrid()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select shopping_list_id as [ref], list_name as [Shopping list], FORMAT(date_created , 'dd/MM/yyyy') as [date created] , FORMAT(date_finish, 'dd/MM/yyyy') as [finish date] ,FORMAT(date_updated, 'dd/MM/yyyy') as [last update],  estimated_budget as [budget] ,  total_amount as [total cost] , (estimated_budget - total_amount) as [remaining amount]  from Shopping_list_tbl where family_id = @familyID and shopping_list_type = 'private_list' and list_status = 'active'"
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
    Private Sub btn_prev_panel_movable_asset_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_movable_asset.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    Private Sub btn_next_panel_movable_asset_Click(sender As Object, e As EventArgs) Handles btn_next_panel_movable_asset.Click
        If GridView_movable_asset.SelectedIndex = -1 Then
            lbl_validation_panel_movable_asset.Text = "select an asset to add as expense"
        Else
            txtbx_expense_name.Text = GridView_movable_asset.SelectedRow.Cells(1).Text
            ddl_category.SelectedItem.Text = "movable asset"
            txtbx_amount.Text = CStr(GridView_movable_asset.SelectedRow.Cells(2).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub btn_prev_panel_immovable_property_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_immovable_property.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    Private Sub btn_next_panel_immovable_property_Click(sender As Object, e As EventArgs) Handles btn_next_panel_immovable_property.Click
        If GridView_immovable_property.SelectedIndex = -1 Then
            lbl_validation_panel_immovable_property.Text = "select an asset to add as expense"
        Else
            txtbx_expense_name.Text = GridView_immovable_property.SelectedRow.Cells(1).Text
            ddl_category.SelectedItem.Text = "immovable property"
            txtbx_amount.Text = CStr(GridView_immovable_property.SelectedRow.Cells(2).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub btn_next_panel_repayment_Click(sender As Object, e As EventArgs) Handles btn_next_panel_repayment.Click
        If RadioButtonList_repayment.SelectedIndex = -1 Then
            lbl_validation_panel_repayment.Text = "Selet an expense to continue"
        ElseIf RadioButtonList_repayment.SelectedIndex = 0 Then
            Panel_insurance_repay.Visible = True
            Panel_loan_repayment.Visible = False
            Panel_movable_asset_repayment.Visible = False
            Panel_immov_property_repayment.Visible = False
            grid_insurance_repay()
            MultiView1.ActiveViewIndex = 2
        ElseIf RadioButtonList_repayment.SelectedIndex = 1 Then
            Panel_insurance_repay.Visible = False
            Panel_loan_repayment.Visible = True
            Panel_movable_asset_repayment.Visible = False
            Panel_immov_property_repayment.Visible = False
             grid_loan_repay()
            MultiView1.ActiveViewIndex = 2
        ElseIf RadioButtonList_repayment.SelectedIndex = 2 Then
            Panel_insurance_repay.Visible = False
            Panel_loan_repayment.Visible = False
            Panel_movable_asset_repayment.Visible = True
            Panel_immov_property_repayment.Visible = False
           grid_movable_asset_repay()
            MultiView1.ActiveViewIndex = 2
        ElseIf RadioButtonList_repayment.SelectedIndex = 3 Then
            Panel_insurance_repay.Visible = False
            Panel_loan_repayment.Visible = False
            Panel_movable_asset_repayment.Visible = False
            Panel_immov_property_repayment.Visible = True
           grid_immovable_repay()
            MultiView1.ActiveViewIndex = 2
        End If
    End Sub
    Private Sub btn_prev_panel_shopping_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_shopping.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    Private Sub btn_prev_view_save_Click(sender As Object, e As EventArgs) Handles btn_prev_view_save.Click
        If RadioButtonList_select_expense.SelectedIndex = 2 Then
            MultiView1.ActiveViewIndex = 2
        ElseIf RadioButtonList_select_expense.SelectedIndex = 4 Then
            MultiView1.ActiveViewIndex = 0
        Else
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub
    Private Sub btn_prev_panel_insurance_repayment_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_insurance_repayment.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    Private Sub btn_next_panel_insurance_repayment_Click(sender As Object, e As EventArgs) Handles btn_next_panel_insurance_repayment.Click
        If GridView_insurance_repayment.SelectedIndex = -1 Then
            lbl_validation_panel_insurance_repayment.Text = "select an asset to add as expense"
        Else
            txtbx_expense_name.Text = GridView_insurance_repayment.SelectedRow.Cells(1).Text + "(" + GridView_insurance_repayment.SelectedRow.Cells(1).Text + ")"
            ddl_category.SelectedItem.Text = "insurance repayment"
            txtbx_amount.Text = CStr(GridView_insurance_repayment.SelectedRow.Cells(3).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub btn_prev_panel_loan_repayment_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_loan_repayment.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    Private Sub btn_next_panel_loan_repayment_Click(sender As Object, e As EventArgs) Handles btn_next_panel_loan_repayment.Click
        If GridView_loan_repayment.SelectedIndex = -1 Then
            lbl_validation_panel_loan_repayment.Text = "select an asset to add as expense"
        Else
            txtbx_expense_name.Text = GridView_loan_repayment.SelectedRow.Cells(1).Text
            ddl_category.SelectedItem.Text = "loan repayment"
            txtbx_amount.Text = CStr(GridView_loan_repayment.SelectedRow.Cells(2).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub btn_prev_movable_asset_repayment_Click(sender As Object, e As EventArgs) Handles btn_prev_movable_asset_repayment.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    Private Sub btn_next_movable_asset_repayment_Click(sender As Object, e As EventArgs) Handles btn_next_movable_asset_repayment.Click
        If GridView_movable_asset_repayment.SelectedIndex = -1 Then
            lbl_validation_movable_asset_repayment.Text = "select an asset to add as expense"
        Else
            txtbx_expense_name.Text = GridView_movable_asset_repayment.SelectedRow.Cells(1).Text
            ddl_category.SelectedItem.Text = "movable asset repayment"
            txtbx_amount.Text = CStr(GridView_movable_asset_repayment.SelectedRow.Cells(2).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub btn_prev_panel_immov_property_repayment_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_immov_property_repayment.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    Private Sub btn_next_panel_immov_property_repayment_Click(sender As Object, e As EventArgs) Handles btn_next_panel_immov_property_repayment.Click
        If GridView_immov_property_repayment.SelectedIndex = -1 Then
            lbl_validation_immov_property_repayment.Text = "select an asset to add as expense"
        Else
            txtbx_expense_name.Text = GridView_immov_property_repayment.SelectedRow.Cells(1).Text
            ddl_category.SelectedItem.Text = "immovable property repayment"
            txtbx_amount.Text = CStr(GridView_immov_property_repayment.SelectedRow.Cells(2).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    Private Sub btn_prev_panel_repayment_Click(sender As Object, e As EventArgs) Handles btn_prev_panel_repayment.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    Private Sub btn_next_panel_shopping_Click(sender As Object, e As EventArgs) Handles btn_next_panel_shopping.Click
        If GridView_private_list.SelectedIndex = -1 Then
            lbl_validation_panel_shopping.Text = "select shopping to add as expense"
        ElseIf GridView_private_list.Rows.Count = 0 Then
            lbl_validation_panel_shopping.Text = "no shopping list created"
        Else
            total_of_list()
            update_amount()
            txtbx_expense_name.Text = GridView_private_list.SelectedRow.Cells(1).Text
            ddl_category.SelectedItem.Text = "shopping"
            txtbx_amount.Text = CStr(GridView_private_list.SelectedRow.Cells(6).Text)
            txtbx_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            MultiView1.ActiveViewIndex = 3
        End If
    End Sub
    '############################################### END OF NAVIGATION #########################################################################

    '########################################### BIND DATA TO DROPDOWNLIST #############################################
    Private Sub bind_category_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from finance_category_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_category.DataSource = ds
                ddl_category.DataTextField = "finance_category"
                ddl_category.DataValueField = "finance_category"
                ddl_category.DataBind()
                ddl_category.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_finance_type()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from finance_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_finance_type.DataSource = ds
                ddl_finance_type.DataTextField = "finance_type"
                ddl_finance_type.DataValueField = "finance_type"
                ddl_finance_type.DataBind()
                ddl_finance_type.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_finance_mean_payment()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from finance_mean_payment_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_mean_payment.DataSource = ds
                ddl_mean_payment.DataTextField = "finance_payment_mean"
                ddl_mean_payment.DataValueField = "finance_payment_mean"
                ddl_mean_payment.DataBind()
                ddl_mean_payment.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    '########################################### END OF BIND DATA TO DROPDOWNLIST #############################################

    '########################################### GET/SAVE ID FROM DROPDOWNLIST #####################################################
    Private Sub check_category()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from finance_category_tbl where finance_category = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_category.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcategory_id = reader2("finance_category_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into finance_category_tbl(finance_category) values (LOWER(@cat))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@cat", ddl_category.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_category_id()
        End If
    End Sub
    Private Sub get_category_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from finance_category_tbl where finance_category = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_category.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcategory_id = reader2("finance_category_id")
            con2.Close()
        End If
    End Sub
    Private Sub check_type()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from finance_type_tbl where finance_type  = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_finance_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vtype_id = reader2("finance_type_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into finance_type_tbl(finance_type) values (LOWER(@cat))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@cat", ddl_finance_type.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_type_id()
        End If
    End Sub
    Private Sub get_type_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from finance_type_tbl where finance_type = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_finance_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vtype_id = reader2("finance_type_id")
            con2.Close()
        End If
    End Sub
    Private Sub check_payment()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from finance_mean_payment_tbl where finance_payment_mean  = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_mean_payment.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpayment_id = reader2("finance_payment_id")
            con2.Close()
        ElseIf reader2.Read() = False Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into finance_mean_payment_tbl(finance_payment_mean) values (LOWER(@cat))"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@cat", ddl_mean_payment.SelectedItem.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_payment_id()
        End If
    End Sub
    Private Sub get_payment_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from finance_mean_payment_tbl where finance_payment_mean = LOWER(@cat)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@cat", ddl_mean_payment.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vpayment_id = reader2("finance_payment_id")
            con2.Close()
        End If
    End Sub
    '########################################### END OF GET/SAVE ID FROM DROPDOWNLIST #####################################################

    '############################################### CALCULATE TOTAL OF EACH LIST ####################################
    Private Sub total_of_list()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select sum((unit_price * product_quantity)) as [total]  from product_tbl as p inner join shopping_product_tbl as s on p.product_id = s.product_id inner join Shopping_list_tbl as sl on s.shopping_list_id = sl.shopping_list_id inner join family_tbl as f on f.family_id = sl.family_id where list_name = @listname and f.family_id = @familyID and s.shopping_list_id = @listID "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@listname", GridView_private_list.SelectedRow.Cells(1).Text)
        sqlCmd.Parameters.AddWithValue("@listID", CInt(GridView_private_list.SelectedRow.Cells(0).Text))
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            If IsDBNull(reader("total")) Then
                total_amt = 0
                lbl_validation_panel_shopping.Text = "no prodeuct to calculate amount"
            Else
                total_amt = CInt(reader("total"))
                con.Close()
            End If
        ElseIf reader.Read() = False Then
            lbl_validation_panel_shopping.Text = "no prodeuct to calculate amount"
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
        If GridView_private_list.SelectedIndex = -1 Then
            lbl_validation_panel_shopping.Text = "select shopping to add as expense"
        ElseIf GridView_private_list.Rows.Count = 0 Then
            lbl_validation_panel_shopping.Text = "no shopping list created"
        Else
            total_of_list()
            update_amount()
        End If
    End Sub
    '############################################## END OF CALCULATE TOTAL OF EACH LIST #############################

    '################################################ MAKE GRIDVIEW SELECTABLE ################################################################
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
    Private Sub GridView_immovable_property_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_immovable_property.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_immovable_property, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_immovable_property_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_immovable_property.SelectedIndexChanged
        For Each row As GridViewRow In GridView_immovable_property.Rows
            If row.RowIndex = GridView_immovable_property.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
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
    End Sub
    Private Sub GridView_insurance_repayment_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_insurance_repayment.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_insurance_repayment, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_insurance_repayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_insurance_repayment.SelectedIndexChanged
        For Each row As GridViewRow In GridView_insurance_repayment.Rows
            If row.RowIndex = GridView_insurance_repayment.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub GridView_loan_repayment_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_loan_repayment.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_loan_repayment, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_loan_repayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_loan_repayment.SelectedIndexChanged
        For Each row As GridViewRow In GridView_loan_repayment.Rows
            If row.RowIndex = GridView_loan_repayment.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub GridView_movable_asset_repayment_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_movable_asset_repayment.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_movable_asset_repayment, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_movable_asset_repayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_movable_asset_repayment.SelectedIndexChanged
        For Each row As GridViewRow In GridView_movable_asset_repayment.Rows
            If row.RowIndex = GridView_movable_asset_repayment.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    Private Sub GridView_immov_property_repayment_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_immov_property_repayment.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_immov_property_repayment, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_immov_property_repayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_immov_property_repayment.SelectedIndexChanged
        For Each row As GridViewRow In GridView_immov_property_repayment.Rows
            If row.RowIndex = GridView_immov_property_repayment.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
    End Sub
    '################################################ END OF MAKE GRIDVIEW SELECTABLE ################################################################

    '########################################################### SAVE EXPENSE #############################################################
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txtbx_expense_name.Text = "" Then
            lbl_validation_save.Text = "Enter name"
        ElseIf ddl_category.SelectedItem.Text = "--Select type--" Then
            lbl_validation_save.Text = "select category"
        ElseIf ddl_finance_type.SelectedItem.Text = "--Select type--" Then
            lbl_validation_save.Text = "select type"
        ElseIf ddl_mean_payment.SelectedItem.Text = "--Select type--" Then
            lbl_validation_save.Text = "select mean of payment"
        ElseIf validation_amount.IsValid = True And validation_date.IsValid = True Then
            check_category()
            check_type()
            check_payment()

            If txtbx_amount.Text = "" Then
                txtbx_amount.Text = 0
            End If

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into finance_tbl(finance_name , finance_date , finance_amount , finance_note , finance_status , family_id , finance_type_id , finance_category_id , finance_payment_id ) values (@name ,  convert(date,@date,103) , @amt , @note , 'active' , @familyID , @typid , @catid , @payid )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_expense_name.Text)
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_date.Text)
            sqlCmd1.Parameters.AddWithValue("@amt", CDec(txtbx_amount.Text))
            sqlCmd1.Parameters.AddWithValue("@note", txtbx_note.Text)
            sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
            sqlCmd1.Parameters.AddWithValue("@typid", Vtype_id)
            sqlCmd1.Parameters.AddWithValue("@catid", Vcategory_id)
            sqlCmd1.Parameters.AddWithValue("@payid", Vpayment_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_save.Text = "new expense added"

            If RadioButtonList_select_expense.SelectedIndex = 0 Then
                change_expense_status()
            ElseIf RadioButtonList_select_expense.SelectedIndex = 1 Then
                change_immov_expn_status()
            ElseIf RadioButtonList_select_expense.SelectedIndex = 2 Then
                If RadioButtonList_repayment.SelectedIndex = 0 Then
                    change_insur_expn_status()
                ElseIf RadioButtonList_repayment.SelectedIndex = 1 Then
                    change_loan_expn_status()
                ElseIf RadioButtonList_repayment.SelectedIndex = 2 Then
                    change_asset_expn_status()
                ElseIf RadioButtonList_repayment.SelectedIndex = 3 Then
                    change_immov_repay_expn_status()
                End If
            End If

        End If
    End Sub
    Private Sub change_immov_repay_expn_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_property_repay set i_rep_expn_status = 'added' where i_repay_id = @assetID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@assetID", CInt(GridView_immov_property_repayment.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub change_asset_expn_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update moveable_asset_repay_tbl set m_rep_expense_status = 'added' where m_repay_id = @assetID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@assetID", CInt(GridView_movable_asset_repayment.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub change_loan_expn_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update loan_pay_tbl set loan_expn_status = 'added' where payment_id = @assetID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@assetID", CInt(GridView_loan_repayment.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub change_insur_expn_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update insurance_pay_tbl set insur_expense_status = 'added' where payment_id = @assetID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@assetID", CInt(GridView_insurance_repayment.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub change_immov_expn_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update immovable_property_tbl set i_expense_status = 'added' where i_property_id = @assetID and family_id = @familyID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd1.Parameters.AddWithValue("@assetID", CInt(GridView_immovable_property.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub change_expense_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update moveable_asset_tbl set m_expense_status = 'added' where m_asset_id = @assetID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@assetID", CInt(GridView_movable_asset.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub btn_add_category_Click(sender As Object, e As EventArgs) Handles btn_add_category.Click
        If txtbx_add_category.Text = "" Then
            lbl_validation_save.Text = "enter category to add"
        Else
            ddl_category.SelectedItem.Text = txtbx_add_category.Text
        End If
    End Sub
    Private Sub btn_add_finance_type_Click(sender As Object, e As EventArgs) Handles btn_add_finance_type.Click
        If txtbx_add_finance_type.Text = "" Then
            lbl_validation_save.Text = "Enter type to add"
        Else
            ddl_finance_type.SelectedItem.Text = txtbx_add_finance_type.Text
        End If
    End Sub
    Private Sub btn_add_mean_payment_Click(sender As Object, e As EventArgs) Handles btn_add_mean_payment.Click
        If txtbx_add_mean_payment.Text = "" Then
            lbl_validation_save.Text = "enter mean of payment to add"
        Else
            ddl_mean_payment.SelectedItem.Text = txtbx_add_mean_payment.Text
        End If
    End Sub
    '########################################################### END OF SAVE EXPENSE #############################################################

    '########################################## PAGING IN GRIDVIEW ############################################################################################
    Private Sub GridView_private_list_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_private_list.PageIndexChanging
        GridView_private_list.PageIndex = e.NewPageIndex
        Me.bind_data_togrid()
    End Sub
    Private Sub GridView_movable_asset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_movable_asset.PageIndexChanging
        GridView_movable_asset.PageIndex = e.NewPageIndex
        Me.grid_movable_assets()
    End Sub
    Private Sub GridView_immovable_property_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_immovable_property.PageIndexChanging
        GridView_immovable_property.PageIndex = e.NewPageIndex
        Me.grid_immovable_aseet()
    End Sub
    Private Sub GridView_insurance_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_insurance_repayment.PageIndexChanging
        GridView_insurance_repayment.PageIndex = e.NewPageIndex
        Me.grid_insurance_repay()
    End Sub
    Private Sub GridView_loan_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_loan_repayment.PageIndexChanging
        GridView_loan_repayment.PageIndex = e.NewPageIndex
        Me.grid_loan_repay()
    End Sub
    Private Sub GridView_movable_asset_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_movable_asset_repayment.PageIndexChanging
        GridView_movable_asset_repayment.PageIndex = e.NewPageIndex
        Me.grid_movable_asset_repay()
    End Sub
    Private Sub GridView_immov_property_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_immov_property_repayment.PageIndexChanging
        GridView_immov_property_repayment.PageIndex = e.NewPageIndex
        Me.grid_immovable_repay()
    End Sub
    '########################################## END OF PAGING IN GRIDVIEW ############################################################################################
End Class