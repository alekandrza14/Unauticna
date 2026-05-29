option casemap:none

extrn CreateFileA:proc
extrn WriteFile:proc
extrn CloseHandle:proc
extrn ExitProcess:proc
extrn GetTickCount:proc

.data
filename db "C:\data\Uhcot.txt",0
buffer db 512 dup(0)

; ===== списки =====

city1 db "Paris",0
city2 db "Tokyo",0
city3 db "Berlin",0
city4 db "London",0
city5 db "Rome",0
city6 db "Madrid",0
city7 db "Oslo",0
city8 db "Dublin",0
city9 db "Vienna",0
city10 db "Prague",0

cities dq city1,city2,city3,city4,city5,city6,city7,city8,city9,city10
cities_count dq 10

name1 db "Fasist",0
name2 db "Gay",0
name3 db "Pirat",0
name4 db "Narcoman",0
name5 db "Kriminal",0
name6 db "Chearter",0
name7 db "Tea Farmer",0
name8 db "Slave",0
name9 db "Lesbian",0
name10 db "Joker",0

names dq name1,name2,name3,name4,name5,name6,name7,name8,name9,name10
names_count dq 10

ideo1 db "Liberalism",0
ideo2 db "Socialism",0
ideo3 db "Conservatism",0
ideo4 db "Libertarianism",0
ideo5 db "Nationalism",0
ideo6 db "Anarchism",0
ideo7 db "Feminism",0
ideo8 db "Environmentalism",0
ideo9 db "Populism",0
ideo10 db "Globalism",0

ideos dq ideo1,ideo2,ideo3,ideo4,ideo5,ideo6,ideo7,ideo8,ideo9,ideo10
ideos_count dq 10

hFile dq 0
bytesWritten dq 0
seed dq 0

GENERIC_WRITE equ 40000000h
CREATE_ALWAYS equ 2
FILE_ATTRIBUTE_NORMAL equ 80h

.code

rand PROC
    mov rax, seed
    imul rax, 1103515245
    add rax, 12345
    mov seed, rax
    ret
rand ENDP

copy_str PROC
@@:
    mov al, [rsi]
    test al, al
    jz @f
    mov [rdi], al
    inc rsi
    inc rdi
    jmp @b
@@:
    ret
copy_str ENDP

; rcx = массив, rdx = count
; -> rsi = выбранная строка
pick PROC
    push rbx

    mov rbx, rdx        ; rbx = count
    call rand

    shr rax, 16         ; 🔥 берём старшие биты
    xor rdx, rdx
    div rbx             ; rdx = индекс

    mov rsi, [rcx + rdx*8]

    pop rbx
    ret
pick ENDP
main PROC
    sub rsp, 40

    call GetTickCount
    mov seed, rax

    ; CreateFile
    lea rcx, filename
    mov rdx, GENERIC_WRITE
    xor r8, r8
    xor r9, r9

    sub rsp, 32
    mov qword ptr [rsp+32], CREATE_ALWAYS
    mov qword ptr [rsp+40], FILE_ATTRIBUTE_NORMAL
    mov qword ptr [rsp+48], 0
    call CreateFileA
    add rsp, 32

    mov hFile, rax
    lea rdi, buffer

    ; ===== 1 строка (город) =====
    lea rcx, cities
    mov rdx, cities_count
    call pick
    call copy_str

    mov byte ptr [rdi], 13
    inc rdi
    mov byte ptr [rdi], 10
    inc rdi

    ; ===== 2 строка (имена ×3) =====
    mov rcx, 3
names_loop:
    push rcx

    mov rbx, 3
inner_names:
    lea rcx, names
    mov rdx, names_count
    call pick
    call copy_str

    dec rbx
    jz names_done_inner

    mov byte ptr [rdi], ' '
    inc rdi
    jmp inner_names

names_done_inner:

    pop rcx
    dec rcx
    jz names_done_all

    mov byte ptr [rdi], ' '
    inc rdi
    jmp names_loop

names_done_all:

    mov byte ptr [rdi], 13
    inc rdi
    mov byte ptr [rdi], 10
    inc rdi

    ; ===== 3 строка (идеология) =====
    lea rcx, ideos
    mov rdx, ideos_count
    call pick
    call copy_str

    mov byte ptr [rdi], 0

    ; длина
    lea rax, buffer
    sub rdi, rax
    mov r8, rdi

    ; WriteFile
    mov rcx, hFile
    lea rdx, buffer
    lea r9, bytesWritten

    sub rsp, 32
    mov qword ptr [rsp+32], 0
    call WriteFile
    add rsp, 32

    ; Close
    mov rcx, hFile
    call CloseHandle

    xor rcx, rcx
    call ExitProcess

main ENDP
END