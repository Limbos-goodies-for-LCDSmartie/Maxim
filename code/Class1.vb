Imports System.IO
Imports System.Reflection
Imports System.Text

Public Class LCDSmartie

    Dim Out As Integer = 0 ', Path As String
    Dim NumberOfErrors = 0

    Public Function function1(ByVal param1 As String, ByVal param2 As String) As String

        If LCase(param1) = "about" Or LCase(param2) = "about" Then
            Return " selection of lines one by one"
        Else
            Dim sValue As String
            Dim sPath As String

            Dim dllPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            sPath = Path.Combine(dllPath, "lines.ini")

Reloop1:
            If File.Exists(sPath) Then
                If Out < 101 Then
                    Out = Out + 1
                Else
                    Out = 1
                End If

                sValue = INIRead(sPath, param1, Out, "NoLine")
                If sValue = "NoLine" Then
                    NumberOfErrors = NumberOfErrors + 1
                    If NumberOfErrors < 3 Then
                        GoTo Reloop1

                        NumberOfErrors = 0
                        Return ""
                        Exit Function
                    End If

                Else
                    Return sValue
                    NumberOfErrors = 0
                End If
            Else
                Return "lines.ini is missing"
                NumberOfErrors = 0

            End If
            ' Return sValue


        End If


    End Function
    Public Function function2(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Or LCase(param2) = "about" Then

            Return " random selection of a line"

        Else
            Dim sValue As String
            Dim sPath As String
            Dim dllPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            sPath = Path.Combine(dllPath, "lines.ini")
            '         SaveSetting("q", "settings", "linespath", param2)

Reloop2:
            If File.Exists(sPath) Then
                Randomize()
                Out = CInt(Int((100 * Rnd()) + 1))
                sValue = INIRead(sPath, param1, Out, "NoLine")

                If sValue = "NoLine" Then
                    NumberOfErrors = NumberOfErrors + 1
                    If NumberOfErrors < 3 Then
                        GoTo Reloop2
                    Else
                        NumberOfErrors = 0
                        Return ""
                        Exit Function
                    End If


                Else

                    Return sValue
                    NumberOfErrors = 0
                End If
            Else
                Return "lines.ini is missing"
                NumberOfErrors = 0


            End If
        End If

    End Function

    'Public Function function3(ByVal param1 As String, ByVal param2 As String) As String
    '    If LCase(param1) = "about" Or LCase(param2) = "about" Then

    '        Return " selection of lines one by one"

    '    Else
    '        Dim sValue As String
    '        Dim sPath As String


    '        Dim dllPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
    '        sPath = Path.Combine(dllPath, "lines.ini")

    '        If file.exists(sPath) Then

    '            If Out < 101 Then
    '                Out = Out + 1
    '            Else
    '                Out = 1
    '            End If

    '            sValue = INIRead(sPath, param1, Out, "NoLine")

    '            Return " *** " & sValue
    '        Else
    '            Return "lines.ini is missing"
    '        End If

    '    End If
    'End Function

    'Public Function function4(ByVal param1 As String, ByVal param2 As String) As String
    '    If LCase(param1) = "about" And LCase(param2) = "function" Then

    '        Return " random selection of lines"

    '    Else
    '        Dim sValue As String
    '        Dim sPath As String

    '        Dim dllPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
    '        sPath = Path.Combine(dllPath, "lines.ini")

    '        Randomize()
    '        Out = CInt(Int((20 * Rnd()) + 1))
    '        sValue = INIRead(sPath, param1, Out, "NoLine")


    '        Return " *** " & sValue
    '    End If

    'End Function


    Public Function function20(ByVal param1 As String, ByVal param2 As String) As String
        If LCase(param1) = "about" Or LCase(param2) = "about" Then
            Return "Developer: Nikos Georgousis"
            '     Return "** http://users.panafonet.gr/indexsmartie.htm **"
        Else

            Return "**  maxim plugin v.1.1 by Limbo."

        End If
    End Function


    Public Function GetMinRefreshInterval() As Integer
        Return 30000
    End Function


    Public Function SmartieDemo()
        Dim demolist As New StringBuilder()

        demolist.AppendLine("maxim plugin for LCD Smartie")
        demolist.AppendLine("This plugin returns one line from the lines.ini file which should be placed on the plugins folder.")
        demolist.AppendLine("------ Function1 ------")
        demolist.AppendLine(">>>  Returns lines in series from 1-100  <<<")
        demolist.AppendLine("You need to pass the ini section on the first prameter. ")
        demolist.AppendLine("Get a line every 30 seconds:  $dll(maxim,1,quotes, )")
        demolist.AppendLine("------ Function2 ------")
        demolist.AppendLine(">>>  Returns lines in random order (1-100)  <<<")
        demolist.AppendLine("You need to pass the ini section on the first prameter. ")
        demolist.AppendLine("Get a random line every 30 seconds:  $dll(maxim,2,quotes, )")
        demolist.AppendLine("------ Function20 ------")
        demolist.AppendLine(">>>  Credits  <<<")
        demolist.AppendLine("Credits:  $dll(maxim,20, , )")
        demolist.AppendLine("------------------------------------------------------------------------------------------------------------------")
        demolist.AppendLine(" *** Visit ***")
        demolist.AppendLine("> Home page")
        demolist.AppendLine("https://lcdsmartie.sourceforge.net")
        demolist.AppendLine("> Forums")
        demolist.AppendLine("https://www.lcdsmartie.org")
        demolist.AppendLine("> Active development branch (latest version)")
        demolist.AppendLine("https://github.com/stokie-ant/lcdsmartie-laz")
        demolist.AppendLine("")
        demolist.AppendLine("")
        demolist.AppendLine("")

        Dim result As String = demolist.ToString()
        Return result
    End Function

    Public Function SmartieInfo()
        Return "Developer: Nikos Georgousis (limbo)" & vbNewLine & "Version: 1.1 "
    End Function


End Class