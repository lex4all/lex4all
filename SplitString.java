/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package ExerciseClasses;

/**
 *
 * @author paulus
 */
public class SplitString {
    
    public String[] splitString (String str) {
        
        String[] result;        
        result = str.split("\\s|,.|\\..?");
        
        return result;
        
    }
    
}
