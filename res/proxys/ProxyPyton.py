import os
import time
import random

INPUT_FILE = "res/temp/Input/Cube_pos.uns"
OUTPUT_DIR = "res/temp/Output"
OUTPUT_FILE = os.path.join(OUTPUT_DIR, "Cube_pos.uns")

os.makedirs(OUTPUT_DIR, exist_ok=True)

start_time = time.time()

while time.time() - start_time < 999999999:  # 60 секунд
    if os.path.exists(INPUT_FILE):
        try:
            with open(INPUT_FILE, "r", encoding="utf-8") as f:
                data = f.read().strip()

            pos = data.split('+')

            if len(pos) >= 3:
                x = float(pos[0])
                y = float(pos[1])
                z = float(pos[2])

                x += random.uniform(-3.0, 3.0)
                z += random.uniform(-3.0, 3.0)

                with open(OUTPUT_FILE, "w", encoding="utf-8") as f:
                    f.write(f"{x}+{y}+{z}")

                print(f"Новая позиция: {x:.2f} {y:.2f} {z:.2f}")

        except Exception as e:
            print("Ошибка:", e)

    time.sleep(1)

print("Готово")