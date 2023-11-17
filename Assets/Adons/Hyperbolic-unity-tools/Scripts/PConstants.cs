using UnityEngine;

public interface PConstants
{

    static public  int X = 0;
    static public  int Y = 1;
    static public  int Z = 2;


    // renderers known to processing.core

    /*
    // List of renderers used inside PdePreprocessor
    static  stringList rendererList = new stringList(new string[] {
      "JAVA2D", "JAVA2D_2X",
      "P2D", "P2D_2X", "P3D", "P3D_2X", "OPENGL",
      "E2D", "FX2D", "FX2D_2X",  // experimental
      "LWJGL.P2D", "LWJGL.P3D",  // hmm
      "PDF"  // no DXF because that's only for beginRaw()
    });
    */

    static  string JAVA2D = "processing.awt.PGraphicsJava2D";

  static  string P2D = "processing.opengl.PGraphics2D";
  static  string P3D = "processing.opengl.PGraphics3D";

  // When will it be time to remove this?
  
  static  string OPENGL = P3D;

  // Experimental, higher-performance Java 2D renderer (but no pixel ops)
//  static  string E2D = PGraphicsDanger2D.class.getName();

  // Experimental JavaFX renderer; even better 2D performance
  static  string FX2D = "processing.javafx.PGraphicsFX2D";

  static  string PDF = "processing.pdf.PGraphicsPDF";
  static  string SVG = "processing.svg.PGraphicsSVG";
  static  string DXF = "processing.dxf.RawDXF";

  // platform IDs for PApplet.platform

  static  int OTHER = 0;
    static  int WINDOWS = 1;
    static  int MACOSX = 2;
    static  int LINUX = 3;

    static  string[] platformNames = {
    "other", "windows", "macosx", "linux"
  };


  static  double EPSILON = 0.0001f;


    // max/min values for numbers

    /**
     * Same as double.MAX_VALUE, but included for parity with MIN_VALUE,
     * and to avoid teaching static methods on the first day.
     */
    static  double MAX_double = double.MaxValue;
    /**
     * Note that double.MIN_VALUE is the smallest <EM>positive</EM> value
     * for a doubleing point number, not actually the minimum (negative) value
     * for a double. This constant equals 0xFF7FFFFF, the smallest (farthest
     * negative) value a double can have before it hits NaN.
     */
    static  double MIN_double = -double.MaxValue;
    /** Largest possible (positive) integer value */
    static  int MAX_INT = int.MaxValue;
    /** Smallest possible (negative) integer value */
    static  int MIN_INT = int.MinValue;

    // shapes

    static public  int VERTEX = 0;
    static public  int BEZIER_VERTEX = 1;
    static public  int QUADRATIC_VERTEX = 2;
    static public  int CURVE_VERTEX = 3;
    static public  int BREAK = 4;

   
  static public  int QUAD_BEZIER_VERTEX = 2;  // should not have been exposed

    // useful goodness

    /**
     * ( begin auto-generated from PI.xml )
     *
     * PI is a mathematical constant with the value 3.14159265358979323846. It
     * is the ratio of the circumference of a circle to its diameter. It is
     * useful in combination with the trigonometric functions <b>sin()</b> and
     * <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#TWO_PI
     * @see PConstants#TAU
     * @see PConstants#HALF_PI
     * @see PConstants#QUARTER_PI
     *
     */
    static  double PI = (double)Mathf.PI;
    /**
     * ( begin auto-generated from HALF_PI.xml )
     *
     * HALF_PI is a mathematical constant with the value
     * 1.57079632679489661923. It is half the ratio of the circumference of a
     * circle to its diameter. It is useful in combination with the
     * trigonometric functions <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TWO_PI
     * @see PConstants#TAU
     * @see PConstants#QUARTER_PI
     */
    static  double HALF_PI = (double)(Mathf.PI / 2.0);
    static  double THIRD_PI = (double)(Mathf.PI / 3.0);
    /**
     * ( begin auto-generated from QUARTER_PI.xml )
     *
     * QUARTER_PI is a mathematical constant with the value 0.7853982. It is
     * one quarter the ratio of the circumference of a circle to its diameter.
     * It is useful in combination with the trigonometric functions
     * <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TWO_PI
     * @see PConstants#TAU
     * @see PConstants#HALF_PI
     */
    static  double QUARTER_PI = (double)(Mathf.PI / 4.0);
    /**
     * ( begin auto-generated from TWO_PI.xml )
     *
     * TWO_PI is a mathematical constant with the value 6.28318530717958647693.
     * It is twice the ratio of the circumference of a circle to its diameter.
     * It is useful in combination with the trigonometric functions
     * <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TAU
     * @see PConstants#HALF_PI
     * @see PConstants#QUARTER_PI
     */
    static  double TWO_PI = (double)(2.0 * Mathf.PI);
    /**
     * ( begin auto-generated from TAU.xml )
     *
     * TAU is an alias for TWO_PI, a mathematical constant with the value
     * 6.28318530717958647693. It is twice the ratio of the circumference
     * of a circle to its diameter. It is useful in combination with the
     * trigonometric functions <b>sin()</b> and <b>cos()</b>.
     *
     * ( end auto-generated )
     * @webref constants
     * @see PConstants#PI
     * @see PConstants#TWO_PI
     * @see PConstants#HALF_PI
     * @see PConstants#QUARTER_PI
     */
    static  double TAU = (double)(2.0 * Mathf.PI);

