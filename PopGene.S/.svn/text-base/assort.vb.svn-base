Module assort
    Public mating_type As Boolean
    Public mating_number As Integer
    Public assort_values_d() As Double
    Public assort_values_h() As Double
    Public points As Boolean
    Public gentorun As Double
    'Public assort_cart(10) As New AssortM_cartesian
    Public assort_group As String

    Public classical_assort As Boolean
    Dim dn, hn As Double

    Sub ass03(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.Aa AA.aa Aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = d + h / 4
            hn = h / 2

            dplot = d + h / 2
            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass04(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.Aa AA.aa Aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            'dn = d * d + ((h * h) / 4) / (d * d + h * h + (1 - d - h) * (1 - d - h))
            'hn = ((h * h) / 2) / (d * d + h * h + (1 - d - h) * (1 - d - h))
            dn = d + h / 4
            hn = h / 2
            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next

    End Sub

    Sub ass05(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA Aa.Aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1

            If d = 0 Then
                dn = 0
                hn = 0.5
            ElseIf d + h = 1 Then
                dn = 0.5
                hn = 0.5
            Else
                dn = d * h * (2 - d - h) / (2 * (1 - d) * (1 - h))
                hn = 0.5 + d * (1 + h) * (1 - d - h) / (2 * (1 - d) * (d + h))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass06(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA Aa.Aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d = 0 Then
                dn = 0
                hn = 0.5
            ElseIf d + h = 1 Then
                dn = 0.5
                hn = 0.5
            Else
                dn = d * h / (2 * (d * h + (d + h) * (1 - d - h)))
                hn = 0.5 + d * (1 - d - h) / (2 * (d * h + (d + h) * (1 - d - h)))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass07(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden  AA.AA aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        If d > 0 And h > 0 Then
            For i = 1 To g + 1
                dn = d * h * (2 - d) / (2 * (1 - d)) + (h * h) / 4
                hn = 0.5 + d * (1 + h) * (1 - d - h) / (2 * (1 - d) * (d + h))

                dplot = d + h / 2
                d = dn
                h = hn

                assort_values_d(i) = dn
                assort_values_h(i) = hn
            Next
        End If
    End Sub

    Sub ass08(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = (4 * d * h + h * h) / (4 * (1 - d * d - (1 - d - h) * (1 - d - h)))
            hn = (2 * d * h + 4 * d * (1 - d - h) + 2 * h * (1 - d - h) + h * h) / (2 * (1 - d * d - (1 - d - h) * (1 - d - h)))

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass09(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 1 Then
                dn = 0.5
                hn = 0.5
            Else
                dn = d * h * (2 - d - h) / (2 * (1 - d - h + d * h))
                hn = (1 - (1 - d - h) * (1 - d - h)) / 2 + d * (1 - d - h) * (2 - d) / (2 * (1 - d))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass10(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h
        For i = 1 To g + 1
            If d + h = 1 Then
                dn = 0.5
                hn = 0.5
            Else
                'dn = d * h / (1 - d * d - h * h)
                'hn = (d * h + (2 * d + h) * (1 - d - h)) / (1 - d * d - h * h)
                dn = d * h * (2 - d - h) / (2 * (1 - d - h + d * h))
                hn = (1 - (1 - d - h) * (1 - d - h)) / 2 + d * (1 - d - h) * (2 - d) / (2 * (1 - d))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass11(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA AA.Aa Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = 0
            hn = (d + h / 2) * (2 - d - h)

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass12(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA AA.Aa Aa.Aa

        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = 0
            hn = (2 * d + h) / (1 + d + h)

            dplot = d + h / 2
            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass13(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = d * (d + h / 2 + h / (2 * (1 - h)))
            hn = h + 2 * d * (1 - d - h) - h * h / 2
            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass14(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = d * (d + h) / (1 - h * h)
            hn = (d * h + (2 * d + h) * (1 - d - h)) / (1 - h * h)

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass15(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = h * (d / (1 - d) + d + h / 2) / 2
            hn = (1 - (1 - d - h) * (1 - d - h)) / 2 + d * (2 - d) * (1 - d - h) / (2 * (1 - d))

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass16(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = h * (4 * d + h) / (4 * (1 - d * d))
            hn = (2 * d + h) * (h + 2 * (1 - d - h)) / (2 * (1 - d * d))
            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass17(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbiddens AA.Aa Aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = d * d / (1 - h) + h / 4
            hn = 2 * d * (1 - d - h) / (1 - h) + h / 2

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub
    Sub ass18(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.Aa Aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d > 0.9999999 Then
                dn = 1
                hn = 0
            ElseIf d + h = 0.00000001 Then
                dn = 0
                hn = 0
            Else
                dn = (4 * d * d + h * h) / (4 * (1 - 2 * h * (1 - h)))
                hn = (4 * d * (1 - d - h) + h * h) / (2 * (1 - 2 * h * (1 - h)))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass19(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA AA.Aa Aa.aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = h / 4
            hn = 1 - h / 2

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass20(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA AA.Aa Aa.aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = ((h * h) / 4) / ((h * h) + 2 * d * (1 - d - h))
                hn = (((h * h) / 2) + 2 * d * (1 - d - h)) / ((h * h) + 2 * d * (1 - d - h))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass21(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.aa Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = d * (2 * d + h) / (2 * (d + h)) + d * h / (2 * (1 - h))
                hn = h * (2 + d / (d + h) - h / (1 - d)) / 2
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass22(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.aa Aa.Aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h
        For i = 1 To g + 1
            dn = d * (1 - (1 - d - h)) / (1 - 2 * d * (1 - d - h) - (h * h))
            hn = h * (1 - h) / (1 - 2 * d * (1 - d - h) - (h * h))

            dplot = d + h / 2
            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass23(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA AA.Aa Aa.Aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h
        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = 0
                hn = (d + h / 2) / (d + h)
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass24(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA AA.Aa Aa.Aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = 0
                hn = (d + h / 2) / (d + h)
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass25(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden AA.AA AA.aa Aa.Aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = d / (2 * (1 - h))
            hn = 1 / 2

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass26(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.AA AA.aa Aa.Aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            dn = d / (2 * (1 - h))
            hn = 1 / 2

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass27(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'forbidden Aa.aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = (d + (h / (2 * (d + h)))) * (d + h / 2)
                hn = (1 + d) * (1 - (d + h / 2))
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next

    End Sub

    Sub ass28(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile Aa.aa aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = (d + h / 2) * (d + h / 2) / ((d + h) * (d + h) + 2 * d * (1 - d - h))
                hn = ((d + h / 2) * h + 2 * d * (1 - d - h)) / ((d + h) * (d + h) + 2 * d * (1 - d - h))
            End If
            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass02(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        'sterile AA.aa Aa.aa
        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            'generation = generation + 1

            dn = (d + h / 2) * (d + h / 2) / ((1 - d - h) * (1 - d - h) + (d + h) * (d + h))
            hn = (d + h / 2) * h / ((1 - d - h) * (1 - d - h) + (d + h) * (d + h))

            dplot = dn + hn / 2
            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

    Sub ass01(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        Dim i As Single
        Dim dplot As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1

            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = (2 * d + h) * (2 * d + h) / (4 * (d + h))
                hn = h * (2 * d + h) / (2 * (d + h))
            End If

            dplot = dn + hn / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
    End Sub

End Module
