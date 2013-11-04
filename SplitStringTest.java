/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ExerciseClasses;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Assert;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
/**
 *
 * @author paulus
 */
public class SplitStringTest {
    
    public SplitStringTest() {
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
     * Test of splitString method, of class SplitString.
     */
    @Test
    public void testSplitString() {
        System.out.println("splitString() is tested");
        String str = "This house is huge. I love it.";
        SplitString instance = new SplitString();
        String[] result = instance.splitString(str);
        String[] expected = {"This","house","is","huge","I","love","it"};
        
        Assert.assertArrayEquals(expected, result);
      
    }
}
