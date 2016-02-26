Imports System.Runtime.CompilerServices
Imports System.Runtime.ConstrainedExecution
Imports Microsoft.VisualStudio.TestTools.UnitTesting


Imports System.Diagnostics.Contracts
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Numerics
Imports System.Text
Imports Conditional = System.Diagnostics.ConditionalAttribute

#Const Inherit = True
Public NotInheritable Class Math
    Protected Math As System.Math
#Region "Signs"
    ''' <summary>
    ''' The plus sign or the addition sign (+). Same as Chr(43) or Chr(&amp;h2B).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PlusSign As Char = "+"c
    ''' <summary>
    ''' The plus or minus sign (±). Same as Chr(177) or Chr(&amp;hB1).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PlusMinusSign As Char = "±"c
    ''' <summary>
    ''' The minus sign (−). Same as Chr(8722) or Chr(&amp;h2212).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MinusSign As Char = "−"c
    ''' <summary>
    ''' The multiplication sign (×). Same as Chr(215) or Chr(&amp;hD7).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MultiplicationSign As Char = "×"c
    ''' <summary>
    ''' The division sign (÷). Same as Chr(247) or Chr(&amp;hF7).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DivisionSign As Char = "÷"c
    ''' <summary>
    ''' The percentage sign (%). Same as Chr(37) or Chr(&amp;h25).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PercentageSign As Char = "%"c
    ''' <summary>
    ''' The per mile or per thousand sign (‰). Same as Chr(137) or Chr(&amp;h2030).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PerMileSign As Char = "‰"c
    ''' <summary>
    ''' The equal sign (=). Same as Chr(61) or Chr(&amp;h3D).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const EqualSign As Char = "="c
    ''' <summary>
    ''' The not equal to sign (≠). Same as Chr(8800) or Chr(&amp;h2260).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const NotEqualToSign As Char = "≠"c
    ''' <summary>
    ''' The approximately equal sign (≈). Same as Chr(8776) or Chr(&amp;h2248).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ApproximatelyEqualSign As Char = "≈"c
    ''' <summary>
    ''' The identical to sign (≡). Same as Chr(8801) or Chr(&amp;h2261).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const IdenticalToSign As Char = "≡"c
    ''' <summary>
    ''' The less than sign (&lt;). Same as Chr(60) or Chr(&amp;h3C).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const LessThanSign As Char = "×"c
    ''' <summary>
    ''' The greater than sign (&gt;). Same as Chr(62) or Chr(&amp;h3E).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const GreaterThanSign As Char = ">"c
    ''' <summary>
    ''' The less than or equal to sign (≤). Same as Chr(8804) or Chr(&amp;h2264).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const LessThanOrEqualToSign As Char = "≤"c
    ''' <summary>
    ''' The greater than or equal to sign (≥). Same as Chr(8805) or Chr(&amp;h2265).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const GreaterThanOrEqualToSign As Char = "≥"c
    ''' <summary>
    ''' The infinity sign (∞). Same as Chr(8734) or Chr(&amp;h221E).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const InfinitySign As Char = "∞"c
    ''' <summary>
    ''' The one eighth fraction (⅛). Same as Chr(8539) or Chr(&amp;h215B).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const OneEighthFraction As Char = "⅛"c
    ''' <summary>
    ''' The one quarter fraction (¼). Same as Chr(188) or Chr(&amp;hBC).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const OneQuarterFraction As Char = "¼"c
    ''' <summary>
    ''' The three eighths fraction (⅜). Same as Chr(8540) or Chr(&amp;h215C).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ThreeEighthsFraction As Char = "⅜"c
    ''' <summary>
    ''' The one half fraction (½). Same as Chr(189) or Chr(&amp;hBD).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const OneHalfFraction As Char = "½"c
    ''' <summary>
    ''' The five eighths fraction (⅝). Same as Chr(8541) or Chr(&amp;h215D).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FiveEighthsFraction As Char = "⅝"c
    ''' <summary>
    ''' The three quarters fraction (¾). Same as Chr(190) or Chr(&amp;hBE).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ThreeQuartersFraction As Char = "¾"c
    ''' <summary>
    ''' The seven eighths fraction (⅞). Same as Chr(8542) or Chr(&amp;h215E).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SevenEighthsFraction As Char = "⅞"c
    ''' <summary>
    ''' The integral sign (∫). Same as Chr(8747) or Chr(&amp;h222B).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const IntegralSign As Char = "∫"c
    ''' <summary>
    ''' The partial differential sign (∂). Same as Chr(8706) or Chr(&amp;h2202).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PartialDifferentialSign As Char = "∂"c
    ''' <summary>
    ''' The increment sign (∆). Same as Chr(8710) or Chr(&amp;h2206).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const IncrementSign As Char = "∆"c
    ''' <summary>
    ''' The n-ary product sign sign (∏). Same as Chr(8719) or Chr(&amp;h220F).
    ''' </summary>
    ''' <remarks>∏ 	  	&#8719; 	&#x220F; 	N-ary Product Sign</remarks>
    Public Const N_aryProductSign As Char = "∏"c
    ''' <summary>
    ''' The n-ary sum sign (∑). Same as Chr(8721) or Chr(&amp;h2211).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const N_arySumSign As Char = "∑"c
    ''' <summary>
    ''' The square root sign (√). Same as Chr(8730) or Chr(&amp;h221A).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SquareRootSign As Char = "√"c
    ''' <summary>
    ''' The right angle sign (∟). Same as Chr(8735) or Chr(&amp;h221F).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const RightAngleSign As Char = "∟"c
    ''' <summary>
    ''' The intersection sign (∩). Same as Chr(8745) or Chr(&amp;h2229).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const IntersectionSign As Char = "∩"c
    ''' <summary>
    ''' The bullet operator (∙). Same as Chr(8729) or Chr(&amp;h2219).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const BulletOperator As Char = "∙"c
    ''' <summary>
    ''' The function sign (ƒ). Same as Chr(131) or Chr(&amp;h83).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FunctionSign As Char = "ƒ"c
    ''' <summary>
    ''' The fraction slash (⁄). Same as Chr(8260) or Chr(&amp;h2044).
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FractionSlash As Char = "⁄"c
#End Region
#Region "Inherited Methods"
#If Inherit Then
    ' Methods
    Public Shared Function Abs(ByVal value As Decimal) As Decimal
        Return System.Math.Abs(value)
    End Function


    Public Shared Function Abs(ByVal value As Double) As Double
        Return System.Math.Abs(value)
    End Function

    Public Shared Function Abs(ByVal value As Short) As Short
        Return System.Math.Abs(value)
    End Function

    Public Shared Function Abs(ByVal value As Integer) As Integer
        Return System.Math.Abs(value)
    End Function

    Public Shared Function Abs(ByVal value As Long) As Long
        Return System.Math.Abs(value)
    End Function
    <CLSCompliant(False)> _
    Public Shared Function Abs(ByVal value As SByte) As SByte
        Return System.Math.Abs(value)
    End Function

    Public Shared Function Abs(ByVal value As Single) As Single
        Return System.Math.Abs(value)
    End Function


    Public Shared Function Acos(ByVal d As Double) As Double
        Return System.Math.Acos(d)
    End Function


    Public Shared Function Asin(ByVal d As Double) As Double
        Return System.Math.Asin(d)
    End Function


    Public Shared Function Atan(ByVal d As Double) As Double
        Return System.Math.Atan(d)
    End Function


    Public Shared Function Atan2(ByVal y As Double, ByVal x As Double) As Double
        Return System.Math.Atan2(y, x)
    End Function

    Public Shared Function BigMul(ByVal a As Integer, ByVal b As Integer) As Long
        Return System.Math.BigMul(a, b)
    End Function

    Public Shared Function Ceiling(ByVal d As Decimal) As Decimal
        Return System.Math.Ceiling(d)
    End Function


    Public Shared Function Ceiling(ByVal a As Double) As Double
        Return System.Math.Ceiling(a)
    End Function


    Public Shared Function Cos(ByVal d As Double) As Double
        Return System.Math.Cos(d)
    End Function


    Public Shared Function Cosh(ByVal value As Double) As Double
        Return System.Math.Cosh(value)
    End Function

    Public Shared Function DivRem(ByVal a As Integer, ByVal b As Integer,
                                  <Runtime.InteropServices.Out> ByRef result As Integer) As Integer
        result = (a Mod b)
        Return (a / b)
    End Function

    Public Shared Function DivRem(ByVal a As Long, ByVal b As Long,
                                  <Runtime.InteropServices.Out> ByRef result As Long) As Long
        result = (a Mod b)
        Return (a / b)
    End Function


    Public Shared Function Exp(ByVal d As Double) As Double
        Return System.Math.Exp(d)
    End Function

    Public Shared Function Floor(ByVal d As Decimal) As Decimal
        Return Decimal.Floor(d)
    End Function


    Public Shared Function Floor(ByVal d As Double) As Double
        Return System.Math.Floor(d)
    End Function

    Public Shared Function IEEERemainder(ByVal x As Double, ByVal y As Double) As Double
        Return System.Math.IEEERemainder(x, y)
    End Function
