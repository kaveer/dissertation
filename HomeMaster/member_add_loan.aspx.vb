Imports System.Data.SqlClient

Public Class member_add_loan
    Inherits System.Web.UI.Page

    Dim Vlender_type_id As Integer
    Dim Vloan_type_id As Integer
    Dim Vlender_id As Integer


    Private Sub member_add_loan_Load(sender As Object, e As EventArgs) Handles Me.Load
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
    Private Sub member_add_loan_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '############################################# END OF THEME SETUP ###################################################################

End Class


'Private Sub save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click
'    Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql2 = "select * from loan_tbl where loan_name = @loanNmae "
'    Dim sqlCmd2 As New SqlCommand(sql2, con2)
'    sqlCmd2.Parameters.AddWithValue("@loanNmae", loanname_txtbx.Text)
'    con2.Open()
'    Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
'    If reader2.Read() = True Then
'        Label15.Text = "lean name already ex"
'    Else
'        con2.Close()
'        obtaintypeID()
'        insert_lenderTBL()
'        obtain_lenderID()
'        insert_mail()
'        addphone()
'        insert_fax_website()
'        insert_location()
'        obtain_loantype()
'        insert_loan()
'    End If


'    Label13.Text = Vloan_type_id
'End Sub
'Private Sub obtaintypeID()
'    Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql2 = "select * from lender_type_tbl where lender_type = @lenderTypeT"
'    Dim sqlCmd2 As New SqlCommand(sql2, con2)
'    sqlCmd2.Parameters.AddWithValue("@lenderTypeT", lender_type_ddl.SelectedItem.Text)
'    con2.Open()
'    Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
'    If reader2.Read() = True Then
'        Vlender_type_id = reader2("type_id")
'    End If
'    con2.Close()
'End Sub
'Private Sub insert_lenderTBL()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into lender_tbl(name, lender_description , type_id) values (@nameT, @descT, @typeT)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@nameT", lendername_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@descT", descrip_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@typeT", Vlender_type_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub obtain_lenderID()
'    Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql2 = "select * from lender_tbl where name = @nameT and lender_description = @descT and type_id = @typeT"
'    Dim sqlCmd2 As New SqlCommand(sql2, con2)
'    sqlCmd2.Parameters.AddWithValue("@nameT", lendername_txtbx.Text)
'    sqlCmd2.Parameters.AddWithValue("@descT", descrip_txtbx.Text)
'    sqlCmd2.Parameters.AddWithValue("@typeT", Vlender_type_id)
'    con2.Open()
'    Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
'    If reader2.Read() = True Then
'        Vlender_id = reader2("lender_id")
'    End If
'    con2.Close()
'End Sub
'Private Sub insert_mail()
'    If email_txtbx.Text <> "" Then
'        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'        Dim sql1 = "insert into lender_mail_tbl(mail , lender_id) values (@emailT , @lenderID)"
'        Dim sqlCmd1 As New SqlCommand(sql1, con1)
'        sqlCmd1.Parameters.AddWithValue("@emailT", email_txtbx.Text)
'        sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'        con1.Open()
'        sqlCmd1.ExecuteNonQuery()
'        con1.Close()
'    End If
'    If addmail1_txtbx.Text <> "" Then
'        addmail1()
'    End If
'    If addmail2_txtbx.Text <> "" Then
'        addmail2()
'    End If
'    If addmail3_txtbx.Text <> "" Then
'        addmail3()
'    End If
'End Sub
'Private Sub addmail1()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into lender_mail_tbl(mail , lender_id) values (@emailT , @lenderID)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@emailT", addmail1_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub addmail2()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into lender_mail_tbl(mail , lender_id) values (@emailT , @lenderID)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@emailT", addmail2_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub addmail3()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into lender_mail_tbl(mail , lender_id) values (@emailT , @lenderID)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@emailT", addmail3_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub addphone()
'    If phone_txtbx.Text <> "" Then
'        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'        Dim sql1 = "insert into contact_tbl(lender_id , phone ) values ( @lenderID , @phoneT )"
'        Dim sqlCmd1 As New SqlCommand(sql1, con1)
'        sqlCmd1.Parameters.AddWithValue("@phoneT", phone_txtbx.Text)
'        sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'        con1.Open()
'        sqlCmd1.ExecuteNonQuery()
'        con1.Close()
'    End If
'    If phone1_txtbx.Text <> "" Then
'        phone1()
'    End If
'    If phone2_txtbx.Text <> "" Then
'        phone2()
'    End If
'    If phone3_txtbx.Text <> "" Then
'        phone3()
'    End If
'End Sub
'Private Sub phone1()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into contact_tbl(lender_id , phone ) values ( @lenderID , @phoneT )"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@phoneT", phone1_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub phone2()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into contact_tbl(lender_id , phone ) values ( @lenderID , @phoneT )"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@phoneT", phone2_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub phone3()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into contact_tbl(lender_id , phone ) values ( @lenderID , @phoneT )"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@phoneT", phone3_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub insert_fax_website()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into contact_tbl(lender_id , fax , website ) values ( @lenderID , @faxT , @websiteT)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@faxT", fax_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@websiteT", website_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub insert_location()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into location_tbl(lender_id , street , town , country , postal_code) values (@lender , @street , @town ,@country , @postal)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@street", street_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@town", town_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@country", country_textbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@postal", postal_code_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@lender", Vlender_id)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'End Sub
'Private Sub obtain_loantype()
'    Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql2 = "select * from loan_type_tbl where type = @laontype "
'    Dim sqlCmd2 As New SqlCommand(sql2, con2)
'    sqlCmd2.Parameters.AddWithValue("@laontype", loantype_ddl.SelectedItem.Text)
'    con2.Open()
'    Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
'    If reader2.Read() = True Then
'        Vloan_type_id = reader2("loan_type_id")
'    End If
'    con2.Close()
'End Sub
'Private Sub insert_loan()
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into loan_tbl(family_id , lender_id , loan_type_id , loan_detail , amount_given, interest_rate , guarantor , mortgage , loan_name , loan_status , loan_term , date_taken) values(@familyID , @lenderID , @loantype , @detail , @amount , @inerst , @guarantor , @mortgage, @loanname , 'active' , @term , convert(date,@datetaken,103))"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@familyID", CInt(Session("family_id")))
'    sqlCmd1.Parameters.AddWithValue("@lenderID", Vlender_id)
'    sqlCmd1.Parameters.AddWithValue("@loantype", Vloan_type_id)
'    sqlCmd1.Parameters.AddWithValue("@detail", loandetail_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@amount", amount_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@inerst", interst_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@guarantor", guarantor_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@mortgage", mortgage_txt.Text)
'    sqlCmd1.Parameters.AddWithValue("@loanname", loanname_txtbx.Text)
'    sqlCmd1.Parameters.AddWithValue("@term", CInt(loanterm_txtbx.Text))
'    sqlCmd1.Parameters.AddWithValue("@datetaken", datetaken_txtbx.Text)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()
'    Label22.Text = "save successful"
'End Sub

