option casemap:none

extern CreateFileA  : proc
extern WriteFile    : proc
extern CloseHandle  : proc
extern ExitProcess  : proc

PUBLIC main

.data
    filePath db "C:\data\licensya.int", 0
    dataBuf  db "1877449", 0
    bytesWritten dq 0

    ; константы
    GENERIC_WRITE equ 40000000h
    CREATE_ALWAYS equ 2
    FILE_ATTRIBUTE_NORMAL equ 80h

.code
main proc
    sub rsp, 28h

    ; CreateFileA(
    ;   lpFileName,
    ;   GENERIC_WRITE,
    ;   0,
    ;   0,
    ;   CREATE_ALWAYS,
    ;   FILE_ATTRIBUTE_NORMAL,
    ;   0
    ; )
    lea rcx, filePath
    mov rdx, GENERIC_WRITE
    xor r8, r8
    xor r9, r9

    sub rsp, 20h
    mov qword ptr [rsp+20h], CREATE_ALWAYS
    mov qword ptr [rsp+28h], FILE_ATTRIBUTE_NORMAL
    mov qword ptr [rsp+30h], 0
    call CreateFileA
    add rsp, 20h

    mov rbx, rax              ; handle файла

    ; WriteFile(
    ;   handle,
    ;   buffer,
    ;   size,
    ;   &bytesWritten,
    ;   0
    ; )
    mov rcx, rbx
    lea rdx, dataBuf
    mov r8d, 7                ; длина "1877449"
    lea r9, bytesWritten

    sub rsp, 20h
    mov qword ptr [rsp+20h], 0
    call WriteFile
    add rsp, 20h

    ; CloseHandle(handle)
    mov rcx, rbx
    call CloseHandle

    ; ExitProcess(0)
    xor ecx, ecx
    call ExitProcess

main endp
end