#If False Then
    Private Shared Function InternalRound(ByVal value As Double, ByVal digits As Integer, ByVal mode As MidpointRounding) As Double
        If (Math.Abs(value) < Math.doubleRoundLimit) Then
            Dim num As Double = Math.roundPower10Double(digits)
            value = (value * num)
            If (mode = MidpointRounding.AwayFromZero) Then
                Dim num2 As Double = Math.SplitFractionDouble(AddressOf value)
                If (Math.Abs(num2) >= 0.5) Then
                    value = (value + Math.Sign(num2))
                End If
            Else
                value = Math.Round(value)
            End If
            value = (value / num)
        End If
        Return value
    End Function
    Private Shared Function InternalTruncate(ByVal d As Double) As Double
        Math.SplitFractionDouble(AddressOf d)
        Return d
    End Function
#End If




    Public Shared Function Log(ByVal d As Double) As Double
        Return System.Math.Log(d)
    End Function

    Public Shared Function Log(ByVal a As Double, ByVal newBase As Double) As Double
        If ((newBase <> 1) AndAlso ((a = 1) OrElse ((newBase <> 0) AndAlso
                                                    Not Double.IsPositiveInfinity(newBase)))) Then
            Return (System.Math.Log(a) / System.Math.Log(newBase))
        End If
        Return Double.NaN
    End Function


    Public Shared Function Log10(ByVal d As Double) As Double
        Return System.Math.Log10(d)
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Byte, ByVal val2 As Byte) As Byte
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Decimal, ByVal val2 As Decimal) As Decimal
        Return System.Math.Max(val1, val2)
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Double, ByVal val2 As Double) As Double
        If (val1 > val2) Then
            Return val1
        End If
        If Double.IsNaN(val1) Then
            Return val1
        End If
        Return val2
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Short, ByVal val2 As Short) As Short
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Integer, ByVal val2 As Integer) As Integer
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Long, ByVal val2 As Long) As Long
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), CLSCompliant(False)> _
    Public Shared Function Max(ByVal val1 As SByte, ByVal val2 As SByte) As SByte
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As Single, ByVal val2 As Single) As Single
        If (val1 > val2) Then
            Return val1
        End If
        If Single.IsNaN(val1) Then
            Return val1
        End If
        Return val2
    End Function

    <CLSCompliant(False), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As UInt16, ByVal val2 As UInt16) As UInt16
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <CLSCompliant(False), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As UInt32, ByVal val2 As UInt32) As UInt32
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <CLSCompliant(False), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Max(ByVal val1 As UInt64, ByVal val2 As UInt64) As UInt64
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Byte, ByVal val2 As Byte) As Byte
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Decimal, ByVal val2 As Decimal) As Decimal
        Return System.Math.Min(val1, val2)
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Double, ByVal val2 As Double) As Double
        If (val1 < val2) Then
            Return val1
        End If
        If Double.IsNaN(val1) Then
            Return val1
        End If
        Return val2
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Short, ByVal val2 As Short) As Short
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Integer, ByVal val2 As Integer) As Integer
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Long, ByVal val2 As Long) As Long
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <CLSCompliant(False), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As SByte, ByVal val2 As SByte) As SByte
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As Single, ByVal val2 As Single) As Single
        If (val1 < val2) Then
            Return val1
        End If
        If Single.IsNaN(val1) Then
            Return val1
        End If
        Return val2
    End Function

    <CLSCompliant(False), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As UInt16, ByVal val2 As UInt16) As UInt16
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <CLSCompliant(False), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Min(ByVal val1 As UInt32, ByVal val2 As UInt32) As UInt32
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function

    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), CLSCompliant(False)> _
    Public Shared Function Min(ByVal val1 As UInt64, ByVal val2 As UInt64) As UInt64
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function


    Public Shared Function Pow(ByVal x As Double, ByVal y As Double) As Double
        Return System.Math.Pow(x, y)
    End Function
    Public Shared Function Round(ByVal d As Decimal) As Decimal
        Return Decimal.Round(d, 0)
    End Function


    Public Shared Function Round(ByVal a As Double) As Double
        Return System.Math.Round(a)
    End Function
    Public Shared Function Round(ByVal d As Decimal, ByVal decimals As Integer) As Decimal
        Return Decimal.Round(d, decimals)
    End Function

    Public Shared Function Round(ByVal d As Decimal, ByVal mode As MidpointRounding) As Decimal
        Return Decimal.Round(d, 0, mode)
    End Function

    Public Shared Function Round(ByVal value As Double, ByVal digits As Integer) As Double
        Return System.Math.Round(value, digits, MidpointRounding.ToEven)
    End Function

    Public Shared Function Round(ByVal value As Double, ByVal mode As MidpointRounding) As Double
        Return System.Math.Round(value, 0, mode)
    End Function

    Public Shared Function Round(ByVal d As Decimal, ByVal decimals As Integer,
                                 ByVal mode As MidpointRounding) As Decimal
        Return Decimal.Round(d, decimals, mode)
    End Function

    Public Shared Function Round(ByVal value As Double, ByVal digits As Integer,
                                 ByVal mode As MidpointRounding) As Double
        Return System.Math.Round(value, digits, mode)
    End Function

    Public Shared Function Sign(ByVal value As Decimal) As Integer
        If (value < 0) Then
            Return -1
        End If
        If (value > 0) Then
            Return 1
        End If
        Return 0
    End Function

    Public Shared Function Sign(ByVal value As Double) As Integer
        Return System.Math.Sign(value)
    End Function

    Public Shared Function Sign(ByVal value As Short) As Integer
        If (value < 0) Then
            Return -1
        End If
        If (value > 0) Then
            Return 1
        End If
        Return 0
    End Function

    Public Shared Function Sign(ByVal value As Integer) As Integer
        If (value < 0) Then
            Return -1
        End If
        If (value > 0) Then
            Return 1
        End If
        Return 0
    End Function

    Public Shared Function Sign(ByVal value As Long) As Integer
        If (value < 0) Then
            Return -1
        End If
        If (value > 0) Then
            Return 1
        End If
        Return 0
    End Function

    <CLSCompliant(False)> _
    Public Shared Function Sign(ByVal value As SByte) As Integer
        If (value < 0) Then
            Return -1
        End If
        If (value > 0) Then
            Return 1
        End If
        Return 0
    End Function

    Public Shared Function Sign(ByVal value As Single) As Integer
        Return System.Math.Sign(value)
    End Function


    Public Shared Function Sin(ByVal a As Double) As Double
        Return System.Math.Sin(a)
    End Function

    Public Shared Function Sinh(ByVal value As Double) As Double
        Return System.Math.Sin(value)
    End Function
