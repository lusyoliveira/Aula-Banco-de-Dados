Module mdlFuncoes
    Public Function moeda(ByVal valor As String)

        If valor = "" Then

            moeda = 0

            Exit Function

        End If

        Dim novovalor As String = valor.Replace("R$", "").Replace(".", "")

        Return novovalor.Replace(",", ".").Trim

    End Function

    Public Function tratadata(ByVal data As String, Optional ByVal mascara As String = "dd/MM/yyyy") As Date

        If IsDate(data) Then

            Return Format(CDate(data), mascara)

        Else

            data = "01/01/1900"

            Return Format(CDate(data), mascara)

        End If

    End Function



    Public Function tratatexto(ByVal texto As String)

        Return texto.Replace("'", "''")

    End Function
End Module
