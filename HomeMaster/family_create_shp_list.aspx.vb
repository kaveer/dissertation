Imports System.Data.SqlClient

Public Class family_create_shp_list
    Inherits System.Web.UI.Page

    Dim Vcat_id As Integer
    Dim Vlist_type_id As Integer

    '################################# START DATE AND END DATE ##############################################
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtbx_date_created.Text = Format(DateAndTime.Today, "dd/MM/yyyy").ToString
            txtbx_finish_date.Text = Format(DateAndTime.Today.AddMonths(1), "dd/MM/yyyy").ToString
        End If
    End Sub
    '################################# END OF START DATE AND END DATE #######################################

    '###################################### SETUP FOR THEME ##################################################
    Private Sub family_create_shp_list_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '###################################### END SETUP FOR THEME ##################################################

    '##################################### SAVE TO DATABASE WITH VALIDATION ######################################
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If txtbx_listName.Text = "" Then
            lbl_validation_for_all.Text = "Enter your list name"
        ElseIf txtbx_finish_date.Text = "" Then
            lbl_validation_for_all.Text = "Enter a valid date like DD/MM/YYYY"
        ElseIf txtbx_estimated_butget.Text = "" Then
            lbl_validation_for_all.Text = "Enter an estimated budget"
        ElseIf validation_for_budget.IsValid = True And validation_for_finishDate.IsValid = True Then
            check_cat()
            add_list_name()
            Response.Redirect("./family_shop_list_form.aspx")
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
        Dim sql = "select * from shopping_category_tbl where category = 'categorized'"
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
        sqlCmd1.Parameters.AddWithValue("@datefinish", txtbx_finish_date.Text)
        sqlCmd1.Parameters.AddWithValue("@budget", txtbx_estimated_butget.Text)
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '##################################### END OF SAVE TO DATABASE WITH VALIDATION ######################################


End Class