'Private Sub load_lendertype()

'End Sub
'Private Sub load_loantype()
'    If Not IsPostBack Then
'        Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'            con.Open()
'            Dim cmd As New SqlCommand("select type from loan_type_tbl", con)
'            Dim da As New SqlDataAdapter(cmd)
'            Dim ds As New DataSet()
'            da.Fill(ds)
'            loantype_ddl.DataSource = ds
'            loantype_ddl.DataTextField = "type"
'            loantype_ddl.DataValueField = "type"
'            loantype_ddl.DataBind()
'            loantype_ddl.Items.Insert(0, New ListItem("--Select type--", "0"))
'            con.Close()
'        End Using
'    End If
'End Sub
'Protected Sub addlendertype_btn_Click(sender As Object, e As EventArgs) Handles addlendertype_btn.Click
'    popup_pnl.Visible = True
'    addtype_pnl.Visible = True

'End Sub
'Private Sub canceladdtype_btn_Click(sender As Object, e As EventArgs) Handles canceladdtype_btn.Click
'    addtype_pnl.Visible = False
'    popup_pnl.Visible = False
'End Sub
'Private Sub addtype_btn_Click(sender As Object, e As EventArgs) Handles addtype_btn.Click
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into lender_type_tbl(lender_type) values (@addtypeT)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@addtypeT", addlendertype_txtbx.Text)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()

