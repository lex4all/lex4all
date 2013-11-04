/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ExerciseClasses;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author Max
 */
public class WordCount {

    public void wordCount(String readpath, String writepath) throws FileNotFoundException, IOException {

        FileReader fr = new FileReader(readpath);
        BufferedReader br = new BufferedReader(fr);

        String str;
        SplitString instance = new SplitString();
        Map<String, Integer> wcmap = new HashMap<>();

        while ((str = br.readLine()) != null) {
            String[] ln = instance.splitString(str);

            for (int x = 0; x < ln.length; x++) {

                if (wcmap.containsKey(ln[x])) {

                    Integer value = wcmap.get(ln[x]);
                    int count = value.intValue();
                    count++;
                    wcmap.put(ln[x], new Integer(count));

                } else {

                    wcmap.put(ln[x], new Integer(1));

                }
            }

        }
        fr.close();

        FileWriter fw = new FileWriter(new File(writepath), true);
        fw.write(wcmap.toString());
        fw.flush();
        fw.close();
    }
}
