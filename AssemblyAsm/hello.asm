option casemap:none

includelib user32.lib
includelib kernel32.lib

extern MessageBoxA : proc
extern ExitProcess : proc

PUBLIC main

.data
    text    db "Hello world!",0
    caption db "ASM",0

.code
main proc
    sub rsp, 28h

    xor rcx, rcx
    lea rdx, text
    lea r8, caption
    xor r9d, r9d
    call MessageBoxA

    xor ecx, ecx
    call ExitProcess

main endp
end