#If False Then

    Private Shared Function SplitFractionDouble(ByRef value As Double) As Double
#End If
    <MethodImpl(MethodImplOptions.InternalCall),
    ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)> _
    Public Shared Function Sqrt(ByVal d As Double) As Double
        Return System.Math.Sqrt(d)
    End Function


    Public Shared Function Tan(ByVal a As Double) As Double
        Return System.Math.Tan(a)
    End Function


    Public Shared Function Tanh(ByVal value As Double) As Double
        Return System.Math.Tanh(value)
    End Function

    Public Shared Function Truncate(ByVal d As Decimal) As Decimal
        Return Decimal.Truncate(d)
    End Function

    Public Shared Function Truncate(ByVal d As Double) As Double
        Return System.Math.Truncate(d)
    End Function

#End If
#End Region
#Region "Constants"
    ' Fields
    ''' <summary>
    ''' 'The base of the natural logarithm.
    ''' </summary>
    ''' <remarks></remarks>
    Public Const e As Decimal =
        2.7182818284590452353602874714D
    Public Const π As Decimal = 3.1415926535897932384626433833D
    Public Const pi As Decimal = 3.1415926535897932384626433833D
    Public Const SqrRoot2 As Decimal =
        1.4142135623730950488016887242D
    Public Const Archimedes_constant As Decimal =
        3.1415926535897932384626433833D
    Public Const Eulers_number As Decimal =
        2.7182818284590452353602874714D
    Public Const Pythagoras_constant As Decimal =
        1.4142135623730950488016887242D
    'The Feigenbaum constants α and δ
    Public Const δ As Decimal = 4.6692016091029906718532038216D
    Public Const Feigenbaum_constant_δ As Decimal = 4.6692016091029906718532038216D
    Public Const α As Decimal = 2.5029078750958928222839028732D
    Public Const Feigenbaum_constant_α As Decimal = 2.5029078750958928222839028732D
    Public Const Golden_ratio_φ As Decimal =
        1.6180339887498948482045868344D
    Public Const φ As Decimal =
        1.6180339887498948482045868344D
    Public Const phi As Decimal =
        1.6180339887498948482045868344D
    Public Const Euler_Mascheroni_constant_γ As Decimal =
    0.5772156649015328606065120901D
    Public Const γ As Decimal =
    0.5772156649015328606065120901D
    Public Const Conways_constant_λ As Decimal =
    1.3035772690342963912570991122D
    Public Const λ As Decimal =
    1.3035772690342963912570991122D
    Public Const Khinchins_constant_K As Decimal =
    2.6854520010653064453097148355D
    Public Const K As Decimal =
    2.6854520010653064453097148355D
    Public Const Glaisher_Kinkelin_constant_A As Decimal =
    1.2824271291006226368753425689D
    Public Const A As Decimal =
    1.2824271291006226368753425689D
    Public Const Googol As Double = 1.0E+100
    Public Const SqrRoot3 As Decimal = 1.7320508075688772935274463415D
    Public Const SqrRoot5 As Decimal = 2.2360679774997896964091736687D
