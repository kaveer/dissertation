Imports System.Data.SqlClient
Imports System.Drawing

Public Class family_loan_repayment_form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_data_gridview_select_loan()
        If Not IsPostBack Then
            txtbx_repayment_date.Text = Format(DateAndTime.Today, "dd/MM/yyyy")
        End If
    End Sub

    '##################################### BIND DATA TO GRIDVIEW SELECT LOAN #################################################################
    Private Sub bind_data_gridview_select_loan()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  transaction_id as [ref no], loan_name as [name] , type as [loan type] , amount_given as [amount] , interest_rate as [interest rate] , loan_term as [term(month)] from loan_tbl as l inner join loan_type_tbl as lt on lt.loan_type_id = l.loan_type_id where family_id = @familyID and loan_status = 'active' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_select_loan.DataSource = dt
        GridView_select_loan.DataBind()
        con.Close()
    End Sub

    
    '##################################### END OF BIND DATA TO GRIDVIEW SELECT LOAN #################################################################

    '######################################## MAKE GRIDVIEW SELECT LOAN SELECTABLE ###################################################################
    Private Sub GridView_select_loan_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView_select_loan.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView_select_loan, "Select$" & e.Row.RowIndex)
            e.Row.ToolTip = "Click to select this row."
        End If
    End Sub
    Private Sub GridView_select_loan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView_select_loan.SelectedIndexChanged
        For Each row As GridViewRow In GridView_select_loan.Rows
            If row.RowIndex = GridView_select_loan.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                row.ToolTip = String.Empty
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                row.ToolTip = "Click to select this row."
            End If
        Next
        txtbx_interest_rate.Text = GridView_select_loan.SelectedRow.Cells(4).Text
    End Sub
    '######################################## END OF MAKE GRIDVIEW SELECT LOAN SELECTABLE ###################################################################

    '############################################## THEME SETUP ######################################################################
    Private Sub family_loan_repayment_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################################## END OF THEME SETUP ##############################################################

    '################################################### INSERT NEW PAYMENT #########################################################
    Private Sub btn_add_repayment_Click(sender As Object, e As EventArgs) Handles btn_add_repayment.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_all.Text = "select a loan to add repayment"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_all.Text = "no loan"
        ElseIf txtbx_capital_paid.Text = "" Then
            lbl_validation_all.Text = "Enter amount paid"
        ElseIf txtbx_repayment_date.Text = "" Then
            lbl_validation_all.Text = "enter date"
        ElseIf validation_capital_paid.IsValid = True And validation_date.IsValid = True And validation_interest_paid.IsValid = True And validation_interest_rate.IsValid = True Then
            lbl_validation_all.Text = "New repayment added"
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into loan_pay_tbl(transaction_id , capital_paid , interest_paid , payment_date , remarks , repay_interest_rate , loan_repay_status , loan_expn_status) values (@tranID , @cap_paid , @intrst_paid , convert(date,@repaydate,103) , @remark , @intrst_rate , 'active' , 'notadded'  )"
            'Convert(DATE,...,103 DOES NOT AFFECT HIS CODE IT WILL WORK IF BUY DIRECT @DATETAKEN)
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@tranID", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            sqlCmd1.Parameters.AddWithValue("@cap_paid", CDec(txtbx_capital_paid.Text))
            sqlCmd1.Parameters.AddWithValue("@intrst_paid", CDec(txtbx_interest_paid.Text))
            sqlCmd1.Parameters.AddWithValue("@repaydate", DateAndTime.Today)
            sqlCmd1.Parameters.AddWithValue("@remark", txtbx_remark.Text)
            sqlCmd1.Parameters.AddWithValue("@intrst_rate", txtbx_interest_rate.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            GridView_select_loan.SelectedIndex = -1
        End If
    End Sub
    '################################################### END OF INSERT NEW PAYMENT #########################################################

    '########################################## PAGING IN GRIDVIEW ############################################################################################
    Private Sub GridView_select_loan_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_loan.PageIndexChanging
        GridView_select_loan.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_select_loan()
    End Sub
    '########################################## END OF PAGING IN GRIDVIEW ############################################################################################

End Class