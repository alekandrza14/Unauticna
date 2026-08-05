import java.io.*;
import java.nio.file.*;
import java.util.zip.*;

public class Main {

    public static void main(String[] args) throws Exception {

        String outputFolder = "";

        unzipResource("/files.zip", outputFolder);

        System.out.println("RunJS:AutomobileCommand/"+args[0]);
    }

    static void unzipResource(String resource, String destination) throws Exception {

        Files.createDirectories(Paths.get(destination));

        try (InputStream is = Main.class.getResourceAsStream(resource);
             ZipInputStream zip = new ZipInputStream(is)) {

            ZipEntry entry;

            while ((entry = zip.getNextEntry()) != null) {

                Path path = Paths.get(destination, entry.getName());

                if (entry.isDirectory()) {
                    Files.createDirectories(path);
                } else {

                    Files.createDirectories(path.getParent());

                    try (OutputStream out = Files.newOutputStream(path)) {

                        byte[] buffer = new byte[8192];
                        int len;

                        while ((len = zip.read(buffer)) > 0) {
                            out.write(buffer, 0, len);
                        }
                    }
                }

                zip.closeEntry();
            }
        }
    }
}