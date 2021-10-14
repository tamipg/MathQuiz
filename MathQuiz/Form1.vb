Public Class Form1

    ' Crea un objeto aleatorio para generar números aleatorios.
    Dim randomizer As New Random

    ' Estos enteros almacenarán los números
    ' para el problema de la suma.
    Dim addend1 As Integer
    Dim addend2 As Integer

    'Estos enteros almacenarán los números
    'para el problema de la resta.
    Dim minuend As Integer
    Dim subtrahend As Integer

    ' Estos enteros almacenarán los números del problema de multiplicación.
    Dim multiplicand As Integer
    Dim multiplier As Integer

    ' Estos enteros almacenarán los números para el problema de división.
    Dim dividend As Integer
    Dim divisor As Integer

    ' Este entero hará un seguimiento del tiempo restante.
    Dim timeLeft As Integer

    ''' <summary>
    ''' Comienza el cuestionario rellenando todos los problemas
    ''' y poner en marcha el temporizador.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartTheQuiz()
        ' Rellena el problema de la suma.
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        plusLeftLabel.Text = addend1.ToString
        plusRightLabel.Text = addend2.ToString

        suma.Value = 0

        ' Rellena el problema de la resta.
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString
        minusRightLabel.Text = subtrahend.ToString
        diferencia.Value = 0

        ' Rellena el problema de la multiplicación.
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timesLeftLabel.Text = multiplicand.ToString
        timesRightLabel.Text = multiplier.ToString
        producto.Value = 0

        ' Rellena el problema de la división.
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString
        dividedRightLabel.Text = divisor.ToString
        cociente.Value = 0

        ' Inicia el temporizador.
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        startButton.Enabled = False
        StartTheQuiz()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CheckTheAnswer() Then
            ' Si el usuario respondió correctamente, detiene el temporizador.
            ' Y muestra un MessageBox.
            Timer1.Stop()
            MessageBox.Show("¡Tienes todas las respuestas correctas!", "¡Felicidades!")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            ' Disminuye el tiempo restante en un segundo y muestra
            ' el nuevo tiempo restante actualizando la etiqueta timeLeft.
            timeLeft = timeLeft - 1
            timeLabel.Text = timeLeft & " segundos"
        Else
            ' Si el usuario se quedó sin tiempo, detiene el temporizador, muestra
            ' un MessageBox y rellena las respuestas.
            Timer1.Stop()
            timeLabel.Text = "¡Se acabó el tiempo!"
            MessageBox.Show("No terminaste a tiempo.", "Lo siento")
            suma.Value = addend1 + addend2
            diferencia.Value = minuend - subtrahend
            producto.Value = multiplicand * multiplier
            cociente.Value = dividend / divisor
            startButton.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' Comprueba la respuesta para ver si el usuario respondió bien.
    ''' </summary>
    ''' <returns>True si la respuesta es correcta, False en caso contrario.</returns>
    ''' <remarks></remarks>
    Public Function CheckTheAnswer() As Boolean

        If ((addend1 + addend2 = suma.Value) AndAlso (minuend - subtrahend = diferencia.Value) AndAlso (multiplicand * multiplier = producto.Value) AndAlso (dividend / divisor = cociente.Value)) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub answer_Enter(sender As Object, e As EventArgs) Handles suma.Enter, producto.Enter, diferencia.Enter, cociente.Enter
        ' Selecciona la respuesta completa en el control NumericUpDown.
        Dim answerBox As NumericUpDown = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer As Integer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If
    End Sub
End Class
