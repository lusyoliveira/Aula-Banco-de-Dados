Module mdlConexao
    Dim x As Integer
    Private aConexao As New ADODB.Connection
    Private aconexao2 As New ADODB.Connection

    Dim acess_server, acess_db, acess_usr, acess_pwd



    Public Function abrir(ByVal sql As String)

        Dim aResultado As New ADODB.Recordset


        acess_db = "C:\Documents and Settings\Administrador\Meus documentos\Técnico\2º Período\VB.net\Aula Conexão Banco de Dados\dbfarmacia.mdb"

        If sql.ToUpper = "FECHAR" Then
            aconexao2.Close()
            Return False
            Exit Function
        End If

        If aconexao2.State = 0 Then
            aconexao2.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & acess_db
            aconexao2.Open()
        End If

        'aResultado2.Open(sql, aconexao2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        aResultado.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        aResultado.Open(sql, aconexao2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        abrir = aResultado
        aResultado = Nothing

    End Function
End Module
