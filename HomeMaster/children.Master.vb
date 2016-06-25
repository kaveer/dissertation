Imports System.Data.SqlClient

Public Class children
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        '"Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True" = "Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True"
        user_lbl.Text = Session("user")
        check_notif()
    End Sub

    '########################################## LOGOUT OPTION #########################################################################
    Private Sub logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Session.Abandon()
        'Session.Remove("user")
        Response.Redirect("Default.aspx")
    End Sub
    '########################################## END OF LOGOUT OPTION #########################################################################

    '################################### NOTIFICATION ###############################################################
    Private Sub btn_notification_Click(sender As Object, e As ImageClickEventArgs) Handles btn_notification.Click
        If Panel_notification.Visible = False Then
            Panel_notification.Visible = True
            btn_notification.ImageUrl = "~\notification\nonotif.png"
        ElseIf Panel_notification.Visible = True Then
            lbl_msg_notif.Visible = False
            lbl_stock_notif.Visible = False
            lbl_share_list_notif.Visible = False
            Panel_notification.Visible = False
            'btn_notification.ImageUrl = "~\notification\notif.png"
        End If

        'If btn_notification.ImageUrl = "~\notification\nonotif.png" Then
        'btn_notification.ImageUrl = "~\notification\notif.png"
        'End If
    End Sub
    Private Sub check_notif()
        If Not IsPostBack Then
            Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
            Dim sql2 = "select * from family_tbl where family_id = @famID and noti_status = 'new-notif'"
            Dim sqlCmd2 As New SqlCommand(sql2, con2)
            sqlCmd2.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
            con2.Open()
            Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
            If reader2.Read() = True Then
                btn_notification.ImageUrl = "~\notification\notif.png"
                check_msg()
                check_shared_list()
                change_user_status()
            ElseIf reader2.Read() = False Then
                btn_notification.ImageUrl = "~\notification\nonotif.png"
            End If
        End If
    End Sub
    Private Sub check_msg()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from messaging_tbl where sent_to = @user and notif_msg = 'notify'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@user", Session("user"))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            lbl_msg_notif.Visible = True
            change_msg_notif_status()
        ElseIf reader2.Read() = False Then
            lbl_msg_notif.Visible = False
        End If
    End Sub
    Private Sub change_msg_notif_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update messaging_tbl set notif_msg = 'no-notif' where sent_to = @user"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@user", Session("user"))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub check_shared_list()
        Dim con2 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql2 = "select * from Shopping_list_tbl where shopping_list_type='shared' and shared_to = @user and shared_notif = 'notify'"
        Dim sqlCmd2 As New SqlCommand(sql2, con2)
        sqlCmd2.Parameters.AddWithValue("@user", Session("user"))
        con2.Open()
        Dim reader2 As SqlDataReader = sqlCmd2.ExecuteReader()
        If reader2.Read() = True Then
            lbl_share_list_notif.Visible = True
            change_shared_list_status()
        ElseIf reader2.Read() = False Then
            lbl_share_list_notif.Visible = False
        End If
    End Sub
    Private Sub change_shared_list_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update Shopping_list_tbl set shared_notif = 'no-notif' where shopping_list_type='shared' and shared_to = @user "
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@user", Session("user"))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    Private Sub change_user_status()
        Dim con1 As New SqlConnection("Data Source=kaveer-pc\SQL12HOMEMASTER;Initial Catalog=HomeMaster;Integrated Security=True")
        Dim sql1 = "update family_tbl set noti_status = 'no-notif' where family_id = @famID"
        Dim sqlCmd1 As New SqlCommand(sql1, con1)
        sqlCmd1.Parameters.AddWithValue("@famID", CInt(Session("family_id")))
        con1.Open()
        sqlCmd1.ExecuteNonQuery()
        con1.Close()
    End Sub
    '################################### END OF NOTIFICATION ###############################################################

    '#################################### SETTING ################################################################
    Private Sub btn_setting_Click(sender As Object, e As EventArgs) Handles btn_setting.Click
        If Panel_setting.Visible = False Then
            Panel_setting.Visible = True
        ElseIf Panel_setting.Visible = True Then
            Panel_setting.Visible = False
        End If
    End Sub
    Private Sub btn_theme_setting_Click(sender As Object, e As EventArgs) Handles btn_theme_setting.Click
        Response.Redirect("./children_display_set_from.aspx")
    End Sub
    Private Sub btn_general_info_setting_Click(sender As Object, e As EventArgs) Handles btn_general_info_setting.Click
        Response.Redirect("./children_general_setting.aspx")
    End Sub
    Private Sub btn_view_user_info_Click(sender As Object, e As EventArgs) Handles btn_view_user_info.Click
        Response.Redirect("./children_view_information.aspx")
    End Sub
    Private Sub Btn_mail_setting_Click(sender As Object, e As EventArgs) Handles Btn_mail_setting.Click
        Response.Redirect("./children_mail_setting.aspx")
    End Sub
    Private Sub btn_password_setting_Click(sender As Object, e As EventArgs) Handles btn_password_setting.Click
        Response.Redirect("./children_password_setting.aspx")
    End Sub
    Private Sub btn_username_setting_Click(sender As Object, e As EventArgs) Handles btn_username_setting.Click
        Response.Redirect("./children_username_setting.aspx")
    End Sub
    Private Sub btn_security_setting_Click(sender As Object, e As EventArgs) Handles btn_security_setting.Click
        Response.Redirect("./children_security_setting.aspx")
    End Sub
    Private Sub btn_deactivate_account_Click(sender As Object, e As EventArgs) Handles btn_deactivate_account.Click
        Response.Redirect("./children_deactivate_account.aspx")
    End Sub
    '#################################### SETTING ################################################################

End Class