'    Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'        con.Open()
'        Dim cmd As New SqlCommand("select lender_type from lender_type_tbl", con)
'        Dim da As New SqlDataAdapter(cmd)
'        Dim ds As New DataSet()
'        da.Fill(ds)
'        lender_type_ddl.DataSource = ds
'        lender_type_ddl.DataTextField = "lender_type"
'        lender_type_ddl.DataValueField = "lender_type"
'        lender_type_ddl.DataBind()
'        lender_type_ddl.Items.Insert(0, New ListItem("--Select type--", "0"))
'        con.Close()
'    End Using

'    lender_type_ddl.SelectedValue = addlendertype_txtbx.Text
'    popup_pnl.Visible = False

'End Sub
'Private Sub addmultiplemail_btn_Click(sender As Object, e As EventArgs) Handles addmultiplemail_btn.Click
'    addmail_pnl.Visible = True
'    popup_pnl.Visible = True


'End Sub
'Private Sub cancel_multiple_btn_Click(sender As Object, e As EventArgs) Handles cancel_multiple_btn.Click
'    addmail_pnl.Visible = False
'    popup_pnl.Visible = False
'End Sub
'Private Sub addmailPNL_btn_Click(sender As Object, e As EventArgs) Handles addmailPNL_btn.Click

'    popup_pnl.Visible = True
'    addmail_pnl.Visible = False
'End Sub
'Private Sub addmultiplephone_btn_Click(sender As Object, e As EventArgs) Handles addmultiplephone_btn.Click
'    addnumber_pnl.Visible = True
'    popup_pnl.Visible = True
'End Sub
'Private Sub addphone_btn_Click(sender As Object, e As EventArgs) Handles addphone_btn.Click
'    addnumber_pnl.Visible = False
'    popup_pnl.Visible = True
'End Sub


'Private Sub loantype_btn_Click(sender As Object, e As EventArgs) Handles loantype_btn.Click
'    loandetail_pnl.Visible = True
'    popup_pnl.Visible = True
'End Sub
'Private Sub addloantype_btn_Click(sender As Object, e As EventArgs) Handles addloantype_btn.Click
'    Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'    Dim sql1 = "insert into loan_type_tbl(type) values (@addtypeT)"
'    Dim sqlCmd1 As New SqlCommand(sql1, con1)
'    sqlCmd1.Parameters.AddWithValue("@addtypeT", addloantype_txtbx.Text)
'    con1.Open()
'    sqlCmd1.ExecuteNonQuery()
'    con1.Close()

'    Using con As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
'        con.Open()
'        Dim cmd As New SqlCommand("select type from loan_type_tbl", con)
'        Dim da As New SqlDataAdapter(cmd)
'        Dim ds As New DataSet()
'        da.Fill(ds)
'        loantype_ddl.DataSource = ds
'        loantype_ddl.DataTextField = "type"
'        loantype_ddl.DataValueField = "type"
'        loantype_ddl.DataBind()
'        loantype_ddl.Items.Insert(0, New ListItem("--Select type--", "0"))
'        con.Close()
'    End Using

'    loantype_ddl.SelectedValue = addloantype_txtbx.Text
'End Sub

'Private Sub cancelloantype_btn_Click(sender As Object, e As EventArgs) Handles cancelloantype_btn.Click
'    loandetail_pnl.Visible = False
'    popup_pnl.Visible = False
'End Sub

'Private Sub cancelphone_btn_Click(sender As Object, e As EventArgs) Handles cancelphone_btn.Click
'    popup_pnl.Visible = False
'    addnumber_pnl.Visible = False
'End Sub
