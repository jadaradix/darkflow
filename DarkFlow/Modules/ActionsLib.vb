Imports System.IO
Module ActionsLib

    Public SelectMultiple As Boolean = True

    Public ActionCategories As New List(Of String)

    Public PossibleArgumentTypes As New List(Of String)

    Public Class DArgument
        Public Name As String
        Public Type As String
        Sub New(ByVal DName As String, ByVal DType As String)
            Name = DName
            Type = DType
        End Sub
        Function CloneMe() As DArgument
            Return New DArgument(Name, Type)
        End Function
    End Class

    Public Class DAction

        Public Name As String
        Public Category As String

        Sub New(ByVal PName As String, ByVal PCategory As String, ByVal PDImageName As String, ByVal PDImage As Image, ByVal PDisplay As String, ByVal PIsConditional As Boolean, ByVal PNoApplies As Boolean, ByVal PArguments As List(Of DArgument), ByVal PIndent As Boolean, ByVal PDedent As Boolean, ByVal PCodeLines As List(Of String), ByVal DBG As Boolean, ByVal DShowMe As Boolean)
            Name = PName
            Category = PCategory
            DImageName = PDImageName
            DImage = PDImage
            Display = PDisplay
            IsConditional = PIsConditional
            NoApplies = PNoApplies
            Arguments = PArguments
            Indent = PIndent
            Dedent = PDedent
            CodeLines = PCodeLines
            BG = DBG
            ShowMe = DShowMe
        End Sub

        Public DImageName As String
        Public DImage As Image
        Public Display As String
        Public IsConditional As Boolean
        Public NoApplies As Boolean
        Public Arguments As New List(Of DArgument)
        Public Indent As Boolean
        Public Dedent As Boolean
        Public CodeLines As New List(Of String)
        Public BG As Boolean
        Public ShowMe As Boolean

        Function CloneMe() As DAction
            Dim NewArgs As New List(Of DArgument)
            If Arguments.Count > 0 Then
                For P As UInt16 = 0 To Arguments.Count - 1
                    NewArgs.Add(Arguments(P).CloneMe())
                Next
            End If
            Return New DAction(Name, Category, DImageName, DImage, Display, IsConditional, NoApplies, NewArgs, Indent, Dedent, CodeLines, BG, ShowMe)
        End Function

    End Class
    Public DActions As New List(Of DAction)

    Sub InitActions()

        PossibleArgumentTypes.AddRange({"Generic", "TrueFalse", "Image", "Object", "Scene", "Sound", "Platform", "Font"})

        For Each X As String In IO.File.ReadAllLines(AppPath + "ActionCategories.dat")
            If X.Length = 0 Then Continue For
            ActionCategories.Add(X)
        Next

        Dim ActionsPath As String = AppPath + "Actions"

        For Each F As String In Directory.GetFiles(ActionsPath)

            Dim AName As String = F.Substring(F.LastIndexOf("\") + 1)
            AName = AName.Substring(0, AName.IndexOf("."))

            Dim DoShowMe As Boolean = True
            If AName = "Loop" Then DoShowMe = False

            Dim A As New DAction(AName, String.Empty, "Empty", New Bitmap(32, 32), AName, False, False, New List(Of DArgument), False, False, New List(Of String), False, DoShowMe)

            For Each P As String In IO.File.ReadAllLines(F)
                If P.StartsWith("TYPE ") Then
                    P = P.Substring(5)
                    If P.Length = 1 Then P = "Control"
                    A.Category = P
                ElseIf P.StartsWith("ICON ") Then
                    P = P.Substring(5)
                    If P.Contains(".") Then
                        P = P.Substring(0, P.IndexOf("."))
                    End If
                    A.DImageName = P
                ElseIf P.StartsWith("DISPLAY ") Then
                    P = P.Substring(8)
                    A.Display = P
                ElseIf P = "CONDITIONAL" Then
                    A.IsConditional = True
                ElseIf P = "NOAPPLIES" Then
                    A.NoApplies = True
                ElseIf P = "INDENT" Then
                    A.Indent = True
                ElseIf P = "DEDENT" Then
                    A.Dedent = True
                ElseIf P = "BG" Then
                    A.BG = True
                ElseIf P.StartsWith("ARG ") Then
                    P = P.Substring(4)
                    P = P.Replace(",", CC)
                    Dim NewArg As New DArgument(P.Substring(0, P.IndexOf(CC)), P.Substring(P.IndexOf(CC) + 1))
                    A.Arguments.Add(NewArg)
                Else
                    If P.Length > 0 Then A.CodeLines.Add(P)
                End If
            Next

            A.DImage = ActionMakeIcon(A.DImageName, A.IsConditional, A.BG)

            'Check for the dummie values
            If A.Category.Length = 0 Then Continue For

            DActions.Add(A)

        Next

    End Sub

    Public MatchFindName As String = String.Empty

    Function MatchAction(ByVal AnAction As DAction) As Boolean
        Return (AnAction.Name = MatchFindName)
    End Function

    Function ActionMakeIcon(ByVal ImageName As String, ByVal IsConditional As Boolean, ByVal DoBG As Boolean) As Bitmap
        Dim TI As Bitmap = PathToImage(AppPath + "ActionIcons\" + ImageName + ".png")
        Dim TBMP As New Bitmap(32, 32)
        Dim TBMPGFX As Graphics = Graphics.FromImage(TBMP)
        Dim TW As UInt16 = TI.Width
        Dim TH As UInt16 = TI.Height
        If DoBG Then
            If IsConditional Then
                TBMPGFX.DrawImageUnscaled(My.Resources.BlankActionCondition, 0, 0)
            Else
                TBMPGFX.DrawImageUnscaled(My.Resources.BlankActionIcon, 0, 0)
            End If
        End If
        TBMPGFX.DrawImageUnscaled(TI, New Point(((32 - TW) / 2), ((32 - TH) / 2)))
        TBMPGFX.Dispose()
        TI.Dispose()
        Return TBMP
    End Function

    Function ActionEquateDisplay(ByVal ActionName As String, ByVal ActionArguments As String, ByVal Applies As String) As String
        MatchFindName = ActionName
        Dim Returnable As String = DActions.Find(AddressOf MatchAction).Display
        For Z = 0 To HowManyChar(ActionArguments, CS)
            Dim Argument As String = iGet(ActionArguments, Z, CS)
            Dim StringThing As String = Argument
            If StringThing = "1" Then StringThing = "true"
            If StringThing = "0" Then StringThing = "false"
            'If StringThing = "<" Or StringThing = ">" Or StringThing = ">=" Or StringThing = "<=" Or StringThing = "==" Then
            '    StringThing = ComparativeToString(StringThing)
            'End If
            Returnable = Returnable.Replace("$" + (Z + 1).ToString + "$", StringThing)
            Returnable = Returnable.Replace("!" + (Z + 1).ToString + "!", Argument)
            If Applies = "this" Then
                Returnable = Returnable.Replace("!Applies!", "this instance")
            ElseIf Applies = "other" Then
                Returnable = Returnable.Replace("!Applies!", "other instance")
            Else
                Returnable = Returnable.Replace("!Applies!", "instances of " + Applies)
            End If
        Next
        Return Returnable
    End Function

    Function ActionIsConditional(ByVal ActionName) As Boolean
        MatchFindName = ActionName
        Return DActions.Find(AddressOf MatchAction).IsConditional
    End Function

    Function ActionGetIcon(ByVal ActionName As String, ByVal WithText As Boolean) As Bitmap
        MatchFindName = ActionName
        If Not WithText Then
            Return DActions.Find(AddressOf MatchAction).DImage
        End If
        Dim Out As Bitmap = New Bitmap(164, 32)
        Dim GFX As Graphics = Graphics.FromImage(Out)
        GFX.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        GFX.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        GFX.DrawImage(DActions.Find(AddressOf MatchAction).DImage, New Point(0, 0))
        Dim fnt As Font = New Font("Segoe UI", 9)
        Dim name As String = DActions.Find(AddressOf MatchAction).Name
        Dim A As Byte = 20
        If name.Length > A Then name = name.Substring(0, A - 1) + "..."
        GFX.DrawString(name, fnt, Brushes.Black, New Point(40, 6))
        Return Out
    End Function
    Function ActionGetCondition(ByVal ActionName As String) As Boolean
        MatchFindName = ActionName
        Return DActions.Find(AddressOf MatchAction).IsConditional
    End Function

    Public Function ArgumentsMakeAttractive(ByVal InputArguments As String, ByVal HideSymbols As Boolean) As String
        Dim Returnable As String = InputArguments
        Returnable = Returnable.Replace(CS, ", ")
        If HideSymbols Then Returnable = Returnable.Replace("<br|>", " .. ")
        Return Returnable
    End Function

End Module
