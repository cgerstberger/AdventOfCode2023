import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.HashMap;

public class Main {
    private static HashMap<String, Integer> maxValues = new HashMap<>();

    public static void main(String[] args) {
        maxValues.put("red", 12);
        maxValues.put("green", 13);
        maxValues.put("blue", 14);

        int sum = 0;
        try {
            BufferedReader reader = new BufferedReader(new FileReader("input.txt"));
            sum = reader.lines().map(Main::handleLine).reduce(0, (acc, val) -> acc + val);
            System.out.println(sum);
        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    private static int handleLine(String s) {
        String[] gameSplit = s.trim().split(":");
        int gameId = Integer.parseInt(gameSplit[0].trim().split(" ")[1]);
        String[] gamesSplit = gameSplit[1].trim().split(";");
        for(String game : gamesSplit) {
            if(!isGameValid(game))
                return 0;
        }
        return gameId;
    }

    private static boolean isGameValid(String game) {
        String[] arr = game.trim().split(",");
        for(String cubeStr : arr) {
            String[] spaceSplit = cubeStr.trim().split(" ");
            int amount = Integer.parseInt(spaceSplit[0]);
            String color = spaceSplit[1];
            int maxVal = maxValues.get(color);
            if(amount > maxVal)
                return false;
        }
        return true;
    }
}