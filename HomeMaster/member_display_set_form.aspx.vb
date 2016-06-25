Public Class member_display_set_form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub member_display_set_form_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub

    Private Sub btn_default_theme_Click(sender As Object, e As EventArgs) Handles btn_default_theme.Click
        Session("theme") = "default_theme"
        Response.Redirect("./member_display_set_form.aspx")
    End Sub

    Private Sub btn_second_theme_Click(sender As Object, e As EventArgs) Handles btn_second_theme.Click
        Session("theme") = "second_color"
        Response.Redirect("./member_display_set_form.aspx")
    End Sub

    Private Sub btn_third_theme_Click(sender As Object, e As EventArgs) Handles btn_third_theme.Click
        Session("theme") = "third_color"
        Response.Redirect("./member_display_set_form.aspx")
    End Sub

    Private Sub btn_forth_theme_Click(sender As Object, e As EventArgs) Handles btn_forth_theme.Click
        Session("theme") = "forth_color"
        Response.Redirect("./member_display_set_form.aspx")
    End Sub

    Private Sub btn_fifth_theme_Click(sender As Object, e As EventArgs) Handles btn_fifth_theme.Click
        Session("theme") = "fifth_color"
        Response.Redirect("./member_display_set_form.aspx")
    End Sub
End Class