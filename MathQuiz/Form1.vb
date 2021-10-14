Public Class Form1

    ' Create a Random object to generate random numbers.
    Dim randomizer As New Random

    ' These Integers will store the numbers
    ' for the addition problem.
    Dim addend1 As Integer
    Dim addend2 As Integer

    ' This Integer will keep track of the time left.
    Dim timeLeft As Integer

    ''' <summary>
    ''' Start the quiz by filling in all of the problems
    ''' and starting the timer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartTheQuiz()
        ' Fill in the addition problem.
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)

        plusLeftLabel.Text = addend1.ToString
        plusRightLabel.Text = addend2.ToString

        suma.Value = 0

        ' Start the timer.
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        startButton.Enabled = False
        StartTheQuiz()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (timeLeft > 0) Then
            ' Display the new time left
            ' by updating the Time Left label.
            timeLeft = timeLeft - 1
            timeLabel.Text = timeLeft & " seconds"
        Else
            ' If the user ran out of time, stop the timer, show
            ' a MessageBox, and fill in the answers.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry")
            suma.Value = addend1 + addend2
            startButton.Enabled = True
        End If
    End Sub
End Class