#End Region
    ''' <summary>
    ''' Provides a method for finding the Highest Common Factor (HCF) between two numbers.
    ''' </summary>
    ''' <param name="Num1">The first number to be calculated.</param>
    ''' <param name="Num2">The second number to be calculated.</param>
    ''' <returns>The Hightest Common Factor (HCF) between two numbers.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function HCF(Num1 As Long, Num2 As Long) As Long
        Dim Big As Long = System.Math.Max(Num1, Num2)
        Dim Small As Long = System.Math.Min(Num1, Num2)
        Dim Modulus As Long = Big Mod Small
        Do Until Modulus = 0
            Big = Small
            Small = Modulus
            Modulus = Big Mod Small
        Loop
        Return Small
    End Function
    ''' <summary>
    ''' Provides a method for finding the Highest Common Factor (HCF) between three or more numbers.
    ''' </summary>
    ''' <param name="Num1">The first number to be calculated.</param>
    ''' <param name="Num2">The second number to be calculated.</param>
    ''' <param name="Num3">The rest to be calculated.</param>
    ''' <returns>The Hightest Common Factor (HCF) between three or more numbers.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function HCF(Num1 As Long, Num2 As Long, ParamArray Num3 As Long()) As Long
        Dim Value As Long = HCF(Num1, Num2)
        For Counter = 0 To (Num3.Length)
            Value = HCF(Value, Num3(Counter))
        Next
        Return Value
    End Function
    ''' <summary>
    ''' Provides a method for finding the Greatest Common Divisor (GCD) between two numbers.
    ''' </summary>
    ''' <param name="Num1">The first number to be calculated.</param>
    ''' <param name="Num2">The second number to be calculated.</param>
    ''' <returns>The Grestest Common Divisor (GCD) between three or more numbers.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GCD(Num1 As Long, Num2 As Long) As Long
        Return HCF(Num1, Num2)
    End Function
    ''' <summary>
    ''' Provides a method for finding the Grestest Common Divisor (GCD) between three or more numbers.
    ''' </summary>
    ''' <param name="Num1">The first number to be calculated.</param>
    ''' <param name="Num2">The second number to be calculated.</param>
    ''' <param name="Num3">The rest to be calculated.</param>
    ''' <returns>The Grestest Common Divisor (GCD) between three or more numbers.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GCD(Num1 As Long, Num2 As Long, ParamArray Num3 As Long()) As Long
        Return HCF(Num1, Num2, Num3)
    End Function
    ''' <summary>
    ''' Provides a method for finding the Least Common Multiple (LCM) between two numbers.
    ''' </summary>
    ''' <param name="Num1">The first number to be calculated.</param>
    ''' <param name="Num2">The second number to be calculated.</param>
    ''' <returns>The Least Common Multiple (LCM) between three or more numbers.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function LCM(Num1 As Long, Num2 As Long) As Long
        Dim Factor As Long = HCF(Num1, Num2)
        Num1 /= Factor
        Num2 /= Factor
        Return Factor * Num1 * Num2
    End Function
    ''' <summary>
    ''' Provides a method for finding the Least Common Multiple (LCM) between three or more numbers.
    ''' </summary>
    ''' <param name="Num1">The first number to be calculated.</param>
    ''' <param name="Num2">The second number to be calculated.</param>
    ''' <param name="Num3">The rest to be calculated.</param>
    ''' <returns>The Least Common Multiple (LCM) between three or more numbers.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function LCM(Num1 As Long, Num2 As Long, ParamArray Num3 As Long()) As Long
        Dim Value As Long = LCM(Num1, Num2)
        For Counter = 1 To (Num3.Length)
            Value = LCM(Value, Num3(Counter))
        Next
        Return Value
    End Function
    Public Shared Function GetFactors(Value As ULong) As System.Collections.ObjectModel.ReadOnlyCollection(Of ULong)
        Select Case Value
            Case 0
                Throw New InvalidOperationException(
                            "Value in getting prime factors cannot be zero.")
            Case 1
                Return New List(Of ULong)(New ULong() {1}).AsReadOnly
            Case Else
                Dim Factors As New List(Of ULong), Square As Boolean = True
                If Sqrt(Value).ToString.Contains(".") Then Square = False
                For Number As ULong = 1 To Value / 2
                Next
                Return Factors.AsReadOnly()
        End Select
    End Function
    ''' <summary>
    ''' Provides a method for one-forth of a circle when drawn into graph a graph between two numbers.
    ''' </summary>
    ''' <param name="Speed">The size of the curve. The bigger this variable, 
    ''' the less numbers it will generate.</param>
    ''' <param name="InitialValue">The initial value or the begginning number of the number curve.</param>
    ''' <param name="FinalValue">The final value or the last number of the number curve.</param>
    ''' <param name="Separator">The separator between values. Default is a carriage-return character.</param>
    ''' <returns>The curve of numbers in a series of Unicode characters.</returns>
    ''' <remarks></remarks>
    Public Shared Function Curved(Optional ByVal Speed As Double = 2,
    Optional ByVal InitialValue As Double = 1, Optional ByVal FinalValue As Double = 100,
    Optional ByVal Separator As String = Chr(13)) As String
        Dim Previous As Double = System.Math.Pow(InitialValue * FinalValue, 1 / Speed)
        Dim [Return] As String = Previous.ToString()
        Do
            Dim Temp As Double = System.Math.Pow(Previous * System.Math.Pow(FinalValue, Speed),
                                        1 / (Speed + 1))
            Previous = Temp
            If Previous = FinalValue Then
                Exit Do
            End If
            [Return] &= Separator
            [Return] &= Temp
        Loop
        Return [Return]
    End Function
    ''' <summary>
    ''' Provides a method for one-forth of a circle when drawn into graph a graph between two numbers.
    ''' </summary>
    ''' <param name="Speed">The size of the curve. The bigger this variable, 
    ''' the less numbers it will generate.</param>
    ''' <param name="InitialValue">The initial value or the begginning number of the number curve.</param>
    ''' <param name="FinalValue">The final value or the last number of the number curve.</param>
    ''' <returns>The curve of numbers in an array of double-precision floating-point numbers.</returns>
    ''' <remarks></remarks>
    Public Shared Function Curved(Optional ByVal Speed As Double = 2,
    Optional ByVal InitialValue As Double = 1, Optional ByVal FinalValue As Double = 100) As Double()
        Dim Values As New List(Of Double)
        Values.Add(System.Math.Pow(InitialValue * FinalValue, 1 / Speed))
        Do Until Values.Last = FinalValue
            Values.Add(System.Math.Pow(Values.Last * System.Math.Pow(FinalValue, Speed), 1 / (Speed + 1)))
        Loop
        Return Values.ToArray
    End Function

