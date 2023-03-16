Imports System

Module Program
    Public Resp, Counter1, CurrentPointer, NextPointer, StartPointer, Counter, ReturnVal, PrevP As Integer
    Public SearchQ As String
    Structure DP
        Dim Data As String
        Dim Pointer As Integer
    End Structure
    Public LinkedL(10) As DP
    Sub Main(args As String())
        Call Initialise()

        Do
            Console.WriteLine("Select 1 to enter data")
            Console.WriteLine("Select 2 to delete data")
            Console.WriteLine("Select 3 to output data")
            Console.WriteLine("Select -1 to exit")
            Resp = Console.ReadLine
            If Resp = 1 Then
                Call EnterD()
            ElseIf Resp = 2 Then
                Call DeleteD()
            ElseIf Resp = 3 Then
                Call OutputD()
            ElseIf Resp = -1 Then
                Console.WriteLine("Goodbye")
                Exit Do
            End If
        Loop

    End Sub

    Sub Initialise()
        StartPointer = 0
        NextPointer = 0
        Counter1 = 1
        For Counter = 0 To 9
            LinkedL(Counter).Pointer = Counter1
            Counter1 += 1
        Next
        LinkedL(10).Pointer = -1
    End Sub

    Sub EnterD()
        If NextPointer = -1 Then
            Console.WriteLine("Linked list is full")
        Else
            CurrentPointer = NextPointer
            Console.WriteLine("Enter data")
            LinkedL(CurrentPointer).Data = Console.ReadLine()
            NextPointer = LinkedL(CurrentPointer).Pointer
            Console.WriteLine("Done")
        End If
    End Sub

    Sub DeleteD()
        Console.WriteLine("Enter data to delete")
        SearchQ = Console.ReadLine
        Counter = StartPointer
        ReturnVal = -1
        Do
            If LinkedL(Counter).Data = SearchQ Then
                ReturnVal = LinkedL(Counter).Pointer
                Exit Do
            Else
                Counter += 1
            End If
        Loop Until LinkedL(Counter).Pointer = -1
        If LinkedL(Counter).Pointer = -1 Then
            Console.WriteLine("Data to be deleted is not found")
        End If
        If ReturnVal <> -1 Then
            Counter = 0
            Do
                If LinkedL(Counter).Pointer = ReturnVal Then
                    PrevP = Counter - 1
                    LinkedL(PrevP).Pointer = LinkedL(ReturnVal - 1).Pointer
                    Exit Do
                Else
                    Counter += 1
                End If
            Loop
            Console.WriteLine("Successfully deleted")
        End If


    End Sub

    Sub OutputD()
        Counter = StartPointer
        Do
            Console.WriteLine(LinkedL(Counter).Data)
            Counter = LinkedL(Counter).Pointer
        Loop Until Counter = -1

    End Sub

End Module
