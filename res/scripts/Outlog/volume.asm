option casemap:none

includelib user32.lib
includelib kernel32.lib
includelib winmm.lib

extern ExitProcess : proc
extern waveOutSetVolume : proc

PUBLIC main

.code
main proc
    sub rsp, 28h

    ; DWORD volume = 0xFFFF_FFFF (левый + правый канал = максимум)
    mov ecx, -1          ; WAVE_MAPPER (0xFFFFFFFF) = все устройства
    mov edx, 0FFFFFFFFh  ; максимальная громкость (L=FFFF, R=FFFF)

    call waveOutSetVolume

    xor ecx, ecx
    call ExitProcess

main endp
end