/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ExerciseClasses;

import java.io.BufferedReader;
import java.io.FileReader;
import junit.framework.Assert;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Max
 */
public class WordCountTest {

    public WordCountTest() {
    }

    @BeforeClass
    public static void setUpClass() {
    }

    @AfterClass
    public static void tearDownClass() {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }

    /**
     * Test of wordCount method, of class WordCount.
     */
    @Test
    public void testWordCount() throws Exception {
        System.out.println("wordCount() is tested");
        String readpath = "C:\\Users\\Max\\Documents\\input.txt";
        String writepath = "C:\\Users\\Max\\Documents\\output.txt";
        WordCount instance = new WordCount();
        instance.wordCount(readpath, writepath);

        String exppath = "C:\\Users\\Max\\Documents\\expected.txt";
        BufferedReader a = new BufferedReader(new FileReader(exppath));
        BufferedReader b = new BufferedReader(new FileReader(writepath));
        String lineA;
        String lineB;

        while (((lineA = a.readLine()) != null) && ((lineB = b.readLine()) != null)) {
            Assert.assertEquals(lineA, lineB);
        }

        a.close();
        b.close();
    }
}