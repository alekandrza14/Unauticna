option casemap:none

; WinAPI
extrn CreateFileA:proc
extrn ReadFile:proc
extrn WriteFile:proc
extrn CloseHandle:proc
extrn GetLastError:proc
extrn ExitProcess:proc

includelib kernel32.lib

.data
srcPath db "C:\data\log1",0
dstPath db "C:\data\vinterer cheats.string",0

buffer db 4096 dup(0)

bytesRead dq 0
bytesWritten dq 0

INVALID_HANDLE_VALUE equ -1

.code

main proc
    sub rsp, 28h

    ; === Открыть исходный файл ===
    lea rcx, srcPath
    mov rdx, 80000000h        ; GENERIC_READ
    mov r8, 1                 ; FILE_SHARE_READ
    xor r9, r9

    sub rsp, 20h
    mov qword ptr [rsp+20h], 3      ; OPEN_EXISTING
    mov qword ptr [rsp+28h], 80h    ; FILE_ATTRIBUTE_NORMAL
    mov qword ptr [rsp+30h], 0
    call CreateFileA
    add rsp, 20h

    cmp rax, INVALID_HANDLE_VALUE
    je error

    mov r12, rax

    ; === Создать файл назначения ===
    lea rcx, dstPath
    mov rdx, 40000000h        ; GENERIC_WRITE
    xor r8, r8
    xor r9, r9

    sub rsp, 20h
    mov qword ptr [rsp+20h], 2      ; CREATE_ALWAYS
    mov qword ptr [rsp+28h], 80h
    mov qword ptr [rsp+30h], 0
    call CreateFileA
    add rsp, 20h

    cmp rax, INVALID_HANDLE_VALUE
    je close_src

    mov r13, rax

read_loop:
    ; === Читать ===
    mov rcx, r12
    lea rdx, buffer
    mov r8, 4096
    lea r9, bytesRead

    sub rsp, 20h
    mov qword ptr [rsp+20h], 0
    call ReadFile
    add rsp, 20h

    cmp qword ptr [bytesRead], 0
    je done

    ; === Писать ===
    mov rcx, r13
    lea rdx, buffer
    mov r8, [bytesRead]
    lea r9, bytesWritten

    sub rsp, 20h
    mov qword ptr [rsp+20h], 0
    call WriteFile
    add rsp, 20h

    jmp read_loop

done:
    mov rcx, r13
    call CloseHandle

close_src:
    mov rcx, r12
    call CloseHandle

    xor ecx, ecx
    call ExitProcess

error:
    ; можно получить код ошибки через GetLastError
    call GetLastError
    mov ecx, eax
    call ExitProcess

main endp
end