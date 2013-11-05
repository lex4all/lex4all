# Pronunciation Lexicons for Any Low-resource Language

### Anjana Vakil & Max Paulus

#### CL4LRL Software Project, University of Saarland

Developers trying to incorporate speech recognition interfaces in a low-resource language (LRL) into their applications currently face the hurdle of not finding recognition engines trained on their target language. Although tools such as Carnegie Mellon University's Sphinx simplify the creation of new acoustic models for recognition, they require large amounts of training data (audio recordings) in the target language. However, for small-vocabulary applications, an existing recognizer for a high-resource language (HRL) can be used to perform recognition in the target language. This requires a pronunciation lexicon mapping the relevant words in the target language into sequences of sounds in the HRL.

Our goal is to build an easy-to-use application that will allow even naive users to automatically create a pronunciation lexicon for words in any language, using a small number of audio recordings and a pre-existing recognition engine in a HRL such as English. The resulting lexicon can then be used to add small-vocabulary speech recognition functionality to applications in the LRL.

Read our [project proposal](http://htmlpreview.github.io/?https://github.com/speech4LRL/makelexicons/blob/master/ProjectProposal.html) for more information!
