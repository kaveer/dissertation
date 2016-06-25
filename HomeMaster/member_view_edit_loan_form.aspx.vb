Imports System.Data.SqlClient
Imports System.Drawing

Public Class member_view_edit_loan_form
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_data_gridview_loan()
    End Sub
  
    '########################################## NAVIGATION ###############################################################################
    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedItem.Value
    End Sub
    Private Sub editloan_btn_Click(sender As Object, e As EventArgs) Handles editloan_btn.Click
        Response.Redirect(".\member_edit_loan_form.aspx")
    End Sub
    '########################################## END OF NAVIGATION ########################################################################

    '########################################### THEME SETUP ###################################################################
    Private Sub member_view_edit_loan_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '########################################### END OF THEME SETUP ###################################################################

    '########################################### BIND DATA TO GRIDVIEW ##############################################################
    Private Sub bind_data_gridview_loan()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select transaction_id as [ref no] , loan_name as [Loan name] , type as [Loan type] from loan_tbl as l inner join loan_type_tbl as lt on l.loan_type_id = lt.loan_type_id where loan_status = 'active' and family_id = @familyID order by transaction_id desc "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_view_loan.DataSource = dt
        GridView_view_loan.DataBind()
        con.Close()
    End Sub
    Private Sub bind_gridview_lender_detail()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select name as [Lender name] , lender_description as [Description], lender_mail as [Email] , lender_street as [Street ] , lender_town as [Town] , lender_country as [Country] ,lender_postal_code as [Postal code] ,lender_phone_fix as [Phone number] , lender_phone_ptb as [Mobile number] , lender_fax as [Fax] , lender_website as [Website] from lender_tbl as l inner join lender_type_tbl as lt on lt.type_id = l.type_id inner join loan_tbl as lo on l.lender_id = lo.lender_id where family_id = @fam_id  and transaction_id = @tans and loan_name = @name "
        'need to coorect sql statment
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@fam_id", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@tans", GridView_view_loan.SelectedRow.Cells(0).Text)
        sqlCmd.Parameters.AddWithValue("@name", GridView_view_loan.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_lender_detail.DataSource = dt
        DetailsView_lender_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_data_detailview_loan()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select loan_name as [Loan name] , type as [Loan type] , loan_detail as [Description] , amount_given as [Total amount] ,  interest_rate as [Interest rate] , guarantor , mortgage , FORMAT(date_taken , 'dd/MM/yyyy')  as [date taken] from loan_tbl as l inner join loan_type_tbl as lt on lt.loan_type_id = l.loan_type_id where family_id = @fam_id and transaction_id = @tans and loan_name = @name "
        'need to coorect sql statment
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@fam_id", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@tans", GridView_view_loan.SelectedRow.Cells(0).Text)
        sqlCmd.Parameters.AddWithValue("@name", GridView_view_loan.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        DetailsView_loan_detail.DataSource = dt
        DetailsView_loan_detail.DataBind()
        con.Close()
    End Sub
    Private Sub bind_data_gridview_repay_history()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select capital_paid as [Capital paid] , interest_paid as [Interest paid] , repay_interest_rate as [Interest rate] , FORMAT(payment_date , 'dd/MM/yyyy')   as [date] , remarks from loan_pay_tbl as l inner join loan_tbl as lo on lo.transaction_id = l.transaction_id where l.transaction_id = @tans and loan_name = @name and family_id = @fam_id and loan_repay_status='active'"
        'need to coorect sql statment
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@fam_id", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@tans", GridView_view_loan.SelectedRow.Cells(0).Text)
        sqlCmd.Parameters.AddWithValue("@name", GridView_view_loan.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        gridview_repay_history.DataSource = dt
        gridview_repay_history.DataBind()
        con.Close()
    End Sub
    '########################################### END OF BIND DATA TO GRIDVIEW ##############################################################

    '############################################## MAKE GRIDVIEW SELECTABLE #######################################################################
    Private Sub GridView_view_loan_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_view_loan.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_view_loan, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_view_loan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_view_loan.SelectedIndexChanged
        For Each row As GridViewRow In GridView_view_loan.Rows
            If row.RowIndex = GridView_view_loan.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        bind_gridview_lender_detail()
        bind_data_detailview_loan()
        bind_data_gridview_repay_history()
    End Sub
    '############################################## END IF MAKE GRIDVIEW SELECTABLE #######################################################################

    Private Sub btn_addloan_Click(sender As Object, e As EventArgs) Handles btn_addloan.Click
        Response.Redirect(".\member_add_loan.aspx")
    End Sub

    Private Sub btn_remove_loan_Click(sender As Object, e As EventArgs) Handles btn_remove_loan.Click
        Response.Redirect(".\member_remove_loan_form.aspx")
    End Sub

    Private Sub btn_add_repayment_Click(sender As Object, e As EventArgs) Handles btn_add_repayment.Click
        Response.Redirect("./member_loan_repayment_form.aspx")
    End Sub

    '########################################## PAGING IN GRIDVIEW #################################################################################
    Private Sub GridView_view_loan_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_view_loan.PageIndexChanging
        GridView_view_loan.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_loan()
    End Sub
    Private Sub gridview_repay_history_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gridview_repay_history.PageIndexChanging
        gridview_repay_history.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_repay_history()
    End Sub
    '########################################## END OF PAGING IN GRIDVIEW #################################################################################
End Class

'Private Sub lenderdetail()
'    Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql = "select distinct name ,lender_type , lender_description, mail ,  street , town , country , postal_code , phone ,website  from loan_tbl as lo left join lender_tbl as l on lo.lender_id = l.lender_id left join lender_mail_tbl as m on l.lender_id = m.lender_id left join lender_type_tbl as t on l.type_id = t.type_id left join location_tbl as loc on l.lender_id = loc.lender_id left join contact_tbl as c on l.lender_id = c.lender_id where loan_status = 'active' and loan_name  = @loanname and transaction_id = @tans"
'    'need to coorect sql statment
'    Dim sqlCmd As New SqlCommand(sql, con)
'    sqlCmd.Parameters.AddWithValue("@loanname", loan_name_ddl.SelectedItem.Text)
'    sqlCmd.Parameters.AddWithValue("@tans", Session("Vtransac"))
'    con.Open()
'    Dim sqladap = New SqlDataAdapter(sqlCmd)
'    Dim dt = New DataTable
'    sqladap.Fill(dt)
'    lender_gridview.DataSource = dt
'    lender_gridview.DataBind()
'    con.Close()
'End Sub
'Private Sub loandetail()
'    Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql = "select loan_name , type  , loan_detail , amount_given , interest_rate , guarantor , mortgage , date_taken , loan_term ,loan_status from loan_tbl as l inner join loan_type_tbl as t on l.loan_type_id = t.loan_type_id where loan_status = 'active' and loan_name = @loanname and transaction_id = @tans"
'    Dim sqlCmd As New SqlCommand(sql, con)
'    'need to coorect sql statment
'    sqlCmd.Parameters.AddWithValue("@loanname", loan_name_ddl.SelectedItem.Text)
'    sqlCmd.Parameters.AddWithValue("@tans", Session("Vtransac"))
'    con.Open()
'    Dim sqladap = New SqlDataAdapter(sqlCmd)
'    Dim dt = New DataTable
'    sqladap.Fill(dt)
'    loan_gridview.DataSource = dt
'    loan_gridview.DataBind()
'    con.Close()
'End Sub
'Private Sub repaymentdetail()
'    Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql = "select capital_paid,interest_paid , repay_interest_rate , payment_date , remarks  from loan_tbl as l left join loan_pay_tbl as p on l.transaction_id = p.transaction_id where loan_status = 'active' and loan_name =  @loanname and l.transaction_id = @tans"
'    Dim sqlCmd As New SqlCommand(sql, con)
'    'need to coorect sql statment
'    sqlCmd.Parameters.AddWithValue("@loanname", loan_name_ddl.SelectedItem.Text)
'    sqlCmd.Parameters.AddWithValue("@tans", Session("Vtransac"))
'    con.Open()
'    Dim sqladap = New SqlDataAdapter(sqlCmd)
'    Dim dt = New DataTable
'    sqladap.Fill(dt)
'    repayment_gridview.DataSource = dt
'    repayment_gridview.DataBind()
'    con.Close()
'End Sub