def make_lexicon(vocab_dict, output_path):
    '''Saves the lexicon file for the chosen vocabulary.
    Returns a string describing success/failure.
    Only handles a test input/output at this point.

    vocab_dict --   a dictionary of type {string:[string]}
                    keys are words in the vocabulary
                    values are lists of paths to wav files for that word

    output_path --  type string, tells where to save lex file

    '''

    #print "Generating and saving lexicon..."

    
    if output_path == "sample_output.pls":
        # This is the only case the method can handle right now
        try:
            with open("samplelexicon.xml", 'r') as readfile:
                lex = readfile.read()
                with open(output_path, 'w') as writefile:
                    writefile.write(lex)
                    msg = "Lexicon saved to: " + output_path
        except:
            msg = "Something wrong with read/write paths. Lexicon not saved."
                

    else:
        # Dummy output for all other cases
        msg = "Sorry, I can't handle that yet!"
                

    return msg

if __name__ == "__main__":

    print "Welcome to the lexicon builder!"

    vocab = dict()
    more_words = "y"

    while more_words == "y":
        word = raw_input("Please enter a word: ")
        vocab[word] = list()
        more_wavs = "y"
        while more_wavs == "y":
            wav = raw_input("Please enter a .wav file path: ")
            vocab[word].append(wav)
            more_wavs = raw_input("Add another .wav? (y/n): ")
        print ""
        more_words = raw_input("Add another word? (y/n): ")

    print ""
    lex_path = raw_input("Please enter the path to save lexicon to: ")

    print make_lexicon(vocab, lex_path)

    
