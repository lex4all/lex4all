## lex4all: pronunciation LEXicons for Any Low-resource Language
### http://lex4all.github.io/lex4all/

#### A project of the Department of Computational Linguistics, Saarland University, Germany

### Creators: Anjana Vakil & Max Paulus
### Advisors: Alexis Palmer & Michaela Regneri
### Contributors: Kayokwa Chibuye (University of Cape Town, South Africa)



Developers trying to incorporate speech recognition interfaces in a low-resource language (LRL) into their applications currently face the hurdle of not finding recognition engines trained on their target language. Although tools such as Carnegie Mellon University's Sphinx simplify the creation of new acoustic models for recognition, they require large amounts of training data (audio recordings) in the target language. However, for small-vocabulary applications, an existing recognizer for a high-resource language (HRL) can be used to perform recognition in the target language. This requires a pronunciation lexicon mapping the relevant words in the target language into sequences of sounds in the HRL.

[lex4all](https://github.com/lex4all/lex4all) is an easy-to-use desktop application for Windows that will allow even naive users to automatically create a pronunciation lexicon for words in any language, using a small number of audio recordings and a pre-existing recognition engine in a HRL such as English. The resulting lexicon can then be used to add small-vocabulary speech recognition functionality to applications in the LRL.

#### How it works

A simple user interface allows the user to easily specify one written form (text string) and and one or more audio samples (`.wav` files) for each word in the target vocabulary, and to set other options (e.g. number of pronunciations per word, name/save location of lexicon file, etc.). The audio is then passed to a speech recognition engine for a HRL (English). An automatic pronunciation generation algorithm (the Salaam method, [2–3]) finds the best pronunciation(s) for each word in the LRL vocabulary. The program outputs a pronunciation lexicon (`.pls` XML file). This lexicon file follows the standard pronunciation lexicon format (http://www.w3.org/TR/pronunciation-lexicon/), so it can be directly included in a speech recognition application, e.g. one built using the [Microsoft Speech Platform](http://msdn.microsoft.com/en-us/library/hh361572) API.

For a guided step-by-step walkthrough with screenshots, see:
http://lex4all.github.io/lex4all/walkthrough.html


#### Features

* Simple graphical interface
* Use existing `.wav` audio files, or use the built-in audio recorder
* Advanced options (number of pronunciations per word, discriminative training [3])
* Evaluation module for testing/research
* Built-in support for 5 source languages: German (de-DE), English (en-US), French (fr-FR), Japanese (ja-JP), Chinese (zh-CN)


#### Requirements & Installation

Requirements:
- Windows 7 or 8, 64-bit
- Microsoft Speech Platform (MSP) runtime (version 11.0). Available here: http://www.microsoft.com/en-us/download/details.aspx?id=27225
- MSP speech recognition engine(s) for US English (and optionally other languages). Available here:
http://www.microsoft.com/en-us/download/details.aspx?id=27224
(From the download page, select the Speech Recognition (SR) engines for the languages you want to use, e.g.  `MSSpeech_SR_en-US_TELE.msi` for US English)

Installation:
- Download the project from GitHub & unzip the archive.
- Double-click the link `run-lex4all.exe` in the folder you just downloaded.
- Enjoy using lex4all!

For troubleshooting help, please see our wiki page:
https://github.com/lex4all/lex4all/wiki/Installation-&-troubleshooting


#### Backend & resources

This approach to language-independent recognition requires an existing high-quality speech recognition engine with a usable API; we chose to use the English recognition engine of the [Microsoft Speech Platform](http://msdn.microsoft.com/en-us/library/hh361572), so lex4all is written in C#. The audio recording feature was built using the [NAudio API](http://naudio.codeplex.com/).

To automatically discover the pronunciation mappings we implement the Salaam algorithm as presented in [2-3]; a slight modification was made to reduce the algorithm's running time. In addition to the basic discovery algorithm [2], users have the choice of applying the discriminative training algorithm [3] as well. 

#### Publications 

Anjana Vakil, Max Paulus, Alexis Palmer and Michaela Regneri. 2014. "lex4all: A language-independent tool for building and evaluating pronunciation lexicons for small-vocabulary speech recognition." In: Proceedings of 52nd Annual Meeting of the Association for Computational Linguistics (ACL 2014): System Demonstrations. [\[pdf\]](http://www.anthology.aclweb.org/P/P14/P14-5.pdf#page=121)

Anjana Vakil and Alexis Palmer. 2014. "Cross-language mapping for small-vocabulary ASR in under-resourced languages: investigating the impact of source language choice." In: Proceedings of the 4th Workshop on Spoken Language Technologies for Under-resourced Languages (SLTU'14). [\[pdf\]](http://www.coli.uni-saarland.de/~apalmer/docs/vakil_crosslg_sltu2014.pdf)

#### References

[1] Jahanzeb Sherwani. 2009. “Speech interfaces for information access by low literate users”. PhD thesis. Pittsburgh, PA, USA: Carnegie Mellon University. [\[pdf\]](http://reports-archive.adm.cs.cmu.edu/anon/anon/home/ftp/usr/ftp/2009/CMU-CS-09-131.pdf).

[2] Fang Qiao, Jahanzeb Sherwani, and Roni Rosenfeld. 2010. “Small-vocabulary speech recognition for resource-scarce languages." In: Proceedings of the First ACM Symposium on Computing for Development (ACM DEV ’10). [\[pdf\]](http://www.cs.cmu.edu/~roni/papers/salaam-DEV2010.pdf).

[3] Hao Yee Chan and Roni Rosenfeld. 2012. “Discriminative pronunciation learning for speech recognition for resource scarce languages." In: Proceedings of the 2nd ACM Symposium on Computing for Development (ACM DEV ’12). [\[pdf\]](http://www.cs.cmu.edu/~roni/papers/salaam-DEV2012.pdf).