#If False Then
                        Unicode characters
       	0 	1 	2 	3 	4 	5 	6 	7 	8 	9 	A 	B 	C 	D 	E 	F
U+00Bx 	  	  	x² 	x³ 	  	  	  	  	  	x¹ 	  	  	  	  	  	 
U+207x 	x⁰ 	xⁱ 	  	  	x⁴ 	x⁵ 	x⁶ 	x⁷ 	x⁸ 	x⁹ 	x⁺ 	x⁻ 	x⁼ 	x⁽ 	x⁾ 	xⁿ
U+208x 	x₀ 	x₁ 	x₂ 	x₃ 	x₄ 	x₅ 	x₆ 	x₇ 	x₈ 	x₉ 	x₊ 	x₋ 	x₌ 	x₍ 	x₎ 	 
U+209x 	xₐ 	xₑ 	xₒ 	xₓ 	xₔ 	xₕ 	xₖ 	xₗ 	xₘ 	xₙ 	xₚ 	xₛ 	xₜ 	  	  	 

                      Equivalent HTML markup
     	0 	1 	2 	3 	4 	5 	6 	7 	8 	9 	A 	B 	C 	D 	E 	F
U+00Bx 	  	  	x2 	x3 	  	  	  	  	  	x1 	  	  	  	  	  	 
U+207x 	x0 	xi 	  	  	x4 	x5 	x6 	x7 	x8 	x9 	x+ 	x− 	x= 	x( 	x) 	xn
U+208x 	x0 	x1 	x2 	x3 	x4 	x5 	x6 	x7 	x8 	x9 	x+ 	x− 	x= 	x( 	x) 	 
U+209x 	xa 	xe 	xo 	xx 	xə 	xh 	xk 	xl 	xm 	xn 	xp 	xs 	xt 	  	  	 
#End If
    ''' <summary>
    ''' Provides a class for temperature conversions.
    ''' </summary>
    ''' <remarks></remarks>
    Class Temperature
        ''' <summary>
        ''' The internal temperature number storage in Celsius.
        ''' </summary>
        ''' <remarks></remarks>
        Private C As Double = Double.NaN
        ''' <summary>
        ''' Gets or sets the temperature value in Celsius.
        ''' </summary>
        ''' <value>The temperature value to be set in Celsius.</value>
        ''' <returns>The temperature value in Celsius.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Celsius() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return C
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Fahrenheit.
        ''' </summary>
        ''' <value>The temperature value to be set in Fahrenheit.</value>
        ''' <returns>The temperature value in Fahrenheit.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Fahrenheit() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return C * 9 / 5 + 32
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = (value - 32) * 5 / 9
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Kelvin.
        ''' </summary>
        ''' <value>The temperature value to be set in Kelvin.</value>
        ''' <returns>The temperature value in Kelvin.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Kelvin() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return C + 273.15
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = value - 273.15
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Rankine.
        ''' </summary>
        ''' <value>The temperature value to be set in Rankine.</value>
        ''' <returns>The temperature value in Rankine.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Rankine() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return (C + 273.15) * 9 / 5
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = (value - 491.67) * 5 / 9
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Delisle.
        ''' </summary>
        ''' <value>The temperature value to be set in Delisle.</value>
        ''' <returns>The temperature value in Delisle.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Delisle() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return (100 - C) * 3 / 2
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = 100 - value * 2 / 3
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Newton.
        ''' </summary>
        ''' <value>The temperature value to be set in Newton.</value>
        ''' <returns>The temperature value in Newton.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Newton() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return C * 33 / 100
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = value * 100 / 33
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Réaumur.
        ''' </summary>
        ''' <value>The temperature value to be set in Réaumur.</value>
        ''' <returns>The temperature value in Réaumur.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Réaumur() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return C * 4 / 5
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = value * 5 / 4
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the temperature value in Rømer.
        ''' </summary>
        ''' <value>The temperature value to be set in Rømer.</value>
        ''' <returns>The temperature value in Rømer.</returns>
        ''' <exception cref="InvalidOperationException">Thrown when the temperature value has not been set.</exception>
        ''' <exception cref="NotFiniteNumberException">Thrown when the value to be not is either infinity or not-a-number (NaN).</exception>
        ''' <remarks></remarks>
        Public Property Rømer() As Double
            Get
                If Double.IsNaN(C) Then Throw New InvalidOperationException("Temperature has not been set.")
                Return C * 21 / 40 + 7.5
            End Get
            Set(ByVal value As Double)
                If Double.IsInfinity(value) OrElse Double.IsNaN(value) Then Throw New NotFiniteNumberException(
                    "Value to be not is either infinity or not-a-number (NaN).", value)
                C = (value - 7.5) * 40 / 21
            End Set
        End Property
    End Class
    Public Class Number
        Protected Structure Digit
            Private D As Byte
            Public Sub New(ByVal b As Byte)
                If (b < 0 OrElse b > 9) Then Throw New System.ArgumentException(
                    "Argument outside range for digit")
                Me.D = b
            End Sub
            Public Shared Widening Operator CType(ByVal d As Digit) As Byte
                Return d.D
            End Operator
            Public Shared Narrowing Operator CType(ByVal b As Byte) As Digit
                Return New Digit(b)
            End Operator
        End Structure
        Protected Value As System.Numerics.BigInteger

    End Class
    <Obsolete("This method is deprecated, use XXXX instead.", False)> _
    Protected Function OperateDetailed(ByVal Operand As Operands, FirstVariable As Object,
                                ParamArray OtherVariables() As Object) As Object
        Dim Temp As Object = FirstVariable And OtherVariables(0)
        For Each EachVariable As Int32 In OtherVariables
            Temp = Temp And EachVariable
        Next
        Return Temp
    End Function
    Private Sub Main()
        'OperateDetailed(Nothing, Nothing, Nothing)

    End Sub

    ''' <summary>
    ''' An unused enumeration of operands.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Operands
        ' Fields
        Add = 0
        AddChecked = 1
        [And] = 2
        [AndAlso] = 3
        ArrayIndex = 5
        ArrayLength = 4
        [Call] = 6
        Coalesce = 7
        Conditional = 8
        Constant = 9
        [Convert] = 10
        ConvertChecked = 11
        Divide = 12
        Equal = 13
        ExclusiveOr = 14
        GreaterThan = 15
        GreaterThanOrEqual = &H10
        Invoke = &H11
        Lambda = &H12
        LeftShift = &H13
        LessThan = 20
        LessThanOrEqual = &H15
        ListInit = &H16
        MemberAccess = &H17
        MemberInit = &H18
        Modulo = &H19
        Multiply = &H1A
        MultiplyChecked = &H1B
        Negate = &H1C
        NegateChecked = 30
        [New] = &H1F
        NewArrayBounds = &H21
        NewArrayInit = &H20
        [Not] = &H22
        NotEqual = &H23
        [Or] = &H24
        [OrElse] = &H25
        Parameter = &H26
        Power = &H27
        Quote = 40
        RightShift = &H29
        Subtract = &H2A
        SubtractChecked = &H2B
        TypeAs = &H2C
        TypeIs = &H2D
        UnaryPlus = &H1D
    End Enum

End Class
#If False Then
Module Extension
    <Extension()> Public Function GetEnumDescription(ByVal EnumConstant As [Enum]) As String
    End Function
End Module
#End If