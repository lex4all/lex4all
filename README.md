# Speech Recognition in Any Language

### Anjana Vakil & Max Paulus
##### Department of Computational Linguistics, University of Saarland

Developers trying to incorporate speech recognition interfaces in a low-resource language (LRL) into their applications currently face the hurdle of not finding recognition engines trained on their target language. Although tools such as Carnegie Mellon University's Sphinx simplify the creation of new acoustic models for recognition, they require large amounts of training data (audio recordings) in the target language. However, for small-vocabulary applications, an existing recognizer for a high-resource language (HRL) can be used to perform recognition in the target language. This requires a pronunciation lexicon mapping the relevant words in the target language into sequences of sounds in the HRL.

[lex4all](https://github.com/lex4all/lex4all) is an easy-to-use desktop application for Windows that will allow even naive users to automatically create a pronunciation lexicon for words in any language, using a small number of audio recordings and a pre-existing recognition engine in a HRL such as English. The resulting lexicon can then be used to add small-vocabulary speech recognition functionality to applications in the LRL.

#### How it works

A simple user interface allows the user to easily specify one written form (text string) and and one or more audio samples (`.wav` files) for each word in the target vocabulary, and to set other options (e.g. number of pronunciations per word, name/save location of lexicon file, etc.). The audio is then passed to a speech recognition engine for a HRL (English). An automatic pronunciation generation algorithm (the Salaam method, [2–3]) finds the best pronunciation(s) for each word in the LRL vocabulary. The program outputs a pronunciation lexicon (`.pls` XML file). This lexicon file follows the standard pronunciation lexicon format [4], so it can be directly included in a speech recognition application, e.g. one built using the [Microsoft Speech Platform](http://msdn.microsoft.com/en-us/library/hh361572) API.

![lex4all System Diagram](https://docs.google.com/drawings/d/1eBPzBluKxJkQLYjMdbYRxi5z1Ez8OgwcMUtmbnbwQpk/pub?w=960&h=582)

#### Features

* Simple graphical interface
* Use existing `.wav` audio files, or use the built-in audio recorder
* Advanced options (number of pronunciations per word, discriminative training [3])
* Evaluation module for testing/research


#### Installation

(Info coming soon!)

#### Backend

This approach to language-independent recognition requires an existing high-quality speech recognition engine with a usable API; we chose to use the English recognition engine of the [Microsoft Speech Platform](http://msdn.microsoft.com/en-us/library/hh361572), so lex4all is written in C#. The audio recording feature was built using the [NAudio API](http://naudio.codeplex.com/).

To automatically discover the pronunciation mappings we implement the Salaam algorithm as presented in [2-3]; a slight modification was made to reduce the algorithm's running time. In addition to the basic discovery algorithm [2], users have the choice of applying the discriminative training algorithm [3] as well. 

#### References

[1] Jahanzeb Sherwani. “Speech interfaces for information access by low literate users”. PhD thesis. Pittsburgh, PA, USA: Carnegie Mellon University, 2009. [\[pdf\]](http://reports-archive.adm.cs.cmu.edu/anon/anon/home/ftp/usr/ftp/2009/CMU-CS-09-131.pdf).

[2] Fang Qiao, Jahanzeb Sherwani, and Roni Rosenfeld. “Small-vocabulary speech recognition for resource-scarce languages”. In: Proceedings of the First ACM Symposium on Computing for Development. ACM DEV ’10. London, United Kingdom: ACM, 2010, 3:1–3:8. [\[pdf\]](http://doi.acm.org/10.1145/1926180.1926184).

[3] Hao Yee Chan and Roni Rosenfeld. “Discriminative pronunciation learning for speech recognition for resource scarce languages”. In: Proceedings of the 2nd ACM Symposium on Computing for Development. ACM DEV ’12. Atlanta, Georgia: ACM, 2012, 12:1–12:6. [\[pdf\]](http://doi.acm.org/10.1145/2160601.2160618).

[4] World Wide Web Consortium (W3C). Pronunciation Lexicon Specification (PLS) Version 1.0. Tech. rep. 2008. [\[url\]](http://www.w3.org/TR/pronunciation-lexicon/).


