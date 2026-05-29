option casemap:none

extern CreateFileA  : proc
extern WriteFile    : proc
extern CloseHandle  : proc
extern ExitProcess  : proc

PUBLIC main

.data
filename db "C:\data\generatorword.masive.string",0

consonants db "bcdfghjklmnpqrstvwxyz"
vowels     db "aeiou"

buffer db 65536 dup(0)

hFile dq 0
bytesWritten dd 0

GENERIC_WRITE equ 40000000h
CREATE_ALWAYS  equ 2
FILE_ATTRIBUTE_NORMAL equ 80h

X_SIZE equ 100
Y_SIZE equ 100

.code

; -------------------------
; FAST RAND (NO DIV)
; -------------------------
rand proc
    rdtsc
    xor eax, edx
    add eax, 12345
    and eax, 1Fh
    ret
rand endp

; -------------------------
main proc

    sub rsp, 28h

    ; -------------------------
    ; CreateFileA
    ; -------------------------
    lea rcx, filename
    mov edx, GENERIC_WRITE
    xor r8, r8
    xor r9, r9

    sub rsp, 20h
    mov qword ptr [rsp+20h], CREATE_ALWAYS
    mov qword ptr [rsp+28h], FILE_ATTRIBUTE_NORMAL
    mov qword ptr [rsp+30h], 0
    call CreateFileA
    add rsp, 20h

    cmp rax, 0FFFFFFFFFFFFFFFFh
    je fail

    mov [hFile], rax

    ; -------------------------
    ; INIT
    ; -------------------------
    lea rdi, buffer
    xor rbx, rbx

    mov r8d, Y_SIZE

y_loop:
    mov r9d, X_SIZE

x_loop:

    ; -------------------------
    ; WORD = CVCVC (5 letters)
    ; -------------------------

    ; C
    call rand
    lea rdx, consonants
    mov al, [rdx + rax]
    mov [rdi], al
    inc rdi
    inc rbx

    ; V
    call rand
    lea rdx, vowels
    and eax, 7
    mov al, [rdx + rax]
    mov [rdi], al
    inc rdi
    inc rbx

    ; C
    call rand
    lea rdx, consonants
    mov al, [rdx + rax]
    mov [rdi], al
    inc rdi
    inc rbx

    ; V
    call rand
    lea rdx, vowels
    and eax, 7
    mov al, [rdx + rax]
    mov [rdi], al
    inc rdi
    inc rbx

    ; C
    call rand
    lea rdx, consonants
    mov al, [rdx + rax]
    mov [rdi], al
    inc rdi
    inc rbx

    ; comma
    mov byte ptr [rdi], ','
    inc rdi
    inc rbx

    dec r9d
    jnz x_loop

    ; end line
    mov byte ptr [rdi], '.'
    inc rdi
    inc rbx

    mov byte ptr [rdi], 10
    inc rdi
    inc rbx

    dec r8d
    jnz y_loop

    ; -------------------------
    ; WRITE FILE
    ; -------------------------
    mov rcx, [hFile]
    lea rdx, buffer
    mov r8d, ebx
    lea r9, bytesWritten

    sub rsp, 20h
    mov qword ptr [rsp+20h], 0
    call WriteFile
    add rsp, 20h

    ; -------------------------
    ; CLOSE
    ; -------------------------
    mov rcx, [hFile]
    call CloseHandle

    xor ecx, ecx
    call ExitProcess

fail:
    xor ecx, ecx
    call ExitProcess

main endp
end