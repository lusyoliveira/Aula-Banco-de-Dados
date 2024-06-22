Public Class Form1
    Dim sql As String
    Dim tbclientes As ADODB.Recordset
    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Sql = "insert into tbclientes (nome,salario,dtnasc) values ('" & tratatexto(txtNome.Text) & "'," & moeda(txtSalario.Text) & ",'" & tratadata(txtDtnasc.Text) & "')"
        tbclientes = abrir(Sql)
        txtNome.Text = ""
        txtDtnasc.Text = ""
        txtSalario.Text = ""
        txtNome.Focus()
        montargrade()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If txtCodigo.Text = "" Then
            MsgBox("Digite um codigo válido !", MsgBoxStyle.Information)
            Exit Sub
        End If
        sql = "Select * from tbClientes where nrseq = " & txtCodigo.Text
        tbclientes = abrir(sql)
        If tbclientes.RecordCount = 0 Then
            MsgBox("Não existem clientes com o codigo digitado !", MsgBoxStyle.Critical)
            Exit Sub
        End If
        txtNome.Text = tbclientes.Fields("nome").Value.ToString
        txtDtnasc.Text = Format(tbclientes.Fields("dtnasc").Value, "dd/MM/yy")
        txtSalario.Text = FormatCurrency(tbclientes.Fields("salario").Value)

    End Sub

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If txtCodigo.Text = "" Then
            MsgBox("Digite um codigo válido !", MsgBoxStyle.Information)
            Exit Sub
        End If
        sql = "Select * from tbClientes where nrseq = " & txtCodigo.Text
        tbclientes = abrir(sql)
        If tbclientes.RecordCount = 0 Then
            MsgBox("Não existem clientes com o codigo digitado !", MsgBoxStyle.Critical)
            Exit Sub
        End If
        txtNome.Text = tbclientes.Fields("nome").Value.ToString
        txtDtnasc.Text = Format(tbclientes.Fields("dtnasc").Value, "dd/MM/yy")
        txtSalario.Text = FormatCurrency(tbclientes.Fields("salario").Value)
        If MsgBox("Confirma a exclusão do cliente ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            sql = "delete * from tbclientes where nrseq = " & txtCodigo.Text
            tbclientes = abrir(sql)
        End If
        txtNome.Text = ""
        txtDtnasc.Text = ""
        txtSalario.Text = ""
        txtNome.Focus()
        montargrade()
    End Sub

    Private Sub btnAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
        If btnAlterar.Text = "Alterar" Then
            If txtCodigo.Text = "" Then
                MsgBox("Digite um codigo válido !", MsgBoxStyle.Information)
                Exit Sub
            End If
            sql = "Select * from tbClientes where nrseq = " & txtCodigo.Text
            tbclientes = abrir(sql)
            If tbclientes.RecordCount = 0 Then
                MsgBox("Não existem clientes com o codigo digitado !", MsgBoxStyle.Critical)
                Exit Sub
            End If
            txtNome.Text = tbclientes.Fields("nome").Value.ToString
            txtDtnasc.Text = Format(tbclientes.Fields("dtnasc").Value, "dd/MM/yy")
            txtSalario.Text = FormatCurrency(tbclientes.Fields("salario").Value)
            btnSalvar.Enabled = False
            btnExcluir.Enabled = False
            btnConsultar.Enabled = False
            btnAlterar.Text = "Salvar"
        Else
            sql = "update tbclientes set nome = '" & tratatexto(txtNome.Text) & "', dtnasc = '" & tratadata(txtDtnasc.Text) & "', salario = " & moeda(txtSalario.Text) & " where nrseq = " & txtCodigo.Text
            tbclientes = abrir(sql)
            btnSalvar.Enabled = True
            btnExcluir.Enabled = True
            btnConsultar.Enabled = True
            btnAlterar.Text = "Alterar"
            txtNome.Text = ""
            txtDtnasc.Text = ""
            txtSalario.Text = ""
            txtNome.Focus()
            montargrade()
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        montargrade()
    End Sub
    Private Sub montargrade()
        Dim x As Integer
        Grade.Rows.Clear()
        sql = "Select * from tbclientes order by nrseq"
        tbclientes = abrir(sql)
        If tbclientes.RecordCount <> 0 Then
            tbclientes.MoveFirst()
            While tbclientes.EOF = False
                Grade.Rows.Add(False)
                Grade.Item(1, x).Value = tbclientes.Fields("nrseq").Value
                Grade.Item(2, x).Value = tbclientes.Fields("nome").Value
                Grade.Item(3, x).Value = Format(tbclientes.Fields("dtnasc").Value, "dd/MM/yy")
                Grade.Item(4, x).Value = FormatCurrency(tbclientes.Fields("salario").Value)
                x += 1
                tbclientes.MoveNext()
            End While
        End If
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub
End Class
