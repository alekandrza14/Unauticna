import java.awt.*;

public class Main {

    static final Robot robot;

    static {
        try {
            robot = new Robot();
        } catch (AWTException e) {
            throw new RuntimeException(e);
        }
    }

    public static void main(String[] args) {
        System.out.println("Программа запущена");

        while (true) {
            try {
                Point mouse = MouseInfo.getPointerInfo().getLocation();

                // Цвет пикселя прямо под курсором
                Color color = robot.getPixelColor(mouse.x, mouse.y);

                // Двигаемся только если пиксель красный
                if (isRed(color)) {
                    moveToRandomTarget();
                }

                Thread.sleep(20);

            } catch (InterruptedException e) {
                break;
            }
        }
    }

    static boolean isRed(Color color) {
        int r = color.getRed();
        int g = color.getGreen();
        int b = color.getBlue();

        // Не только идеально #FF0000,
        // но и близкие оттенки красного
        return r > 180 &&
               g < 100 &&
               b < 100;
    }

  

static int timerA = 0;
static int[] targetY = new int[]{-1,1,1,-1,-1,1,1,-1};
static int[] targetX = new int[]{-1,-1,1,1,-1,1,-1,1};

public static void moveToRandomTarget() {

    Point mouse = MouseInfo.getPointerInfo().getLocation();

    // Выбираем новую цель ТОЛЬКО если старой цели нет
    

     //   Dimension screen = Toolkit.getDefaultToolkit().getScreenSize();

        timerA += 1;
        timerA %= 8;

    int dx = targetX[timerA];
    int dy = targetY[timerA];

   // double distance = Math.sqrt(dx * dx + dy * dy);

    // Дошли до цели
   

    // Плавно идём к одной и той же цели
    int newX = mouse.x+(int)dx;
    int newY = mouse.y+ (int)dy;

    robot.mouseMove(newX, newY);
}
}