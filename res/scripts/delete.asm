option casemap:none

extern DeleteFileA : proc
extern ExitProcess : proc

PUBLIC main

.data
    filePath db "C:\data\licensya.int", 0

.code
main proc
    sub rsp, 28h

    lea rcx, filePath
    call DeleteFileA

    xor ecx, ecx
    call ExitProcess

main endp
end