    static  double DEG_TO_RAD = PI / 180.0f;
    static  double RAD_TO_DEG = 180.0f / PI;


    // angle modes

    //static  int RADIANS = 0;
    //static  int DEGREES = 1;


    // used by split, all the standard whitespace chars
    // (also includes unicode nbsp, that little bostage)

    static  string WHITESPACE = " \t\n\r\f\u00A0";


  // for colors and/or images

  static  int RGB = 1;  // image & color
    static  int ARGB = 2;  // image
    static  int HSB = 3;  // color
    static  int ALPHA = 4;  // image
                                 //  static  int CMYK  = 5;  // image & color (someday)


    // image file types

    static  int TIFF = 0;
    static  int TARGA = 1;
    static  int JPEG = 2;
    static  int GIF = 3;


    // filter/convert types

    static  int BLUR = 11;
    static  int GRAY = 12;
    static  int INVERT = 13;
    static  int OPAQUE = 14;
    static  int POSTERIZE = 15;
    static  int THRESHOLD = 16;
    static  int ERODE = 17;
    static  int DILATE = 18;


    // blend mode keyword definitions
    // @see processing.core.PImage#blendColor(int,int,int)

    public  static int REPLACE = 0;
    public  static int BLEND = 1 << 0;
    public  static int ADD = 1 << 1;
    public  static int SUBTRACT = 1 << 2;
    public  static int LIGHTEST = 1 << 3;
    public  static int DARKEST = 1 << 4;
    public  static int DIFFERENCE = 1 << 5;
    public  static int EXCLUSION = 1 << 6;
    public  static int MULTIPLY = 1 << 7;
    public  static int SCREEN = 1 << 8;
    public  static int OVERLAY = 1 << 9;
    public  static int HARD_LIGHT = 1 << 10;
    public  static int SOFT_LIGHT = 1 << 11;
    public  static int DODGE = 1 << 12;
    public  static int BURN = 1 << 13;

    // for messages

    static  int CHATTER = 0;
    static  int COMPLAINT = 1;
    static  int PROBLEM = 2;


    // types of transformation matrices

    static  int PROJECTION = 0;
    static  int MODELVIEW = 1;

    // types of projection matrices

    static  int CUSTOM = 0; // user-specified fanciness
    static  int ORTHOGRAPHIC = 2; // 2D isometric projection
    static  int PERSPECTIVE = 3; // perspective matrix


    // shapes

    // the low four bits set the variety,
    // higher bits set the specific shape type

    static  int GROUP = 0;   // createShape()

    static  int POINT = 2;   // primitive
    static  int POINTS = 3;   // vertices

    static  int LINE = 4;   // primitive
    static  int LINES = 5;   // beginShape(), createShape()
    static  int LINE_STRIP = 50;  // beginShape()
    static  int LINE_LOOP = 51;

    static  int TRIANGLE = 8;   // primitive
    static  int TRIANGLES = 9;   // vertices
    static  int TRIANGLE_STRIP = 10;  // vertices
    static  int TRIANGLE_FAN = 11;  // vertices

    static  int QUAD = 16;  // primitive
    static  int QUADS = 17;  // vertices
    static  int QUAD_STRIP = 18;  // vertices

    static  int POLYGON = 20;  // in the end, probably cannot
    static  int PATH = 21;  // separate these two

    static  int RECT = 30;  // primitive
    static  int ELLIPSE = 31;  // primitive
    static  int ARC = 32;  // primitive

    static  int SPHERE = 40;  // primitive
    static  int BOX = 41;  // primitive

    //  static public  int POINT_SPRITES = 52;
    //  static public  int NON_STROKED_SHAPE = 60;
    //  static public  int STROKED_SHAPE     = 61;


    // shape closing modes

    static  int OPEN = 1;
    static  int CLOSE = 2;


    // shape drawing modes

    /** Draw mode convention to use (x, y) to (width, height) */
    static  int CORNER = 0;
    /** Draw mode convention to use (x1, y1) to (x2, y2) coordinates */
    static  int CORNERS = 1;
    /** Draw mode from the center, and using the radius */
    static  int RADIUS = 2;
    /**
     * Draw from the center, using second pair of values as the diameter.
     * Formerly called CENTER_DIAMETER in alpha releases.
     */
    static  int CENTER = 3;
    /**
     * Synonym for the CENTER constant. Draw from the center,
     * using second pair of values as the diameter.
     */
    static  int DIAMETER = 3;


    // arc drawing modes

    //static  int OPEN = 1;  // shared
    static  int CHORD = 2;
    static  int PIE = 3;


    // vertically alignment modes for text

    /** Default vertical alignment for text placement */
    static  int BASELINE = 0;
    /** Align text to the top */
    static  int TOP = 101;
    /** Align text from the bottom, using the baseline. */
    static  int BOTTOM = 102;


