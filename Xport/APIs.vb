Option Strict On
Imports System.Runtime.InteropServices

Namespace Xport
    Public Class General
        Public Const WM_USER As Int32 = &H400
        Public Const WM_SETREDRAW As Int32 = &HB

        'Declare Function SendMessageByString Lib "user32" Alias "SendMessageA" _
        ' (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As String) As Long

        ' Declare Function SendMessageByLong Lib "user32" Alias "SendMessageA" _
        ' (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

        Public Declare Auto Function SendMessage Lib "user32" _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr

        Private Declare Auto Function FormatMessage Lib "kernel32" Alias "FormatMessageA" (ByVal dwFlags As Integer, ByRef lpSource As Object, ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByVal lpBuffer As String, ByVal nSize As Integer, ByRef Arguments As Integer) As Integer

        Public Shared Function GetLastErrorMessageDescription() As String
            Const FORMAT_MESSAGE_FROM_SYSTEM As Short = &H1000S
            Const LANG_NEUTRAL As Short = &H0S
            Dim Win32Error As Integer
            Win32Error = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            Dim Buffer As String = Space(999)
            FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, 0, Win32Error, LANG_NEUTRAL, Buffer, 999, 0)
            Return Trim(Buffer)
        End Function
    End Class

    Public Class RichEditControl
        Public Declare Function SendMessageA Lib "user32.dll" _
        (ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As CharFormat2) As Integer

        <StructLayout(LayoutKind.Sequential)> Public Structure CharFormat2
            Public cbSize As Int32
            Public dwMask As Int32
            Public dwEffects As Int32
            Public yHeight As Int32
            Public yOffset As Int32
            Public crTextColor As Int32
            Public bCharSet As Byte
            Public bPitchAndFamily As Byte
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Public szFaceName As String
            Public wWeight As Int16
            Public sSpacing As Int16
            Public crBackColor As Int32
            Public lcid As Int32
            Public dwReserved As Int32
            Public sStyle As Int16
            Public wKerning As Int16
            Public bUnderlineType As Byte
            Public bAnimation As Byte
            Public bRevAuthor As Byte
            Public bReserved1 As Byte
        End Structure

        Public Declare Function SendMessageAv Lib "user32.dll" Alias "SendMessageA" _
        (ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByRef lParam As CharRange) As Integer

        <StructLayout(LayoutKind.Sequential)> Public Structure CharRange
            Public cpMin As Int32
            Public cpMax As Int32
        End Structure

        'RichEdit messages
        Public Const EM_GETLIMITTEXT As Int32 = General.WM_USER + 37
        Public Const EM_POSFROMCHAR As Int32 = General.WM_USER + 38
        Public Const EM_CHARFROMPOS As Int32 = General.WM_USER + 39
        Public Const EM_SCROLLCARET As Int32 = General.WM_USER + 49
        Public Const EM_CANPASTE As Int32 = General.WM_USER + 50
        Public Const EM_DISPLAYBAND As Int32 = General.WM_USER + 51
        Public Const EM_EXGETSEL As Int32 = General.WM_USER + 52
        Public Const EM_EXLIMITTEXT As Int32 = General.WM_USER + 53
        Public Const EM_EXLINEFROMCHAR As Int32 = General.WM_USER + 54
        Public Const EM_EXSETSEL As Int32 = General.WM_USER + 55
        Public Const EM_FINDTEXT As Int32 = General.WM_USER + 56
        Public Const EM_FORMATRANGE As Int32 = General.WM_USER + 57
        Public Const EM_GETCHARFORMAT As Int32 = General.WM_USER + 58
        Public Const EM_GETEVENTMASK As Int32 = General.WM_USER + 59
        Public Const EM_GETOLEINTERFACE As Int32 = General.WM_USER + 60
        Public Const EM_GETPARAFORMAT As Int32 = General.WM_USER + 61
        Public Const EM_GETSELTEXT As Int32 = General.WM_USER + 62
        Public Const EM_HIDESELECTION As Int32 = General.WM_USER + 63
        Public Const EM_PASTESPECIAL As Int32 = General.WM_USER + 64
        Public Const EM_REQUESTRESIZE As Int32 = General.WM_USER + 65
        Public Const EM_SELECTIONTYPE As Int32 = General.WM_USER + 66
        Public Const EM_SETBKGNDCOLOR As Int32 = General.WM_USER + 67
        Public Const EM_SETCHARFORMAT As Int32 = General.WM_USER + 68
        Public Const EM_SETEVENTMASK As Int32 = General.WM_USER + 69
        Public Const EM_SETOLECALLBACK As Int32 = General.WM_USER + 70
        Public Const EM_SETPARAFORMAT As Int32 = General.WM_USER + 71
        Public Const EM_SETTARGETDEVICE As Int32 = General.WM_USER + 72
        Public Const EM_STREAMIN As Int32 = General.WM_USER + 73
        Public Const EM_STREAMOUT As Int32 = General.WM_USER + 74
        Public Const EM_GETTEXTRANGE As Int32 = General.WM_USER + 75
        Public Const EM_FINDWORDBREAK As Int32 = General.WM_USER + 76
        Public Const EM_SETOPTIONS As Int32 = General.WM_USER + 77
        Public Const EM_GETOPTIONS As Int32 = General.WM_USER + 78
        Public Const EM_FINDTEXTEX As Int32 = General.WM_USER + 79
        Public Const EM_GETWORDBREAKPROCEX As Int32 = General.WM_USER + 80
        Public Const EM_SETWORDBREAKPROCEX As Int32 = General.WM_USER + 81
        'Richedit v2.0 messages
        Public Const EM_SETUNDOLIMIT As Int32 = General.WM_USER + 82
        Public Const EM_REDO As Int32 = General.WM_USER + 84
        Public Const EM_CANREDO As Int32 = General.WM_USER + 85
        Public Const EM_GETUNDONAME As Int32 = General.WM_USER + 86
        Public Const EM_GETREDONAME As Int32 = General.WM_USER + 87
        Public Const EM_STOPGROUPTYPING As Int32 = General.WM_USER + 88
        Public Const EM_SETTEXTMODE As Int32 = General.WM_USER + 89
        Public Const EM_GETTEXTMODE As Int32 = General.WM_USER + 90

        Public Const CFM_BOLD As Int32 = &H1
        Public Const CFM_ITALIC As Int32 = &H2
        Public Const CFM_UNDERLINE As Int32 = &H4
        Public Const CFM_STRIKEOUT As Int32 = &H8
        Public Const CFM_PROTECTED As Int32 = &H10
        Public Const CFM_LINK As Int32 = &H20
        Public Const CFM_SIZE As Int32 = &H80000000
        Public Const CFM_COLOR As Int32 = &H40000000
        Public Const CFM_FACE As Int32 = &H20000000
        Public Const CFM_OFFSET As Int32 = &H10000000
        Public Const CFM_CHARSET As Int32 = &H8000000

        Public Const SCF_SELECTION As Int32 = &H1
        Public Const SCF_WORD As Int32 = &H2
        Public Const SCF_DEFAULT As Int32 = &H0
        Public Const SCF_ALL As Int32 = &H4
        Public Const SCF_USEUIRULES As Int32 = &H8

        'Event notification masks
        Public Const ENM_NONE As Int32 = &H0
        Public Const ENM_CHANGE As Int32 = &H1
        Public Const ENM_UPDATE As Int32 = &H2
        Public Const ENM_SCROLL As Int32 = &H4
        Public Const ENM_KEYEVENTS As Int32 = &H10000
        Public Const ENM_MOUSEEVENTS As Int32 = &H20000
        Public Const ENM_REQUESTRESIZE As Int32 = &H40000
        Public Const ENM_SELCHANGE As Int32 = &H80000
        Public Const ENM_DROPFILES As Int32 = &H100000
        Public Const ENM_PROTECTED As Int32 = &H200000
        Public Const ENM_CORRECTTEXT As Int32 = &H400000 ' PenWin specific
        Public Const ENM_SCROLLEVENTS As Int32 = &H8
        Public Const ENM_DRAGDROPDONE As Int32 = &H10
        Public Const ENM_PARAGRAPHEXPANDED As Int32 = &H20

        Public Const WM_LBUTTONDOWN As Int32 = &H201
        Public Const WM_LBUTTONUP As Int32 = &H202
        Public Const WM_LBUTTONDBLCLK As Int32 = &H203
        Public Const WM_RBUTTONDOWN As Int32 = &H204
        Public Const WM_RBUTTONUP As Int32 = &H205
        Public Const WM_RBUTTONDBLCLK As Int32 = &H206
        Public Const WM_MBUTTONDOWN As Int32 = &H207
        Public Const WM_MBUTTONUP As Int32 = &H208
        Public Const WM_SETCURSOR As Int32 = &H20
        Public Const WM_MOUSEMOVE As Int32 = &H200

    End Class

End Namespace
