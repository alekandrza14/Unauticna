option casemap:none

extern CreateFileA : proc extern WriteFile : proc extern CloseHandle : proc extern ExitProcess : proc

PUBLIC main

.data filePath db "C:\data\licensya.int", 0 ; Путь к файлу dataBuf db "1877449", 0 ; Данные для записи bytesWritten dq 0 ; Переменная для хранения количества записанных байт

; Константы
GENERIC_WRITE equ 40000000h                ; Права на запись
CREATE_ALWAYS equ 2                        ; Вариант открытия файла (создавать заново)
FILE_ATTRIBUTE_NORMAL equ 80h              ; Обычные атрибуты файла
.code main proc sub rsp, 28h ; Выделяем место в стеке

; Вызов CreateFileA
lea rcx, filePath                          ; Аргумент: путь к файлу
mov rdx, GENERIC_WRITE                     ; Права на запись
xor r8, r8                                 ; Указываем, что значение не используется
xor r9, r9                                 ; Указываем, что значение не используется

sub rsp, 20h                               ; Выделяем место для дополнительных аргументов
mov qword ptr [rsp+20h], CREATE_ALWAYS    ; Аргумент: создать всегда
mov qword ptr [rsp+28h], FILE_ATTRIBUTE_NORMAL ; Аргумент: обычные атрибуты
mov qword ptr [rsp+30h], 0                 ; Аргумент: нет наследования
call CreateFileA                           ; Вызов функции
add rsp, 20h                               ; Восстанавливаем стек

mov rbx, rax                               ; Сохраняем дескриптор файла в rbx

; Вызов WriteFile
mov rcx, rbx                               ; Дескриптор файла
lea rdx, dataBuf                           ; Буфер с данными
mov r8d, 7                                 ; Длина записи (длина строки &quot;1877449&quot;)
lea r9, bytesWritten                       ; Адрес переменной для хранения числа записанных байт

sub rsp, 20h                               ; Выделяем место в стеке
mov qword ptr [rsp+20h], 0                 ; Указываем, что не требуется дополнительное значение
call WriteFile                             ; Вызов функции
add rsp, 20h                               ; Восстанавливаем стек

; Вызов CloseHandle
mov rcx, rbx                               ; Дескриптор файла
call CloseHandle                           ; Закрываем файл

; Вызов ExitProcess
xor ecx, ecx                               ; Код завершения равен 0
call ExitProcess                           ; Завершаем процесс
main endp 
end