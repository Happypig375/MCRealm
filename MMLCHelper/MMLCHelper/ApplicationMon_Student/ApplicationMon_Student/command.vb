Imports System

Namespace ApplicationMon_Student
    Public Class command
        ' Nested Types
        Public Enum APPMON_CMD
            ' Fields
            CMD_CLOSE_APP_MON = 6
            CMD_STUDENT_CURRENT_PROCESS = 11
            CMD_STUDENT_DISABLE_RUN = &H10
            CMD_STUDENT_ENABLE_RUN = 15
            CMD_STUDENT_GET_CURRENT_PROCESS = 12
            CMD_STUDENT_KILL_CURRENT_PROCESS = 14
            CMD_STUDENT_KILL_PROCESS = 13
            CMD_STUDENT_PROCESS_LIST = 9
            CMD_STUDENT_SEND_PROCESS_LIST = 10
            CMD_TEACHER_DISABLE_RUN = 8
            CMD_TEACHER_ENABLE_RUN = 7
            CMD_TEACHER_GET_CURRENT_PROCESS = 0
            CMD_TEACHER_GET_PROCESS_LIST = 1
            CMD_TEACHER_KILL_CURRENT_PROCESS = 5
            CMD_TEACHER_KILL_PROCESS = 4
            CMD_TEACHER_POST_CURRENT_PROCESS = 3
            CMD_TEACHER_POST_PROCESS_LIST = 2
        End Enum
    End Class
End Namespace