    // uv texture orientation modes

    /** texture coordinates in 0..1 range */
    static  int NORMAL = 1;
    /** texture coordinates based on image width/height */
    static  int IMAGE = 2;


    // texture wrapping modes

    /** textures are clamped to their edges */
    public static  int CLAMP = 0;
    /** textures wrap around when uv values go outside 0..1 range */
    public static  int REPEAT = 1;


    // text placement modes

    /**
     * textMode(MODEL) is the default, meaning that characters
     * will be affected by transformations like any other shapes.
     * <p/>
     * Changed value in 0093 to not interfere with LEFT, CENTER, and RIGHT.
     */
    static  int MODEL = 4;

    /**
     * textMode(SHAPE) draws text using the the glyph outlines of
     * individual characters rather than as textures. If the outlines are
     * not available, then textMode(SHAPE) will be ignored and textMode(MODEL)
     * will be used instead. For this reason, be sure to call textMode()
     * <EM>after</EM> calling textFont().
     * <p/>
     * Currently, textMode(SHAPE) is only supported by OPENGL mode.
     * It also requires Java 1.2 or higher (OPENGL requires 1.4 anyway)
     */
    static  int SHAPE = 5;


    // text alignment modes
    // are inherited from LEFT, CENTER, RIGHT

    // stroke modes

    static  int SQUARE = 1 << 0;  // called 'butt' in the svg spec
    static  int ROUND = 1 << 1;
    static  int PROJECT = 1 << 2;  // called 'square' in the svg spec
    static  int MITER = 1 << 3;
    static  int BEVEL = 1 << 5;


    // lighting

    static  int AMBIENT = 0;
    static  int DIRECTIONAL = 1;
    //static  int POINT  = 2;  // shared with shape feature
    static  int SPOT = 3;


    // key constants

    // only including the most-used of these guys
    // if people need more esoteric keys, they can learn about
    // the esoteric java KeyEvent api and of virtual keys

    // both key and keyCode will equal these values
    // for 0125, these were changed to 'char' values, because they
    // can be upgraded to ints automatically by Java, but having them
    // as ints prevented split(blah, TAB) from working
    static  int BACKSPACE = 8;
    static int TAB = 9;
    static int ENTER = 10;
    static int RETURN = 13;
    static int ESC = 27;
    static int DELETE = 127;

    // i.e. if ((key == CODED) && (keyCode == UP))
    static  int CODED = 0xffff;

    // key will be CODED and keyCode will be this value
    static  int UP = 1;
    static  int DOWN = -1;
    static  int LEFT = -1;
    static int RIGHT = 1;

    // key will be CODED and keyCode will be this value
    static  int ALT = 1;
    static  int CONTROL = 1;
    static  int SHIFT = 1;


    // orientations (only used on Android, ignored on desktop)

    /** Screen orientation constant for portrait (the hamburger way). */
    static  int PORTRAIT = 1;
    /** Screen orientation constant for landscape (the hot dog way). */
    static  int LANDSCAPE = 2;

    /** Use with fullScreen() to indicate all available displays. */
    static  int SPAN = 0;

    // cursor types

    static  int ARROW = 0;
    static  int CROSS = 0;
    static  int HAND = 0;
    static  int MOVE = 0;
    static  int TEXT = 0;
    static  int WAIT = 0;


    // hints - hint values are positive for the alternate version,
    // negative of the same value returns to the normal/default state

    
  static  int ENABLE_NATIVE_FONTS = 1;
    
  static  int DISABLE_NATIVE_FONTS = -1;

    static  int DISABLE_DEPTH_TEST = 2;
    static  int ENABLE_DEPTH_TEST = -2;

    static  int ENABLE_DEPTH_SORT = 3;
    static  int DISABLE_DEPTH_SORT = -3;

    static  int DISABLE_OPENGL_ERRORS = 4;
    static  int ENABLE_OPENGL_ERRORS = -4;

    static  int DISABLE_DEPTH_MASK = 5;
    static  int ENABLE_DEPTH_MASK = -5;

    static  int DISABLE_OPTIMIZED_STROKE = 6;
    static  int ENABLE_OPTIMIZED_STROKE = -6;

    static  int ENABLE_STROKE_PERSPECTIVE = 7;
    static  int DISABLE_STROKE_PERSPECTIVE = -7;

    static  int DISABLE_TEXTURE_MIPMAPS = 8;
    static  int ENABLE_TEXTURE_MIPMAPS = -8;

    static  int ENABLE_STROKE_PURE = 9;
    static  int DISABLE_STROKE_PURE = -9;

    static  int ENABLE_BUFFER_READING = 10;
    static  int DISABLE_BUFFER_READING = -10;

    static  int DISABLE_KEY_REPEAT = 11;
    static  int ENABLE_KEY_REPEAT = -11;

    static  int DISABLE_ASYNC_SAVEFRAME = 12;
    static  int ENABLE_ASYNC_SAVEFRAME = -12;

    static  int HINT_COUNT = 13;
}
