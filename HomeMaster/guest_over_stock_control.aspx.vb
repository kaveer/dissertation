﻿Public Class guest_over_stock_control
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '################################################# THEME SETUP ###################################################################
    Private Sub guest_over_stock_control_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If Session("theme") = "" Then
            Session("theme") = "default_theme"
        End If
        Page.Theme = Session("theme")
    End Sub
    '################################################# END OF THEME SETUP ###################################################################



End Class