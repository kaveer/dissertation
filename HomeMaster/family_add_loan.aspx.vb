Imports System.Data.SqlClient

Public Class family_add_loan
    Inherits System.Web.UI.Page

    Dim Vlender_type_id As Integer
    Dim Vloan_type_id As Integer
    Dim Vlender_id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        notpostback_bind_lendertype_ddl()
        notpostback_bind_loantype_ddl()
    End Sub

    '################################################ BIND LENDER TYPE TO DROPDOWNLIST #############################################
    Private Sub notpostback_bind_lendertype_ddl()
        If Not IsPostBack Then
            Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                con.Open()
                Dim cmd As New SqlCommand("select lender_type from lender_type_tbl", con)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                ddl_lender_type.DataSource = ds
                ddl_lender_type.DataTextField = "lender_type"
                ddl_lender_type.DataValueField = "lender_type"
                ddl_lender_type.DataBind()
                ddl_lender_type.Items.Insert(0, New ListItem("--Select type--", "0"))
                con.Close()
            End Using
        End If
    End Sub
    Private Sub bind_data_lender_type_ddl()
        Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            con.Open()
            Dim cmd As New SqlCommand("select lender_type from lender_type_tbl", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            ddl_lender_type.DataSource = ds
            ddl_lender_type.DataTextField = "lender_type"
            ddl_lender_type.DataValueField = "lender_type"
            ddl_lender_type.DataBind()
            ddl_lender_type.Items.Insert(0, New ListItem("--Select type--", "0"))
            con.Close()
        End Using
    End Sub
    '################################################ END OF BIND LENDER TYPE TO DROPDOWNLIST #############################################

    '################################################ ADD NEW LENDER TYPE #############################################################
    Private Sub btn_add_lender_type_Click(sender As Object, e As EventArgs) Handles btn_add_lender_type.Click
        If txtbx_add_lender_type.Text = "" Then
            panel_add_lender_type.Visible = False
            panel_add_loan_type.Visible = False
            panel_popup.Visible = False
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select * from lender_type_tbl where lender_type = LOWER(@lenderT) "
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@lenderT", txtbx_add_lender_type.Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                Vlender_type_id = CInt(reader("type_id"))
                ddl_lender_type.SelectedItem.Text = reader("lender_type")
                con.Close()
            ElseIf reader.Read() = False Then
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "insert into lender_type_tbl(lender_type) values (LOWER(@lenderT))"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@lenderT", txtbx_add_lender_type.Text)
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                get_lender_type_id()
            End If
            panel_add_lender_type.Visible = False
            panel_add_loan_type.Visible = False
            panel_popup.Visible = False
        End If
    End Sub
    Private Sub get_lender_type_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from lender_type_tbl where lender_type = LOWER(@lenderT) "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@lenderT", txtbx_add_lender_type.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vlender_type_id = CInt(reader("type_id"))
            ddl_lender_type.SelectedItem.Text = reader("lender_type")
            con.Close()
        End If
    End Sub
    '################################################ END OF ADD NEW LENDER TYPE #############################################################

    '################################################ BIND LOAN TYPE TO DROPDOWNLIST ########################################################
    Private Sub notpostback_bind_loantype_ddl()
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
    Private Sub bind_data_loan_type_ddl()
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
    End Sub
    '################################################ END OF BIND LOAN TYPE TO DROPDOWNLIST ########################################################

    '################################################ ADD NEW LOAN TYPE ############################################################################
    Private Sub btn_add_loan_type_Click(sender As Object, e As EventArgs) Handles btn_add_loan_type.Click
        If txtbx_add_loan_type.Text = "" Then
            panel_add_lender_type.Visible = False
            panel_add_loan_type.Visible = False
            panel_popup.Visible = False
        Else
            Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql = "select * from loan_type_tbl where type = LOWER(@loanT)"
            Dim sqlCmd As New SqlCommand(sql, con)
            sqlCmd.Parameters.AddWithValue("@loanT", txtbx_add_loan_type.Text)
            con.Open()
            Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
            If reader.Read() Then
                Vloan_type_id = CInt(reader("loan_type_id"))
                ddl_loan_type.SelectedItem.Text = reader("type")
                con.Close()
            ElseIf reader.Read() = False Then
                Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
                Dim sql1 = "insert into loan_type_tbl(type) values (LOWER(@loanT))"
                Dim sqlCmd1 As New SqlCommand(sql1, con1)
                sqlCmd1.Parameters.AddWithValue("@loanT", txtbx_add_loan_type.Text)
                con1.Open()
                sqlCmd1.ExecuteNonQuery()
                con1.Close()
                get_loan_type_id()
            End If
            panel_add_lender_type.Visible = False
            panel_add_loan_type.Visible = False
            panel_popup.Visible = False
        End If
    End Sub
    Private Sub get_loan_type_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from loan_type_tbl where type = LOWER(@loanT) "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@loanT", txtbx_add_loan_type.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vloan_type_id = CInt(reader("loan_type_id"))
            ddl_loan_type.SelectedItem.Text = reader("type")
            con.Close()
        End If
    End Sub
    '################################################ END OF ADD NEW LOAN TYPE ############################################################################

    '################################################ NAVIGATION BETWEEN VIEWS ################################################
    Private Sub nextinV0_btn_Click(sender As Object, e As EventArgs) Handles nextinV0_btn.Click
        If txtbx_lendername.Text = "" Then
            lbl_validation_view1.Text = "Enter lender name"
        ElseIf ddl_lender_type.SelectedItem.Text = "--Select type--" Then
            lbl_validation_view1.Text = "select lender type"
        ElseIf validation_email.IsValid = True And validation_fax.IsValid = True And validation_phn_fix.IsValid = True And validation_phn_ptb.IsValid = True Then
            MultiView1.ActiveViewIndex = 1
            lbl_validation_view1.Text = ""
        End If
    End Sub
    Private Sub previnV1_btn_Click(sender As Object, e As EventArgs) Handles previnV1_btn.Click
        MultiView1.ActiveViewIndex = 1
    End Sub
    Private Sub previousv2_btn_Click(sender As Object, e As EventArgs) Handles previousv2_btn.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
    Private Sub nextv2_btn_Click(sender As Object, e As EventArgs) Handles nextv2_btn.Click
        If validation_country.IsValid = True And validation_postal_code.IsValid = True And validation_town.IsValid = True Then
            MultiView1.ActiveViewIndex = 2
        End If
    End Sub
    '################################################ END OF NAVIGATION BETWEEN VIEWS ################################################

    '####################################### MAKE PANEL VISIBLE/UNVISIBLE #######################################################
    Private Sub btn_addlendertype_popup_Click(sender As Object, e As EventArgs) Handles btn_addlendertype_popup.Click
        panel_popup.Visible = True
        panel_add_lender_type.Visible = True
        panel_add_loan_type.Visible = False
        txtbx_add_lender_type.Text = ""
    End Sub
    Private Sub btn_cancel_lender_type_Click(sender As Object, e As EventArgs) Handles btn_cancel_lender_type.Click
        panel_popup.Visible = False
        panel_add_lender_type.Visible = False
        panel_add_loan_type.Visible = False
    End Sub
    Private Sub btn_cancel_loan_type_Click(sender As Object, e As EventArgs) Handles btn_cancel_loan_type.Click
        panel_popup.Visible = False
        panel_add_lender_type.Visible = False
        panel_add_loan_type.Visible = False
    End Sub
    Private Sub btn_addloan_type_popup_Click(sender As Object, e As EventArgs) Handles btn_addloan_type_popup.Click
        panel_popup.Visible = True
        panel_add_lender_type.Visible = False
        panel_add_loan_type.Visible = True
        txtbx_add_loan_type.Text = ""
    End Sub
    '####################################### END OF MAKE PANEL VISIBLE/UNVISIBLE #######################################################

    '############################################## SAVE LENDER AND LOAN INFORMATION ########################################################
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txtbx_loan_name.Text = "" Then
            lbl_validation_view3.Text = "Enter loan name"
        ElseIf ddl_loan_type.SelectedItem.Text = "--Select type--" Then
            lbl_validation_view3.Text = "Select loan type"
        ElseIf txtbx_amount.Text = "" Then
            lbl_validation_view3.Text = "Enter amount"
        ElseIf txtbx_interest_rate.Text = "" Then
            lbl_validation_view3.Text = "Enter interest rate"
        ElseIf txtbx_date_taken.Text = "" Then
            lbl_validation_view3.Text = "Enter date"
        ElseIf txtbx_loan_term.Text = "" Then
            lbl_validation_view3.Text = "enter the loan term(month)"
        ElseIf validation_amount.IsValid = True And validation_interest_rate.IsValid = True And validation_date_taken.IsValid = True And validation_loan_term.IsValid = True Then
            get_lender_type_id_tosave()
            Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql1 = "insert into lender_tbl(name , lender_description , type_id , lender_mail , lender_country , lender_town , lender_street , lender_postal_code , lender_phone_fix , lender_phone_ptb , lender_fax , lender_website) values (LOWER(@name) , @desrip , @lenderType_id , @mail , @country , @town , @street , @code , @phnefix , @phnptb , @fax , '@tochange' )"
            Dim sqlCmd1 As New SqlCommand(sql1, con1)
            sqlCmd1.Parameters.AddWithValue("@name", txtbx_lendername.Text)
            sqlCmd1.Parameters.AddWithValue("@desrip", txtbx_description.Text)
            sqlCmd1.Parameters.AddWithValue("@lenderType_id", Vlender_type_id)
            sqlCmd1.Parameters.AddWithValue("@mail", txtbx_email.Text)
            sqlCmd1.Parameters.AddWithValue("@country", txtbx_country.Text)
            sqlCmd1.Parameters.AddWithValue("@town", txtbx_town.Text)
            sqlCmd1.Parameters.AddWithValue("@street", txtbx_street.Text)
            sqlCmd1.Parameters.AddWithValue("@code", txtbx_postal_code.Text)
            sqlCmd1.Parameters.AddWithValue("@phnefix", txtbx_phone_fix.Text)
            sqlCmd1.Parameters.AddWithValue("@phnptb", txtbx_phone_ptb.Text)
            sqlCmd1.Parameters.AddWithValue("@fax", txtbx_fax.Text)
            con1.Open()
            sqlCmd1.ExecuteNonQuery()
            con1.Close()
            get_lender_id()
            change_lender_website_back()

            insert_loan()
        End If
    End Sub
    Private Sub get_lender_id()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from lender_tbl where name = LOWER(@name) and type_id = @typeID and lender_website = '@tochange' "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@name", txtbx_lendername.Text)
        sqlCmd.Parameters.AddWithValue("@typeID", Vlender_type_id)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vlender_id = CInt(reader("lender_id"))
            con.Close()
        End If
    End Sub
    Private Sub change_lender_website_back()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update lender_tbl set lender_website = @website where lender_id = @ID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@website", txtbx_website.Text)
        sqlCmd1.Parameters.AddWithValue("@ID", Vlender_id)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        get_lender_id()
    End Sub
    Private Sub get_lender_type_id_tosave()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from lender_type_tbl where lender_type = LOWER(@lenderT) "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@lenderT", ddl_lender_type.SelectedItem.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vlender_type_id = CInt(reader("type_id"))
            con.Close()
        End If
    End Sub
    Private Sub insert_loan()
        get_loan_type_id_tosave()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "insert into loan_tbl(family_id , lender_id , loan_type_id , loan_detail , amount_given , interest_rate , guarantor , mortgage , date_taken , loan_term , loan_status , loan_name ) values (@famID, @lenderID , @loantypeID , @detail , @amount , @interst , @guarantor , @mortgage ,convert(date,@date,103)  , @term , 'active' , LOWER(@name))"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
        sqlCmd1.Parameters.AddWithValue("@loantypeID", Vloan_type_id)
        sqlCmd1.Parameters.AddWithValue("@detail", txtbx_loan_detail.Text)
        sqlCmd1.Parameters.AddWithValue("@amount", txtbx_amount.Text)
        sqlCmd1.Parameters.AddWithValue("@interst", txtbx_interest_rate.Text)
        sqlCmd1.Parameters.AddWithValue("@guarantor", txtbx_guarantor.Text)
        sqlCmd1.Parameters.AddWithValue("@mortgage", txtbx_mortgage.Text)
        sqlCmd1.Parameters.AddWithValue("@date", txtbx_date_taken.Text)
        sqlCmd1.Parameters.AddWithValue("@term", txtbx_loan_term.Text)
        sqlCmd1.Parameters.AddWithValue("@name", txtbx_loan_name.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
        lbl_validation_view3.Text = "new loan added"
    End Sub
    Private Sub get_loan_type_id_tosave()
        Dim con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql = "select * from loan_type_tbl where type = LOWER(@loanT) "
        Dim sqlCmd As New SqlCommand(sql, con)
        sqlCmd.Parameters.AddWithValue("@loanT", ddl_loan_type.SelectedItem.Text)
        con.Open()
        Dim reader As SqlDataReader = sqlCmd.ExecuteReader()
        If reader.Read() Then
            Vloan_type_id = CInt(reader("loan_type_id"))
            con.Close()
        End If
    End Sub
    '############################################## SAVE LENDER AND LOAN INFORMATION ########################################################

    '################################################# THEME SETUP ###################################################################
    Private Sub family_add_loan_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ###################################################################




End Class