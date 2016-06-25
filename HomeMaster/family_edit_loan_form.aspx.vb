Imports System.Drawing
Imports System.Data.SqlClient

Public Class family_edit_loan_form
    Inherits System.Web.UI.Page

    Dim Vlender_id As Integer
    Dim Vstreet As String
    Dim Vtown As String
    Dim Vcountry As String
    Dim Vpostal As Integer
    Dim Vphne_fix As Integer
    Dim Vphne_ptb As Integer
    Dim Vfax As Integer
    Dim Vweb As String
    Dim Vlender_type_id As Integer

    Dim Vloan_type_id As Integer

    Dim Vcapital_paid As Decimal
    Dim Vinterest_paid As Decimal
    Dim Vinterest_rate As Decimal
    Dim Vdate_repay As String
    Dim Vremark As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_data_gridview_select_loan()
        notpostback_bind_ddl_lender_type()
        notpostback_loan_type()
    End Sub


    '########################################### NAVIGATION #######################################################################
    Private Sub Menu1_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu1.MenuItemClick
        MultiView1.ActiveViewIndex = Menu1.SelectedValue
    End Sub
    Private Sub link_lendername_Click(sender As Object, e As EventArgs) Handles link_lendername.Click
        If panel_lender_name_edit.Visible = False Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = True
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        ElseIf panel_lender_name_edit.Visible = True Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        End If
    End Sub
    Private Sub link_lenderDescription_Click(sender As Object, e As EventArgs) Handles link_lenderDescription.Click
        If panel_lender_descrip_edit.Visible = False Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = True
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        ElseIf panel_lender_descrip_edit.Visible = True Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        End If
    End Sub
    Private Sub link_lendermail_Click(sender As Object, e As EventArgs) Handles link_lendermail.Click
        If panel_lendermail.Visible = False Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = True
        ElseIf panel_lendermail.Visible = True Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        End If
    End Sub
    Private Sub link_lendertype_Click(sender As Object, e As EventArgs) Handles link_lendertype.Click
        If panel_lender_type.Visible = False Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = True
            panel_lendermail.Visible = False
        ElseIf panel_lender_type.Visible = True Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        End If
    End Sub
    Private Sub link_lenderlocation_Click(sender As Object, e As EventArgs) Handles link_lenderlocation.Click
        If panel_lender_location.Visible = False Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = True
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        ElseIf panel_lender_location.Visible = True Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        End If
    End Sub
    Private Sub link_lender_contact_Click(sender As Object, e As EventArgs) Handles link_lender_contact.Click
        If panel_lender_contact.Visible = False Then
            panel_lender_contact.Visible = True
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        ElseIf panel_lender_contact.Visible = True Then
            panel_lender_contact.Visible = False
            panel_lender_descrip_edit.Visible = False
            panel_lender_location.Visible = False
            panel_lender_name_edit.Visible = False
            panel_lender_type.Visible = False
            panel_lendermail.Visible = False
        End If
    End Sub
    Private Sub link_loan_name_Click(sender As Object, e As EventArgs) Handles link_loan_name.Click
        If panel_loan_name.Visible = False Then
            panel_loan_name.Visible = True
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_loan_name.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_loantype_Click(sender As Object, e As EventArgs) Handles link_loantype.Click
        If panel_loan_type.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = True
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_loan_type.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_loandetail_Click(sender As Object, e As EventArgs) Handles link_loandetail.Click
        If panel_loandetail.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = True
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_loandetail.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_amount_Click(sender As Object, e As EventArgs) Handles link_amount.Click
        If panel_loan_amount.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = True
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_loan_amount.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_interest_rate_Click(sender As Object, e As EventArgs) Handles link_interest_rate.Click
        If panel_interest_rate.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = True
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_interest_rate.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_date_taken_Click(sender As Object, e As EventArgs) Handles link_date_taken.Click
        If panel_date_taken.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = True
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_date_taken.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_loan_term_Click(sender As Object, e As EventArgs) Handles link_loan_term.Click
        If panel_loan_term.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = True
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        ElseIf panel_loan_term.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_guarantor_Click(sender As Object, e As EventArgs) Handles link_guarantor.Click
        If panel_guarantor.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = True
            panel_mortgage.Visible = False
        ElseIf panel_guarantor.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    Private Sub link_mortgage_Click(sender As Object, e As EventArgs) Handles link_mortgage.Click
        If panel_mortgage.Visible = False Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = True
        ElseIf panel_mortgage.Visible = True Then
            panel_loan_name.Visible = False
            panel_loan_type.Visible = False
            panel_loandetail.Visible = False
            panel_loan_amount.Visible = False
            panel_interest_rate.Visible = False
            panel_date_taken.Visible = False
            panel_loan_term.Visible = False
            panel_guarantor.Visible = False
            panel_mortgage.Visible = False
        End If
    End Sub
    '########################################### END OF NAVIGATION #######################################################################

    '########################################## THEME SETUP ##########################################################################
    Private Sub family_edit_loan_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '########################################## END OF THEME SETUP ##################################################################

    '##################################### BIND DATA TO GRIDVIEW #################################################################
    Private Sub bind_data_gridview_select_loan()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select  transaction_id as [ref no], loan_name as [Name] , type as [Loan type] , amount_given as [Amount] , interest_rate as [Interest rate] , loan_term as [Term(month)] from loan_tbl as l inner join loan_type_tbl as lt on lt.loan_type_id = l.loan_type_id where family_id = @familyID and loan_status = 'active' order by transaction_id desc "
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
    Private Sub bind_data_gridview_repayment()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = " select payment_id as [ref no] ,capital_paid as [capital paid] , interest_paid as [interest paid] , repay_interest_rate as [interest rate] , FORMAT(payment_date , 'dd/MM/yyyy')  as [date] , remarks from loan_pay_tbl as lp inner join loan_tbl as l on lp.transaction_id = l.transaction_id where family_id = @familyID and l.transaction_id = @tranID and loan_name = @name  order by payment_id desc"
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd.Parameters.AddWithValue("@tranID", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
        sqlCmd.Parameters.AddWithValue("@name", GridView_select_loan.SelectedRow.Cells(1).Text)
        con.Open()
        Dim sqladap = New SqlDataAdapter(sqlCmd)
        Dim dt = New DataTable
        sqladap.Fill(dt)
        GridView_loan_repayment.DataSource = dt
        GridView_loan_repayment.DataBind()
        con.Close()
    End Sub

    
    '##################################### END OF BIND DATA TO GRIDVIEW  #################################################################

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
        bind_data_gridview_repayment()

    End Sub

    
    '######################################## END OF MAKE GRIDVIEW SELECT LOAN SELECTABLE ###################################################################

    '####################################### MAKE GRIDVIEW REPAYMENT SELECTABLE ##################################################################################
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
    '####################################### END OF MAKE GRIDVIEW REPAYMENT SELECTABLE ##################################################################################

    '############################################### UPDATE LENDER DETAILS #######################################################################################
    Private Sub get_lender_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from lender_tbl as l inner join loan_tbl as lo on l.lender_id = lo.lender_id where family_id = @familyID and transaction_id = @tranID and loan_name = @name"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
        sqlCmd2.Parameters.AddWithValue("@tranID", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
        sqlCmd2.Parameters.AddWithValue("@name", GridView_select_loan.SelectedRow.Cells(1).Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vlender_id = CInt(reader2("lender_id"))
            Vstreet = reader2("lender_street")
            Vtown = reader2("lender_town")
            Vcountry = reader2("lender_country")
            Vpostal = reader2("lender_postal_code")
            Vphne_fix = CInt(reader2("lender_phone_fix"))
            Vphne_ptb = CInt(reader2("lender_phone_ptb"))
            Vfax = CInt(reader2("lender_fax"))
            Vweb = reader2("lender_website")
        End If
        con2.Close()
    End Sub
    Private Sub btn_save_lender_name_edit_Click(sender As Object, e As EventArgs) Handles btn_save_lender_name_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view1.Text = "no loan"
        ElseIf txtbx_lender_name_edit.Text = "" Then
            lbl_validation_view1.Text = "enter name to update"
        Else
            get_lender_id()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update lender_tbl set name = LOWER(@name) where lender_id = @lender_id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_lender_name_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@lender_id", Vlender_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "name updated to" + " " + txtbx_lender_name_edit.Text
            GridView_select_loan.SelectedIndex = -1
        End If
    End Sub
    Private Sub btn_save_lender_descrip_edit_Click(sender As Object, e As EventArgs) Handles btn_save_lender_descrip_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view1.Text = "no loan"
        ElseIf txtbx_lender_descrip_edit.Text = "" Then
            lbl_validation_view1.Text = "enter description to update"
        Else
            get_lender_id()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update lender_tbl set lender_description = @des where lender_id = @lender_id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@des", txtbx_lender_descrip_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@lender_id", Vlender_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "description updated "
            GridView_select_loan.SelectedIndex = -1
        End If
    End Sub
    Private Sub btn_save_lender_mail_Click(sender As Object, e As EventArgs) Handles btn_save_lender_mail.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view1.Text = "no loan"
        ElseIf txtbx_lender_mail_edit.Text = "" Then
            lbl_validation_view1.Text = "enter mail to update"
        ElseIf validation_lender_email.IsValid = True Then
            get_lender_id()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update lender_tbl set lender_mail = @des where lender_id = @lender_id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@des", txtbx_lender_mail_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@lender_id", Vlender_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "mail updated " + " " + txtbx_lender_mail_edit.Text
            GridView_select_loan.SelectedIndex = -1
        End If
    End Sub
    Private Sub btn_save_lender_location_Click(sender As Object, e As EventArgs) Handles btn_save_lender_location.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view1.Text = "no loan"
        ElseIf validation_lender_town.IsValid = True And validation_lender_country.IsValid = True And validation_postal_code.IsValid = True Then
            get_lender_id()

            If txtbx_lender_street_edit.Text = "" Then
                txtbx_lender_street_edit.Text = Vstreet
            End If
            If txtbx_lender_town_edit.Text = "" Then
                txtbx_lender_town_edit.Text = Vtown
            End If
            If txtbx_lender_country_edit.Text = "" Then
                txtbx_lender_country_edit.Text = Vcountry
            End If
            If txtbx_lender_postal_edit.Text = "" Then
                txtbx_lender_postal_edit.Text = CStr(Vpostal)
            End If

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update lender_tbl set lender_street= @street , lender_town = @town , lender_country = @country , lender_postal_code = @postal where lender_id = @lender_id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@street", txtbx_lender_street_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@town", txtbx_lender_town_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@country", txtbx_lender_country_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@postal", CInt(txtbx_lender_postal_edit.Text))
            sqlCmd1.Parameters.AddWithValue("@lender_id", Vlender_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "location updated "
            GridView_select_loan.SelectedIndex = -1
            txtbx_lender_street_edit.Text = ""
            txtbx_lender_town_edit.Text = ""
            txtbx_lender_country_edit.Text = ""
            txtbx_lender_postal_edit.Text = ""
        End If
    End Sub
    Private Sub btn_save_lender_contact_Click(sender As Object, e As EventArgs) Handles btn_save_lender_contact.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view1.Text = "no loan"
        ElseIf validation_phn_fix.IsValid = True And validation_phn_ptb.IsValid = True And validation_fax.IsValid = True Then
            get_lender_id()

            If txtbx_lender_phn_fix_edit.Text = "" Then
                txtbx_lender_phn_fix_edit.Text = CStr(Vphne_fix)
            End If
            If txtbx_lender_phn_ptb_edit.Text = "" Then
                txtbx_lender_phn_ptb_edit.Text = CStr(Vphne_ptb)
            End If
            If txtbx_lender_fax_edit.Text = "" Then
                txtbx_lender_fax_edit.Text = CStr(Vfax)
            End If
            If txtbx_lender_website_edit.Text = "" Then
                txtbx_lender_website_edit.Text = Vweb
            End If

            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = " update lender_tbl set lender_phone_fix = @fix , lender_phone_ptb = @ptb , lender_fax = @fax , lender_website = @web where lender_id = @lender_id "
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@fix", txtbx_lender_phn_fix_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@ptb", txtbx_lender_phn_ptb_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@fax", txtbx_lender_fax_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@web", txtbx_lender_website_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@lender_id", Vlender_id)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = "contact updated "
            GridView_select_loan.SelectedIndex = -1
            txtbx_lender_phn_fix_edit.Text = ""
            txtbx_lender_phn_ptb_edit.Text = ""
            txtbx_lender_fax_edit.Text = ""
            txtbx_lender_website_edit.Text = ""
        End If
    End Sub
    Private Sub notpostback_bind_ddl_lender_type()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from lender_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_lender_type_edit.DataSource = ds
                ddl_lender_type_edit.DataTextField = "lender_type"
                ddl_lender_type_edit.DataValueField = "lender_type"
                ddl_lender_type_edit.DataBind()
                ddl_lender_type_edit.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub btn_add_new_type_Click(sender As Object, e As EventArgs) Handles btn_add_new_type.Click
        If txtbx_add_new_type.Text = "" Then
            lbl_validation_view1.Text = "enter new type to add"
        Else
            ddl_lender_type_edit.SelectedItem.Text = txtbx_add_new_type.Text
        End If
    End Sub
    Private Sub btn_save_lender_type_edit_Click(sender As Object, e As EventArgs) Handles btn_save_lender_type_edit.Click
        If ddl_lender_type_edit.SelectedIndex = 0 Then
            lbl_validation_view1.Text = "select type to update"
        ElseIf GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view1.Text = "select loan to update"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view1.Text = "no loan to update"
        Else
            Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql2 = "select * from lender_type_tbl where lender_type = LOWER(@type)"
            Dim sqlCmd2 As New SqlCommand(sql2, con2)
            sqlCmd2.Parameters.AddWithValue("@type", ddl_lender_type_edit.SelectedItem.Text)
            con2.Open()
            Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
            If reader2.Read() = True Then
                get_lender_id()
                Vlender_type_id = reader2("type_id")
                update_lender_type_iD()
                lbl_validation_view1.Text = "type updated"
                GridView_select_loan.SelectedIndex = -1
            ElseIf reader2.Read() = False Then
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = " insert into lender_type_tbl(lender_type) values (LOWER(@type)) "
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@type", ddl_lender_type_edit.SelectedItem.Text)
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                get_lender_id()
                get_lender_type_id()
                update_lender_type_iD()
                lbl_validation_view1.Text = "type updated"
                GridView_select_loan.SelectedIndex = -1
            End If
            con2.Close()
        End If
    End Sub
    Private Sub get_lender_type_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from lender_type_tbl where lender_type = LOWER(@type)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@type", ddl_lender_type_edit.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vlender_type_id = reader2("type_id")
        End If
        con2.Close()
    End Sub
    Private Sub update_lender_type_iD()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update lender_tbl set type_id = @type where lender_id = @lenderID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@type", Vlender_type_id)
        sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '############################################### END OF UPDATE LENDER DETAILS #######################################################################################

    '################################################# UPDATE LOAN DETAILS #############################################################################################
    Private Sub btn_save_loan_name_edit_Click(sender As Object, e As EventArgs) Handles btn_save_loan_name_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_loan_name_edit.Text = "" Then
            lbl_validation_view2.Text = "enter name to update"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set loan_name = LOWER(@name) where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_loan_name_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view1.Text = " loan name updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_add_loan_type_Click(sender As Object, e As EventArgs) Handles btn_add_loan_type.Click
        If btn_add_loan_type.Text = "" Then
            lbl_validation_view2.Text = "enter new loan type"
        Else
            ddl_loan_type.SelectedItem.Text = txtbx_add_loan_type.Text
        End If
    End Sub
    Private Sub btn_save_loan_type_Click(sender As Object, e As EventArgs) Handles btn_save_loan_type.Click
        If ddl_loan_type.SelectedIndex = 0 Then
            lbl_validation_view2.Text = "select type to update"
        ElseIf GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select loan to update"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan to update"
        Else
            Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql2 = "select * from loan_type_tbl where type = LOWER(@type)"
            Dim sqlCmd2 As New SqlCommand(sql2, con2)
            sqlCmd2.Parameters.AddWithValue("@type", ddl_loan_type.SelectedItem.Text)
            con2.Open()
            Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
            If reader2.Read() = True Then
                Vloan_type_id = reader2("loan_type_id")
                update_loan_type_id()
                lbl_validation_view2.Text = "type updated"
                GridView_select_loan.SelectedIndex = -1
                bind_data_gridview_select_loan()
            ElseIf reader2.Read() = False Then
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = " insert into loan_type_tbl(type) values (LOWER(@type)) "
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@type", ddl_loan_type.SelectedItem.Text)
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                get_loan_type_id()
                update_loan_type_id()
                lbl_validation_view2.Text = "type updated"
                GridView_select_loan.SelectedIndex = -1
                bind_data_gridview_select_loan()
            End If
            con2.Close()
        End If
    End Sub
    Private Sub get_loan_type_id()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from loan_type_tbl where type = LOWER(@type)"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@type", ddl_loan_type.SelectedItem.Text)
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vloan_type_id = reader2("loan_type_id")
        End If
        con2.Close()
    End Sub
    Private Sub update_loan_type_id()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update loan_tbl set loan_type_id = @type where transaction_id = @tranID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@type", Vloan_type_id)
        sqlCmd1.Parameters.AddWithValue("@tranID", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub notpostback_loan_type()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select * from loan_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_loan_type.DataSource = ds
                ddl_loan_type.DataTextField = "type"
                ddl_loan_type.DataValueField = "type"
                ddl_loan_type.DataBind()
                ddl_loan_type.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub btn_save_loan_detail_edit_Click(sender As Object, e As EventArgs) Handles btn_save_loan_detail_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_loan_detail_edit.Text = "" Then
            lbl_validation_view2.Text = "enter description to update"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set loan_detail = @des where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@des", txtbx_loan_detail_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan description updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_save_loan_amount_Click(sender As Object, e As EventArgs) Handles btn_save_loan_amount.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_loan_amount_edit.Text = "" Then
            lbl_validation_view2.Text = "enter amount to update"
        ElseIf validation_loan_amount.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set amount_given = @amt where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@amt", txtbx_loan_amount_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan amount updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_save_loan_inrst_rate_edit_Click(sender As Object, e As EventArgs) Handles btn_save_loan_inrst_rate_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_interest_rate.Text = "" Then
            lbl_validation_view2.Text = "enter amount to update"
        ElseIf validation_intrest_rate.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set interest_rate = @rate where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@rate", txtbx_interest_rate.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan interest rate updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_save_loan_date_edit_Click(sender As Object, e As EventArgs) Handles btn_save_loan_date_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_loan_date_edit.Text = "" Then
            lbl_validation_view2.Text = "enter amount to update"
        ElseIf validation_date_taken.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set date_taken = convert(date,@date,103) where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@date", txtbx_loan_date_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan date updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_save_loan_term_edit_Click(sender As Object, e As EventArgs) Handles btn_save_loan_term_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_loan_term_edit.Text = "" Then
            lbl_validation_view2.Text = "enter term to update"
        ElseIf validation_loan_term.IsValid = True Then
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set loan_term = @term where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@term", txtbx_loan_term_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan term updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_save_guarantor_edit_Click(sender As Object, e As EventArgs) Handles btn_save_guarantor_edit.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_guarantor_edit.Text = "" Then
            lbl_validation_view2.Text = "enter guarantor to update"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set guarantor = @term where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@term", txtbx_guarantor_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan guarantor updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    Private Sub btn_save_mortgage_Click(sender As Object, e As EventArgs) Handles btn_save_mortgage.Click
        If GridView_select_loan.SelectedIndex = -1 Then
            lbl_validation_view2.Text = "select a loan"
        ElseIf GridView_select_loan.Rows.Count = 0 Then
            lbl_validation_view2.Text = "no loan"
        ElseIf txtbx_mortgage_edit.Text = "" Then
            lbl_validation_view2.Text = "enter mortgage to update"
        Else
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "update loan_tbl set mortgage = @mrt where transaction_id = @loan_id"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@mrt", txtbx_mortgage_edit.Text)
            sqlCmd1.Parameters.AddWithValue("@loan_id", CInt(GridView_select_loan.SelectedRow.Cells(0).Text))
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            lbl_validation_view2.Text = " loan mortgage updated "
            GridView_select_loan.SelectedIndex = -1
            bind_data_gridview_select_loan()
        End If
    End Sub
    '################################################# END OF UPDATE LOAN DETAILS #############################################################################################

    '####################################################### UPDATE REPAYMENT OF LOAN DETAILS ##################################################################################
    Private Sub btn_save_repay_Click(sender As Object, e As EventArgs) Handles btn_save_repay.Click
        If GridView_loan_repayment.SelectedIndex = -1 Then
            lbl_validation_view3.Text = "Select a repayment to update"
        ElseIf GridView_loan_repayment.Rows.Count = 0 Then
            lbl_validation_view3.Text = "no repayment"
        ElseIf validation_repay_capital.IsValid = True And validation_repay_date.IsValid = True And validation_repay_intrst_paid.IsValid = True And validation_repay_intrst_rate.IsValid = True Then
            get_repay_detail()

            If txtbx_repy_capital_edit.Text = "" Then
                txtbx_repy_capital_edit.Text = Vcapital_paid
            End If
            If txtbx_repay_interest_paid_edit.Text = "" Then
                txtbx_repay_interest_paid_edit.Text = Vinterest_paid
            End If
            If txtbx_repay_intrst_rate_edit.Text = "" Then
                txtbx_repay_intrst_rate_edit.Text = Vinterest_rate
            End If
            If txtbx_repay_date_edit.Text = "" Then
                txtbx_repay_date_edit.Text = Vdate_repay
            End If
            If txtbx_repay_remark_edit.Text = "" Then
                txtbx_repay_remark_edit.Text = Vremark
            End If

            update_repayment()
        End If

    End Sub
    Private Sub get_repay_detail()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from loan_pay_tbl where payment_id = @payID"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@payID", CInt(GridView_loan_repayment.SelectedRow.Cells(0).Text))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            Vcapital_paid = CDec(reader2("capital_paid"))
            Vinterest_paid = CDec(reader2("interest_paid"))
            Vinterest_rate = CDec(reader2("repay_interest_rate"))
            Vdate_repay = reader2("payment_date")
            Vremark = reader2("remarks")
        End If
        con2.Close()
    End Sub
    Private Sub update_repayment()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update loan_pay_tbl set capital_paid = @cap , interest_paid = @intPaid , payment_date = convert(date,@payDate,103)  , remarks = @remark , repay_interest_rate = @rate where payment_id = @payID "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@payID", CInt(GridView_loan_repayment.SelectedRow.Cells(0).Text))
        sqlCmd1.Parameters.AddWithValue("@cap", txtbx_repy_capital_edit.Text)
        sqlCmd1.Parameters.AddWithValue("@intPaid", txtbx_repay_interest_paid_edit.Text)
        sqlCmd1.Parameters.AddWithValue("@payDate", txtbx_repay_date_edit.Text)
        sqlCmd1.Parameters.AddWithValue("@remark", txtbx_repay_remark_edit.Text)
        sqlCmd1.Parameters.AddWithValue("@rate", txtbx_repay_intrst_rate_edit.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        lbl_validation_view3.Text = " repayment updated "
        GridView_loan_repayment.SelectedIndex = -1
        bind_data_gridview_repayment()
        txtbx_repy_capital_edit.Text = ""
        txtbx_repay_interest_paid_edit.Text = ""
        txtbx_repay_intrst_rate_edit.Text = ""
        txtbx_repay_date_edit.Text = ""
        txtbx_repay_remark_edit.Text = ""
    End Sub
    '####################################################### END OF UPDATE REPAYMENT OF LOAN DETAILS ##################################################################################

    '####################################################### PAGING FOR GRIDVIEW ###############################################################################################
    Private Sub GridView_select_loan_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_select_loan.PageIndexChanging
        GridView_select_loan.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_select_loan()
    End Sub
    Private Sub GridView_loan_repayment_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_loan_repayment.PageIndexChanging
        GridView_loan_repayment.PageIndex = e.NewPageIndex
        Me.bind_data_gridview_repayment()
    End Sub
    '####################################################### END OF PAGING FOR GRIDVIEW ###############################################################################################
End Class